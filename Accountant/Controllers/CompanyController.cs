using Accountant.Data;
using Accountant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Accountant.Controllers
{
    public class CompanyController : Controller
    {
        private readonly DataContextDB dbContext;
        public CompanyController(DataContextDB dataContextDB)

        {
               this.dbContext = dataContextDB;
        }
        public IActionResult ScreenCompany()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ScreenCompany(Company model)

        {
            Company? company = await dbContext.company.Where(C =>C.CompanyName == model.CompanyName).FirstOrDefaultAsync();
             
            if (ModelState.IsValid)

            {
                if (company != null)
                {
                    ModelState.AddModelError("CompanyName", "هذا الاسم محجوز لا يمكن استخدامه");
                }
                else
                {
                    model.CreatedDate = DateTime.Now;
                    dbContext.Add(model);
                    dbContext.SaveChanges();
                    Company? IDCompany = await dbContext.company.Where(C => C.CompanyName == model.CompanyName).FirstOrDefaultAsync();
                    int idMainUser = 0;
                    if (!string.IsNullOrEmpty(HttpContext?.Session.GetString("IDMainUser")))
                    {
                        idMainUser = int.Parse(HttpContext.Session.GetString("IDMainUser")!);

                        MainUser ?mainUser = await dbContext.mainUser.Where(M => M.Id == idMainUser).FirstOrDefaultAsync();
                        mainUser!.CompanyId = IDCompany!.Id;
                        dbContext.Update(mainUser!);
                        dbContext.SaveChanges();
                        if (mainUser != null)
                        {
                            HttpContext.Session.SetString("IDCompany", mainUser.CompanyId.ToString()!);
                        }
                        else
                        {
                            ModelState.AddModelError("CompanyName", "حصل مشكلة في الحصول على رقم الشركة ويجب التاكد من الكود هل يعمل بشكل صحيح");
                        }
                        return RedirectToAction("Index", "Home");
                    }


 
                }

                
            }
            return View();
        }
        public async Task<IActionResult> ScreenEditCompany()
        {
            Company? company = await dbContext.company.Where(c=>c.Id == int.Parse(HttpContext.Session.GetString("IDCompany")!)).FirstOrDefaultAsync();
            return View(company);
        }
        [HttpPost]
        public async Task<IActionResult> ScreenEditCompany(Company model)
        {
            Company? company = await dbContext.company.Where(c => c.Id == model.Id).FirstOrDefaultAsync();
            Company? company_Name = await dbContext.company.Where(c => c.CompanyName == model.CompanyName).FirstOrDefaultAsync();
            if (company != null)
            {
                if(company_Name == null)
                {
                    company.CompanyName = model.CompanyName;
                    company.CompanyFunction = model.CompanyFunction;
                    dbContext.Update(company);
                    dbContext.SaveChanges();
                }
                else
                {
                    if(company.CompanyName != model.CompanyName) 
                    {
                     ModelState.AddModelError("CompanyName", "هذا اسم الشركة موجود اخر اسم اخر");
                    return View(model);
                    }
                   
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
