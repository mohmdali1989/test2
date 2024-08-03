using Accountant.Data;
using Accountant.Models;
using Accountant.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Accountant.Controllers
{
    public class DriversDiaryController : Controller
    {
        private readonly DataContextDB dbContext;

        public DriversDiaryController(DataContextDB dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> ScreenDriversDiary( int DriverID)
        {
            ViewModelDriversDiary Driver_VM = new ViewModelDriversDiary(); // اتدعينا الكلاس الي مجموع فيه اكثر من جدول 
            List<DriversDiary> dreivDrivers; // ليست من يوميات السائقين
            int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;// جلب رقم الشركة عند تسجيل الدخول واذا ما كان هناك رقم الافتراضي هو 0 عشان تجنب للاخطاء
            List<Driver> driver = await dbContext.driver.Where(d => d.CompanyId == ID).ToListAsync();
            //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            
            if (DriverID > 0)
            {
                dreivDrivers = await dbContext.driversDiary.Where(d => d.CompanyId == ID && d.DriverId == DriverID).OrderBy(o=>o.CreatedDate)
               .Include(c => c.car)
               .Include(e => e.driver).ToListAsync();
                //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                 

                Driver_VM.DriversDiary_List = dreivDrivers;
                Driver_VM.Driver_List = driver;
                 
                if (DriverID != 0)
                {
                    Driver? driverID = await dbContext.driver.Where(d => d.CompanyId == ID && d.Id == DriverID).FirstOrDefaultAsync();

                    Driver_VM.StatusButtonDriver = driverID?.Id ?? 0 ;
                }
                return View(Driver_VM);
            }
            else
            {
                var lastDriversDiary = dbContext.driversDiary.Where(e => e.CompanyId == ID).OrderByDescending(e => e.ID).FirstOrDefault();//جلب اخر بيانات تم تسجيها من يوميات السائقين
                var llastDriversDiaryDriverId = lastDriversDiary?.DriverId ?? 0;
                dreivDrivers = await dbContext.driversDiary.Where(d => d.CompanyId == ID && d.DriverId == llastDriversDiaryDriverId).OrderBy(o => o.CreatedDate)
                .Include(c => c.car)
                .Include(e => e.driver).ToListAsync();
                //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                 
                Driver_VM.DriversDiary_List = dreivDrivers;
                
                Driver_VM.Driver_List = driver;
                Driver_VM.StatusButtonDriver =llastDriversDiaryDriverId ;
                return View(Driver_VM);
            }
             
        }
        public async Task<IActionResult> ScreenDetailsDriversDiary(int DriverID, DateOnly DateDriversDiary, int CarId ,bool AddToEdit)
        {
            ViewModelDriversDiary Driver_VM = new ViewModelDriversDiary(); // اتدعينا الكلاس الي مجموع فيه اكثر من جدول 
            List<DriversDiary> dreivDrivers; // ليست من يوميات السائقين
            int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;// جلب رقم الشركة عند تسجيل الدخول واذا ما كان هناك رقم الافتراضي هو 0 عشان تجنب للاخطاء
            HttpContext.Session.SetInt32("Car_Id_DriversDiary",CarId);
            //DateOnly DateDriversDiary;
            if (AddToEdit == true)
            { 
                //if (DateDriversDiaryString != null)
                //{
                //     DateDriversDiary = DateOnly.ParseExact(DateDriversDiaryString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                //}else
                //{
                //    DateDriversDiary = DateOnly.FromDateTime(DateTime.Now);
                //}
             
                dreivDrivers = await dbContext.driversDiary.Where(d => d.CompanyId == ID && d.DriverId == DriverID && d.CreatedDate == DateDriversDiary)
               .Include(c => c.car)
               .Include(e => e.driver).ToListAsync();

                Driver_VM.DriversDiary_List = dreivDrivers;
                Driver_VM.StatusButtonDriver = DriverID;
                Driver_VM.StatusDate = DateDriversDiary;
                Driver_VM.AddToEdit = AddToEdit;    

                return View(Driver_VM);

            }
            else if (AddToEdit == false)
            {
              DriversDiary? dreivDrivers_M = await dbContext.driversDiary.Where(d => d.CompanyId == ID && d.DriverId == DriverID && d.CreatedDate == DateDriversDiary)
              .Include(c => c.car)
              .Include(e => e.driver).FirstOrDefaultAsync();
                if (dreivDrivers_M != null)
                { 
                Driver_VM.DriversDiary_M = dreivDrivers_M;
                Driver_VM.StatusButtonDriver = DriverID;
                Driver_VM.StatusDate = DateDriversDiary;
                Driver_VM.AddToEdit = AddToEdit;

                }
               

            }
            else 
            {

            }
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> ScreenDetailsDriversDiary(ViewModelDriversDiary model)
        {
            int IDCompany = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            int IDMainUser = int.TryParse(HttpContext.Session.GetString("IDMainUser"), out int ID) ? ID : 0;
            int IDGeneralUser = int.TryParse(HttpContext.Session.GetString("IDGeneralUser"), out int id) ? id : 0;
            DriversDiary? driversDiary_m = await dbContext.driversDiary.Where(d => d.ID == model.DriversDiary_M.ID).FirstOrDefaultAsync();


            string LoadType = Regex.Replace(model.DriversDiary_M.LoadType.Trim(), @"\s+", " ");
            string TransportationLocation = Regex.Replace(model.DriversDiary_M.TransportationLocation.Trim(), @"\s+", " ");
            string DeliveryLocation = Regex.Replace(model.DriversDiary_M.DeliveryLocation.Trim(), @"\s+", " ");
            model.DriversDiary_M.LoadType = LoadType;
            model.DriversDiary_M.TransportationLocation = TransportationLocation;
            model.DriversDiary_M.DeliveryLocation = DeliveryLocation;

            if (model.DriversDiary_M.ID == 0)
            {

                if (IDCompany > 0 && IDMainUser > 0)
                {
                    model.DriversDiary_M.IDMainUser = IDMainUser;
                    model.DriversDiary_M.CompanyId = IDCompany;
                    model.DriversDiary_M.CarId = HttpContext.Session.GetInt32("Car_Id_DriversDiary");
                    model.DriversDiary_M.DriverId = model.DriversDiary_M.DriverId;
                    dbContext.driversDiary.Add(model.DriversDiary_M);
                    dbContext.SaveChanges();

                    //=========================================================================



                }
                else if (IDCompany > 0 && IDGeneralUser > 0)
                {
                    model.DriversDiary_M.IDGeneralUser = IDGeneralUser;
                    model.DriversDiary_M.CompanyId = IDCompany;
                    model.DriversDiary_M.CarId = HttpContext.Session.GetInt32("Car_Id_Expenses");
                    dbContext.driversDiary.Add(model.DriversDiary_M);
                    dbContext.SaveChanges();

                }
                else
                {
                    ModelState.AddModelError("Error", "يوجد خطاء ويمكن ان هنا خطاء في تسجيل البيانات غير مكتملة");
                    return RedirectToAction("ScreenWorkDiary", new { WorkDiary_Id = HttpContext.Session.GetInt32("Car_Id_Expenses"), Driver_Id = HttpContext.Session.GetInt32("Driver_Id") });

                }
            }
            else if (model.DriversDiary_M.ID != 0)
            {
                DriversDiary? DriversDiary_M = await dbContext.driversDiary.Where(d => d.ID == model.DriversDiary_M.ID).FirstOrDefaultAsync();
                if (IDCompany > 0 && IDMainUser > 0)
                {
                    model.DriversDiary_M.IDMainUser = IDMainUser;
                    model.DriversDiary_M.CompanyId = IDCompany;
                    model.DriversDiary_M.CarId = HttpContext.Session.GetInt32("Car_Id_Expenses");

                    if (DriversDiary_M != null)
                    {
                        DriversDiary_M.TransportationLocation = model.DriversDiary_M.TransportationLocation;
                        DriversDiary_M.DeliveryLocation = model.DriversDiary_M.DeliveryLocation;
                        DriversDiary_M.LoadType = model.DriversDiary_M.LoadType;
                        DriversDiary_M.CreatedDate = model.DriversDiary_M.CreatedDate;
                       
                        dbContext.driversDiary.Update(DriversDiary_M);
                        dbContext.SaveChanges();
                    }


                    //=========================================================================



                }
                else if (IDCompany > 0 && IDGeneralUser > 0)
                {
                    model.DriversDiary_M.IDGeneralUser = IDGeneralUser;
                    model.DriversDiary_M.CompanyId = IDCompany;
                    model.DriversDiary_M.CarId = HttpContext.Session.GetInt32("Car_Id_Expenses");
                    if (DriversDiary_M != null)
                    {
                        DriversDiary_M.TransportationLocation = model.DriversDiary_M.TransportationLocation;
                        DriversDiary_M.DeliveryLocation = model.DriversDiary_M.DeliveryLocation;
                        DriversDiary_M.LoadType = model.DriversDiary_M.LoadType;
                        DriversDiary_M.CreatedDate = model.DriversDiary_M.CreatedDate;

                        dbContext.driversDiary.Update(DriversDiary_M);
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
            var lastdriversDiaryEntry = dbContext.driversDiary.Where(e => e.CompanyId == ID).OrderByDescending(e => e.ID).FirstOrDefault();//جلب اخر بيانات تم تسجيها من يوميات العمل

            return RedirectToAction("ScreenDetailsDriversDiary", new { DriverID = model.DriversDiary_M.DriverId, DateDriversDiary = lastdriversDiaryEntry?.CreatedDate, CarId = lastdriversDiaryEntry?.CarId, AddToEdit = model.AddToEdit });

        }
        public async Task<IActionResult> DeleteDriversDiary(int id ,bool AddToEdit)
        {
            DriversDiary? DriversDiarys = await dbContext.driversDiary.Where(d => d.ID == id).FirstOrDefaultAsync();
            if (DriversDiarys != null)
            {
                dbContext.Remove(DriversDiarys);
                dbContext.SaveChanges();

            }
            return RedirectToAction("ScreenDetailsDriversDiary", new { DriverID = DriversDiarys?.DriverId, DateDriversDiary = DriversDiarys?.CreatedDate, CarId = DriversDiarys?.CarId, AddToEdit = AddToEdit }); ;

        }
    }
}
