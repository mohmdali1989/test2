using Accountant.Data;
using Accountant.Models;
using Accountant.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Accountant.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly DataContextDB dbContext;

        public ExpensesController(DataContextDB dbContext)
        {
            this.dbContext = dbContext;
        }
         

        public async Task<IActionResult> ScreenExpenses(int Car_Id, string Errore)
        {
            int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;// جلب رقم الشركة عند تسجيل الدخول واذا ما كان هناك رقم الافتراضي هو 0 عشان تجنب للاخطاء
            List<Car> car = await dbContext.car.Where(d => d.CompanyId == ID).ToListAsync();
            ViewModelExpenses viewModelExpenses = new ViewModelExpenses();
            List<Expenses> expenses;// لجلب البيانات مع البيانات الجدول المربطه معو
            List<Expenses> groupedExpenses; //  وازاله التكرار منها expenses لفرز بيانات الي اجت من 
            //==================================================================================
            if (Car_Id > 0)// فحص اذا رقم السياره موحود ولا لا اذا صفر معناتو غير موجود 
            {
                // جلبنا البيانات مع بيانات الحدول المرطبة معها 
                //expenses = await dbContext.expenses.Where(d => d.CompanyId == ID && d.CarId == Car_Id).Include(c => c.repairWorkshops).Include(e => e.sparePartsCenters).Include(b => b.car).ToListAsync();
                expenses = await dbContext.expenses
      .Where(d => d.CompanyId == ID && d.CarId == Car_Id)
      .Include(c => c.repairWorkshops)
      .Include(e => e.sparePartsCenters)
      .Include(b => b.car)
      .Select(d => new Expenses
      {
         
          UnitPrice = d.UnitPrice,
          NumberPieces = d.NumberPieces,
          TotalPrice = d.UnitPrice * d.NumberPieces,
          MaintenancePrice = d.MaintenancePrice,
          DateExchange = d.DateExchange,
          repairWorkshops = d.repairWorkshops,
          sparePartsCenters = d.sparePartsCenters,
          car =d.car,
          CarId = d.CarId,
          WorkshopsID = d.WorkshopsID
      })
      .ToListAsync();


                //---------------------------------

                //ونزيل التكرار عن طريق التاريخ يعني كل الييانات الي بنفس التاريخ ياتي صف واخد expenses نفرز البيانات الي اجت من المتغير 
                groupedExpenses = expenses.GroupBy(d => d.DateExchange).Select(g => new Expenses
                {
                    DateExchange = g.Key,
                    PartsId = g.Select(d => d.PartsId).FirstOrDefault(),//السليكت تعني حلب كل البيانات وازاله التكرار  
                    CarId = g.Select(d => d.CarId).FirstOrDefault(),//
                    WorkshopsID = g.Select(d => d.WorkshopsID).FirstOrDefault(),
                     
                    TotalPrice = g.Sum(d =>d.TotalPrice),
                     
                    MaintenancePrice = g.Sum(d => d.MaintenancePrice),
                    car = g.Select(d => d.car).FirstOrDefault(),  // جلب بيانات جدول المركبات
                    repairWorkshops = g.Select(b => b.repairWorkshops).FirstOrDefault(),// جلب بيانات جدول ورشات التصليح
                    sparePartsCenters = g.Select(d => d.sparePartsCenters).FirstOrDefault(),  // مراكز قطع الغيار
                }).ToList();
                //---------------------------------
                viewModelExpenses.Expenses = groupedExpenses;  // جلب البيانات عن طريق الداله الي بتجلب اخر تسجيل حصل
                viewModelExpenses.car_List = car; // جلب بيانات السيارات الي في القاعده البيانات
                viewModelExpenses.StatusButtonCar = Car_Id; // جلب رقم السياره عشان تضليل على الزر من شان نعرف انو سياره ضهرت بياناتها
                viewModelExpenses.IDCar = Car_Id; // رقم السياره عشان نبعتها لصفحه الثانيه الي هي صفحه تفاصيل البيانات للسياره
                //---------------------------------
                return View(viewModelExpenses);
            }
            else // اذا 
            {
                var lastExpensesEntry = await dbContext.expenses.Where(e => e.CompanyId == ID).OrderByDescending(e => e.Id).FirstOrDefaultAsync();//جلب اخر بيانات تم تسجيها من يوميات العمل
                var lastWorkDiaryEntryCarId = lastExpensesEntry?.CarId ?? 0;
                // expenses = await dbContext.expenses.Where(d => d.CompanyId == ID && d.CarId == lastWorkDiaryEntryCarId)
                //.Include(c => c.repairWorkshops)
                //.Include(e => e.sparePartsCenters)
                //.Include(b => b.car).ToListAsync();
                expenses = await dbContext.expenses
     .Where(d => d.CompanyId == ID && d.CarId == lastWorkDiaryEntryCarId)
     .Include(c => c.repairWorkshops)
     .Include(e => e.sparePartsCenters)
     .Include(b => b.car)
     .Select(d => new Expenses
     {

         UnitPrice = d.UnitPrice,
         NumberPieces = d.NumberPieces,
         TotalPrice = d.UnitPrice * d.NumberPieces,
         MaintenancePrice = d.MaintenancePrice,
         DateExchange = d.DateExchange,
         repairWorkshops = d.repairWorkshops,
         sparePartsCenters = d.sparePartsCenters,
         car = d.car,
         CarId = d.CarId,
         WorkshopsID = d.WorkshopsID
     })
     .ToListAsync();
                groupedExpenses = expenses.GroupBy(d => d.DateExchange).Select(g => new Expenses
                {
                    DateExchange = g.Key,
                    PartsId = g.Select(d => d.PartsId).FirstOrDefault(),
                    CarId = g.Select(d => d.CarId).FirstOrDefault(),
                    WorkshopsID = g.Select(d => d.WorkshopsID).FirstOrDefault(),
                    TotalPrice = g.Sum(d=>d.TotalPrice),
                    MaintenancePrice = g.Sum(d => d.MaintenancePrice),
                    car = g.Select(d => d.car).FirstOrDefault(),  // جلب بيانات جدول المركبات
                    repairWorkshops = g.Select(b => b.repairWorkshops).FirstOrDefault(),// جلب بيانات جدول ورشات التصليح
                    sparePartsCenters = g.Select(d => d.sparePartsCenters).FirstOrDefault(),  // مراكز قطع الغيار
                }).ToList();
                Car? Car;
                int? Carid;
                Car  = await dbContext.car.Where(c => c.CompanyId == ID).OrderBy(c => c.Id).FirstOrDefaultAsync();
                if (Car != null)
                {
                    Carid = Car.Id;
                }
                else
                {
                    Carid = 0;
                }
                viewModelExpenses.Expenses = groupedExpenses;
                viewModelExpenses.car_List = car;
                viewModelExpenses.StatusButtonCar = lastExpensesEntry?.CarId != null ? lastExpensesEntry?.CarId : Carid;
                viewModelExpenses.IDCar = lastExpensesEntry?.CarId != null ? lastExpensesEntry?.CarId : Carid;
                return View(viewModelExpenses);
            }
        }
         
         
        public async Task<IActionResult> DetailsExpenses(int IDExchange,int CarID, string DateExchangeString ,bool AddNew, bool Add ,bool Edit)
        {
              ViewModelExpenses viewModelExpenses = new ViewModelExpenses();
            int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            var lastExpensesEntry = dbContext.expenses.Where(e => e.CompanyId == ID).OrderByDescending(e => e.Id).FirstOrDefault();//جلب اخر بيانات تم تسجيها من يوميات العمل
            DateOnly dateExchange;
            if (DateExchangeString != null)
            {
                dateExchange = DateOnly.ParseExact(DateExchangeString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                viewModelExpenses.StatusDate = dateExchange;

            }
            else
            {
                dateExchange = DateOnly.FromDateTime(DateTime.Now);
                viewModelExpenses.StatusDate = dateExchange;


            }
            List<Expenses> expenses = await dbContext.expenses.Where(d => d.CarId == CarID && d.DateExchange == dateExchange).ToListAsync();

            Car? Carid = await dbContext.car.Where(d => d.Id == CarID).FirstOrDefaultAsync();
            List<SparePartsCenters> sparePartsCenters = await dbContext.sparePartsCenters.Where(S=>S.CompanyId == ID).ToListAsync();
            List<RepairWorkshops> repairWorkshops = await dbContext.repairWorkshops.Where(S => S.CompanyId == ID).ToListAsync();

            HttpContext.Session.SetInt32("Car_Id_Expenses", CarID);
            if (Edit == true)
            {
                Expenses? expenses_M = await dbContext.expenses.Where(d => d.Id == IDExchange).FirstOrDefaultAsync();
                if (expenses_M != null) { viewModelExpenses.Expenses_M = expenses_M; };


                viewModelExpenses.Expenses = expenses;
                viewModelExpenses.NameTypeCar = Carid?.NameCar;
                viewModelExpenses.sparePartsCenters_List = sparePartsCenters;
                viewModelExpenses.Workshops_List = repairWorkshops;
                viewModelExpenses.AddToEdit = AddNew;
            }
            else
            {
                 


                



                viewModelExpenses.Expenses = expenses;
                viewModelExpenses.NameTypeCar = Carid?.NameCar;
                viewModelExpenses.sparePartsCenters_List = sparePartsCenters;
                viewModelExpenses.Workshops_List = repairWorkshops;
                viewModelExpenses.AddToEdit = AddNew;

            }
           
            
            
             
            
            return View(viewModelExpenses);
        }
        [HttpPost]
        public async Task<IActionResult>DetailsExpenses(ViewModelExpenses model)
        {
            int IDCompany = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            int IDMainUser = int.TryParse(HttpContext.Session.GetString("IDMainUser"), out int ID) ? ID : 0;
            int IDGeneralUser = int.TryParse(HttpContext.Session.GetString("IDGeneralUser"), out int id) ? id : 0;
            
            string TypeCar = Regex.Replace(model.Expenses_M.TypeCar.Trim(), @"\s+", " ");
            string NamePiece = Regex.Replace(model.Expenses_M.NamePiece.Trim(), @"\s+", " ");
            model.Expenses_M.TypeCar = TypeCar;
            model.Expenses_M.NamePiece = NamePiece;

            if (model.Expenses_M.Id == 0)
            {

                if (IDCompany > 0 && IDMainUser > 0)
                {
                    model.Expenses_M.IDMainUser = IDMainUser;
                    model.Expenses_M.CompanyId = IDCompany;
                    model.Expenses_M.TotalPrice = model.Expenses_M.UnitPrice * model.Expenses_M.NumberPieces;
                    model.Expenses_M.CarId = HttpContext.Session.GetInt32("Car_Id_Expenses");
                    dbContext.expenses.Add(model.Expenses_M);
                    dbContext.SaveChanges();

                    //=========================================================================



                }
                else if (IDCompany > 0 && IDGeneralUser > 0)
                {
                    model.Expenses_M.IDGeneralUser = IDGeneralUser;
                    model.Expenses_M.CompanyId = IDCompany;
                    model.Expenses_M.TotalPrice = model.Expenses_M.UnitPrice * model.Expenses_M.NumberPieces;
                    model.Expenses_M.CarId = HttpContext.Session.GetInt32("Car_Id_Expenses");
                    dbContext.expenses.Add(model.Expenses_M);
                    dbContext.SaveChanges();

                }
                else
                {
                    ModelState.AddModelError("Error", "يوجد خطاء ويمكن ان هنا خطاء في تسجيل البيانات غير مكتملة");
                    return RedirectToAction("ScreenWorkDiary", new { WorkDiary_Id = HttpContext.Session.GetInt32("Car_Id_Expenses"), Driver_Id = HttpContext.Session.GetInt32("Driver_Id") });

                }
            }
            else if (model.Expenses_M.Id != 0)
            {
                Expenses? expenses_M = await dbContext.expenses.Where(d => d.Id == model.Expenses_M.Id).FirstOrDefaultAsync();
                if (IDCompany > 0 && IDMainUser > 0)
                {
                    model.Expenses_M.IDMainUser = IDMainUser;
                    model.Expenses_M.CompanyId = IDCompany;
                    model.Expenses_M.CarId = HttpContext.Session.GetInt32("Car_Id_Expenses");

                    if(expenses_M != null) 
                    {
                        expenses_M.TypeCar = model.Expenses_M.TypeCar;
                        expenses_M.NamePiece = model.Expenses_M.NamePiece;
                        expenses_M.UnitPrice = model.Expenses_M.UnitPrice;
                        expenses_M.NumberPieces = model.Expenses_M.NumberPieces;
                        expenses_M.MaintenancePrice = model.Expenses_M.MaintenancePrice;
                        expenses_M.Image = model.Expenses_M.Image;
                        expenses_M.DateExchange = model.Expenses_M.DateExchange;
                        expenses_M.PartsId = model.Expenses_M.PartsId;
                        expenses_M.WorkshopsID = model.Expenses_M.WorkshopsID;
                        expenses_M.TotalPrice = model.Expenses_M.UnitPrice * model.Expenses_M.NumberPieces;
                        dbContext.expenses.Update(expenses_M);
                        dbContext.SaveChanges();
                    }
                   

                    //=========================================================================



                }
                else if (IDCompany > 0 && IDGeneralUser > 0)
                {
                    model.Expenses_M.IDGeneralUser = IDGeneralUser;
                    model.Expenses_M.CompanyId = IDCompany;
                    model.Expenses_M.CarId = HttpContext.Session.GetInt32("Car_Id_Expenses");
                    if (expenses_M != null)
                    {
                        expenses_M.TypeCar = model.Expenses_M.TypeCar;
                        expenses_M.NamePiece = model.Expenses_M.NamePiece;
                        expenses_M.UnitPrice = model.Expenses_M.UnitPrice;
                        expenses_M.NumberPieces = model.Expenses_M.NumberPieces;
                        expenses_M.MaintenancePrice = model.Expenses_M.MaintenancePrice;
                        expenses_M.Image = model.Expenses_M.Image;
                        expenses_M.DateExchange = model.Expenses_M.DateExchange;
                        expenses_M.sparePartsCenters = model.Expenses_M.sparePartsCenters;
                        expenses_M.repairWorkshops = model.Expenses_M.repairWorkshops;
                        expenses_M.TotalPrice = model.Expenses_M.UnitPrice * model.Expenses_M.NumberPieces;
                        dbContext.expenses.Update(expenses_M);
                        dbContext.SaveChanges();
                    }

                }
                else
                {
                    ModelState.AddModelError("Error", "يوجد خطاء ويمكن ان هنا خطاء في تسجيل البيانات غير مكتملة");
                    return RedirectToAction("ScreenWorkDiary", new { WorkDiary_Id = HttpContext.Session.GetInt32("Car_Id_Expenses"), Driver_Id = HttpContext.Session.GetInt32("Driver_Id") });

                }

            }
            else
            {

            }
            var lastExpensesEntry = dbContext.expenses.Where(e => e.CompanyId == ID).OrderByDescending(e => e.Id).FirstOrDefault();//جلب اخر بيانات تم تسجيها من يوميات العمل
            return RedirectToAction("DetailsExpenses", new { CarID = HttpContext.Session.GetInt32("Car_Id_Expenses"), DateExchangeString = lastExpensesEntry?.DateExchange.ToString("yyyy-MM-dd"),AddNew = model.AddToEdit});


        }
        public async Task<IActionResult> DeleteExpenses(int id , bool AddToEdit)
        {
            Expenses? ExpensesID = await dbContext.expenses.Where(d => d.Id == id).FirstOrDefaultAsync();
            ViewModelExpenses viewModelExpenses = new ViewModelExpenses();
            if (ExpensesID != null)
            {
                dbContext.Remove(ExpensesID);
                dbContext.SaveChanges();
            }
            //return RedirectToAction("ScreenExpenses", new { WorkDiary_Id = HttpContext.Session.GetInt32("Car_Id") });
            return RedirectToAction("DetailsExpenses", new { CarID = HttpContext.Session.GetInt32("Car_Id_Expenses"), DateExchangeString=ExpensesID?.DateExchange.ToString("yyyy-MM-dd"), AddNew = AddToEdit });

        }


    }

}
 


 