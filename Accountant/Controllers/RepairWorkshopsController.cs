using Accountant.Data;
using Accountant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Accountant.Controllers
{
    public class RepairWorkshopsController : Controller
    {
        private readonly DataContextDB dbContext;

        public RepairWorkshopsController(DataContextDB dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> ScreenRepairWorkshops(int RepairWorkshops_id, int RepairWorkshopsEdit_id, string Errore)
        {
            if (Errore != null)
            {

            }
            if (RepairWorkshopsEdit_id > 0)
            {
                int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
                RepairWorkshops? repairWorkshopsEdit = await dbContext.repairWorkshops.Where(C => C.Id == RepairWorkshopsEdit_id).FirstOrDefaultAsync();
                List<RepairWorkshops> repairWorkshops = await dbContext.repairWorkshops.Where(C => C.CompanyId == ID).ToListAsync();

                ViewBag.repairWorkshops = repairWorkshops;
                return View(repairWorkshopsEdit);
            }
            else
            {
                int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
                List<RepairWorkshops> repairWorkshops = await dbContext.repairWorkshops.Where(C => C.CompanyId == ID).ToListAsync(); 
                ViewBag.repairWorkshops = repairWorkshops;

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ScreenRepairWorkshops(RepairWorkshops model)
        {
            int IDCompany = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            int IDMainUser = int.TryParse(HttpContext.Session.GetString("IDMainUser"), out int ID) ? ID : 0;
            int IDGeneralUser = int.TryParse(HttpContext.Session.GetString("IDGeneralUser"), out int id) ? id : 0;
            if (model.Id == 0)
            {
                if (IDCompany > 0)
                {
                    string NameRepairShop = Regex.Replace(model.NameRepairShop.Trim(), @"\s+", " ");
                    string WorkshopLocation = Regex.Replace(model.WorkshopLocation.Trim(), @"\s+", " ");
                    string WorkshopSpecialty = Regex.Replace(model.WorkshopSpecialty.Trim(), @"\s+", " ");
                    model.NameRepairShop = NameRepairShop;
                    model.WorkshopLocation = WorkshopLocation;
                    model.WorkshopSpecialty = WorkshopSpecialty;

                    if (IDCompany > 0 && IDMainUser > 0)
                    {
                        model.IDMainUser = IDMainUser;
                        model.CompanyId = IDCompany;



                        dbContext.repairWorkshops.Add(model);
                        dbContext.SaveChanges();
                    }
                    else if (IDCompany > 0 && IDGeneralUser > 0)
                    {
                        model.IDGeneralUser = IDGeneralUser;
                        model.CompanyId = IDCompany;


                        dbContext.repairWorkshops.Add(model);
                        dbContext.SaveChanges();
                    }
                    else
                    {

                        return RedirectToAction("ScreenRepairWorkshops", new { Errore = "يوجد خطاء ويمكن ان هنا خطاء في تسجيل البيانات غير مكتملة" });

                    }

                }
            }
            else if (model.Id != 0)
            {
                RepairWorkshops? repairWorkshopsID = await dbContext.repairWorkshops.Where(d => d.Id == model.Id).FirstOrDefaultAsync();
                string NameRepairShop = Regex.Replace(model.NameRepairShop.Trim(), @"\s+", " ");
                string WorkshopLocation = Regex.Replace(model.WorkshopLocation.Trim(), @"\s+", " ");
                string WorkshopSpecialty = Regex.Replace(model.WorkshopSpecialty.Trim(), @"\s+", " ");
                model.NameRepairShop = NameRepairShop;
                model.WorkshopLocation = WorkshopLocation;
                model.WorkshopSpecialty = WorkshopSpecialty;
                if (IDCompany > 0 && IDMainUser > 0)
                {
                    model.IDMainUser = IDMainUser;
                    model.CompanyId = IDCompany;

                    if (repairWorkshopsID != null)
                    {
                        repairWorkshopsID.NameRepairShop = model.NameRepairShop;
                        repairWorkshopsID.WorkshopLocation = model.WorkshopLocation;
                        repairWorkshopsID.WorkshopSpecialty = model.WorkshopSpecialty;
                        repairWorkshopsID.WorkingHours = model.WorkingHours;

                        dbContext.repairWorkshops.Update(repairWorkshopsID);
                        dbContext.SaveChanges();
                    }

                }
                else if (IDCompany > 0 && IDGeneralUser > 0)
                {
                    model.IDGeneralUser = IDGeneralUser;
                    model.CompanyId = IDCompany;


                    if (repairWorkshopsID != null)
                    {
                        repairWorkshopsID.NameRepairShop = model.NameRepairShop;
                        repairWorkshopsID.WorkshopLocation = model.WorkshopLocation;
                        repairWorkshopsID.WorkshopSpecialty = model.WorkshopSpecialty;
                        repairWorkshopsID.WorkingHours = model.WorkingHours;

                        dbContext.repairWorkshops.Update(repairWorkshopsID);
                        dbContext.SaveChanges();
                    }
                }
                else
                {

                    return RedirectToAction("ScreenRepairWorkshops", new { Error = "يوجد خطاء ويمكن ان هنا خطاء في تسجيل البيانات غير مكتملة" });



                }
            }
            return RedirectToAction("ScreenRepairWorkshops");
        }
        public async Task<IActionResult> DeleteRepairWorkshops(int id)
        {
            RepairWorkshops? repairWorkshops = await dbContext.repairWorkshops.Where(d => d.Id == id).FirstOrDefaultAsync();

            if (repairWorkshops != null)
            {
                dbContext.Remove(repairWorkshops);
                dbContext.SaveChanges();
            }
            return RedirectToAction("ScreenRepairWorkshops");

        }
    }
}
