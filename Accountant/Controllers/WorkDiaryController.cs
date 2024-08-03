using Accountant.Data;
using Accountant.Models;
using Accountant.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace Accountant.Controllers
{
    public class WorkDiaryController : Controller
    {

        private readonly DataContextDB dbContext;

        public WorkDiaryController(DataContextDB dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> ScreenWorkDiary(int WorkDiary_Id, int WorkDiaryEdit_Id, int Driver_Id, string? Errore)
        {
            int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;// جلب رقم الشركة عند تسجيل الدخول واذا ما كان هناك رقم الافتراضي هو 0 عشان تجنب للاخطاء
            var WorkID_ID = WorkDiary_Id != 0 ? WorkDiary_Id : HttpContext.Session.GetInt32("Car_Id"); // رقم المركبة

            List<Driver>? driver = null;

            driver = await dbContext.driver.Where(C => C.CompanyId == ID).ToListAsync(); // جلب البيانات الجدول السائقين
            List<WorkDiary> workDiary = await dbContext.workDiary.Where(C => C.CompanyId == ID && C.CarId == WorkID_ID).ToListAsync(); //  جلب البيانات الجدول يوميات العمل
            List<WorkCompanies> workCompanies = await dbContext.workCompanies.Where(C => C.CompanyId == ID).ToListAsync();// جلب البيانات للكمبوبكوس لحقل المشغل
            List<Car> car = await dbContext.car.Where(C => C.CompanyId == ID).ToListAsync();// جلب البيانات للأزرار الي منختار المركبة الي بدنا انسجل عليها البيانات
            Car? Car = await dbContext.car.Where(C => C.CompanyId == ID && C.Id == WorkDiary_Id).FirstOrDefaultAsync(); // لملء حقل اسم المركبة تلقائي

            //var DriverID = Driver_Id != 0 ? Driver_Id : HttpContext.Session.GetInt32("Driver_Id");// رقم السائق ؟؟؟؟؟؟؟ المشكلة عند اول سيشين يتم تسجيله مثال اذا قمنا بتسجيل سيشين رقم 2 والان نريد تسجيل سجل جديد والرقم لازم يكون 1 لاكن في السيشين القديم رقم 2

            var DriverID = Driver_Id != 0 ? Driver_Id :Car?.IDDriver; 
            int DriverID_ID = DriverID ?? 0;// var في بعض المناطق لا يقبل الا متغيير من نوع رقم ولا يقبل من نوع 


            //=================================================


            if (WorkDiary_Id > 0)
            {
                int Driver_ID = Car?.IDDriver ?? 0;
                HttpContext.Session.SetInt32("Car_Id", WorkDiary_Id);
                HttpContext.Session.SetInt32("Driver_Id", DriverID_ID == 0 ? Driver_ID : DriverID_ID);// Driver_ID  تساوي قيمه DriverID_ID يساوي 0 بتكون قيمت  DriverID_ID هذا الشرط يعني اذا كان
                CarToWorkDiayToWorkCom CarToWorkDiayToWorkCom_New = new CarToWorkDiayToWorkCom
                {
                    Car_List_L = car,
                    Car_M = Car,
                    WorkDiary_List_M = workDiary,
                    WorkCompanies_List_M = workCompanies,
                    Driver_List_M = driver,
                    StatusButtonCar = WorkDiary_Id,
                    StatusButtonDrivr = Driver_Id != 0 ? Driver_Id : Driver_ID,
                    PageStatus = false
                };

                return View(CarToWorkDiayToWorkCom_New);
            }
            else if (WorkDiaryEdit_Id > 0)
            {
                CarToWorkDiayToWorkCom CarToWorkDiayToWorkCom_New = new CarToWorkDiayToWorkCom();
                WorkDiary? workDiaryEdit = await dbContext.workDiary.Where(C => C.Id == WorkDiaryEdit_Id && C.CompanyId == ID).FirstOrDefaultAsync();
                int CarEdit_ID = workDiaryEdit?.CarId ?? 0; 
                int DriverEdit_ID = workDiaryEdit?.DriverId ?? 0;
                if (workDiaryEdit != null)
                {
                    CarToWorkDiayToWorkCom_New.WorkDiary_M = workDiaryEdit;
                    CarToWorkDiayToWorkCom_New.Car_List_L = car;
                    CarToWorkDiayToWorkCom_New.Car_M = Car;
                    CarToWorkDiayToWorkCom_New.WorkDiary_List_M = workDiary;
                    CarToWorkDiayToWorkCom_New.WorkCompanies_List_M = workCompanies;
                    CarToWorkDiayToWorkCom_New.Driver_List_M = driver;
                    CarToWorkDiayToWorkCom_New.StatusButtonCar = CarEdit_ID;
                    CarToWorkDiayToWorkCom_New.StatusButtonDrivr = DriverEdit_ID;
                    CarToWorkDiayToWorkCom_New.PageStatus = true;


                }
                return View(CarToWorkDiayToWorkCom_New);


            }
            else
            {
                var lastWorkDiaryEntry = dbContext.workDiary.Where(e => e.CompanyId == ID).OrderByDescending(e => e.Id).FirstOrDefault();//جلب اخر بيانات تم تسجيها من يوميات العمل
                var lastWorkDiaryEntryCarId = lastWorkDiaryEntry?.CarId ?? 0;// فارغ يكون له قيمه افتراضية من اجل تجنب الخطاء لان اذا كانت القيمه 0 لا يخرج خطاء lastWorkDiaryEntry اذا كانت ال
                Car? Idcar = await dbContext.car.Where(e => e.CompanyId == ID).OrderBy(e => e.Id).FirstOrDefaultAsync();
                Car? Car_UponEntry = await dbContext.car.Where(C => C.CompanyId == ID && C.Id == lastWorkDiaryEntryCarId).FirstOrDefaultAsync();// من اجل ملء حقل اسم المركبة تلقائي
                int idCar;
                if (Idcar != null){idCar = Idcar.Id;}else{idCar = 0;}
                var Car_UponEntryID = Car_UponEntry?.Id ?? idCar;
                if(Driver_Id == 0) { Driver_Id = Idcar?.IDDriver ?? 0; }
                var Driver_UponEntryID = lastWorkDiaryEntry?.DriverId ?? Driver_Id;
                List<WorkDiary> workDiarylastEntry = await dbContext.workDiary.Where(C => C.CompanyId == ID && C.CarId == lastWorkDiaryEntryCarId).ToListAsync();// البيانات الذي سنعدل عليها

                HttpContext.Session.SetInt32("Car_Id", lastWorkDiaryEntryCarId != 0 ? lastWorkDiaryEntryCarId : idCar );
                HttpContext.Session.SetInt32("Driver_Id", Driver_UponEntryID);
                CarToWorkDiayToWorkCom CarToWorkDiayToWorkCom_New = new CarToWorkDiayToWorkCom
                {
                    Car_List_L = car,
                    Car_M= Car_UponEntry ?? Idcar,
                    WorkDiary_List_M = workDiarylastEntry,
                    WorkCompanies_List_M = workCompanies,
                    Driver_List_M= driver,
                    StatusButtonCar = Car_UponEntryID,
                    StatusButtonDrivr = Driver_UponEntryID,
                    PageStatus = false

            };
               
                return View(CarToWorkDiayToWorkCom_New);
            }
        }
        [HttpPost]
        public async Task<IActionResult> ScreenWorkDiary( CarToWorkDiayToWorkCom model)
        {
            int IDCompany = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            int IDMainUser = int.TryParse(HttpContext.Session.GetString("IDMainUser"), out int ID) ? ID : 0;
            int IDGeneralUser = int.TryParse(HttpContext.Session.GetString("IDGeneralUser"), out int id) ? id : 0;
            int IDD = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int IID) ? IID : 0;
            List<WorkDiary> workDiary =  dbContext.workDiary.Where(C => C.CompanyId == IDD && C.CarId == HttpContext.Session.GetInt32("Car_Id")).ToList();
            if(model.WorkDiary_M.Id == 0)
            {
                if (model.WorkDiary_M.MeansTransportation != null)
                {
                    string MeansTransportation = Regex.Replace(model.WorkDiary_M.MeansTransportation.Trim(), @"\s+", " ");
                    model.WorkDiary_M.MeansTransportation = MeansTransportation;
                }
                else
                {

                    return RedirectToAction("ScreenWorkDiary", new { WorkDiary_Id = HttpContext.Session.GetInt32("Car_Id"), Errore = "يبدو انك لم تختار المركبة الذي سيتم اضافه عليه البيانات" });

                }
                string TransportationLocation = Regex.Replace(model.WorkDiary_M.TransportationLocation.Trim(), @"\s+", " ");
                string DeliveryLocation = Regex.Replace(model.WorkDiary_M.DeliveryLocation.Trim(), @"\s+", " ");
                string LoadType = Regex.Replace(model.WorkDiary_M.LoadType.Trim(), @"\s+", " ");
                string PaymentType = Regex.Replace(model.WorkDiary_M.PaymentType.Trim(), @"\s+", " ");
                model.WorkDiary_M.TransportationLocation = TransportationLocation;
                model.WorkDiary_M.DeliveryLocation = DeliveryLocation;
                model.WorkDiary_M.LoadType = LoadType;
                
                model.WorkDiary_M.PaymentType = PaymentType;


                if (IDCompany > 0 && IDMainUser > 0)
                {
                    model.WorkDiary_M.IDMainUser = IDMainUser;
                    model.WorkDiary_M.CompanyId = IDCompany;
                     
                    model.WorkDiary_M.CreatedDateTime = TimeOnly.FromTimeSpan(model.WorkDiary_M.CreatedDate.TimeOfDay);
                    model.WorkDiary_M.CreatedDateOnly = DateOnly.FromDateTime(model.WorkDiary_M.CreatedDate.Date);
                    model.WorkDiary_M.DriverId = HttpContext.Session.GetInt32("Driver_Id");
                    model.WorkDiary_M.CarId = HttpContext.Session.GetInt32("Car_Id");
                    dbContext.workDiary.Add(model.WorkDiary_M);
                    dbContext.SaveChanges();

                    //=========================================================================


                    model.DriverDiary_M.IDMainUser = IDMainUser;
                    model.DriverDiary_M.CompanyId = IDCompany;
                    model.DriverDiary_M.CarId = HttpContext.Session.GetInt32("Car_Id");
                    model.DriverDiary_M.DriverId = HttpContext.Session.GetInt32("Driver_Id");
                    model.DriverDiary_M.TransportationLocation = model.WorkDiary_M.TransportationLocation;
                    model.DriverDiary_M.DeliveryLocation = model.WorkDiary_M.DeliveryLocation;
                    model.DriverDiary_M.LoadType = model.WorkDiary_M.LoadType;
                    model.DriverDiary_M.CreatedDate = DateOnly.FromDateTime(model.WorkDiary_M.CreatedDate);
                    model.DriverDiary_M.CreatedTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                    dbContext.driversDiary.Add(model.DriverDiary_M);
                    dbContext.SaveChanges();
                }
                else if (IDCompany > 0 && IDGeneralUser > 0)
                {
                    model.WorkDiary_M.IDGeneralUser = IDGeneralUser;
                    model.WorkDiary_M.CompanyId = IDCompany;
                    model.WorkDiary_M.CarId = HttpContext.Session.GetInt32("Car_Id");
                    model.WorkDiary_M.DriverId = HttpContext.Session.GetInt32("Driver_Id");
                    dbContext.workDiary.Add(model.WorkDiary_M);
                    dbContext.SaveChanges();

                    //=========================================================================
                    model.DriverDiary_M.IDGeneralUser = IDGeneralUser;
                    model.DriverDiary_M.CompanyId = IDCompany;
                    model.DriverDiary_M.CarId = HttpContext.Session.GetInt32("Car_Id");
                    model.DriverDiary_M.DriverId = HttpContext.Session.GetInt32("Driver_Id");
                    model.DriverDiary_M.TransportationLocation = model.WorkDiary_M.TransportationLocation;
                    model.DriverDiary_M.DeliveryLocation = model.WorkDiary_M.DeliveryLocation;
                    model.DriverDiary_M.LoadType = model.WorkDiary_M.LoadType;
                    model.DriverDiary_M.CreatedDate = DateOnly.FromDateTime(model.WorkDiary_M.CreatedDate);
                    model.DriverDiary_M.CreatedTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                    dbContext.driversDiary.Add(model.DriverDiary_M);
                    dbContext.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("Error", "يوجد خطاء ويمكن ان هنا خطاء في تسجيل البيانات غير مكتملة");
                    return RedirectToAction("ScreenWorkDiary", new { WorkDiary_Id = HttpContext.Session.GetInt32("Car_Id"), Driver_Id = HttpContext.Session.GetInt32("Driver_Id")});

                }
            }else if (model.WorkDiary_M.Id != 0)
            {
                WorkDiary? WorkDiaryID = await dbContext.workDiary.Where(d => d.Id == model.WorkDiary_M.Id).FirstOrDefaultAsync();
                 
                string MeansTransportation = Regex.Replace(model.WorkDiary_M.MeansTransportation.Trim(), @"\s+", " ");
                string TransportationLocation = Regex.Replace(model.WorkDiary_M.TransportationLocation.Trim(), @"\s+", " ");
                string DeliveryLocation = Regex.Replace(model.WorkDiary_M.DeliveryLocation.Trim(), @"\s+", " ");
                string LoadType = Regex.Replace(model.WorkDiary_M.LoadType.Trim(), @"\s+", " ");
                string PaymentType = Regex.Replace(model.WorkDiary_M.PaymentType.Trim(), @"\s+", " ");



                model.WorkDiary_M.MeansTransportation = MeansTransportation;    
                model.WorkDiary_M.TransportationLocation = TransportationLocation;
                model.WorkDiary_M.DeliveryLocation = DeliveryLocation;
                model.WorkDiary_M.LoadType = LoadType;
                model.WorkDiary_M.PaymentType = PaymentType;

                if (IDCompany > 0 && IDMainUser > 0)
                {
                    model.WorkDiary_M.IDMainUser = IDMainUser;
                    model.WorkDiary_M.CompanyId = IDCompany;

                    model.WorkDiary_M.CarId = HttpContext.Session.GetInt32("Car_Id");
                    if (WorkDiaryID != null)
                    {
                        WorkDiaryID.MeansTransportation = model.WorkDiary_M.MeansTransportation;
                        WorkDiaryID.TransportationLocation = model.WorkDiary_M.TransportationLocation;
                        WorkDiaryID.DeliveryLocation = model.WorkDiary_M.DeliveryLocation;
                        WorkDiaryID.LoadType = model.WorkDiary_M.LoadType;
                        WorkDiaryID.TransportationPrice = model.WorkDiary_M.TransportationPrice;
                        WorkDiaryID.CreatedDate = model.WorkDiary_M.CreatedDate;
                        WorkDiaryID.CreatedDateOnly = DateOnly.FromDateTime(model.WorkDiary_M.CreatedDate);

                        WorkDiaryID.CreatedDateTime = TimeOnly.FromDateTime(model.WorkDiary_M.CreatedDate);
                        WorkDiaryID.PaymentType = model.WorkDiary_M.PaymentType;
                        WorkDiaryID.OperatorId = model.WorkDiary_M.OperatorId;

                        dbContext.workDiary.Update(WorkDiaryID);
                        dbContext.SaveChanges();
                    }

                }
                else if (IDCompany > 0 && IDGeneralUser > 0)
                {
                    model.WorkDiary_M.IDGeneralUser = IDGeneralUser;
                    model.WorkDiary_M.CompanyId = IDCompany;

                    model.WorkDiary_M.CarId = HttpContext.Session.GetInt32("Car_Id");
                    if (WorkDiaryID != null)
                    {
                        WorkDiaryID.MeansTransportation = model.WorkDiary_M.MeansTransportation;
                        WorkDiaryID.TransportationLocation = model.WorkDiary_M.TransportationLocation;
                        WorkDiaryID.DeliveryLocation = model.WorkDiary_M.DeliveryLocation;
                        WorkDiaryID.LoadType = model.WorkDiary_M.LoadType;
                        WorkDiaryID.TransportationPrice = model.WorkDiary_M.TransportationPrice;
                        WorkDiaryID.CreatedDate = model.WorkDiary_M.CreatedDate;
                        WorkDiaryID.CreatedDateOnly = DateOnly.FromDateTime(model.WorkDiary_M.CreatedDate);
                        WorkDiaryID.CreatedDateTime = TimeOnly.FromDateTime(model.WorkDiary_M.CreatedDate);
                        WorkDiaryID.NumberLoad = model.WorkDiary_M.NumberLoad;
                        WorkDiaryID.PaymentType = model.WorkDiary_M.PaymentType;
                        WorkDiaryID.OperatorId = model.WorkDiary_M.OperatorId;


                        dbContext.workDiary.Update(WorkDiaryID);
                        dbContext.SaveChanges();
                    }
                }
                else
                {

                    return RedirectToAction("ScreenWorkDiary", new { WorkDiary_Id = HttpContext.Session.GetInt32("Car_Id"), Errore = "يوجد خطاء ويمكن ان هنا خطاء في تسجيل البيانات غير مكتملة" });



                }

            }






            return RedirectToAction("ScreenWorkDiary", new { WorkDiary_Id = HttpContext.Session.GetInt32("Car_Id"), Driver_Id = HttpContext.Session.GetInt32("Driver_Id") });

        }
        public async Task<IActionResult> DeleteWorkDiary(int id)
        {
            WorkDiary? WorkDiaryID = await dbContext.workDiary.Where(d => d.Id == id).FirstOrDefaultAsync();

            if (WorkDiaryID != null)
            {
                dbContext.Remove(WorkDiaryID);
                dbContext.SaveChanges();
            }
            return RedirectToAction("ScreenWorkDiary", new { WorkDiary_Id = HttpContext.Session.GetInt32("Car_Id") });


        }


    } 
}
        
       
       
 
