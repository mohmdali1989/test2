using Accountant.Data;
using Accountant.Models;
using Accountant.Models.ViewModel.ReportscVM;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Accountant.Controllers.Reports
{
    public class ReportscCarController : Controller
    {
        private readonly DataContextDB dbContext;
        public ReportscCarController(DataContextDB dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task<IActionResult> ScreenReportscCar(int IDCar)
        {
            ReportscCarViewModel reportscCarVM = new ReportscCarViewModel();
            int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            List<Car> car = await dbContext.car.Where(W => W.CompanyId == ID).ToListAsync();
            var WorkDiary_List = await dbContext.workDiary.Where(c => c.CompanyId == ID).Select(c => c.CreatedDateOnly).ToListAsync(); // اختر الخاصية التي تحتوي على التاريخ
            int ID_Car = 0;
            reportscCarVM.Cars = car;
            if (IDCar > 0)
            {
                reportscCarVM.StatusButtonCar = IDCar;
                ID_Car = IDCar;
                reportscCarVM.IDCar = ID_Car;
            }
            else
            {
                Car? IDCar_M = await dbContext.car.Where(C => C.CompanyId == ID).OrderBy(c => c.Id).FirstOrDefaultAsync();
                if (IDCar_M != null)
                {
                    reportscCarVM.StatusButtonCar = IDCar_M.Id;
                    ID_Car = IDCar_M.Id;
                    reportscCarVM.IDCar = ID_Car;
                }
                 
            }
             


            //=================================================================
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //=================================================================
            
            //=================================================================
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //=================================================================
            //جلب بيانات  اليوميه للمركبة 

            List<WorkDiary> groupedWorkDiary = await dbContext.workDiary.Where(d => d.CompanyId == ID && d.CarId == ID_Car).Include(c => c.workCompanies).GroupBy(wd => new { wd.OperatorId, wd.CreatedDateOnly.Year, wd.CreatedDateOnly.Month }).Select(g => new WorkDiary
            {
                OperatorId = g.Key.OperatorId,
                Year = g.Select(d => d.CreatedDateOnly.Year).FirstOrDefault(),
                Month = g.Select(d => d.CreatedDateOnly.Month).FirstOrDefault(),
                TransportationPrice = g.Sum(wd => wd.TransportationPrice),
                workCompanies = g.Select(d => d.workCompanies).FirstOrDefault()

            }).OrderBy(o => o.OperatorId)
              .ThenByDescending(o => o.Year)
              .ThenByDescending(o => o.Month)
              .ToListAsync();
            //====  جمع النقود المشغلين

            List<WorkDiary> PluralPrice = await dbContext.workDiary.Where(d => d.CompanyId == ID && d.CarId == ID_Car).Include(c => c.workCompanies).
                GroupBy(W => new { W.CreatedDateOnly.Year, W.CreatedDateOnly.Month }).Select(G => new WorkDiary
                {
                    Year = G.Key.Year,
                    Month = G.Key.Month,

                    TransportationPrice = G.Sum(g => g.TransportationPrice),
                    workCompanies = G.Select(g => g.workCompanies).FirstOrDefault(),
                }).ToListAsync();
            reportscCarVM.WorkDiary = groupedWorkDiary;
            reportscCarVM.PluralPrice = PluralPrice;
            //=================================================================
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //=================================================================
            // جلب بيانات السولر

            List<Fuel> Fuel = dbContext.fuel.Where(d => d.CompanyId == ID && d.CarId == ID_Car).Include(i => i.Fuelprovider).GroupBy(G => new { G.FuelProviderID, G.SupplyDateOnly.Year, G.SupplyDateOnly.Month }).Select(S => new Fuel
            {

                Year = S.Key.Year,
                Month = S.Key.Month,
                FuelProviderID = S.Key.FuelProviderID,
                FuelQuantity = S.Sum(S => S.FuelQuantity),
                Fuelprovider = S.Select(s => s.Fuelprovider).FirstOrDefault(),

            }).ToList();

            //جمع مجموع الكميه السولر

            List<Fuel> PluralFuelQuantity = await dbContext.fuel.Where(f => f.CompanyId == ID && f.CarId == ID_Car).Include(i => i.Fuelprovider).GroupBy(g => new { g.SupplyDateOnly.Year, g.SupplyDateOnly.Month }).Select(s => new Fuel
            {
                Year = s.Key.Year,
                Month = s.Key.Month,

                FuelQuantity = s.Sum(s => s.FuelQuantity),
                Fuelprovider = s.Select(s => s.Fuelprovider).FirstOrDefault()
            }).ToListAsync();
            reportscCarVM.Fuel = Fuel;
            reportscCarVM.PluralFuelQuantity = PluralFuelQuantity;
            //=================================================================
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //=================================================================

             
            List<Expenses> expenses = await dbContext.expenses.Where(w => w.CompanyId == ID && w.CarId == ID_Car).Include(I => I.sparePartsCenters).GroupBy(G => new { G.PartsId, G.DateExchange.Year, G.DateExchange.Month }).Select(S => new Expenses
            {
                PartsId = S.Key.PartsId,
                Year = S.Key.Year,
                Month = S.Key.Month,
                TotalPrice = S.Sum(s => s.TotalPrice),
                Total = S.Sum(s => s.UnitPrice * s.NumberPieces),
                sparePartsCenters = S.Select(s => s.sparePartsCenters).FirstOrDefault()



            }).ToListAsync();
            reportscCarVM.Expenses = expenses;
            List<Expenses> PluralExpenses = expenses.GroupBy(G => new { G.Year, G.Month }).Select(S => new Expenses
            {
                Year = S.Key.Year,
                Month = S.Key.Month,

                Total = S.Sum(s => s.Total),

            }).ToList();
            reportscCarVM.PluralExpenses = PluralExpenses;
            //=================================================================
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //=================================================================

            List<Expenses> Expensess = await dbContext.expenses.Where(w => w.CompanyId == ID && w.CarId == ID_Car).Include(I => I.repairWorkshops).GroupBy(G => new { G.WorkshopsID, G.DateExchange.Year, G.DateExchange.Month }).Select(S => new Expenses
            {
                WorkshopsID = S.Key.WorkshopsID,
                Year = S.Key.Year,
                Month = S.Key.Month,

                MaintenancePrice = S.Sum(s => s.MaintenancePrice),
                repairWorkshops = S.Select(s => s.repairWorkshops).FirstOrDefault()



            }).ToListAsync();
            reportscCarVM.ExpensesWork = Expensess;
            List<Expenses> Pluralexpenses = Expensess.GroupBy(G => new { G.Year, G.Month }).Select(S => new Expenses
            {
                Year = S.Key.Year,
                Month = S.Key.Month,

                MaintenancePrice = S.Sum(s => s.MaintenancePrice),

            }).ToList();
            reportscCarVM.PluralExpensesWork = Pluralexpenses;
            //=================================================================
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //=================================================================

            List<TrafficViolations> trafficViolations = await dbContext.trafficViolations.Where(w => w.CompanyId == ID && w.CarId == ID_Car).Include(I => I.driver).GroupBy(G => new { G.IdDrivr, G.DateOfViolation.Year, G.DateOfViolation.Month }).Select(S => new TrafficViolations
            {
                IdDrivr = S.Key.IdDrivr,
                Year = S.Key.Year,
                Month = S.Key.Month,

                AmountViolated = S.Sum(s => s.AmountViolated),
                driver = S.Select(s => s.driver).FirstOrDefault()



            }).ToListAsync();
            reportscCarVM.trafficViolations = trafficViolations;
            List<TrafficViolations> PluraltrafficViolations = trafficViolations.GroupBy(G => new { G.Year, G.Month }).Select(S => new TrafficViolations
            {
                Year = S.Key.Year,
                Month = S.Key.Month,

                AmountViolated = S.Sum(s => s.AmountViolated),

            }).ToList();
            reportscCarVM.PluraltrafficViolations = PluraltrafficViolations;
            //=================================================================
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //=================================================================

            List<combinedList> combinedList = PluraltrafficViolations
            .Select(f => new { f.Year, f.Month, ToTal = f.AmountViolated, Type = "PluraltrafficViolationsSUM" })
            .Concat(Pluralexpenses.Select(e => new { e.Year, e.Month, ToTal = e.MaintenancePrice, Type = "ExpensesWrkSUM" }))
            .Concat(PluralExpenses.Select(t => new { t.Year, t.Month, ToTal = t.Total, Type = "ExpensesCentersSUM" }))
            .Concat(PluralFuelQuantity.Select(g => new { g.Year, g.Month, ToTal = g.FuelQuantity, Type = "PluralFuelQuantitySUM" }))
            .Concat(PluralPrice.Select(p => new {p.Year,p.Month , ToTal = p.TransportationPrice, Type= "PluralPriceSUM"}))
            .GroupBy(g => new { g.Year, g.Month })
             
            .Select(s => new combinedList
            {
                Year = s.Key.Year,
                Month = s.Key.Month,



                PluraltrafficViolations = s.Where(x => x.Type == "PluraltrafficViolationsSUM").Sum(x => x.ToTal),
                Pluralexpenses = s.Where(x => x.Type == "ExpensesWrkSUM").Sum(x => x.ToTal),
                PluralExpenses = s.Where(x => x.Type == "ExpensesCentersSUM").Sum(x => x.ToTal),
                PluralFuelQuantity = s.Where(x => x.Type == "PluralFuelQuantitySUM").Sum(x => x.ToTal),
                PluralPrice = s.Where(x => x.Type== "PluralPriceSUM").Sum(x=>x.ToTal),
                GrandTotal = s.Sum(x => x.ToTal)
            })
             .OrderBy(x => x.Year)
            .ThenBy(x => x.Month)
            .ToList();

            List<DateOnly> monthlyData = combinedList

                // استخرج السنة والشهر من كل عنصر في القائمة
                .Select(combinedList => new { Year = combinedList.Year, Month = combinedList.Month  })
                // قم بتجميع البيانات حسب السنة والشهر
                .GroupBy(data => new { data.Year, data.Month})
                // حدد فقط الأشهر الفريدة
                .Select(group =>  group.Key )

                .ToList()
                //1: يُستخدم هذا الرقم لإنشاء اليوم الأول من الشهر.
                .Select(data => new DateOnly(data.Year, data.Month, 1))
                .OrderBy(o => o.Year)
                .ThenBy (o => o.Month)
                .ToList();

            reportscCarVM.DateYearMonth = monthlyData;
            reportscCarVM.CombinedList = combinedList;
            return View(reportscCarVM);
        }
        public async Task<IActionResult> ScreenAllCar_W_F_E_T(int IDCar  ,int dateOnly_M , int dateOnly_Y)
        {
            int ID = int.TryParse(HttpContext.Session.GetString("IDCompany"), out int Id) ? Id : 0;
            ReportscCarViewModel reportscCarVM = new ReportscCarViewModel();

            List<WorkDiary> workDiaries = await dbContext.workDiary.Where(w=>w.CompanyId ==ID && w.CarId ==IDCar && w.CreatedDateOnly.Month == dateOnly_M && w.CreatedDateOnly.Year ==dateOnly_Y).Include(w=>w.workCompanies).ToListAsync();
            reportscCarVM.WorkDiary = workDiaries;
            List<Fuel> fuels = await dbContext.fuel.Where(w => w.CompanyId == ID && w.CarId == IDCar && w.SupplyDateOnly.Month == dateOnly_M && w.SupplyDateOnly.Year == dateOnly_Y).Include(i=>i.Fuelprovider).ToListAsync();
            reportscCarVM.Fuel = fuels;
            List<Expenses> expenses = await dbContext.expenses.Where(w => w.CompanyId == ID && w.CarId == IDCar && w.DateExchange.Month == dateOnly_M && w.DateExchange.Year == dateOnly_Y).Include(I=>I.repairWorkshops).Include(i=>i.sparePartsCenters).ToListAsync();
            reportscCarVM.Expenses = expenses;
            List<TrafficViolations> trafficViolations = await dbContext.trafficViolations.Where(w => w.CompanyId == ID && w.CarId == IDCar && w.DateOfViolation.Month == dateOnly_M && w.DateOfViolation.Year == dateOnly_Y).Include(i=>i.driver).ToListAsync();

            reportscCarVM.trafficViolations = trafficViolations;

            List<combinedList> combinedList = trafficViolations
            .Select(f => new { f.Year, f.Month, ToTal = f.AmountViolated, Type = "PluraltrafficViolationsSUM" })
            .Concat(expenses.Select(e => new { e.Year, e.Month, ToTal = e.MaintenancePrice + e.UnitPrice * e.NumberPieces, Type = "ExpensesSUM" }))
            .Concat(fuels.Select(g => new { g.Year, g.Month, ToTal = g.FuelQuantity, Type = "PluralFuelQuantitySUM" }))
            .Concat(workDiaries.Select(p => new { p.Year, p.Month, ToTal = p.TransportationPrice * p.NumberLoad, Type = "PluralPriceSUM" })) // تعديل هنا
            .GroupBy(g => new { g.Year, g.Month })
            .Select(s => new combinedList
            {
                Year = s.Key.Year,
                Month = s.Key.Month,
                PluraltrafficViolations = s.Where(x => x.Type == "PluraltrafficViolationsSUM").Sum(x => x.ToTal),
                Pluralexpenses = s.Where(x => x.Type == "ExpensesSUM").Sum(x => x.ToTal),
              
                PluralFuelQuantity = s.Where(x => x.Type == "PluralFuelQuantitySUM").Sum(x => x.ToTal),
                PluralPrice = s.Where(x => x.Type == "PluralPriceSUM").Sum(x => x.ToTal),
                GrandTotal = s.Sum(x => x.ToTal)
            })
            .OrderBy(x => x.Year)
            .ThenBy(x => x.Month)
            .ToList();

             reportscCarVM.CombinedList = combinedList;

            return View(reportscCarVM);
        }
    }
}
 