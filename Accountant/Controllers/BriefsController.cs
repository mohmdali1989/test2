using Accountant.Data;
using Accountant.Models;
using Accountant.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;


namespace Accountant.Controllers
{

    // لازم ما يكون في يوم عمل يوافق يوم ايجاوه
    public class BriefsController : Controller
    {
        private readonly DataContextDB dbContext;
        public BriefsController(DataContextDB dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task<IActionResult> ScreenBriefs(int BriefsID, bool AddToEdit)
        {
            BriefsViewModel briefsViewModel = new BriefsViewModel();


            int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            List<Driver> drivers = await dbContext.driver.Where(C => C.CompanyId == ID && C.monthlyTypeId == 1).ToListAsync();
             if(AddToEdit == false)
            {
            if (BriefsID > 0)
                {
                    List<Briefs> briefs = await dbContext.briefs.Where(B => B.CompanyId == ID && B.IDDriver == BriefsID).Include(D => D.Drivers).ToListAsync();

                    briefs =  briefs.OrderBy(item => item.VacationDate).ToList();

                    Driver? driverID = await dbContext.driver.Where(C => C.CompanyId == ID && C.Id == BriefsID).FirstOrDefaultAsync();
                    briefsViewModel.StatusButtonDriver = driverID?.Id ?? 0;
                    briefsViewModel.Driver_List = drivers;
                    briefsViewModel.Briefs_List = briefs;
                    briefsViewModel.ID_Driver= driverID?.Id ?? 0;
                    briefsViewModel.Name_Driver = driverID?.Name;
                    briefsViewModel.AddToEdit = AddToEdit;
                    briefsViewModel.ID_Briefs = BriefsID;

                }
                else
                {
                    var LastBrisfs = await dbContext.briefs.Where(B=>B.CompanyId == ID).OrderByDescending(b => b.id).FirstOrDefaultAsync();            
                    var LastDriver = await dbContext.driver.Where(B => B.CompanyId == ID).OrderBy(b => b.Id).FirstOrDefaultAsync();
                    briefsViewModel.Driver_List = drivers;
                    briefsViewModel.AddToEdit = AddToEdit;
                    briefsViewModel.ID_Briefs = BriefsID;
                    if (LastBrisfs != null)
                    {
                        List<Briefs> briefs = await dbContext.briefs.Where(B => B.CompanyId == ID && B.IDDriver == LastBrisfs.IDDriver).Include(D => D.Drivers).ToListAsync();
                        briefsViewModel.StatusButtonDriver = LastBrisfs?.IDDriver ?? 0;
                        briefsViewModel.Briefs_List = briefs;
                        briefsViewModel.ID_Driver = LastBrisfs?.Drivers?.Id ?? 0;
                        briefsViewModel.Name_Driver = LastBrisfs?.Drivers?.Name;
                    }
                    else if (LastDriver != null)             
                    {
                        briefsViewModel.StatusButtonDriver = LastDriver?.Id ?? 0;
                    
                        briefsViewModel.ID_Driver = LastDriver?.Id ?? 0;
                        briefsViewModel.Name_Driver = LastDriver?.Name;
                    }
               
                }
            }else if (AddToEdit == true)
            {
                Briefs? briefs = dbContext.briefs.Where(d => d.id == BriefsID && d.CompanyId == ID).FirstOrDefault();
                if(briefs != null)
                {
                    List<Briefs> briefs_List = await dbContext.briefs.Where(B => B.CompanyId == ID && B.IDDriver == briefs.IDDriver).Include(D => D.Drivers).ToListAsync();

                    briefsViewModel.Briefs_M = briefs;
                    briefsViewModel.StatusButtonDriver = briefs?.IDDriver ?? 0;
                    briefsViewModel.Driver_List = drivers;
                    briefsViewModel.Briefs_List = briefs_List;
                    briefsViewModel.ID_Driver = briefs?.IDDriver ?? 0;
                    briefsViewModel.Name_Driver = briefs?.Drivers?.Name;
                    briefsViewModel.AddToEdit = AddToEdit;
                }
                
            }
            
         

            return View(briefsViewModel);
        }
        [HttpPost]

        public async Task<IActionResult> ScreenBriefs(BriefsViewModel model)
        {
            int IDCompany = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            int IDMainUser = int.TryParse(HttpContext.Session.GetString("IDMainUser"), out int ID) ? ID : 0;
            int IDGeneralUser = int.TryParse(HttpContext.Session.GetString("IDGeneralUser"), out int id) ? id : 0;
            string PushStatusDescription = Regex.Replace(model.Briefs_M.PushStatusDescription.Trim(), @"\s+", " ");
            model.Briefs_M.PushStatusDescription = PushStatusDescription;
            if(model.Briefs_M.id == 0)
            {
                if (IDCompany > 0 && IDMainUser > 0)
                {
                    model.Briefs_M.IDMainUser = IDMainUser;
                    model.Briefs_M.CompanyId = IDCompany;
                    model.Briefs_M.IDDriver = model.Briefs_M.IDDriver;
                    dbContext.briefs.Add(model.Briefs_M);
                    dbContext.SaveChanges();
                }
                else if (IDCompany > 0 && IDGeneralUser > 0)
                {
                    model.Briefs_M.IDGeneralUser = IDGeneralUser;
                    model.Briefs_M.CompanyId = IDCompany;
                    model.Briefs_M.IDDriver = model.Briefs_M.IDDriver;
                    dbContext.briefs.Add(model.Briefs_M);
                    dbContext.SaveChanges();
                }
            }
            else if (model.Briefs_M.id != 0)
            {
                Briefs? briefs = await dbContext.briefs.Where(b => b.id == model.Briefs_M.id).FirstOrDefaultAsync(); 
                if (briefs != null)
                {
                    briefs.VacationDate = model.Briefs_M.VacationDate;
                    briefs.PushStatusDescription = model.Briefs_M.PushStatusDescription;
                    briefs.DriverName = model.Briefs_M.DriverName;
                    briefs.PushStatus = model.Briefs_M.PushStatus;
                    dbContext.Update(briefs);
                    dbContext.SaveChanges();
                }


            }

            return RedirectToAction("ScreenBriefs", new { BriefsID = model.Briefs_M.IDDriver});


        }
        public IActionResult test () { return View(); }
        public async Task<IActionResult> DeleteBriefs( int ID)
        {
            Briefs? briefs =await dbContext.briefs.Where(d => d.id == ID).FirstOrDefaultAsync();
            if (briefs != null)
            {
                dbContext.Remove(briefs);
                dbContext.SaveChanges();
                
            }
            return RedirectToAction("ScreenBriefs", new { BriefsID = briefs?.IDDriver ?? 0 });

        }
    }
}
