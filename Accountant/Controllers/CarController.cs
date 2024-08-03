

using Accountant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
 
using System.Text.RegularExpressions;
using Accountant.Data;


namespace Accountant.Controllers
{//  يسبب بعض المشاكل بسبب بعد تحميل البيانات تفقد البيانات بعد التحميل لان عند ارجوع لصفحه تكون البيانات مفقوده viewBig المشكلة هذا النضام المستعمل الذي نرسل البيانات عن طريق 
  //ViewModel  يجب تحديث طريق الارسال عن طريق  
    public class CarController : Controller
    {
        private readonly DataContextDB dbContext;
        public CarController(DataContextDB dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task<IActionResult> ScreenCar()
        {

            int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            List<Car> car = await dbContext.car.Where(C => C.CompanyId == ID).ToListAsync();

             
            return View(car);
        }
        public async Task<IActionResult> ScreenAddCar()
        {
            int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            List<Driver> driver = await dbContext.driver.Where(C => C.CompanyId == ID).ToListAsync();

            ViewBag.driver = driver;
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> ScreenAddCar(Car model)
        {

            try
            {

             


                string trimmed = Regex.Replace(model.NameCar.Trim(), @"\s+", " ");
                string trimmednumber = Regex.Replace(model.CarNumber.Trim(), @"\s+", " ");
                string trimmedCarModel = Regex.Replace(model.CarModel.Trim(), @"\s+", " ");
                string trimmedCarType = Regex.Replace(model.CarType.Trim(), @"\s+", " ");

                string trimmedCarWeight = Regex.Replace(model.CarWeight.Trim(), @"\s+", " ");
                string trimmedMaximumLoad = Regex.Replace(model.MaximumLoad.Trim(), @"\s+", " ");
                model.NameCar = trimmed;
                model.CarNumber = trimmednumber;
                model.CarModel = trimmedCarModel;
                model.CarType = trimmedCarType;
                model.CarWeight = trimmedCarWeight;
                model.MaximumLoad = trimmedMaximumLoad;
                model.CreatedDate = DateTime.Now;

                int IDCompany = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
                int IDMainUser = int.TryParse(HttpContext.Session.GetString("IDMainUser"), out int ID) ? ID : 0;
                int IDGeneralUser = int.TryParse(HttpContext.Session.GetString("IDGeneralUser"), out int id) ? id : 0;

                Car? car = await dbContext.car.Where(C => C.NameCar == model.NameCar).FirstOrDefaultAsync();
                Car? Car = await dbContext.car.Where(C => C.CarNumber == model.CarNumber).FirstOrDefaultAsync();
                if (Car == null)
                {
                    if (car == null)
                    {
                        

                        if (IDCompany >= 1 && IDMainUser >= 1)
                        {
                            model.IDMainUser = IDMainUser;
                            model.CompanyId = IDCompany;


                            dbContext.car.Add(model);
                            dbContext.SaveChanges();
                        }
                        else if (IDCompany >= 1 && IDGeneralUser >= 1)
                        {
                            model.IDGeneralUser = IDGeneralUser;
                            model.CompanyId = IDCompany;
                            dbContext.car.Add(model);
                            dbContext.SaveChanges();
                        }
                        else
                        {
                            ModelState.AddModelError("Error", "يوجد خطاء ويمكن ان هنا خطاء في تسجيل البيانات غير مكتملة");
                            return View(model);
                        }
                        Car? CarID = await dbContext.car.Where(C => C.CarNumber == model.CarNumber).FirstOrDefaultAsync();
                        CarInsurance carInsurance = new CarInsurance();
                        carInsurance.NumberCar = model.CarNumber;
                        carInsurance.CarType = model.CarType;
                        carInsurance.CarModel = model.CarModel;
                        carInsurance.InsuranceType = model.InsuranceType;
                        carInsurance.LicenseStartDate = model.LicenseExpirationDate;
                        carInsurance.LicenseExpirationDate = model.LicenseStartDate;
                        carInsurance.CreatedDate = DateTime.Now;
                        carInsurance.CarId = CarID!.Id;
                       
                        if (IDCompany >= 1 && IDMainUser >= 1)
                        {
                            carInsurance.IDMainUser = IDMainUser;
                            
                            carInsurance.CompanyId = IDCompany;
                        }
                        else if (IDCompany >= 1 && IDGeneralUser >= 1)
                        {
                            carInsurance.IDGeneralUser = IDGeneralUser;
                            carInsurance.CompanyId = IDCompany;
                        }
                        else
                        {
                            ModelState.AddModelError("Error", "يوجد خطاء ويمكن ان هنا خطاء في تسجيل البيانات غير مكتملة");
                            return View(model);
                        }
                        dbContext.Add(carInsurance);
                        dbContext.SaveChanges();
                        CarLicense carLicense = new CarLicense();
                        carLicense.NumberCar = model.CarNumber;
                        carLicense.CarType = model.CarType;
                        carLicense.CarModel = model.CarModel;
                         
                        carLicense.LicenseStartDate = DateTime.Now;
                        carLicense.LicenseExpirationDate = DateTime.Now;
                        carLicense.CreatedDate = DateTime.Now;
                        carLicense.CarId = CarID!.Id;
                       
                        if (IDCompany >= 1 && IDMainUser >= 1)
                        {
                            carLicense.IDMainUser = IDMainUser;
                            carLicense.CompanyId = IDCompany;
                        }
                        else if (IDCompany >= 1 && IDGeneralUser >= 1)
                        {
                            carLicense.IDGeneralUser = IDGeneralUser;
                            carLicense.CompanyId = IDCompany;
                        }
                        else
                        {
                            ModelState.AddModelError("Error", "يوجد خطاء ويمكن ان هنا خطاء في تسجيل البيانات غير مكتملة");
                            return View(model);
                        }
                        dbContext.Add(carLicense);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        ModelState.AddModelError("NameCar", "هذا الاسم موجود");
                        if (Car != null) { ModelState.AddModelError("CarNumber", " هذا الرقم السياره موجود ولا يمكن تكرار الرقم اكثر من مره"); }
                        return RedirectToAction("ScreenAddCar"); // ViewBig حل موقت لتجنب الخطاء لان اذا وضعنا الرجوع لصفحه سيتسبب في مشاكل لانه لا يوجد بيانات 
                    }
                }
                else
                {
                    ModelState.AddModelError("CarNumber", " هذا الرقم السياره موجود ولا يمكن تكرار الرقم اكثر من مره");
                    if (car != null) { ModelState.AddModelError("NameCar", "هذا الاسم موجود"); }
                    return RedirectToAction("ScreenAddCar");// ViewBig حل موقت لتجنب الخطاء لان اذا وضعنا الرجوع لصفحه سيتسبب في مشاكل لانه لا يوجد بيانات 

                }








                return RedirectToAction("ScreenCar");
            }
        catch
        {
            ModelState.AddModelError("Error", " يوجد خطاء ويمكن ان هنا خطاء في تسجيل البيانات غير مكتملة ويمكن من بيانات تامين السيارة");
            return View(model);
        }
        }
        public async Task<IActionResult> ScreenEditCar(int ID)
        {
            Car? car = await dbContext.car.Where(C => C.Id == ID).FirstOrDefaultAsync();
            var CompanyId_ID = car?.CompanyId != 0 ? car?.CompanyId : 0;
            List <Driver> driver = await dbContext.driver.Where(C => C.CompanyId == CompanyId_ID).ToListAsync();

            ViewBag.driver = driver;
            return View(car);
        }
        [HttpPost]
        public async Task<IActionResult> ScreenEditCar(Car model)

        {
            string trimmed = Regex.Replace(model.NameCar.Trim(), @"\s+", " ");
            string trimmednumber = Regex.Replace(model.CarNumber.Trim(), @"\s+", " ");
            string trimmedCarModel = Regex.Replace(model.CarModel.Trim(), @"\s+", " ");
            string trimmedCarWeight = Regex.Replace(model.CarWeight.Trim(), @"\s+", " ");
            string trimmedMaximumLoad = Regex.Replace(model.MaximumLoad.Trim(), @"\s+", " ");
            model.NameCar = trimmed;
            model.CarNumber = trimmednumber;
            model.CarModel = trimmedCarModel;
            model.CarWeight = trimmedCarWeight;
            model.MaximumLoad = trimmedMaximumLoad;

            Car? car = await dbContext.car.Where(C => C.Id == model.Id).FirstOrDefaultAsync();
            Car? NameCar = await dbContext.car.Where(C => C.NameCar == model.NameCar).FirstOrDefaultAsync();
            Car? CarNumber = await dbContext.car.Where(C => C.CarNumber == model.CarNumber).FirstOrDefaultAsync();

            if (car != null)
            {
                if(car.NameCar == model.NameCar && car.CarNumber == model.CarNumber)
                {
                    car.CarModel = model.CarModel;
                    car.CarWeight = model.CarWeight;
                    car.MaximumLoad = model.MaximumLoad;
                    car.IDDriver= model.IDDriver;
                    dbContext.Update(car);
                    dbContext.SaveChanges();
                    return RedirectToAction("ScreenCar");
                }
                else
                {
                    if (car.NameCar != model.NameCar)
                    {
                        if (NameCar == null)
                        {
                            car.NameCar = model.NameCar;
                            car.CarModel = model.CarModel;
                            car.CarWeight = model.CarWeight;
                            car.MaximumLoad = model.MaximumLoad;
                            car.IDDriver = model.IDDriver;

                        }
                        else
                        {
                            ModelState.AddModelError("NameCar", "هذا الاسم موجود");
                            if (NameCar != null && car.CarNumber != model.CarNumber) { ModelState.AddModelError("CarNumber", " هذا الرقم السياره موجود ولا يمكن تكرار الرقم اكثر من مره"); }
                            return View(model);
                        }
                         
                    }
                    if (car.CarNumber != model.CarNumber)
                    {
                        if (CarNumber == null)
                        {
                            car.CarNumber = model.CarNumber;
                            car.CarModel = model.CarModel;
                            car.CarWeight = model.CarWeight;
                            car.MaximumLoad = model.MaximumLoad;
                            car.IDDriver = model.IDDriver;

                        }
                        else
                        {
                            ModelState.AddModelError("CarNumber", " هذا الرقم السياره موجود ولا يمكن تكرار الرقم اكثر من مره");
                            if (CarNumber != null && car.CarNumber != model.CarNumber) { ModelState.AddModelError("CarNumber", "هذا الاسم موجود"); }
                            return View(model);
                            
                        }
                         
                    }

                dbContext.Update(car);
                dbContext.SaveChanges();
                return RedirectToAction("ScreenCar");
                }
                 

                //===========================
                
                       
               
                 
                 
                
                

            }
            return View(car);
        }
        public async Task<IActionResult> DeleteCar(int ID_Dalete_Car)
        {
            Car? car = await dbContext.car.Where(C => C.Id == ID_Dalete_Car).FirstOrDefaultAsync();
            if (car != null)
            {
                CarInsurance? carInsurance = await dbContext.carInsurance.Where(C => C.CarId == car.Id).FirstOrDefaultAsync();
                CarLicense? carLicense = await dbContext.carLicense.Where(C => C.CarId == car.Id).FirstOrDefaultAsync();
                if(carInsurance != null)
                {
                    dbContext.Remove(carInsurance);
                    dbContext.SaveChanges();

                }
                if (carLicense != null)
                {
                    dbContext.Remove(carLicense);
                    dbContext.SaveChanges();
                }
                CarInsurance? carInsuranceTest = await dbContext.carInsurance.Where(C => C.CarId == car.Id).FirstOrDefaultAsync();
                CarLicense? carLicenseTest = await dbContext.carLicense.Where(C => C.CarId == car.Id).FirstOrDefaultAsync();

                if (carInsuranceTest == null && carLicenseTest == null)
                {
                    dbContext.Remove(car);
                    dbContext.SaveChanges();
                }
                
            }
            return RedirectToAction("ScreenCar");
        }
        public async Task <IActionResult> ScreenCarInsurance(int ID_Insurance)
        {
            CarInsurance? carInsurance = await dbContext.carInsurance.Where(c => c.CarId == ID_Insurance).FirstOrDefaultAsync();
          
            return View(carInsurance);
        }
        [HttpPost]
        public async Task<IActionResult> ScreenCarInsurance(CarInsurance model)
        {

            string trimmedCarWeight = Regex.Replace(model.InsuranceType.Trim(), @"\s+", " ");
            model.InsuranceType = trimmedCarWeight;
        
        

            CarInsurance ? carInsurance = await dbContext.carInsurance.Where(C => C.Id == model.Id).FirstOrDefaultAsync();
            if(carInsurance != null)
            {
                carInsurance.NumberCar = model.NumberCar;
                carInsurance.CarType = model.CarType;
                carInsurance.CarModel = model.CarModel;
                carInsurance.InsuranceType = model.InsuranceType;
                carInsurance.LicenseExpirationDate = model.LicenseExpirationDate;
                carInsurance.LicenseStartDate = model.LicenseStartDate;
                dbContext.Update(carInsurance);
                dbContext.SaveChanges();
                return RedirectToAction("ScreenEditCar", new {ID= carInsurance.CarId});
            }
            return View(model);
        }
        public async Task<IActionResult> ScreenaCrLicense(int ID_License)
        {
            CarLicense? carLicense = await dbContext.carLicense.Where(c => c.CarId == ID_License).FirstOrDefaultAsync();


            return View(carLicense);
        }
        [HttpPost]
        public async Task<IActionResult> ScreenaCrLicense(CarLicense model)
        {
          


            CarLicense? carLicense = await dbContext.carLicense.Where(C => C.Id == model.Id).FirstOrDefaultAsync();
            if (carLicense != null)
            {
                carLicense.NumberCar = model.NumberCar;
                carLicense.CarType = model.CarType;
                carLicense.CarModel = model.CarModel;
                 
                carLicense.LicenseExpirationDate = model.LicenseExpirationDate;
                carLicense.LicenseStartDate = model.LicenseStartDate;
                dbContext.Update(carLicense);
                dbContext.SaveChanges();
                return RedirectToAction("ScreenEditCar", new { ID = carLicense.CarId });
            }
            return View(model);
        }
    }
    
}
 
//if (Regex.IsMatch(model.NameCar, @"\d"))
//{
//    ModelState.AddModelError("", "البيانات تحتوي على أرقام لاتينية!");
//    return View(model);
//}