using Accountant.Data;
using Accountant.Models;
using Accountant.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Accountant.Controllers
{
    public class InputCompanyController : Controller
    {
        private readonly DataContextDB dbContext;
        public InputCompanyController(DataContextDB dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task< IActionResult> ScereenInputCompany( int InputCompanyID, int WorkCompniesID , bool AddToEdit)
        {
            ViewModelInputCompany viewModelInputCompany = new ViewModelInputCompany();
            int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            List<WorkCompanies> workCompanies = await dbContext.workCompanies.Where(w=>w.CompanyId ==ID).ToListAsync();
            viewModelInputCompany.workCompanies_List = workCompanies;
            if (AddToEdit == false)  
            {
                
                if (WorkCompniesID > 0)
                {
                    List<InputCompany> inputCompanies = await dbContext.inputCompany.Where(I=>I.CompanyId ==ID && I.IDWorkCompanies == WorkCompniesID).OrderByDescending(d=>d.Id).ToListAsync();
                    WorkCompanies? workCompaniesID = await dbContext.workCompanies.Where(w => w.Id == WorkCompniesID).FirstOrDefaultAsync();
                    viewModelInputCompany.inputCompanies_List = inputCompanies;
                    viewModelInputCompany.StatusButtonworkCompaniesID = workCompaniesID?.Id ??0;
                    viewModelInputCompany.StatusButtonworkCompaniesName = workCompaniesID?.CompanyName;
                    viewModelInputCompany.AddToEdit = AddToEdit;
                }
                else
                {
                    WorkCompanies? workCompaniesID = await dbContext.workCompanies.Where(w => w.CompanyId ==ID).OrderBy(w=>w.Id).FirstOrDefaultAsync();
                    if (workCompaniesID !=null)
                    {
                     
                        List<InputCompany> inputCompanies = await dbContext.inputCompany.Where(I => I.CompanyId == ID && I.IDWorkCompanies == workCompaniesID.Id).OrderByDescending(d => d.Id).ToListAsync();
                        viewModelInputCompany.inputCompanies_List = inputCompanies;
                        viewModelInputCompany.StatusButtonworkCompaniesID = workCompaniesID?.Id ?? 0;
                        viewModelInputCompany.StatusButtonworkCompaniesName = workCompaniesID?.CompanyName;
                        viewModelInputCompany.AddToEdit = AddToEdit;
                    }
                }

            }
            else if(AddToEdit == true)
            {
                InputCompany? inputCompanies_M = await dbContext.inputCompany.Where(I => I.CompanyId == ID && I.Id == InputCompanyID).FirstOrDefaultAsync();
                List<InputCompany> inputCompanies_List = await dbContext.inputCompany.Where(I => I.CompanyId == ID && I.IDWorkCompanies == WorkCompniesID).OrderByDescending(d => d.Id).ToListAsync();
                if(inputCompanies_M != null)
                {
                    viewModelInputCompany.inputCompany_M = inputCompanies_M;
                }
                WorkCompanies? workCompaniesID = await dbContext.workCompanies.Where(w => w.Id == WorkCompniesID).FirstOrDefaultAsync();
                viewModelInputCompany.inputCompanies_List = inputCompanies_List;
                viewModelInputCompany.StatusButtonworkCompaniesID = workCompaniesID?.Id ?? 0;
                viewModelInputCompany.StatusButtonworkCompaniesName = workCompaniesID?.CompanyName;
                viewModelInputCompany.AddToEdit = AddToEdit;
            }
            return View(viewModelInputCompany);
        }
        [HttpPost]
        public async Task<IActionResult> ScereenInputCompany(ViewModelInputCompany model)
        {
            int IDCompany = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            int IDMainUser = int.TryParse(HttpContext.Session.GetString("IDMainUser"), out int ID) ? ID : 0;
            int IDGeneralUser = int.TryParse(HttpContext.Session.GetString("IDGeneralUser"), out int id) ? id : 0;
            if (model.inputCompany_M.Id==0)
            {
                if (IDCompany > 0 && IDMainUser > 0)
                {
                    model.inputCompany_M.CompanyId = IDCompany;
                    model.inputCompany_M.IDMainUser = IDMainUser;
                    model.inputCompany_M.IDWorkCompanies = model.StatusButtonworkCompaniesID;
                    dbContext.Add(model.inputCompany_M);
                    dbContext.SaveChanges();


                }
                else if (IDCompany > 0 && IDGeneralUser > 0)
                {
                    model.inputCompany_M.CompanyId = IDCompany;
                    model.inputCompany_M.IDGeneralUser = IDGeneralUser;
                    model.inputCompany_M.IDWorkCompanies = model.StatusButtonworkCompaniesID;
                    dbContext.Add(model.inputCompany_M);
                    dbContext.SaveChanges();

                }
                
                
            }
            else if (model.inputCompany_M.Id>0)
            {
                InputCompany? inputCompany = await dbContext.inputCompany.Where(i=>i.Id == model.inputCompany_M.Id).FirstOrDefaultAsync();
                if(inputCompany != null)
                {

               
                    
                        model.inputCompany_M.CompanyId = IDCompany;
                        model.inputCompany_M.IDMainUser = IDMainUser;
                        model.inputCompany_M.IDWorkCompanies = model.StatusButtonworkCompaniesID;
                        inputCompany.AmountMoneyReceived = model.inputCompany_M.AmountMoneyReceived;
                        inputCompany.DateReceiptMoney = model.inputCompany_M.DateReceiptMoney;
                        dbContext.Update(inputCompany);
                        dbContext.SaveChanges();
                     


                }
            }
            return RedirectToAction("ScereenInputCompany", new { WorkCompniesID = model.StatusButtonworkCompaniesID });

        }
        public async Task<IActionResult> DeleteInputCompany(int ID)
        {
            InputCompany? inputCompany = await dbContext.inputCompany.Where(d => d.Id == ID).FirstOrDefaultAsync();
            if (inputCompany != null)
            {
                dbContext.Remove(inputCompany);
                dbContext.SaveChanges();

            }
             
            return RedirectToAction("ScereenInputCompany", new { WorkCompniesID = inputCompany?.IDWorkCompanies ?? 0 });

        }
    }
}
