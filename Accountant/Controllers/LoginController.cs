using Accountant.Data;
using Accountant.Models;
using Accountant.Models.MySharedService;
using Accountant.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Accountant.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContextDB dbContext;
        
        public LoginController( DataContextDB dbContext )
        {
            this.dbContext = dbContext;
            
        }
        public IActionResult ScreenLogin()
        {
            return View();
        }
        [HttpPost]  
        public async Task<IActionResult> ScreenLogin(Login model)
            {
            ProgramUser? programUser = await dbContext.programUser.Where(P => P.Name == model.Name && P.Password == model.Passowrde).FirstOrDefaultAsync();
            MainUser? mainUser = await dbContext.mainUser.Where(M =>M.Name == model.Name && M.Password == model.Passowrde).FirstOrDefaultAsync();
            MainUserTem? mainUserTem = await dbContext.mainUserTem.Where(MT => MT.Name == model.Name && MT.Password == model.Passowrde).FirstOrDefaultAsync();
            GeneralUser? generalUser = await dbContext.generalUser.Where(G => G.Name == model.Name && G.Password == model.Passowrde).FirstOrDefaultAsync();
            //==================== ==================================================================================================================================

            HttpContext.Session.Remove("NameProgramUser");
            HttpContext.Session.Remove("NameMainUser");
            HttpContext.Session.Remove("NameGeneralUser");
            HttpContext.Session.Remove("Car");
            HttpContext.Session.Remove("Company");
            HttpContext.Session.Remove("CompanyDebts");
            HttpContext.Session.Remove("CompanyObligations");
            HttpContext.Session.Remove("Contracts");
            HttpContext.Session.Remove("CustomerDebts");
            HttpContext.Session.Remove("Driver");
            HttpContext.Session.Remove("Expenses");
            HttpContext.Session.Remove("Fuel");
            HttpContext.Session.Remove("GeneralUser");
            HttpContext.Session.Remove("InsuranceCar");
            HttpContext.Session.Remove("LicenseCar");
            HttpContext.Session.Remove("MainUser");
            HttpContext.Session.Remove("MainUserTem");
            HttpContext.Session.Remove("Memo");
            HttpContext.Session.Remove("Monthly");
            HttpContext.Session.Remove("Payments");
            HttpContext.Session.Remove("ProgramUser");
            HttpContext.Session.Remove("RepairWorkshops");
            HttpContext.Session.Remove("SparePartsCenters");
            HttpContext.Session.Remove("WorkCompanies");
            HttpContext.Session.Remove("WorkDiary");
            HttpContext.Session.Remove("IDCompany");
            HttpContext.Session.Remove("IDMainUser");
            
            //======================================================================================================================================================

            if (ModelState.IsValid)
            {
                 
                //=======================================================================================
                if (programUser != null) 
                {
                    HttpContext.Session.SetString("NameProgramUser", programUser.Name!);
                    HttpContext.Session.SetString("IDProgramUser", programUser.Id.ToString());
                   
                    return RedirectToAction("ScreenHome", "Home");
                }
                //=======================================================================================             
                else if (mainUser != null)
                {
                    if (mainUser.Confirmed == true)
                    {
                        if (mainUser.CompanyId == null)
                        {
                            HttpContext.Session.SetString("NameMainUser", mainUser!.Name);
                            HttpContext.Session.SetString("IDMainUser", mainUser.Id.ToString());
                            
                            return RedirectToAction("ScreenCompany", "Company");
                            
                              
                            

                        }
                        else
                        {
                            if (mainUser != null)
                            {
                                HttpContext.Session.SetString("IDCompany", mainUser.CompanyId.ToString()!);
                                
                            }
                             
                            HttpContext.Session.SetString("NameMainUser", mainUser!.Name);
                            HttpContext.Session.SetString("IDMainUser", mainUser.Id.ToString());
                            ViewData["Layout"] = "~/Views/Shared/_Layout2.cshtml";
                            return RedirectToAction("ScreenHome", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Name", "يبدو ان هذا الحساب اما قد تم توقيفه او يحتاج تفعيل");
                    }                  
                }
                //=======================================================================================
                else if (mainUserTem != null)
                { 
                    ModelState.AddModelError("Error", "لقد تم تقديم لك من قبل وهوا في انتظار القبول");
                }
                //=======================================================================================
                else if (generalUser != null) 
                {
                    
                        PagesPermissions? pagesPermissions = await dbContext.pagesPermissions.Where(P => P.IDUser == generalUser.ID).FirstOrDefaultAsync();
                    
                    if (generalUser.Confirmed == true)
                    {
                        if (pagesPermissions != null)
                        {
                            HttpContext.Session.SetString("NameGeneralUser", generalUser.Name);
                            HttpContext.Session.SetString("IDGeneralUser", generalUser.ID.ToString());
                            HttpContext.Session.SetString("IDCompany", generalUser.CompanyId.ToString()!);
                            
                            //HttpContext.Session.SetString("Briefs", pagesPermissions!.Briefs.ToString());
                            //HttpContext.Session.SetString("Car", pagesPermissions!.Car.ToString());
                            //HttpContext.Session.SetString("Company", pagesPermissions!.Company.ToString());
                            //HttpContext.Session.SetString("CompanyDebts", pagesPermissions!.CompanyDebts.ToString());
                            //HttpContext.Session.SetString("CompanyObligations", pagesPermissions!.CompanyObligations.ToString());
                            //HttpContext.Session.SetString("Contracts", pagesPermissions!.Contracts.ToString());
                            //HttpContext.Session.SetString("CustomerDebts", pagesPermissions!.CustomerDebts.ToString());
                            //HttpContext.Session.SetString("Driver", pagesPermissions!.Driver.ToString());
                            //HttpContext.Session.SetString("Expenses", pagesPermissions!.Expenses.ToString());
                            //HttpContext.Session.SetString("Fuel", pagesPermissions!.Fuel.ToString());
                            //HttpContext.Session.SetString("GeneralUser", pagesPermissions!.GeneralUser.ToString());
                            //HttpContext.Session.SetString("InsuranceCar", pagesPermissions!.InsuranceCar.ToString());
                            //HttpContext.Session.SetString("LicenseCar", pagesPermissions!.LicenseCar.ToString());
                            //HttpContext.Session.SetString("MainUser", pagesPermissions!.MainUser.ToString());
                            //HttpContext.Session.SetString("MainUserTem", pagesPermissions!.MainUserTem.ToString());
                            //HttpContext.Session.SetString("Memo", pagesPermissions!.Memo.ToString());
                            //HttpContext.Session.SetString("Monthly", pagesPermissions!.Monthly.ToString());
                            //HttpContext.Session.SetString("Payments", pagesPermissions!.Payments.ToString());
                            //HttpContext.Session.SetString("ProgramUser", pagesPermissions!.ProgramUser.ToString());
                            //HttpContext.Session.SetString("RepairWorkshops", pagesPermissions!.RepairWorkshops.ToString());
                            //HttpContext.Session.SetString("SparePartsCenters", pagesPermissions!.SparePartsCenters.ToString());
                            //HttpContext.Session.SetString("WorkCompanies", pagesPermissions!.WorkCompanies.ToString());
                            //HttpContext.Session.SetString("WorkDiary", pagesPermissions!.WorkDiary.ToString());
                            // استبدلنا هذا الكود الي تحت زي جدول يغني عن كل الي فوق

                            var pagesPermissionsTest = await dbContext.pagesPermissions.Where(w => w.IDUser == generalUser.ID).FirstOrDefaultAsync();
                            var jsonPagesPermissions = JsonConvert.SerializeObject(pagesPermissions);
                            HttpContext.Session.SetString("PagesPermissions", jsonPagesPermissions);
                            return RedirectToAction("ScreenHome", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("Name", "يوحد لدي مشكلة في الصلاحيات تاكد بان لديك صلاحيات");
                            return View();
                        }
                   



                        
                    }
                    else
                    {
                        
                        ModelState.AddModelError("Name", "يبدو ان هذا الحساب اما قد تم توقيفه او يحتاج تفعيل");
                        
                    }
                }
                //=======================================================================================
                else
                {
                    ModelState.AddModelError("Name", "هناك خطاء في اسم المستخدم او الباسورد");
                }
            }
            else
            {
                ModelState.AddModelError("Error", "هناك خطاء تأكد من البيانات");
            }

            return View();        
        }

        public IActionResult Exst()
        {
            

            HttpContext.Session.Remove("NameProgramUser");
            HttpContext.Session.Remove("IDProgramUser");
            HttpContext.Session.Remove("NameMainUser");
            HttpContext.Session.Remove("NameGeneralUser");
            HttpContext.Session.Remove("Car");
            HttpContext.Session.Remove("Company");
            HttpContext.Session.Remove("CompanyDebts");
            HttpContext.Session.Remove("CompanyObligations");
            HttpContext.Session.Remove("Contracts");
            HttpContext.Session.Remove("CustomerDebts");
            HttpContext.Session.Remove("Driver");
            HttpContext.Session.Remove("Expenses");
            HttpContext.Session.Remove("Fuel");
            HttpContext.Session.Remove("GeneralUser");
            HttpContext.Session.Remove("InsuranceCar");
            HttpContext.Session.Remove("LicenseCar");
            HttpContext.Session.Remove("MainUser");
            HttpContext.Session.Remove("MainUserTem");
            HttpContext.Session.Remove("Memo");
            HttpContext.Session.Remove("Monthly");
            HttpContext.Session.Remove("Payments");
            HttpContext.Session.Remove("ProgramUser");
            HttpContext.Session.Remove("RepairWorkshops");
            HttpContext.Session.Remove("SparePartsCenters");
            HttpContext.Session.Remove("WorkCompanies");
            HttpContext.Session.Remove("WorkDiary");
            HttpContext.Session.Remove("IDCompany");
            HttpContext.Session.Remove("IDMainUser");
            HttpContext.Session.Remove("PagesPermissions");

            return RedirectToAction("ScreenLogin", "Login");
        }
    }
}
