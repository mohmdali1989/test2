using Accountant.Data;
using Accountant.Models;
using Accountant.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Accountant.Controllers
{
    public class TrafficViolationsController : Controller
    {
        private readonly DataContextDB dbContext;
        public TrafficViolationsController(DataContextDB dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> ScreenTrafficViolations( int IDTrafficViolations , int IDCar ,string CarName, int IDDriver,bool AddToEdit)
        {
            int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            ViewModelTrafficViolations ViewModelTrafficViolations = new ViewModelTrafficViolations();
            List<Car> CarList = await dbContext.car.Where(C => C.CompanyId == ID).ToListAsync();
            List<Driver> DriverList = await dbContext.driver.Where(C => C.CompanyId ==ID).ToListAsync();
            
            ViewModelTrafficViolations.Car_List = CarList;
            ViewModelTrafficViolations.Driver_List = DriverList;

            if (AddToEdit ==false)
            {
                if (IDCar >0)
                {
                    List<TrafficViolations> trafficViolations = await dbContext.trafficViolations.Where(C => C.CompanyId == ID && C.CarId == IDCar).ToListAsync();
                    ViewModelTrafficViolations.TrafficViolations_List = trafficViolations;
                    
                    ViewModelTrafficViolations.StatusButtonCar = IDCar;
                    ViewModelTrafficViolations.CarName = CarName;



                }
                else
                {
                    TrafficViolations? trafficViolations_M = await dbContext.trafficViolations.Where(T => T.CompanyId == ID).OrderBy(t => t.Id).FirstOrDefaultAsync();
                     Car? ID_Car_M  = await dbContext.car.Where(C => C.CompanyId == ID).OrderBy(I =>I.Id).FirstOrDefaultAsync();
                    if (trafficViolations_M != null)
                    {
                        List<TrafficViolations> trafficViolations = await dbContext.trafficViolations.Where(C => C.CompanyId == ID && C.CarId == trafficViolations_M.CarId).ToListAsync();
                        ViewModelTrafficViolations.TrafficViolations_List = trafficViolations;
                        ViewModelTrafficViolations.StatusButtonCar = trafficViolations_M.CarId ?? 0;
                        ViewModelTrafficViolations.CarName = trafficViolations_M.car?.NameCar;
                    }
                    else if(ID_Car_M != null)
                    {
                        ViewModelTrafficViolations.StatusButtonCar = ID_Car_M?.Id ?? 0;
                    }
                    
                }


            }
            else if (AddToEdit == true)
            {
                TrafficViolations? trafficViolations_M = await dbContext.trafficViolations.Where(T => T.CompanyId == ID && T.Id == IDTrafficViolations).FirstOrDefaultAsync();
                if (trafficViolations_M !=null)
                {
                    ViewModelTrafficViolations.TrafficViolations_M = trafficViolations_M;
                    ViewModelTrafficViolations.StatusButtonCar = IDCar;
                }
                
            }
            return View(ViewModelTrafficViolations);
        }
        [HttpPost]
        public async Task<IActionResult> ScreenTrafficViolations(ViewModelTrafficViolations model)
        {
            int IDCompany = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            int IDMainUser = int.TryParse(HttpContext.Session.GetString("IDMainUser"), out int ID) ? ID : 0;
            int IDGeneralUser = int.TryParse(HttpContext.Session.GetString("IDGeneralUser"), out int id) ? id : 0;
            string PushStatusDescription = Regex.Replace(model.TrafficViolations_M.LocationOfViolation.Trim(), @"\s+", " ");

            string reasonForViolation = Regex.Replace(model.TrafficViolations_M.reasonForViolation.Trim(), @"\s+", " ");


            model.TrafficViolations_M.LocationOfViolation = PushStatusDescription;
            model.TrafficViolations_M.reasonForViolation = reasonForViolation;
            if (model.TrafficViolations_M.Id ==0)
            {
                if (IDCompany > 0 && IDMainUser > 0)
                {
                    model.TrafficViolations_M.IDMainUser = IDMainUser;
                    model.TrafficViolations_M.CompanyId = IDCompany;
                     

                    dbContext.trafficViolations.Add(model.TrafficViolations_M);
                    dbContext.SaveChanges();
                }
                else if (IDCompany > 0 && IDGeneralUser > 0)
                {
                    model.TrafficViolations_M.IDGeneralUser = IDGeneralUser;
                    model.TrafficViolations_M.CompanyId = IDCompany;
                     
                    dbContext.trafficViolations.Add(model.TrafficViolations_M);
                    dbContext.SaveChanges();
                }
            }
            else if (model.TrafficViolations_M.Id > 0)
            {
                TrafficViolations? trafficViolations_M = await dbContext.trafficViolations.Where(T => T.CompanyId == ID && T.Id == model.TrafficViolations_M.Id).FirstOrDefaultAsync();
                if(trafficViolations_M != null)
                {
                    trafficViolations_M.LocationOfViolation = model.TrafficViolations_M.LocationOfViolation;
                    trafficViolations_M.DateOfViolation = model.TrafficViolations_M.DateOfViolation;
                    trafficViolations_M.TiemOfViolation = model.TrafficViolations_M.TiemOfViolation;
                    trafficViolations_M.reasonForViolation = model.TrafficViolations_M.reasonForViolation;
                    trafficViolations_M.PushStatus = model.TrafficViolations_M.PushStatus;
                    trafficViolations_M.AmountViolated = model.TrafficViolations_M.AmountViolated;
                    trafficViolations_M.dateLastTimePayFine = model.TrafficViolations_M.dateLastTimePayFine;
                    dbContext.Update(trafficViolations_M);
                    dbContext.SaveChanges();
                     
                }

            }

            return RedirectToAction("ScreenTrafficViolations", new { IDCar = model.TrafficViolations_M.CarId });

        }
        public async Task<IActionResult> DeleteTrafficViolations(int ID)
        {
            TrafficViolations? TrafficViolations = await dbContext.trafficViolations.Where(d => d.Id == ID).FirstOrDefaultAsync();
            if (TrafficViolations != null)
            {
                dbContext.Remove(TrafficViolations);
                dbContext.SaveChanges();

            }
            return RedirectToAction("ScreenTrafficViolations", new { IDCar = TrafficViolations?.CarId });

        }
    }
}
