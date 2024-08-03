using Accountant.Data;
using Accountant.Models;
using Accountant.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Accountant.Controllers
{

    public class MonthlyController : Controller
    {
        private readonly DataContextDB dbContext;

        public MonthlyController(DataContextDB dbContext)

        {
            this.dbContext = dbContext;

        }

        public IActionResult ScreenCalendarMonthly(int ID_Dreivr)
        {
            int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            MonthlyViewModel monthlyViewModel = new MonthlyViewModel();
            List<Driver> drivers = dbContext.driver.Where(d =>d.CompanyId == ID).ToList();
            Driver? driver = dbContext.driver.Where(w => w.CompanyId == ID && w.Id == 1).FirstOrDefault();

             

            if(ID_Dreivr > 0)
            {
                List<DriversDiary> driversDiary = dbContext.driversDiary.Where(d => d.CompanyId == ID && d.DriverId == ID_Dreivr).GroupBy(g => g.CreatedDate.Month).Select(S => S.First()).ToList();
                List<Monthly> monthlies = dbContext.monthly.Where(d => d.CompanyId == ID && d.IDDriver == ID_Dreivr).ToList();

                monthlyViewModel.Drivers_L = drivers;
                monthlyViewModel.StatusButtonDrivers = driver?.Id;
                monthlyViewModel.driversDiary_L = driversDiary;
                monthlyViewModel.Monthly_L = monthlies;
            }
            else
            {
                Monthly? monthlies = dbContext.monthly.Where(d => d.CompanyId == ID).OrderByDescending(O => O.id).FirstOrDefault();

                if (monthlies != null)
                {
                    List<DriversDiary> driversDiary2 = dbContext.driversDiary.Where(d => d.CompanyId == ID && d.DriverId == monthlies.IDDriver).GroupBy(g => g.CreatedDate.Month).Select(S => S.First()).ToList();
                    List<Monthly> monthlies2 = dbContext.monthly.Where(d => d.CompanyId == ID && d.IDDriver == monthlies.IDDriver).ToList();

                    monthlyViewModel.Drivers_L = drivers;
                    monthlyViewModel.StatusButtonDrivers = driver?.Id;
                    monthlyViewModel.driversDiary_L = driversDiary2;
                    monthlyViewModel.Monthly_L = monthlies2;
                }
                else
                {
                    Driver? driverID = dbContext.driver.Where(d => d.CompanyId == ID).OrderBy(O => O.Id).FirstOrDefault();
                    if(driverID!= null)
                    {
                        List<DriversDiary> driversDiary2 = dbContext.driversDiary.Where(d => d.CompanyId == ID && d.DriverId == driverID.Id).GroupBy(g => g.CreatedDate.Month).Select(S => S.First()).ToList();
                        List<Monthly> monthlies2 = dbContext.monthly.Where(d => d.CompanyId == ID && d.IDDriver == driverID.Id).ToList();

                        monthlyViewModel.Drivers_L = drivers;
                        monthlyViewModel.StatusButtonDrivers = driver?.Id;
                        monthlyViewModel.driversDiary_L = driversDiary2;
                        monthlyViewModel.Monthly_L = monthlies2;
                    }
                    
                }

            }



            return View(monthlyViewModel);
        }
        public async Task< IActionResult> ScreenMonthly(int ID_Driver , int Data_Year ,int Data_Month ,bool Edit_Month,int ID_Minth ,string Error)
        {
            int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            MonthlyViewModel monthlyViewModel = new MonthlyViewModel();
            List<Briefs> briefs = dbContext.briefs.Where(b => b.CompanyId == ID && b.IDDriver == ID_Driver && b.VacationDate.Year == Data_Year && b.VacationDate.Month == Data_Month && b.PushStatus ==true).GroupBy(d => d.VacationDate.Date).Select(S => S.First()).ToList();
            List<Briefs> briefsPushStatus = dbContext.briefs.Where(b => b.CompanyId == ID && b.IDDriver == ID_Driver && b.VacationDate.Year == Data_Year && b.VacationDate.Month == Data_Month && b.PushStatus == false).GroupBy(d => d.VacationDate.Date).Select(S => S.First()).ToList();
            Driver? driver =await dbContext.driver.Where(w =>w.CompanyId == ID && w.Id ==ID_Driver).FirstOrDefaultAsync();
            //هذا يعني عند دمج ان ناخذ القيمه الاوله وندمج الباقي  First ان نجلب البيانات وان نحتارGroupBy يجب بعد وضع 

            List<DriversDiary> driversDiary = dbContext.driversDiary.Where(b => b.CompanyId == ID && b.DriverId == ID_Driver && b.CreatedDate.Year == Data_Year && b.CreatedDate.Month == Data_Month).GroupBy(G=>G.CreatedDate).Select(S=>S.First()).ToList();
            Monthly? monthly = dbContext.monthly.Where(d => d.CompanyId == ID && d.id == ID_Minth).FirstOrDefault();


            if (Edit_Month == true)
            {

                monthlyViewModel.Briefs_L = briefs;
                monthlyViewModel.briefsPushStatus_L = briefsPushStatus;
                if(driver?.monthlyTypeId == 2)
                {
                    monthlyViewModel.MonthlyAmount = (int?)(driver?.Amount) * driversDiary.Count();
                    monthlyViewModel.AfterDiscount = (int?)(driver?.Amount) * driversDiary.Count();
                }
                else
                {

                    monthlyViewModel.MonthlyAmount = (int?)(driver?.Amount);
                    int? AmountANDWorkingDays = ((int?)(driver?.Amount) / driver?.NumberWorkingDays) * (briefsPushStatus.Count()); ;
                    monthlyViewModel.AfterDiscount = ((int?)(driver?.Amount) - AmountANDWorkingDays);
                }

                monthlyViewModel.NumberWorkingDays = driver?.NumberWorkingDays;
                monthlyViewModel.driversDiary_L = driversDiary;
                monthlyViewModel.Edit_Month = Edit_Month;
                monthlyViewModel.ID_Driver = ID_Driver;
                monthlyViewModel.Month_Y = String.Format("{0:00}", Data_Year);
                monthlyViewModel.Month_M = String.Format("{0:00}", Data_Month);
                monthlyViewModel.Month_D = DateTime.Now.ToString("dd");
                monthlyViewModel.Error = Error;
                monthlyViewModel.ID_Monthly = ID_Minth;
                monthlyViewModel.CountBriefs = briefsPushStatus.Count();
                monthlyViewModel.monthlyTypeId = driver?.monthlyTypeId;

                if (monthly != null)
                {
                    monthlyViewModel.Monthly_M = monthly;
                }
            }
            else if (Edit_Month == false)
            {
                monthlyViewModel.Briefs_L = briefs;
                monthlyViewModel.briefsPushStatus_L = briefsPushStatus;
                if (driver?.monthlyTypeId == 2)
                {
                    monthlyViewModel.MonthlyAmount = (int?)(driver?.Amount) * driversDiary.Count();
                    monthlyViewModel.AfterDiscount = (int?)(driver?.Amount) * driversDiary.Count();
                }
                else
                {

                    monthlyViewModel.MonthlyAmount = (int?)(driver?.Amount);
                    int? AmountANDWorkingDays = ((int?)(driver?.Amount) / driver?.NumberWorkingDays) * (briefsPushStatus.Count());;
                    monthlyViewModel.AfterDiscount = ((int?)(driver?.Amount) - AmountANDWorkingDays);

                }
                monthlyViewModel.NumberWorkingDays = driver?.NumberWorkingDays;
                monthlyViewModel.driversDiary_L = driversDiary;
                monthlyViewModel.Edit_Month = Edit_Month;
                monthlyViewModel.ID_Driver = ID_Driver;
                monthlyViewModel.Month_Y = String.Format("{0:00}", Data_Year);
                monthlyViewModel.Month_M = String.Format("{0:00}", Data_Month);
                monthlyViewModel.Month_D = DateTime.Now.ToString("dd");
                monthlyViewModel.ID_Monthly = ID_Minth;
                monthlyViewModel.CountBriefs = briefsPushStatus.Count();
                monthlyViewModel.monthlyTypeId = driver?.monthlyTypeId;


            }

            return View(monthlyViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ScreenMonthly(MonthlyViewModel model)
        {
            int IDCompany = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Idd) ? Idd : 0;
            int IDMainUser = int.TryParse(HttpContext.Session.GetString("IDMainUser"), out int IDD) ? IDD : 0;
            int IDGeneralUser = int.TryParse(HttpContext.Session.GetString("IDGeneralUser"), out int id) ? id : 0;

            Monthly? monthly = await dbContext.monthly.Where(M=>M.CompanyId == IDCompany && M.id == model.Monthly_M.id).FirstOrDefaultAsync();
            Driver? driver = await dbContext.driver.Where(D=>D.CompanyId == IDCompany && D.Id == model.ID_Driver).FirstOrDefaultAsync();

            if (model.Monthly_M.TransferAmount + model.Monthly_M.HandDeliveryAmount == model.AfterDiscount)
            {
                if (model.Monthly_M.id == 0)
                {
                    if (IDCompany > 0 && IDMainUser > 0)
                    {
                        if (driver != null)
                        {
                            model.Monthly_M.IDMainUser = IDMainUser;
                            model.Monthly_M.CompanyId = IDCompany;
                            model.Monthly_M.IDDriver = model.ID_Driver;
                            model.Monthly_M.DriverName = driver.Name;
                            model.Monthly_M.monthlyTypeId = driver.monthlyTypeId;

                            dbContext.Add(model.Monthly_M);
                            dbContext.SaveChanges();
                        }
                    }
                    else if (IDCompany > 0 && IDGeneralUser > 0)
                    {
                        if (driver != null)
                        {
                            model.Monthly_M.IDGeneralUser = IDGeneralUser;
                            model.Monthly_M.CompanyId = IDCompany;
                            model.Monthly_M.IDDriver = model.ID_Driver;
                            model.Monthly_M.DriverName = driver.Name;
                            model.Monthly_M.monthlyTypeId = driver.monthlyTypeId;

                            dbContext.Add(model.Monthly_M);
                            dbContext.SaveChanges();
                        }
                       
                    }
                }
                else if (model.Monthly_M.id > 0)
                {
                    if (monthly != null)
                    {
                        monthly.TransferAmount = model.Monthly_M.TransferAmount;
                        monthly.HandDeliveryAmount = model.Monthly_M.HandDeliveryAmount;

                        monthly.MonthlyReceiptDate = model.Monthly_M.MonthlyReceiptDate;
                        dbContext.Update(monthly);
                        dbContext.SaveChanges();
                    }


                }
                return RedirectToAction("ScreenCalendarMonthly", new { ID_Dreivr = model.ID_Driver });
            }
            else
            {
                int? Month_Y = int.TryParse(model.Month_Y,out int iid) ? iid :0;
                int? Month_M = int.TryParse(model.Month_M, out int Iid) ? Iid : 0;
                List<Briefs> briefs = dbContext.briefs.Where(b => b.CompanyId == IDCompany && b.IDDriver == model.ID_Driver && b.VacationDate.Year == Month_Y && b.VacationDate.Month == Month_M && b.PushStatus == true).GroupBy(d => d.VacationDate.Date).Select(S => S.First()).ToList();
                List<Briefs> briefsPushStatus = dbContext.briefs.Where(b => b.CompanyId == IDCompany && b.IDDriver == model.ID_Driver && b.VacationDate.Year == Month_Y && b.VacationDate.Month == Month_M && b.PushStatus == false).GroupBy(d => d.VacationDate.Date).Select(S => S.First()).ToList();

                //هذا يعني عند دمج ان ناخذ القيمه الاوله وندمج الباقي  First ان نجلب البيانات وان نحتارGroupBy يجب بعد وضع

                List<DriversDiary> driversDiary = dbContext.driversDiary.Where(b => b.CompanyId == IDCompany && b.DriverId == model.ID_Driver && b.CreatedDate.Year == Month_Y && b.CreatedDate.Month == Month_M).GroupBy(G => G.CreatedDate).Select(S => S.First()).ToList();

                model.Briefs_L = briefs;
                model.briefsPushStatus_L = briefsPushStatus;
                model.MonthlyAmount = (int?)(driver?.Amount);
                model.NumberWorkingDays = driver?.NumberWorkingDays;
                model.driversDiary_L = driversDiary;
                model.Edit_Month = model.Edit_Month;
                model.ID_Driver = model.ID_Driver;
                model.Month_Y = String.Format("{0:00}", Month_Y);
                model.Month_M = String.Format("{0:00}", Month_M);
                model.Month_D = DateTime.Now.ToString("dd");
                model.Error = "يجب ان يكون المبلغين مساويين مبلغ الشهرية";
                model.ID_Monthly = monthly?.id;
                if (driver?.monthlyTypeId == 2)
                {
                    model.MonthlyAmount = (int?)(driver?.Amount) * driversDiary.Count();
                    model.AfterDiscount = (int?)(driver?.Amount) * driversDiary.Count();
                }
                else
                {

                    model.MonthlyAmount = (int?)(driver?.Amount);
                    int? AmountANDWorkingDays = ((int?)(driver?.Amount) / driver?.NumberWorkingDays) * (briefsPushStatus.Count()); ;
                    model.AfterDiscount = ((int?)(driver?.Amount) - AmountANDWorkingDays);

                }
                if (monthly != null)
                {
                    model.Monthly_M = monthly;
                }
                model.Month_Y = model.Month_Y;
                return View(model);
            }
           
        }
        public IActionResult DeleteMonthly( int IDMonthly)
        {
            int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            Monthly? monthly = dbContext.monthly.Where(M=>M.CompanyId == ID && M.id == IDMonthly).FirstOrDefault();
            if (monthly != null) 
            {
             dbContext.Remove(monthly);
            dbContext.SaveChanges();
            }
           
            return RedirectToAction("ScreenCalendarMonthly", new { ID_Dreivr = monthly?.IDDriver });

        }
    }
}
