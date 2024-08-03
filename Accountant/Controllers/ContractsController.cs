using Accountant.Data;
using Accountant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace Accountant.Controllers
{
    public class ContractsController : Controller
    {
        private readonly DataContextDB dbContext;
        public ContractsController(DataContextDB dbContext)
        {
            this.dbContext = dbContext; 
        }
        public async Task<IActionResult> ScreenContracts()
        {
            int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"),out int id)?id :0;
            List<Contracts> contract = await dbContext.contracts.Where(C => C.CompanyId == ID).ToListAsync();
            
            ViewBag.DataContract = contract;
            return View();


        }

        public IActionResult ScreenAddContracts()
        {
            return View();

        }
        [HttpPost]
        public async Task <IActionResult> ScreenAddContracts(Contracts model)
        {
            int IDCompany = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            int IDMainUser = int.TryParse(HttpContext.Session.GetString("IDMainUser"), out int ID) ? ID : 0;
            int IDGeneralUser = int.TryParse(HttpContext.Session.GetString("IDGeneralUser"), out int id) ? id : 0;
            if (IDCompany > 0)
            {
                Contracts? contractsName = await dbContext.contracts.Where(d => d.NameCompany == model.NameCompany && d.CompanyId == IDCompany).FirstOrDefaultAsync();
             
            string trimmed = Regex.Replace(model.NameCompany.Trim(), @"\s+", " ");
            string TWorkSite = Regex.Replace(model.CompanyWorkSite.Trim(), @"\s+", " ");
            model.NameCompany = trimmed;
            model.CompanyWorkSite = TWorkSite;
            
            if (contractsName == null)
            {
                 


                        if (IDCompany > 0 && IDMainUser >0)
                        {
                            model.IDMainUser = IDMainUser;
                            model.CompanyId = IDCompany;
                            model.CreatedDate = DateTime.Now;


                            dbContext.contracts.Add(model);
                            dbContext.SaveChanges();
                        return RedirectToAction("ScreenContracts");
                    }
                        else if (IDCompany > 0 && IDGeneralUser > 0)
                        {
                            model.IDGeneralUser = IDGeneralUser;
                            model.CompanyId = IDCompany;
                            model.CreatedDate = DateTime.Now;
                            dbContext.contracts.Add(model);
                            dbContext.SaveChanges();
                        return RedirectToAction("ScreenContracts");
                    }
                        else
                        {
                            ModelState.AddModelError("Error", "يوجد خطاء ويمكن ان هنا خطاء في تسجيل البيانات غير مكتملة");
                        return View();
                    }

                     
                }
            else
            {
                ModelState.AddModelError("NameCompany", "هذا الاسم موجدو ارجاء اختار اسم اخر ");
                return View();
                }
            }
            return View();
        }

        public async Task <IActionResult> ScreenEditContracts( int Contracts_Edit_ID)
        {
            Contracts? contracts = await dbContext.contracts.Where(d => d.Id == Contracts_Edit_ID).FirstOrDefaultAsync();
            return View(contracts);

        }
        [HttpPost]
        public async Task<IActionResult> ScreenEditContracts(Contracts model)
        {
            Contracts? contractsID = await dbContext.contracts.Where(d => d.Id == model.Id).FirstOrDefaultAsync();
            Contracts? contractsName = await dbContext.contracts.Where(d => d.NameCompany == model.NameCompany && d.CompanyId == model.CompanyId).FirstOrDefaultAsync();
             
            string trimmed = Regex.Replace(model.NameCompany.Trim(), @"\s+", " ");
            string TWorkSite = Regex.Replace(model.CompanyWorkSite.Trim(), @"\s+", " ");
            model.NameCompany = trimmed;
            model.CompanyWorkSite = TWorkSite;
             
            if (contractsID != null)
            {
                if (contractsName == null || contractsID.NameCompany == model.NameCompany)
                {


                    contractsID.NameCompany = model.NameCompany;
                    contractsID.NumberHours = model.NumberHours;
                    contractsID.NumberDays = model.NumberDays;
                    contractsID.WatchPrice = model.WatchPrice;
                    contractsID.CompanyWorkSite = model.CompanyWorkSite;
                    contractsID.ContractExpiryDate = model.ContractExpiryDate;
                    contractsID.CreatedDate = DateTime.Now;

                    dbContext.Update(contractsID);
                    dbContext.SaveChanges();
                    return RedirectToAction("ScreenContracts");




                      
                }
                else
                {
                    ModelState.AddModelError("NameCompany", "هذا الاسم موجدو ارجاء اختار اسم اخر ");
                    
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("Error", "يبدو ان هناك مشكلة في البيانات ويحتمل رقم التسلسل غير موجود");
                return View(model);
            }
        }

        
        public async Task<IActionResult> ScreenDeleteContracts(int Contracts_Delete_ID)
        {
            Contracts? contractsv = await dbContext.contracts.Where(c => c.Id == Contracts_Delete_ID).FirstOrDefaultAsync();
            if (contractsv != null)
            {
                dbContext.Remove(contractsv);
                dbContext.SaveChanges();    
            }
            return RedirectToAction("ScreenContracts");
             ;
        }
    }
}
