using Accountant.Data;
using Accountant.Models;
using Accountant.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Accountant.Controllers
{
    public class FuelController : Controller
    {
        private readonly DataContextDB dbContext;

        public FuelController(DataContextDB dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> ScreenFuel(int Fuel_Id ,int Car_ID, bool Fuel_Edit ,string Error )
        {
            int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            FuelViewModel fuelViewModel = new FuelViewModel();
            List<Car> car = await dbContext.car.Where(C => C.CompanyId == ID).ToListAsync();
            List<FuelProvider> fuelProviders = await dbContext.fuelProvider.Where(F => F.CompanyId == ID).ToListAsync();
            fuelViewModel.fuel_M.Error = Error;
            if (Fuel_Edit ==false)
            {
                     
                    
                    
                    fuelViewModel.DataCar_List = car;
                    fuelViewModel.FuelEdit = Fuel_Edit;
                    fuelViewModel.fuelProviders_List = fuelProviders;

                if (Car_ID >0)
                {
                   
                   
                    List<Fuel> Fuel = await dbContext.fuel.Where(C => C.CompanyId == ID && C.CarId == Car_ID).ToListAsync();
                    List<WorkDiary> workDiaries =await dbContext.workDiary.Where(w=>w.CompanyId == ID && w.CarId == Car_ID).ToListAsync();
                    Car? Car = await dbContext.car.Where(C => C.CompanyId == ID && C.Id == Car_ID).FirstOrDefaultAsync();

                    fuelViewModel.DataFuel_List = Fuel;
                    fuelViewModel.NameCar = Car?.NameCar;
                    fuelViewModel.StatusButtonCar = Car?.Id;
                    fuelViewModel.workDiaries_List = workDiaries;


                }
                else if(Car_ID ==0)
                {

                    Fuel? OrderByFuel = await dbContext.fuel.Where(C => C.CompanyId == ID).OrderByDescending(C => C.id).FirstOrDefaultAsync();
                    Car? CarOrderBy = await dbContext.car.Where(C => C.CompanyId == ID).OrderBy(C => C.Id).FirstOrDefaultAsync();

                    if ( OrderByFuel != null)
                    {
                        int IDCar = (int)(OrderByFuel.CarId != null ? OrderByFuel.CarId : CarOrderBy?.Id);
                        Car ? Car = await dbContext.car.Where(C => C.CompanyId == ID && C.Id == IDCar).FirstOrDefaultAsync();
                        List<Fuel> Fuel = await dbContext.fuel.Where(C => C.CompanyId == ID && C.CarId == IDCar).ToListAsync();
                        List<WorkDiary> workDiaries = await dbContext.workDiary.Where(w => w.CompanyId == ID && w.CarId == IDCar).ToListAsync();


                        fuelViewModel.DataFuel_List = Fuel;
                        fuelViewModel.NameCar = Car?.NameCar;
                        fuelViewModel.StatusButtonCar = Car?.Id;
                        fuelViewModel.workDiaries_List = workDiaries;
                    } 
                    else
                    {
                        Car? Car = await dbContext.car.Where(C => C.CompanyId == ID ).OrderBy(C=>C.Id).FirstOrDefaultAsync();
                        
                        if ( Car != null )
                        {
                            
                            fuelViewModel.NameCar = Car?.NameCar;
                            fuelViewModel.StatusButtonCar = Car?.Id;

                        }
                    }

                }
               
               
                 
            } 
             
            else if (Fuel_Edit==true)
            {
                Fuel? Fuel = await dbContext.fuel.Where(C => C.CompanyId == ID && C.id == Fuel_Id).FirstOrDefaultAsync();

                if ( Fuel != null )
                {
                    fuelViewModel.fuel_M = Fuel;
                    List<WorkDiary> workDiaries = await dbContext.workDiary.Where(w => w.CompanyId == ID && w.CarId == Fuel.CarId).ToListAsync();

                    fuelViewModel.workDiaries_List = workDiaries;
                }
                List<Fuel> FuelEdit = await dbContext.fuel.Where(C => C.CompanyId == ID && C.CarId == Car_ID).ToListAsync();
                 
                Car? Car = await dbContext.car.Where(C => C.CompanyId == ID && C.Id == Car_ID).FirstOrDefaultAsync();
                fuelViewModel.DataCar_List = car;
                fuelViewModel.FuelEdit = Fuel_Edit;
                fuelViewModel.fuelProviders_List = fuelProviders;
                
                fuelViewModel.DataFuel_List = FuelEdit;
                fuelViewModel.NameCar = Car?.NameCar;
                fuelViewModel.StatusButtonCar = Car?.Id;
            }
            return View(fuelViewModel);





        }
        [HttpPost]
        public async Task<IActionResult> ScreenFuel(FuelViewModel model)
        {
            int IDCompany = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            int IDMainUser = int.TryParse(HttpContext.Session.GetString("IDMainUser"), out int ID) ? ID : 0;
            int IDGeneralUser = int.TryParse(HttpContext.Session.GetString("IDGeneralUser"), out int id) ? id : 0;
            WorkDiary? workDiary = await dbContext.workDiary.Where(w=>w.CompanyId ==IDCompany && w.Id ==model.fuel_M.workDiaryID).FirstOrDefaultAsync();
             
            
             
                
            if(workDiary != null)
            {
                if (model.fuel_M.id == 0)
                {
                    if (IDCompany > 0)
                    {

                        string FuelType = Regex.Replace(model.fuel_M.FuelType.Trim(), @"\s+", " ");
                        model.fuel_M.FuelType = FuelType;




                        if (IDCompany > 0 && IDMainUser > 0)
                        {
                            model.fuel_M.IDMainUser = IDMainUser;
                            model.fuel_M.CompanyId = IDCompany;
                            model.fuel_M.SupplyDateOnly = workDiary.CreatedDateOnly;
                            model.fuel_M.SupplyTimeOnly = TimeOnly.FromDateTime(DateTime.Now);
                            model.fuel_M.FuelProviderID = model.fuel_M.FuelProviderID;



                            dbContext.fuel.Add(model.fuel_M);
                            dbContext.SaveChanges();
                        }
                        else if (IDCompany > 0 && IDGeneralUser > 0)
                        {
                            model.fuel_M.IDGeneralUser = IDGeneralUser;
                            model.fuel_M.CompanyId = IDCompany;
                            model.fuel_M.SupplyDateOnly = workDiary.CreatedDateOnly;
                            model.fuel_M.SupplyTimeOnly = TimeOnly.FromDateTime(DateTime.Now);
                           


                            dbContext.fuel.Add(model.fuel_M);
                            dbContext.SaveChanges();
                        }
                        else
                        {
                            ModelState.AddModelError("Error", "يوجد خطاء ويمكن ان هنا خطاء في تسجيل البيانات غير مكتملة");
                            return View(model);
                        }


                    }


                }
                else if (model.fuel_M.id != 0)
                {
                    if (IDCompany > 0)
                    {
                        Fuel? FuelID = await dbContext.fuel.Where(d => d.id == model.fuel_M.id).FirstOrDefaultAsync();
                        string FuelType = Regex.Replace(model.fuel_M.FuelType.Trim(), @"\s+", " ");
                        model.fuel_M.FuelType = FuelType;




                        if (IDCompany > 0 && IDMainUser > 0)
                        {
                            model.fuel_M.IDMainUser = IDMainUser;
                            model.fuel_M.CompanyId = IDCompany;


                            if (FuelID != null)
                            {

                                 
                                FuelID.FuelQuantity = model.fuel_M.FuelQuantity;
                                FuelID.workDiaryID = model.fuel_M.workDiaryID;
                                FuelID.SupplyDateOnly = workDiary.CreatedDateOnly;
                                FuelID.SupplyTimeOnly = TimeOnly.FromDateTime(DateTime.Now);
                                FuelID.FuelProviderID = model.fuel_M.FuelProviderID;

                                


                                dbContext.fuel.Update(FuelID);
                                dbContext.SaveChanges();
                            }

                        }
                        else if (IDCompany > 0 && IDGeneralUser > 0)
                        {
                            model.fuel_M.IDGeneralUser = IDGeneralUser;
                            model.fuel_M.CompanyId = IDCompany;

                            if (FuelID != null)
                            {

                                 
                                FuelID.FuelQuantity = model.fuel_M.FuelQuantity;
                                FuelID.workDiaryID = model.fuel_M.workDiaryID;
                                FuelID.SupplyDateOnly = workDiary.CreatedDateOnly;
                                FuelID.SupplyTimeOnly = TimeOnly.FromDateTime(DateTime.Now);
                                FuelID.FuelProviderID = model.fuel_M.FuelProviderID;
 


                                dbContext.fuel.Update(FuelID);
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

            }
            else
            {
                return RedirectToAction("ScreenFuel", new { Car_ID = model.fuel_M.CarId ,Error = "يوجد مشكلة يمكن ان يكون التاريخ غير متوافق مع التاريخ عمل اليوميات للمركبه"});
            }








            return RedirectToAction("ScreenFuel", new { Car_ID = model.fuel_M.CarId});







             

            

        }
        public async Task<IActionResult> DeleteFuel(int id)
        {
            Fuel? fuelID = await dbContext.fuel.Where(d => d.id == id).FirstOrDefaultAsync();

            if (fuelID != null)
            {
                dbContext.Remove(fuelID);
                dbContext.SaveChanges();
            }
            return RedirectToAction("ScreenFuel", new { Fuel_Id = HttpContext.Session.GetInt32("Car_Id") });


        }
    }
}
