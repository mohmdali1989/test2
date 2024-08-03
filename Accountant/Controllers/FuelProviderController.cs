using Accountant.Data;
using Accountant.Models;
using Accountant.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Accountant.Controllers
{
    public class FuelProviderController : Controller
    {
        private readonly DataContextDB dbContext;

        public FuelProviderController(DataContextDB dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task <IActionResult> ScreenFuelProvider(int IDFuelProvider , bool EditFuelProvider)
        {
            int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            ViewModelFuelProvider viewModelFuelProvider = new ViewModelFuelProvider();

            List<FuelProvider> fuelProviders = await dbContext.fuelProvider.Where(f => f.CompanyId == ID).ToListAsync();
            if (EditFuelProvider == false)
            {
                viewModelFuelProvider.FuelProvider_List = fuelProviders;
            }
            else if(EditFuelProvider==true)
            {

                 FuelProvider? fuelProviders_M = await dbContext.fuelProvider.Where(f => f.CompanyId == ID && f.Id == IDFuelProvider).FirstOrDefaultAsync();
               if(fuelProviders_M != null)
                {
                    viewModelFuelProvider.FuelProvider_M = fuelProviders_M;
                    viewModelFuelProvider.FuelProvider_List = fuelProviders;

                }


            }
            return View(viewModelFuelProvider);
        }
        [HttpPost]
        public async Task<IActionResult> ScreenFuelProvider(ViewModelFuelProvider model)
        {
            int IDCompany = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            int IDMainUser = int.TryParse(HttpContext.Session.GetString("IDMainUser"), out int ID) ? ID : 0;
            int IDGeneralUser = int.TryParse(HttpContext.Session.GetString("IDGeneralUser"), out int id) ? id : 0;
            if(model.FuelProvider_M.Id == 0)
            {
                string NameFuelProvider = Regex.Replace(model.FuelProvider_M.NameFuelProvider.Trim(), @"\s+", " ");
                model.FuelProvider_M.NameFuelProvider = NameFuelProvider;
                string stationLocation = Regex.Replace(model.FuelProvider_M.stationLocation.Trim(), @"\s+", " ");
                model.FuelProvider_M.stationLocation = stationLocation;


                if (IDCompany > 0 && IDMainUser > 0)
                {
                    model.FuelProvider_M.IDMainUser = IDMainUser;
                    model.FuelProvider_M.CompanyId = IDCompany;
                    


                    dbContext.fuelProvider.Add(model.FuelProvider_M);
                    dbContext.SaveChanges();
                }
                else if (IDCompany > 0 && IDGeneralUser > 0)
                {
                    model.FuelProvider_M.IDGeneralUser = IDGeneralUser;
                    model.FuelProvider_M.CompanyId = IDCompany;
                    

                    dbContext.fuelProvider.Add(model.FuelProvider_M);
                    dbContext.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("Error", "يوجد خطاء ويمكن ان هنا خطاء في تسجيل البيانات غير مكتملة");
                    return View(model);
                }

            }
            else if(model.FuelProvider_M.Id >0)
            {

                if (IDCompany > 0)
                {
                    FuelProvider? FuelProviderID = await dbContext.fuelProvider.Where(d => d.Id == model.FuelProvider_M.Id).FirstOrDefaultAsync();
                    string NameFuelProvider = Regex.Replace(model.FuelProvider_M.NameFuelProvider.Trim(), @"\s+", " ");
                    model.FuelProvider_M.NameFuelProvider = NameFuelProvider;
                    string stationLocation = Regex.Replace(model.FuelProvider_M.stationLocation.Trim(), @"\s+", " ");
                    model.FuelProvider_M.stationLocation = stationLocation;



                    if (IDCompany > 0 && IDMainUser > 0)
                    {
                        model.FuelProvider_M.IDMainUser = IDMainUser;
                        model.FuelProvider_M.CompanyId = IDCompany;


                        if (FuelProviderID != null)
                        {

                            FuelProviderID.NameFuelProvider = model.FuelProvider_M.NameFuelProvider;
                            FuelProviderID.stationLocation = model.FuelProvider_M.stationLocation;

                            

                            dbContext.fuelProvider.Update(FuelProviderID);
                            dbContext.SaveChanges();
                        }

                    }
                    else if (IDCompany > 0 && IDGeneralUser > 0)
                    {
                        model.FuelProvider_M.IDGeneralUser = IDGeneralUser;
                        model.FuelProvider_M.CompanyId = IDCompany;

                        if (FuelProviderID != null)
                        {

                            FuelProviderID.NameFuelProvider = model.FuelProvider_M.NameFuelProvider;
                            FuelProviderID.stationLocation = model.FuelProvider_M.stationLocation;
 

                            dbContext.fuelProvider.Update(FuelProviderID);
                            dbContext.SaveChanges();
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("Error", "يوجد خطاء ويمكن ان هنا خطاء في تسجيل البيانات غير مكتملة");
                        return View(model);
                    }


                }
            }



            return RedirectToAction("ScreenFuelProvider");






        }

        public async Task<IActionResult> DeleteFuelProvider(int id)
        {
            FuelProvider? fuelProviderID = await dbContext.fuelProvider.Where(d => d.Id == id).FirstOrDefaultAsync();

            if (fuelProviderID != null)
            {
                dbContext.Remove(fuelProviderID);
                dbContext.SaveChanges();
            }
            return RedirectToAction("ScreenFuelProvider");


        }
    }
}
