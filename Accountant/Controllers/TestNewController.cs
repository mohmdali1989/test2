using Microsoft.AspNetCore.Mvc;

namespace Accountant.Controllers
{
    public class TestNewController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }
    }
}
//public async Task<IActionResult> IndexTest()
        //{
        //    int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;// جلب رقم الشركة عند تسجيل الدخول واذا ما كان هناك رقم الافتراضي هو 0 عشان تجنب للاخطاء
        //    var WorkID_ID = WorkDiary_Id != 0 ? WorkDiary_Id : HttpContext.Session.GetInt32("Car_Id");

        //    List<Driver>? driver = null;
        //    if (driver == null) // الشرط
        //    {
        //        driver = await dbContext.driver.Where(C => C.CompanyId == ID).ToListAsync(); // جلب البيانات الجدول السائقين
        //    }

        //    List<WorkDiary> workDiary = await dbContext.workDiary.Where(C => C.CompanyId == ID && C.CarId == WorkID_ID).ToListAsync(); //  جلب البيانات الجدول يوميات العمل
        //    List<WorkCompanies> workCompanies = await dbContext.workCompanies.Where(C => C.CompanyId == ID).ToListAsync();// جلب البيانات للكمبوبكوس لحقل المشغل
        //    List<Car> car = await dbContext.car.Where(C => C.CompanyId == ID).ToListAsync();// جلب البيانات للأزرار الي منختار المركبة الي بدنا انسجل عليها البيانات
        //    Car? Car = await dbContext.car.Where(C => C.CompanyId == ID && C.Id == WorkDiary_Id).FirstOrDefaultAsync(); // لملء حقل اسم المركبة تلقائي

        //    var DriverID = Driver_Id != 0 ? Driver_Id : HttpContext.Session.GetInt32("Driver_Id");
        //    int DriverID_ID = DriverID ?? 0;// var في بعض المناطق لا يقبل الا متغيير من نوع رقم ولا يقبل من نوع 


        //    //=================================================


        //    if (WorkDiary_Id > 0)
        //    {
        //        int Driver_ID = Car?.IDDriver ?? 0;
        //        HttpContext.Session.SetInt32("Car_Id", WorkDiary_Id);
        //        if (DriverID_ID == 0)
        //        {
        //            HttpContext.Session.SetInt32("Driver_Id", Driver_ID);
        //        }
        //        else
        //        {
        //            HttpContext.Session.SetInt32("Driver_Id", DriverID_ID);
        //        }


        //        CarToWorkDiayToWorkCom CarToWorkDiayToWorkCom_New = new CarToWorkDiayToWorkCom();

        //        CarToWorkDiayToWorkCom_New.Car_List_M = car;
        //        CarToWorkDiayToWorkCom_New.Car_M = Car;
        //        CarToWorkDiayToWorkCom_New.WorkDiary_List_M = workDiary;
        //        CarToWorkDiayToWorkCom_New.WorkCompanies_List_M = workCompanies;
        //        CarToWorkDiayToWorkCom_New.Driver_List_M = driver;
        //        CarToWorkDiayToWorkCom_New.StatusButtonCar = WorkDiary_Id;
        //        CarToWorkDiayToWorkCom_New.PageStatus = false;
        //        if (Driver_Id != 0 || Driver_Id != 0)
        //        {
        //            CarToWorkDiayToWorkCom_New.StatusButtonDrivr = Driver_Id;
        //        }
        //        else
        //        {
        //            CarToWorkDiayToWorkCom_New.StatusButtonDrivr = Driver_ID;
        //        }





        //        return View(CarToWorkDiayToWorkCom_New);

        //    }
        //    else if (WorkDiaryEdit_Id > 0)
        //    {
        //        CarToWorkDiayToWorkCom CarToWorkDiayToWorkCom_New = new CarToWorkDiayToWorkCom();
        //        WorkDiary? workDiaryEdit = await dbContext.workDiary.Where(C => C.Id == WorkDiaryEdit_Id).FirstOrDefaultAsync();
        //        int CarEdit_ID = workDiaryEdit?.CarId ?? 0;
        //        int DriverEdit_ID = workDiaryEdit?.DriverId ?? 0;
        //        if (workDiaryEdit != null)
        //        {
        //            CarToWorkDiayToWorkCom_New.WorkDiary_M = workDiaryEdit;
        //            CarToWorkDiayToWorkCom_New.Car_List_M = car;
        //            CarToWorkDiayToWorkCom_New.Car_M = Car;
        //            CarToWorkDiayToWorkCom_New.WorkDiary_List_M = workDiary;
        //            CarToWorkDiayToWorkCom_New.WorkCompanies_List_M = workCompanies;
        //            CarToWorkDiayToWorkCom_New.Driver_List_M = driver;
        //            CarToWorkDiayToWorkCom_New.StatusButtonCar = CarEdit_ID;
        //            CarToWorkDiayToWorkCom_New.StatusButtonDrivr = DriverEdit_ID;
        //            CarToWorkDiayToWorkCom_New.PageStatus = true;


        //        }
        //        return View(CarToWorkDiayToWorkCom_New);


        //    }
        //    else
        //    {
        //        var lastWorkDiaryEntry = dbContext.workDiary.Where(e => e.CompanyId == ID).OrderByDescending(e => e.Id).FirstOrDefault();//جلب اخر بيانات تم تسجيها من يوميات العمل
        //        var lastWorkDiaryEntryCarId = lastWorkDiaryEntry?.CarId ?? 0;// فارغ يكون له قيمه افتراضية من اجل تجنب الخطاء لان اذا كانت القيمه 0 لا يخرج خطاء lastWorkDiaryEntry اذا كانت ال
        //        Car? Car_UponEntry = await dbContext.car.Where(C => C.CompanyId == ID && C.Id == lastWorkDiaryEntryCarId).FirstOrDefaultAsync();// من اجل ملء حقل اسم المركبة تلقائي
        //        var Car_UponEntryID = Car_UponEntry?.Id ?? 0;
        //        var Driver_UponEntryID = lastWorkDiaryEntry?.DriverId ?? Driver_Id;
        //        List<WorkDiary> workDiarylastEntry = await dbContext.workDiary.Where(C => C.CompanyId == ID && C.CarId == lastWorkDiaryEntryCarId).ToListAsync();// البيانات الذي سنعدل عليها

        //        HttpContext.Session.SetInt32("Car_Id", lastWorkDiaryEntryCarId);
        //        HttpContext.Session.SetInt32("Driver_Id", Driver_UponEntryID);
        //        CarToWorkDiayToWorkCom CarToWorkDiayToWorkCom_New = new CarToWorkDiayToWorkCom
        //        {
        //            Car_List_M = car,
        //            Car_M = Car_UponEntry,
        //            WorkDiary_List_M = workDiarylastEntry,
        //            WorkCompanies_List_M = workCompanies,
        //            Driver_List_M = driver,
        //            StatusButtonCar = Car_UponEntryID,
        //            StatusButtonDrivr = Driver_UponEntryID,
        //            PageStatus = false

        //        };

        //        return View(CarToWorkDiayToWorkCom_New);
        //    }
        //    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //    //if (Errore != null)
        //    //{
        //    //    ModelState.AddModelError("Error", Errore);
        //    //}


        //    //if (WorkDiaryEdit_Id > 0)
        //    //{

        //    //    int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
        //    //    WorkDiary? workDiaryEdit = await dbContext.workDiary.Where(C => C.Id == WorkDiaryEdit_Id).FirstOrDefaultAsync();
        //    //    List<Car> car = await dbContext.car.Where(C => C.CompanyId == ID).ToListAsync();

        //    //    List<WorkDiary> workDiary = await dbContext.workDiary.Where(C => C.CompanyId == ID && C.CarId == workDiaryEdit!.CarId).ToListAsync();/*يمكن ان يسبب مشاكل اذا وضعنا عدم الفراغ*/
        //    //    Car? Car = await dbContext.car.Where(C => C.CompanyId == ID && C.Id == workDiaryEdit!.CarId).FirstOrDefaultAsync();

        //    //    ViewBag.DataworkDiary = workDiary;
        //    //    ViewBag.MeansTransportation = Car?.NameCar;

        //    //    ViewBag.DataCar = car;
        //    //    // في C#
        //    //    var data = dbContext.workCompanies.ToList();
        //    //    ViewBag.DataList = data;
        //    //    if (workDiaryEdit != null)
        //    //    {
        //    //        int? IdCar = workDiaryEdit.CarId;
        //    //        if (IdCar != null)
        //    //        {
        //    //            HttpContext.Session.SetInt32("Car_Id", (int)IdCar);
        //    //        }

        //    //    }


        //    //    return View(workDiaryEdit);
        //    //}
        //    //else
        //    //{


        //    //    int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;

        //    //    var lastWorkDiaryEntry = dbContext.workDiary.Where(e => e.CompanyId == ID).OrderByDescending(e => e.Id).FirstOrDefault();

        //    //    if (WorkDiaryId == 0)
        //    //    {

        //    //        if (lastWorkDiaryEntry != null)
        //    //        {
        //    //            List<WorkDiary> workDiary = await dbContext.workDiary.Where(C => C.CompanyId == ID && C.CarId == lastWorkDiaryEntry.CarId).ToListAsync();
        //    //            Car? Car = await dbContext.car.Where(C => C.CompanyId == ID && C.Id == lastWorkDiaryEntry.CarId).FirstOrDefaultAsync();

        //    //            ViewBag.MeansTransportation = Car?.NameCar;
        //    //            int? IdCar = lastWorkDiaryEntry.CarId;
        //    //            if (IdCar != null)
        //    //            {
        //    //                HttpContext.Session.SetInt32("Car_Id", (int)IdCar);
        //    //            }

        //    //            List<Car> car = await dbContext.car.Where(C => C.CompanyId == ID).ToListAsync();

        //    //            var data = dbContext.workCompanies.ToList();

        //    //            CarToWorkDiayToWorkCom CarToWorkDiayToWorkCom_New = new CarToWorkDiayToWorkCom
        //    //            {
        //    //                Car_List_M = car,


        //    //                WorkCompanies_List_M = data,
        //    //                WorkDiary_List_M = workDiary,

        //    //                Car_M = Car






        //    //            };



        //    //            return View(CarToWorkDiayToWorkCom_New);

        //    //        }
        //    //        else if (lastWorkDiaryEntry == null)
        //    //        {
        //    //            List<WorkDiary> workDiary = await dbContext.workDiary.Where(C => C.CompanyId == ID && C.CarId == WorkDiaryId).ToListAsync();
        //    //            Car? Car = await dbContext.car.Where(C => C.CompanyId == ID && C.Id == WorkDiaryId).FirstOrDefaultAsync();
        //    //            ViewBag.DataworkDiary = workDiary;
        //    //            ViewBag.MeansTransportation = Car?.NameCar;
        //    //            HttpContext.Session.SetInt32("Car_Id", WorkDiaryId);
        //    //            List<Car> car = await dbContext.car.Where(C => C.CompanyId == ID).ToListAsync();
        //    //            ViewBag.DataCar = car;
        //    //            var data = dbContext.workCompanies.ToList();
        //    //            if (car.Count == 0)
        //    //            {

        //    //            }

        //    //            CarToWorkDiayToWorkCom CarToWorkDiayToWorkCom_New = new CarToWorkDiayToWorkCom
        //    //            {
        //    //                Car_List_M = car,


        //    //                WorkCompanies_List_M = data,
        //    //                WorkDiary_List_M = workDiary,

        //    //                Car_M = Car






        //    //            };
        //    //        }

        //    //        else
        //    //        {
        //    //            List<WorkDiary> workDiary = await dbContext.workDiary.Where(C => C.CompanyId == ID && C.CarId == WorkDiaryId).ToListAsync();
        //    //            Car? Car = await dbContext.car.Where(C => C.CompanyId == ID && C.Id == WorkDiaryId).FirstOrDefaultAsync();
        //    //            ViewBag.DataworkDiary = workDiary;
        //    //            ViewBag.MeansTransportation = Car?.NameCar;
        //    //            HttpContext.Session.SetInt32("Car_Id", WorkDiaryId);
        //    //            return View();
        //    //        }






        //    //    }
        //    // return View();










        //}

     

    //
    //public async Task<IActionResult> ScreenWorkDiary(CarToWorkDiayToWorkCom model)
    //{
    //    //int IDD = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int IID) ? IID : 0;
    //    //List<WorkDiary> workDiary =  dbContext.workDiary.Where(C => C.CompanyId == IDD && C.CarId == HttpContext.Session.GetInt32("Car_Id")).ToList();
    //    //ViewBag.DataworkDiary = workDiary;
    //    //List<Car> car =  dbContext.car.Where(C => C.CompanyId == IDD).ToList();
    //    //ViewBag.DataCar = car;
    //    int IDCompany = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
    //    int IDMainUser = int.TryParse(HttpContext.Session.GetString("IDMainUser"), out int ID) ? ID : 0;
    //    int IDGeneralUser = int.TryParse(HttpContext.Session.GetString("IDGeneralUser"), out int id) ? id : 0;

    //    if (model.WorkDiary_M.Id == 0)
    //    {
    //        if (IDCompany > 0)
    //        {
    //            if (model.WorkDiary_M.MeansTransportation != null)
    //            {
    //                string MeansTransportation = Regex.Replace(model.WorkDiary_M.MeansTransportation.Trim(), @"\s+", " ");
    //                model.WorkDiary_M.MeansTransportation = MeansTransportation;
    //            }
    //            else
    //            {

    //                return RedirectToAction("ScreenWorkDiary", new { WorkDiary_Id = HttpContext.Session.GetInt32("Car_Id"), Errore = "يبدو انك لم تختار المركبة الذي سيتم اضافه عليه البيانات" });

    //            }

    //            string TransportationLocation = Regex.Replace(model.WorkDiary_M.TransportationLocation.Trim(), @"\s+", " ");
    //            string DeliveryLocation = Regex.Replace(model.WorkDiary_M.DeliveryLocation.Trim(), @"\s+", " ");
    //            string LoadType = Regex.Replace(model.WorkDiary_M.LoadType.Trim(), @"\s+", " ");
    //            string TransportationPrice = Regex.Replace(model.WorkDiary_M.TransportationPrice.Trim(), @"\s+", " ");
    //            string PaymentType = Regex.Replace(model.WorkDiary_M.PaymentType.Trim(), @"\s+", " ");




    //            model.WorkDiary_M.TransportationLocation = TransportationLocation;
    //            model.WorkDiary_M.DeliveryLocation = DeliveryLocation;
    //            model.WorkDiary_M.LoadType = LoadType;
    //            model.WorkDiary_M.TransportationPrice = TransportationPrice;
    //            model.WorkDiary_M.PaymentType = PaymentType;




    //            if (IDCompany > 0 && IDMainUser > 0)
    //            {
    //                model.WorkDiary_M.IDMainUser = IDMainUser;
    //                model.WorkDiary_M.CompanyId = IDCompany;

    //                model.WorkDiary_M.CarId = HttpContext.Session.GetInt32("Car_Id");


    //                dbContext.workDiary.Add(model.WorkDiary_M);
    //                dbContext.SaveChanges();
    //            }
    //            else if (IDCompany > 0 && IDGeneralUser > 0)
    //            {
    //                model.WorkDiary_M.IDGeneralUser = IDGeneralUser;
    //                model.WorkDiary_M.CompanyId = IDCompany;

    //                model.WorkDiary_M.CarId = HttpContext.Session.GetInt32("Car_Id");
    //                dbContext.workDiary.Add(model.WorkDiary_M);
    //                dbContext.SaveChanges();
    //            }
    //            else
    //            {
    //                ModelState.AddModelError("Error", "يوجد خطاء ويمكن ان هنا خطاء في تسجيل البيانات غير مكتملة");
    //                return RedirectToAction("ScreenWorkDiary", new { WorkDiary_Id = HttpContext.Session.GetInt32("Car_Id") });

    //            }


    //        }


    //    }
    //    else if (model.WorkDiary_M.Id != 0)
    //    {
    //        if (IDCompany > 0)
    //        {
    //            WorkDiary? WorkDiaryID = await dbContext.workDiary.Where(d => d.Id == model.WorkDiary_M.Id).FirstOrDefaultAsync();

    //            if (model.WorkDiary_M.MeansTransportation != null)
    //            {
    //                string MeansTransportation = Regex.Replace(model.WorkDiary_M.MeansTransportation.Trim(), @"\s+", " ");
    //                model.WorkDiary_M.MeansTransportation = MeansTransportation;
    //            }
    //            else
    //            {

    //                return RedirectToAction("ScreenWorkDiary", new { WorkDiary_Id = HttpContext.Session.GetInt32("Car_Id"), Errore = "يبدو انك لم تختار المركبة الذي سيتم اضافه عليه البيانات" });

    //            }
    //            string TransportationLocation = Regex.Replace(model.WorkDiary_M.TransportationLocation.Trim(), @"\s+", " ");
    //            string DeliveryLocation = Regex.Replace(model.WorkDiary_M.DeliveryLocation.Trim(), @"\s+", " ");
    //            string LoadType = Regex.Replace(model.WorkDiary_M.LoadType.Trim(), @"\s+", " ");
    //            string TransportationPrice = Regex.Replace(model.WorkDiary_M.TransportationPrice.Trim(), @"\s+", " ");
    //            string PaymentType = Regex.Replace(model.WorkDiary_M.PaymentType.Trim(), @"\s+", " ");




    //            model.WorkDiary_M.TransportationLocation = TransportationLocation;
    //            model.WorkDiary_M.DeliveryLocation = DeliveryLocation;
    //            model.WorkDiary_M.LoadType = LoadType;
    //            model.WorkDiary_M.TransportationPrice = TransportationPrice;
    //            model.WorkDiary_M.PaymentType = PaymentType;




////                if (IDCompany > 0 && IDMainUser > 0)
////                {
////                    model.WorkDiary_M.IDMainUser = IDMainUser;
////                    model.WorkDiary_M.CompanyId = IDCompany;

////                    model.WorkDiary_M.CarId = HttpContext.Session.GetInt32("Car_Id");
////                    if (WorkDiaryID != null)
////                    {
////                        WorkDiaryID.MeansTransportation = model.WorkDiary_M.MeansTransportation;
////                        WorkDiaryID.TransportationLocation = model.WorkDiary_M.TransportationLocation;
////                        WorkDiaryID.DeliveryLocation = model.WorkDiary_M.DeliveryLocation;
////                        WorkDiaryID.LoadType = model.WorkDiary_M.LoadType;
////                        WorkDiaryID.TransportationPrice = model.WorkDiary_M.TransportationPrice;
////                        WorkDiaryID.CreatedDate = model.WorkDiary_M.CreatedDate;
////                        WorkDiaryID.NumberLoad = model.WorkDiary_M.NumberLoad;
////                        WorkDiaryID.PaymentType = model.WorkDiary_M.PaymentType;
////                        WorkDiaryID.OperatorId = model.WorkDiary_M.OperatorId;

////                        dbContext.workDiary.Update(WorkDiaryID);
////                        dbContext.SaveChanges();
////                    }

////                }
////                else if (IDCompany > 0 && IDGeneralUser > 0)
////{
////    model.WorkDiary_M.IDGeneralUser = IDGeneralUser;
////    model.WorkDiary_M.CompanyId = IDCompany;

////    model.WorkDiary_M.CarId = HttpContext.Session.GetInt32("Car_Id");
////    if (WorkDiaryID != null)
////    {
////        WorkDiaryID.MeansTransportation = model.WorkDiary_M.MeansTransportation;
////        WorkDiaryID.TransportationLocation = model.WorkDiary_M.TransportationLocation;
////        WorkDiaryID.DeliveryLocation = model.WorkDiary_M.DeliveryLocation;
////        WorkDiaryID.LoadType = model.WorkDiary_M.LoadType;
////        WorkDiaryID.TransportationPrice = model.WorkDiary_M.TransportationPrice;
////        WorkDiaryID.CreatedDate = model.WorkDiary_M.CreatedDate;
////        WorkDiaryID.NumberLoad = model.WorkDiary_M.NumberLoad;
////        WorkDiaryID.PaymentType = model.WorkDiary_M.PaymentType;
////        WorkDiaryID.OperatorId = model.WorkDiary_M.OperatorId;


////        dbContext.workDiary.Update(WorkDiaryID);
////        dbContext.SaveChanges();
////    }
////}
////else
////{

////    return RedirectToAction("ScreenWorkDiary", new { WorkDiary_Id = HttpContext.Session.GetInt32("Car_Id"), Errore = "يوجد خطاء ويمكن ان هنا خطاء في تسجيل البيانات غير مكتملة" });



////}


    //        }
    //    }
    //    else
    //    {

    //    }


    //    return RedirectToAction("ScreenWorkDiary", new { WorkDiary_Id = HttpContext.Session.GetInt32("Car_Id") });


    //}

    //
 



//List<Expenses> groupedExpenses1 = expenses
//.GroupBy(d => new { d.DateExchange, d.WorkshopsID, d.PartsId })
//.Select(g => new Expenses
//{
//    DateExchange = g.Key.DateExchange,

//    PartsId = g.Select(d => d.PartsId).FirstOrDefault(),
//    WorkshopsID = g.Select(d => d.WorkshopsID).FirstOrDefault(),
//    UnitPrice = g.Sum(d => d.UnitPrice),
//    MaintenancePrice = g.Sum(d => d.MaintenancePrice),
//    car = g.Select(d => d.car).FirstOrDefault(),  // جلب بيانات جدول المركبات
//    repairWorkshops = g.Select(b => b.repairWorkshops).FirstOrDefault(),// جلب بيانات جدول ورشات التصليح
//    sparePartsCenters = g.Select(d => d.sparePartsCenters).FirstOrDefault(),  // مراكز قطع الغيار
//}).ToList();




//if (ExpensesEdit_Id > 0)
//{

//    int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
//    Expenses? expensesEdit = await dbContext.expenses.Where(C => C.Id == ExpensesEdit_Id).FirstOrDefaultAsync();
//    List<Car> car = await dbContext.car.Where(C => C.CompanyId == ID).ToListAsync();

//    List<Expenses> expenses = await dbContext.expenses.Where(C => C.CompanyId == ID && C.CarId == expensesEdit!.CarId).ToListAsync();/*يمكن ان يسبب مشاكل اذا وضعنا عدم الفراغ*/
//    Car? Car = await dbContext.car.Where(C => C.CompanyId == ID && C.Id == expensesEdit!.CarId).FirstOrDefaultAsync();

//    ViewBag.DataworkDiary = expenses;
//    ViewBag.MeansTransportation = Car?.NameCar;

//    ViewBag.DataCar = car;
//    // في C#
//    var data = dbContext.workCompanies.ToList();
//    ViewBag.DataList = data;
//    if (expensesEdit != null)
//    {
//        int? IdCar = expensesEdit.CarId;
//        if (IdCar != null)
//        {
//            HttpContext.Session.SetInt32("Car_Id", (int)IdCar);
//        }

//    }


//    return View(expensesEdit);
//}
//else
//{


//    int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;

//    var lastWorkDiaryEntry = dbContext.expenses.Where(e => e.CompanyId == ID).OrderByDescending(e => e.Id).FirstOrDefault();

//    if (Expenses_Id == 0)
//    {

//        if (lastWorkDiaryEntry != null)
//        {
//            List<Expenses> expenses = await dbContext.expenses.Where(C => C.CompanyId == ID && C.CarId == lastWorkDiaryEntry.CarId).ToListAsync();
//            Car? Car = await dbContext.car.Where(C => C.CompanyId == ID && C.Id == lastWorkDiaryEntry.CarId).FirstOrDefaultAsync();
//            ViewBag.DataworkDiary = expenses;
//            ViewBag.MeansTransportation = Car?.NameCar;
//            int? IdCar = lastWorkDiaryEntry.CarId;
//            if (IdCar != null)
//            {
//                HttpContext.Session.SetInt32("Car_Id", (int)IdCar);
//            }

//        }
//        else if (lastWorkDiaryEntry == null)
//        {
//            List<Expenses> expenses = await dbContext.expenses.Where(C => C.CompanyId == ID && C.CarId == Expenses_Id).ToListAsync();
//            Car? Car = await dbContext.car.Where(C => C.CompanyId == ID && C.Id == Expenses_Id).FirstOrDefaultAsync();
//            ViewBag.DataworkDiary = expenses;
//            ViewBag.MeansTransportation = Car?.NameCar;
//            HttpContext.Session.SetInt32("Car_Id", Expenses_Id);
//        }

//    }
//    else
//    {
//        List<Expenses> expenses = await dbContext.expenses.Where(C => C.CompanyId == ID && C.CarId == Expenses_Id).ToListAsync();
//        Car? Car = await dbContext.car.Where(C => C.CompanyId == ID && C.Id == Expenses_Id).FirstOrDefaultAsync();
//        ViewBag.DataworkDiary = expenses;
//        ViewBag.MeansTransportation = Car?.NameCar;
//        HttpContext.Session.SetInt32("Car_Id", Expenses_Id);
//    }










//    List<Car> car = await dbContext.car.Where(C => C.CompanyId == ID).ToListAsync();
//    ViewBag.DataCar = car;
//    // في C#
//    var data = dbContext.workCompanies.ToList();
//    ViewBag.DataList = data;





//    return View();

//}