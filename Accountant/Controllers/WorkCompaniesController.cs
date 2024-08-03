using Accountant.Data;
using Accountant.Models;
using Accountant.Models.MySharedService;
using Accountant.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace Accountant.Controllers
{
    public class WorkCompaniesController : Controller
    {
        private readonly DataContextDB dbContext;
        
        public WorkCompaniesController(DataContextDB dbContext)
        {
            this.dbContext = dbContext; 
            
        }
        public async Task<IActionResult> ScreenWorkComp()
        {
            int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
           
            int IDGeneralUser = int.TryParse(HttpContext.Session.GetString("IDGeneralUser"), out int IdG) ? IdG : 0;
            int IDMainUser = int.TryParse(HttpContext.Session.GetString("IDMainUser"), out int IdI) ? IdI : 0;
            int IDProgramUser = int.TryParse(HttpContext.Session.GetString("IDProgramUser"), out int IdP) ? IdP : 0;
            

            List<WorkCompanies> workCompanies = await dbContext.workCompanies.Where(C => C.CompanyId == ID).ToListAsync();
            PermissionsWorkCompanies? permissionsWorkCompanies = dbContext.permissionsWorkCompanies.Where(p=>p.IDUser ==IDGeneralUser).FirstOrDefault();
            ViewModelWorkCompanies viewModelWorkCompanies = new ViewModelWorkCompanies();
            viewModelWorkCompanies.workCompanies = workCompanies;
            viewModelWorkCompanies.permissionsWorkCompanies = permissionsWorkCompanies;
           
            viewModelWorkCompanies.IDMainUser = IDMainUser;
            viewModelWorkCompanies.IDGeneralUser = IDGeneralUser;
            viewModelWorkCompanies.IDProgramUser = IDProgramUser;
            viewModelWorkCompanies.id = ID;




            return View(viewModelWorkCompanies);
        }

        public IActionResult ScreenAddWorkComp() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ScreenAddWorkComp( WorkCompanies model)
        {
            int IDCompany = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            int IDMainUser = int.TryParse(HttpContext.Session.GetString("IDMainUser"), out int ID) ? ID : 0;
            int IDGeneralUser = int.TryParse(HttpContext.Session.GetString("IDGeneralUser"), out int id) ? id : 0;
            if (IDCompany > 0)
            {
                string TCompanyName = Regex.Replace(model.CompanyName.Trim(), @"\s+", " ");
                string TphoneNumber = Regex.Replace(model.phoneNumber.Trim(), @"\s+", " ");
                string TNumberVirtualHours = Regex.Replace(model.NumberVirtualHours.Trim(), @"\s+", " ");
                string TDefaultNumberDays = Regex.Replace(model.DefaultNumberDays.Trim(), @"\s+", " ");
                model.CompanyName = TCompanyName;
                model.phoneNumber = TphoneNumber;
                model.NumberVirtualHours = TNumberVirtualHours;
                model.DefaultNumberDays = TDefaultNumberDays;
                WorkCompanies? workCompaniesName = await dbContext.workCompanies.Where(d => d.CompanyName == model.CompanyName && d.CompanyId == IDCompany).FirstOrDefaultAsync();
                WorkCompanies? workCompaniesPhon = await dbContext.workCompanies.Where(d => d.phoneNumber == model.phoneNumber).FirstOrDefaultAsync();
                //Contracts? contracts = await dbContext.contracts.Where(d => d.id == model.phoneNumber).FirstOrDefaultAsync();

                if (workCompaniesName == null)
                {
                    if (workCompaniesPhon == null)
                    {

                        if (IDCompany > 0 && IDMainUser > 0)
                        {
                            model.IDMainUser = IDMainUser;
                            model.CompanyId = IDCompany;
                            model.CreatedDate = DateTime.Now;


                            dbContext.workCompanies.Add(model);
                            dbContext.SaveChanges();
                        }
                        else if (IDCompany > 0 && IDGeneralUser > 0)
                        {
                            model.IDGeneralUser = IDGeneralUser;
                            model.CompanyId = IDCompany;
                            model.CreatedDate = DateTime.Now;
                            dbContext.workCompanies.Add(model);
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
                        ModelState.AddModelError("phoneNumber", "هذا رقم الهاتف موجود ومرطبت بشخص اخر ارجاء تاكد من رقم الهاتف");
                        if (workCompaniesName != null) { ModelState.AddModelError("CompanyName", "هذا الرقم الوية موجود ارجاء تاكد من رقم الهوية "); }
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("CompanyName", "هذا اسم الشركة موجود بلفعل ارجاء اختر اسم اخر");
                    if (workCompaniesPhon != null) { ModelState.AddModelError("phoneNumber", "هذا الرقم الوية موجود ارجاء تاكد من رقم الهوية "); }
                    return View(model);
                }
            }
                return RedirectToAction("ScreenWorkComp");
            
        }
         

        public async Task<IActionResult> ScreenEditWorkComp(int WorkComp_Edit_ID)
        {
           WorkCompanies? workCompanies = await dbContext.workCompanies.Where(d => d.Id == WorkComp_Edit_ID).FirstOrDefaultAsync();
            return View(workCompanies);
        }
        [HttpPost]
        public async Task<IActionResult> ScreenEditWorkComp(WorkCompanies model)
        {
            WorkCompanies? workCompaniesID = await dbContext.workCompanies.Where(d => d.Id == model.Id).FirstOrDefaultAsync();
            WorkCompanies? workCompaniesName = await dbContext.workCompanies.Where(d => d.CompanyName == model.CompanyName && d.CompanyId == model.Id).FirstOrDefaultAsync();
            WorkCompanies? workCompaniesPhone = await dbContext.workCompanies.Where(d => d.phoneNumber == model.phoneNumber).FirstOrDefaultAsync();

            string TCompanyName = Regex.Replace(model.CompanyName.Trim(), @"\s+", " ");
            string TphoneNumber = Regex.Replace(model.phoneNumber.Trim(), @"\s+", " ");
            string TNumberVirtualHours = Regex.Replace(model.NumberVirtualHours.Trim(), @"\s+", " ");
            string TDefaultNumberDays = Regex.Replace(model.DefaultNumberDays.Trim(), @"\s+", " ");
            model.CompanyName = TCompanyName;
            model.phoneNumber = TphoneNumber;
            model.NumberVirtualHours = TNumberVirtualHours;
            model.DefaultNumberDays = TDefaultNumberDays;

            if (workCompaniesID != null)
            {
                if (workCompaniesName == null || workCompaniesID.CompanyName == model.CompanyName)
                {
                    if (workCompaniesPhone == null || workCompaniesID.phoneNumber == model.phoneNumber)
                    {
                        
                            workCompaniesID.CompanyName = model.CompanyName;
                            workCompaniesID.phoneNumber = model.phoneNumber;
                            workCompaniesID.NumberVirtualHours = model.NumberVirtualHours;
                            workCompaniesID.DefaultNumberDays = model.DefaultNumberDays;

                            dbContext.Update(workCompaniesID);
                            dbContext.SaveChanges();
                            return RedirectToAction("ScreenWorkComp");



 
                    }
                    else
                    {
                        ModelState.AddModelError("phoneNumber", "هذا الرقم الهوية موجود ارجاء تاكد من رقم الهوية ");
                        if (workCompaniesName == null || workCompaniesID.CompanyName == model.CompanyName) { } else { ModelState.AddModelError("Name", "هذا الاسم موجدو ارجاء اختار اسم اخر "); }
                        
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("CompanyName", "هذا اسم الشركة موجود بلفعل ارجاء اختر اسم اخر");
                    if (workCompaniesPhone == null || workCompaniesID.phoneNumber == model.phoneNumber) { } else { ModelState.AddModelError("PhoneNumber", "هذا رقم الهاتف موجود ومرطبت بشخص اخر ارجاء تاكد من رقم الهاتف"); }

                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("Error", "يبدو ان هناك مشكلة في البيانات ويحتمل رقم التسلسل غير موجود");
                return View(model);
            }


        }

        public async Task<IActionResult> DeleteWorkComp(int WorkComp_Delete_ID)
        {
            WorkCompanies? workCompanies = await dbContext.workCompanies.Where(d => d.Id == WorkComp_Delete_ID).FirstOrDefaultAsync();
            if (workCompanies != null)
            {
                dbContext.Remove(workCompanies);
                dbContext.SaveChanges();

            }
            return RedirectToAction("ScreenWorkComp");
        }
        public IActionResult Popupview()
        {
            return PartialView();
        }
        
    }
}
