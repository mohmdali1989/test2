using Accountant.Data;
using Accountant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Accountant.Controllers
{
    public class SparePartsCentersController : Controller
    {
        private readonly DataContextDB dbContext;

        public SparePartsCentersController(DataContextDB dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> ScreenSparePartsCenters(int SpareParts_id , int SparePartsEdit_id , string Errore)
        {
            if(Errore != null)
            {

            }
            if(SparePartsEdit_id > 0)
            {
                int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
                SparePartsCenters? sparePartsCentersEdit = await dbContext.sparePartsCenters.Where(C => C.Id ==SparePartsEdit_id).FirstOrDefaultAsync();/*يمكن ان يسبب مشاكل اذا وضعنا عدم الفراغ*/
                List<SparePartsCenters> sparePartsCenters = await dbContext.sparePartsCenters.Where(C => C.CompanyId == ID).ToListAsync();/*يمكن ان يسبب مشاكل اذا وضعنا عدم الفراغ*/

                ViewBag.sparePartsCenters = sparePartsCenters;
                return View(sparePartsCentersEdit);
            }
            else
            {
                int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
                List<SparePartsCenters> sparePartsCenters = await dbContext.sparePartsCenters.Where(C => C.CompanyId == ID).ToListAsync();/*يمكن ان يسبب مشاكل اذا وضعنا عدم الفراغ*/
                ViewBag.sparePartsCenters = sparePartsCenters;

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ScreenSparePartsCenters(SparePartsCenters model)
        {
            int IDCompany = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            int IDMainUser = int.TryParse(HttpContext.Session.GetString("IDMainUser"), out int ID) ? ID : 0;
            int IDGeneralUser = int.TryParse(HttpContext.Session.GetString("IDGeneralUser"), out int id) ? id : 0;
            if(model.Id == 0)
            {
                if(IDCompany > 0)
                {
                    string NameCenter = Regex.Replace(model.NameCenter.Trim(), @"\s+", " ");
                    string CentrLocation = Regex.Replace(model.CentrLocation.Trim(), @"\s+", " ");
                    string CenterSpecialty = Regex.Replace(model.CenterSpecialty.Trim(), @"\s+", " ");
                    model.NameCenter = NameCenter;
                    model.CentrLocation = CentrLocation;
                    model.CenterSpecialty = CenterSpecialty;
                    if (IDCompany > 0 && IDMainUser > 0)
                    {
                        model.IDMainUser = IDMainUser;
                        model.CompanyId = IDCompany;

                        

                        dbContext.sparePartsCenters.Add(model);
                        dbContext.SaveChanges();
                    }
                    else if (IDCompany > 0 && IDGeneralUser > 0)
                    {
                        model.IDGeneralUser = IDGeneralUser;
                        model.CompanyId = IDCompany;

                       
                        dbContext.sparePartsCenters.Add(model);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        
                        return RedirectToAction("ScreenSparePartsCenters", new { Errore = "يوجد خطاء ويمكن ان هنا خطاء في تسجيل البيانات غير مكتملة" });

                    }

                }
            }else if(model.Id != 0)
            {
                SparePartsCenters? sparePartsCentersID = await dbContext.sparePartsCenters.Where(d => d.Id == model.Id).FirstOrDefaultAsync();
                string NameCenter = Regex.Replace(model.NameCenter.Trim(), @"\s+", " ");
                string CentrLocation = Regex.Replace(model.CentrLocation.Trim(), @"\s+", " ");
                string CenterSpecialty = Regex.Replace(model.CenterSpecialty.Trim(), @"\s+", " ");
                model.NameCenter = NameCenter;
                model.CentrLocation = CentrLocation;
                model.CenterSpecialty = CenterSpecialty;
                if (IDCompany > 0 && IDMainUser > 0)
                {
                    model.IDMainUser = IDMainUser;
                    model.CompanyId = IDCompany;
 
                    if (sparePartsCentersID != null)
                    {
                        sparePartsCentersID.NameCenter = model.NameCenter;
                        sparePartsCentersID.CentrLocation = model.CentrLocation;
                        sparePartsCentersID.CenterSpecialty = model.CenterSpecialty;
                        sparePartsCentersID.CenterWorkingHours = model.CenterWorkingHours;
                        
                        dbContext.sparePartsCenters.Update(sparePartsCentersID);
                        dbContext.SaveChanges();
                    }

                }
                else if (IDCompany > 0 && IDGeneralUser > 0)
                {
                    model.IDGeneralUser = IDGeneralUser;
                    model.CompanyId = IDCompany;

                     
                    if (sparePartsCentersID != null)
                    {
                        sparePartsCentersID.NameCenter = model.NameCenter;
                        sparePartsCentersID.CentrLocation = model.CentrLocation;
                        sparePartsCentersID.CenterSpecialty = model.CenterSpecialty;
                        sparePartsCentersID.CenterWorkingHours = model.CenterWorkingHours;

                        dbContext.sparePartsCenters.Update(sparePartsCentersID);
                        dbContext.SaveChanges();
                    }
                }
                else
                {

                    return RedirectToAction("ScreenSparePartsCenters", new { Error = "يوجد خطاء ويمكن ان هنا خطاء في تسجيل البيانات غير مكتملة" });



                }
            }
            return RedirectToAction("ScreenSparePartsCenters");
        }
        public async Task<IActionResult> DeleteparePartsCenters(int id)
        {
            SparePartsCenters? sparePartsCenters = await dbContext.sparePartsCenters.Where(d => d.Id == id).FirstOrDefaultAsync();

            if (sparePartsCenters != null)
            {
                dbContext.Remove(sparePartsCenters);
                dbContext.SaveChanges();
            }
            return RedirectToAction("ScreenSparePartsCenters");

        }
    }
}
