using Accountant.Data;
using Accountant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Accountant.Controllers
{
    public class DriverController : Controller
    {
        private readonly DataContextDB dbContext;

        public DriverController(DataContextDB dbContext)

        {
            this.dbContext = dbContext;

        }
        public async Task<IActionResult> ScreenDriver()
        {
            int ID_Driver = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int id) ? id : 0;
           

            List<Driver> drivers = await dbContext.driver.Where(D=>D.CompanyId == ID_Driver).ToListAsync();
            return View(drivers);
        }


        //=====================
        public IActionResult ScreenAddDriver()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ScreenAddDriver(Driver model)
            
        {
            int ID_Driver = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int iid) ? iid : 0;
            Driver? driverName = await dbContext.driver.Where(d=>d.Name == model.Name && d.CompanyId == ID_Driver).FirstOrDefaultAsync();
            Driver? driverHobby = await dbContext.driver.Where(d=>d.HobbyNumber == model.HobbyNumber && d.CompanyId == ID_Driver).FirstOrDefaultAsync();
            Driver? dreiverPhone = await dbContext.driver.Where(d=>d.PhoneNumber == model.PhoneNumber && d.CompanyId == ID_Driver).FirstOrDefaultAsync();
            if(driverName == null)
            {
                if (driverHobby == null)
                {
                    if(dreiverPhone == null)
                    {

                        int IDCompany = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
                        int IDMainUser = int.TryParse(HttpContext.Session.GetString("IDMainUser"), out int ID) ? ID : 0;
                        int IDGeneralUser = int.TryParse(HttpContext.Session.GetString("IDGeneralUser"), out int id) ? id : 0;

                        if (IDCompany >= 1 && IDMainUser >= 1)
                        {
                            model.IDMainUser = IDMainUser;
                            model.CompanyId = IDCompany;
                            model.CreatedDate = DateTime.Now;
                            model.monthlyTypeId = model.monthlyTypeId;

                            dbContext.driver.Add(model);
                            dbContext.SaveChanges();
                        }
                        else if (IDCompany >= 1 && IDGeneralUser >= 1)
                        {
                            model.IDGeneralUser = IDGeneralUser;
                            model.CompanyId = IDCompany;
                            model.CreatedDate = DateTime.Now;
                              model.monthlyTypeId = model.monthlyTypeId;


                            dbContext.driver.Add(model);
                            dbContext.SaveChanges();
                        }
                        else
                        {
                            ModelState.AddModelError("Error", "يوجد خطاء ويمكن ان هنا خطاء في تسجيل البيانات غير مكتملة");
                            return View(model);
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("PhoneNumber","هذا رقم الهاتف موجود ومرطبت بشخص اخر ارجاء تاكد من رقم الهاتف");
                        if (driverHobby != null) { ModelState.AddModelError("HobbyNumber", "هذا الرقم الوية موجود ارجاء تاكد من رقم الهوية "); }
                        if (driverName != null) { ModelState.AddModelError("Name", "هذا الاسم موجدو ارجاء اختار اسم اخر "); }
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("HobbyNumber", "هذا الرقم الوية موجود ارجاء تاكد من رقم الهوية ");
                    if (driverName != null) { ModelState.AddModelError("Name", "هذا الاسم موجدو ارجاء اختار اسم اخر "); }
                    if (dreiverPhone != null) { ModelState.AddModelError("PhoneNumber", "هذا رقم الهاتف موجود ومرطبت بشخص اخر ارجاء تاكد من رقم الهاتف"); }

                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("Name", "هذا الاسم موجدو ارجاء اختار اسم اخر ");
                if(driverHobby != null){ModelState.AddModelError("HobbyNumber", "هذا الرقم الوية موجود ارجاء تاكد من رقم الهوية ");}
                if (dreiverPhone != null){ModelState.AddModelError("PhoneNumber", "هذا رقم الهاتف موجود ومرطبت بشخص اخر ارجاء تاكد من رقم الهاتف");}

                return View(model);
            }
            return RedirectToAction("ScreenDriver");

        }
        //=========================
        //=========================

        public async Task<IActionResult> ScreenEditDriver(int driver_Edit_Id)
        {
            Driver? driver  = await dbContext.driver.Where(d=>d.Id ==  driver_Edit_Id).FirstOrDefaultAsync();
            return View(driver);
        }
        [HttpPost]
        public async Task<IActionResult> ScreenEditDriver(Driver model)
        {
            Driver? driverID= await dbContext.driver.Where(d => d.Id == model.Id).FirstOrDefaultAsync();
            Driver? driverName = await dbContext.driver.Where(d => d.Name == model.Name).FirstOrDefaultAsync();
            Driver? driverHobby = await dbContext.driver.Where(d => d.HobbyNumber == model.HobbyNumber).FirstOrDefaultAsync();
            Driver? dreiverPhone = await dbContext.driver.Where(d => d.PhoneNumber == model.PhoneNumber).FirstOrDefaultAsync();

            string trimmed = Regex.Replace(model.Name.Trim(), @"\s+", " ");
            string trimmednumber = Regex.Replace(model.HobbyNumber.Trim(), @"\s+", " ");
            string trimmedCarModel = Regex.Replace(model.PhoneNumber.Trim(), @"\s+", " ");
            model.Name = trimmed;
            model.HobbyNumber = trimmednumber;
            model.PhoneNumber = trimmedCarModel;

            if(driverID != null)
                        {
            if (driverName == null || driverID.Name == model.Name )
            {
                if (driverHobby == null || driverID.HobbyNumber == model.HobbyNumber)
                {
                    if (dreiverPhone == null || driverID.PhoneNumber == model.PhoneNumber)
                    {
                        
                            driverID.Name = model.Name;
                            driverID.HobbyNumber = model.HobbyNumber;
                            driverID.PhoneNumber = model.PhoneNumber;
                            driverID.LicenseExpirationDate = model.LicenseExpirationDate;
                            driverID.Amount = model.Amount;
                            driverID.monthlyTypeId = model.monthlyTypeId;

                            dbContext.Update(driverID);
                            dbContext.SaveChanges();
                            return RedirectToAction("ScreenDriver");
                        



                    }
                    else
                    {
                        ModelState.AddModelError("PhoneNumber", "هذا رقم الهاتف موجود ومرطبت بشخص اخر ارجاء تاكد من رقم الهاتف");
                        if (driverHobby == null || driverID.HobbyNumber == model.HobbyNumber) { } else { ModelState.AddModelError("HobbyNumber", "هذا الرقم الوية موجود ارجاء تاكد من رقم الهوية "); }
                        if (driverName == null || driverID.Name == model.Name) { } else { ModelState.AddModelError("Name", "هذا الاسم موجدو ارجاء اختار اسم اخر "); }
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("HobbyNumber", "هذا الرقم الهوية موجود ارجاء تاكد من رقم الهوية ");
                    if (driverName == null || driverID.Name == model.Name) { } else { ModelState.AddModelError("Name", "هذا الاسم موجدو ارجاء اختار اسم اخر "); }
                    if (dreiverPhone == null || driverID.PhoneNumber == model.PhoneNumber) { } else { ModelState.AddModelError("PhoneNumber", "هذا رقم الهاتف موجود ومرطبت بشخص اخر ارجاء تاكد من رقم الهاتف"); }

                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("Name", "هذا الاسم موجدو ارجاء اختار اسم اخر ");
                if (driverHobby == null || driverID.HobbyNumber == model.HobbyNumber) { }else { ModelState.AddModelError("HobbyNumber", "هذا الرقم الوية موجود ارجاء تاكد من رقم الهوية "); }
                if (dreiverPhone == null || driverID.PhoneNumber == model.PhoneNumber) { } else { ModelState.AddModelError("PhoneNumber", "هذا رقم الهاتف موجود ومرطبت بشخص اخر ارجاء تاكد من رقم الهاتف"); }

                return View(model);
            }
            }
            else
            {
                ModelState.AddModelError("Error", "يبدو ان هناك مشكلة في البيانات ويحتمل رقم التسلسل غير موجود");
                return View(model);
            }


        }
        //=========================
        //=========================

        public async Task<IActionResult> ScreenDaleteDriver(int driver_Dalete_Id)
        {
            Driver? driver = await dbContext.driver.Where(d => d.Id == driver_Dalete_Id).FirstOrDefaultAsync();
            if (driver != null)
            {
                dbContext.Remove(driver);   
                dbContext.SaveChanges();
                
            }
            return RedirectToAction("ScreenDriver");


        }
        //=========================
        //=========================

    }
}
