using Accountant.Data;
using Accountant.Models;
using Accountant.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
 
namespace Accountant.Controllers
{
    public class GeneralUserController : Controller
    {
        private readonly DataContextDB dbContext;

        public GeneralUserController(DataContextDB dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult ScreenAddGeneralUser()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> ScreenAddGeneralUser(GeneralUser model)
        {
            MainUserTem? mainUserTem = await dbContext.mainUserTem.Where(M => M.Name == model.Name).FirstOrDefaultAsync();
            MainUser? mainUser = await dbContext.mainUser.Where(M => M.Name == model.Name).FirstOrDefaultAsync();
            ProgramUser? programUser = await dbContext.programUser.Where(P => P.Name == model.Name).FirstOrDefaultAsync();
            GeneralUser? generalUser = await dbContext.generalUser.Where(G => G.Name == model.Name).FirstOrDefaultAsync();
            
            if (ModelState.IsValid) 
            {
                if (mainUserTem != null) 
                {
                    ModelState.AddModelError("Name", "هذا الاسم او الباسورد موجود بلفعل");
                }
                else if (mainUser != null)
                {
                    ModelState.AddModelError("Name", "هذا الاسم او الباسورد موجود بلفعل");
                }
                
                else if (programUser != null)
                {
                    ModelState.AddModelError("Name", "هذا الاسم او الباسورد موجود بلفعل");
                }
                else if (generalUser != null)
                {
                    ModelState.AddModelError("Name", "هذا الاسم او الباسورد موجود بلفعل");
                }
                else
                {
                    

                    model.CreatedDate = DateTime.Now;
                    model.IDMainUser =int.Parse(HttpContext.Session.GetString("IDMainUser")!);
                    model.CompanyId = int.Parse(HttpContext.Session.GetString("IDCompany")!);  
                    model.Confirmed = true;
                    dbContext.Add(model);
                    dbContext.SaveChanges();
                    GeneralUser? IDgeneralUser = await dbContext.generalUser.Where(G => G.Name == model.Name).FirstOrDefaultAsync();
                    PagesPermissions pagesPermissions = new PagesPermissions();//الصفحات
                    if (IDgeneralUser != null) { 
                     
                    pagesPermissions.Briefs = model.Briefs;
                    pagesPermissions.Car = model.Car;
                    pagesPermissions.Company = model.Companys;
                    pagesPermissions.CompanyDebts = model.CompanyDebts;
                    pagesPermissions.CompanyObligations = model.CompanyObligations;
                    pagesPermissions.Contracts = model.Contracts;
                    pagesPermissions.CustomerDebts = model.CustomerDebts;
                    pagesPermissions.Expenses = model.Expenses;
                    pagesPermissions.Fuel = model.Fuel;
                    pagesPermissions.GeneralUser = false;
                    pagesPermissions.InsuranceCar = model.CarInsurance;
                    pagesPermissions.LicenseCar = model.CarLicense;
                    pagesPermissions.MainUser = false;
                    pagesPermissions.MainUserTem = false;
                    pagesPermissions.Memo = model.Memo;
                    pagesPermissions.Monthly = model.Monthly;
                    pagesPermissions.Payments = model.Payments;
                    pagesPermissions.ProgramUser = false;
                    pagesPermissions.RepairWorkshops = model.RepairWorkshops;
                    pagesPermissions.SparePartsCenters = model.SparePartsCenters;
                    pagesPermissions.WorkCompanies = model.WorkCompanies;
                    pagesPermissions.WorkDiary = model.WorkDiary;
                    pagesPermissions.DriversDiary = model.DriversDiary;
                    pagesPermissions.FuelProvider = model.FuelProvider;
                    pagesPermissions.InputCompany = model.InputCompany;
                    pagesPermissions.TrafficViolations = model.TrafficViolations;
                    pagesPermissions.ReportscCar = model.ReportscCar;
                    pagesPermissions.IDUser = IDgeneralUser.ID;
                    }
                    PermissionsDriversDiary permissionsDriversDiary = new PermissionsDriversDiary();// الايجازات
                    permissionsDriversDiary.Add = model.DriversDiaryAdd;
                    permissionsDriversDiary.Edit = model.DriversDiaryEdit;
                    permissionsDriversDiary.Delete = model.DriversDiaryDelete;
                    permissionsDriversDiary.IDUser = IDgeneralUser!.ID;
                    PermissionsFuelProvider permissionsFuelProvider = new PermissionsFuelProvider();// الايجازات
                    permissionsFuelProvider.Add = model.FuelProviderAdd;
                    permissionsFuelProvider.Edit = model.FuelProviderEdit;
                    permissionsFuelProvider.Delete = model.FuelProviderDelete;
                    permissionsFuelProvider.IDUser = IDgeneralUser!.ID;
                    PermissionsInputCompany permissionsInputCompany = new PermissionsInputCompany();// الايجازات
                    permissionsInputCompany.Add = model.InputCompanyAdd;
                    permissionsInputCompany.Edit = model.InputCompanyEdit;
                    permissionsInputCompany.Delete = model.InputCompanyDelete;
                    permissionsInputCompany.IDUser = IDgeneralUser!.ID;
                    PermissionsTrafficViolations permissionsTrafficViolations = new PermissionsTrafficViolations();// الايجازات
                    permissionsTrafficViolations.Add = model.TrafficViolationsAdd;
                    permissionsTrafficViolations.Edit = model.TrafficViolationsEdit;
                    permissionsTrafficViolations.Delete = model.TrafficViolationsDelete;
                    permissionsTrafficViolations.IDUser = IDgeneralUser!.ID;
                    PermissionsReportscCar permissionsReportscCar = new PermissionsReportscCar();// الايجازات
                    permissionsReportscCar.Add = model.ReportscCarAdd;
                    permissionsReportscCar.Edit = model.ReportscCarEdit;
                    permissionsReportscCar.Delete = model.ReportscCarDelete;
                    permissionsReportscCar.IDUser = IDgeneralUser!.ID;



                    PermissionsBriefs permissionsBriefs = new PermissionsBriefs();// الايجازات
                    permissionsBriefs.Add = model.BriefsAdd;
                    permissionsBriefs.Edit = model.BriefsEdit;
                    permissionsBriefs.Delete = model.BriefsDelete;
                    permissionsBriefs.IDUser = IDgeneralUser!.ID;
                    PermissionsCar permissionsCar = new PermissionsCar();//السيارات
                    permissionsCar.Add = model.CarAdd;
                    permissionsCar.Edit = model.CarEdit;
                    permissionsCar.Delete = model.CarDelete;
                    permissionsCar.IDUser = IDgeneralUser!.ID;
                    PermissionsCompany permissionsCompany = new PermissionsCompany();// الشركة
                    permissionsCompany.Add = false;
                    permissionsCompany.Edit = false;
                    permissionsCompany.Delete = false;
                    permissionsCompany.IDUser = IDgeneralUser!.ID;
                    PermissionsCompanyDebts permissionsCompanyDebts = new PermissionsCompanyDebts();// ديون الشركة
                    permissionsCompanyDebts.Add = model.CompanyDebtsAdd;
                    permissionsCompanyDebts.Edit = model.CompanyDebtsEdit;
                    permissionsCompanyDebts.Delete = model.CompanyDebtsDelete;
                    permissionsCompanyDebts.IDUser = IDgeneralUser!.ID;
                    PermissionsCompanyObligations permissionsCompanyObligations = new PermissionsCompanyObligations();// التزامات الشركة
                    permissionsCompanyObligations.Add = model.CompanyObligationsAdd;
                    permissionsCompanyObligations.Edit = model.CompanyObligationsEdit;
                    permissionsCompanyObligations.Delete = model.CompanyObligationsDelete;
                    permissionsCompanyObligations.IDUser = IDgeneralUser!.ID;
                    PermissionsContracts permissionsContracts = new PermissionsContracts();// العقود
                    permissionsContracts.Add = model.ContractsAdd;
                    permissionsContracts.Edit = model.ContractsEdit;
                    permissionsContracts.Delete = model.ContractsDelete;
                    permissionsContracts.IDUser = IDgeneralUser!.ID;
                    PermissionsCustomerDebts permissionsCustomerDebts = new PermissionsCustomerDebts();// ديون الزبائن
                    permissionsCustomerDebts.Add = model.CustomerDebtsAdd;
                    permissionsCustomerDebts.Edit = model.CustomerDebtsEdit;
                    permissionsCustomerDebts.Delete = model.CustomerDebtsDelete;
                    permissionsCustomerDebts.IDUser = IDgeneralUser!.ID;
                    PermissionsDriver permissionsDriver = new PermissionsDriver();// السائقين
                    permissionsDriver.Add = model.DriverAdd;
                    permissionsDriver.Edit = model.DriverEdit;
                    permissionsDriver.Delete = model.DriverDelete;
                    permissionsDriver.IDUser = IDgeneralUser!.ID;
                    PermissionsExpenses permissionsExpenses = new PermissionsExpenses();// المصاريف
                    permissionsExpenses.Add = model.ExpensesAdd;
                    permissionsExpenses.Edit = model.ExpensesEdit;
                    permissionsExpenses.Delete = model.ExpensesDelete;
                    permissionsExpenses.IDUser = IDgeneralUser!.ID;
                    PermissionsFuel permissionsFuel = new PermissionsFuel();//الوقود
                    permissionsFuel.Add = model.FuelAdd;
                    permissionsFuel.Edit = model.FuelEdit;
                    permissionsFuel.Delete = model.FuelDelete;
                    permissionsFuel.IDUser = IDgeneralUser!.ID;
                    PermissionsGeneralUser permissionsGeneralUser = new PermissionsGeneralUser();// مستخدم عام
                    permissionsGeneralUser.Add = false;
                    permissionsGeneralUser.Edit = false;
                    permissionsGeneralUser.Delete = false;
                    permissionsGeneralUser.IDUser = IDgeneralUser!.ID;
                    PermissionsInsuranceCar permissionsInsuranceCar = new PermissionsInsuranceCar();// تامين السيارة
                    permissionsInsuranceCar.Add = model.CarLicenseAdd;
                    permissionsInsuranceCar.Edit = model.CarLicenseEdit;
                    permissionsInsuranceCar.Delete = model.CarLicenseDelete;
                    permissionsInsuranceCar.IDUser = IDgeneralUser!.ID;
                    PermissionsLicenseCar permissionsLicenseCar = new PermissionsLicenseCar();// ترخيص السيارة
                    permissionsLicenseCar.Add = model.CarLicenseAdd;
                    permissionsLicenseCar.Edit = model.CarLicenseEdit;
                    permissionsLicenseCar.Delete = model.CarLicenseDelete;
                    permissionsLicenseCar.IDUser = IDgeneralUser!.ID;
                    PermissionsMainUser permissionsMainUser = new PermissionsMainUser();//مستخدم رئيسي
                    permissionsMainUser.Add = false;
                    permissionsMainUser.Edit = false;
                    permissionsMainUser.Delete =false;
                    permissionsMainUser.IDUser = IDgeneralUser!.ID;
                    PermissionsMainUserTem permissionsMainUserTem = new PermissionsMainUserTem(); // مستخدم مؤقت
                    permissionsMainUserTem.Add = false;
                    permissionsMainUserTem.Edit =false;
                    permissionsMainUserTem.Delete = false;
                    permissionsMainUserTem.IDUser = IDgeneralUser!.ID;
                    PermissionsMemo permissionsMemo = new PermissionsMemo();// المذكرة
                    permissionsMemo.Add = model.MemoAdd;
                    permissionsMemo.Edit = model.MemoEdit;
                    permissionsMemo.Delete = model.MemoDelete;
                    permissionsMemo.IDUser = IDgeneralUser!.ID;
                    PermissionsMonthly permissionsMonthly = new PermissionsMonthly(); // الشهريات
                    permissionsMonthly.Add = model.MonthlyAdd;
                    permissionsMonthly.Edit = model.MonthlyEdit;
                    permissionsMonthly.Delete = model.MonthlyDelete;
                    permissionsMonthly.IDUser = IDgeneralUser!.ID;
                    PermissionsPayments permissionsPayments = new PermissionsPayments();// المدفوعات
                    permissionsPayments.Add = model.PaymentsAdd;
                    permissionsPayments.Edit = model.PaymentsEdit;
                    permissionsPayments.Delete = model.PaymentsDelete;
                    permissionsPayments.IDUser = IDgeneralUser!.ID;
                    PermissionsProgramUser permissionsProgramUser = new PermissionsProgramUser();// مستخدم البرنامج
                    permissionsProgramUser.Add = model.ProgramUserAdd;
                    permissionsProgramUser.Edit = model.ProgramUserEdit;
                    permissionsProgramUser.Delete = model.ProgramUserDelete;
                    permissionsProgramUser.IDUser = IDgeneralUser!.ID;
                    PermissionsRepairWorkshops permissionsRepairWorkshops = new PermissionsRepairWorkshops();// ورشات التصليح
                    permissionsRepairWorkshops.Add = model.RepairWorkshopsAdd;
                    permissionsRepairWorkshops.Edit = model.RepairWorkshopsEdit;
                    permissionsRepairWorkshops.Delete = model.RepairWorkshopsDelete;
                    permissionsRepairWorkshops.IDUser = IDgeneralUser!.ID;
                    PermissionsSparePartsCenters permissionsSparePartsCenters = new PermissionsSparePartsCenters();//مراكز قطع الغيار
                    permissionsSparePartsCenters.Add = model.SparePartsCentersAdd;
                    permissionsSparePartsCenters.Edit = model.SparePartsCentersEdit;
                    permissionsSparePartsCenters.Delete = model.SparePartsCentersDelete;
                    permissionsSparePartsCenters.IDUser = IDgeneralUser!.ID;
                    PermissionsWorkCompanies permissionsWorkCompanies = new PermissionsWorkCompanies();// شركات العمل
                    permissionsWorkCompanies.Add = model.WorkCompaniesAdd;
                    permissionsWorkCompanies.Edit = model.WorkCompaniesEdit;
                    permissionsWorkCompanies.Delete = model.WorkCompaniesDelete;
                    permissionsWorkCompanies.IDUser = IDgeneralUser!.ID;
                    PermissionsWorkDiary permissionsWorkDiary = new PermissionsWorkDiary(); //يوميات العمل
                    permissionsWorkDiary.Add = model.WorkDiaryAdd;
                    permissionsWorkDiary.Edit = model.WorkDiaryEdit;
                    permissionsWorkDiary.Delete = model.WorkDiaryDelete;
                    permissionsWorkDiary.IDUser = IDgeneralUser!.ID;

                    //===========================================================================
                    dbContext.Add(pagesPermissions);
                    dbContext.Add(permissionsBriefs);
                    dbContext.Add(permissionsCar);
                    dbContext.Add(permissionsCompany);
                    dbContext.Add(permissionsCompanyDebts);
                    dbContext.Add(permissionsCompanyObligations);
                    dbContext.Add(permissionsContracts);
                    dbContext.Add(permissionsCustomerDebts);
                    dbContext.Add(permissionsDriver);
                    dbContext.Add(permissionsExpenses);
                    dbContext.Add(permissionsFuel);
                    dbContext.Add(permissionsGeneralUser);
                    dbContext.Add(permissionsInsuranceCar);
                    dbContext.Add(permissionsLicenseCar);
                    dbContext.Add(permissionsMainUser);
                    dbContext.Add(permissionsMainUserTem);
                    dbContext.Add(permissionsMemo);
                    dbContext.Add(permissionsMonthly);
                    dbContext.Add(permissionsPayments);
                    dbContext.Add(permissionsProgramUser);
                    dbContext.Add(permissionsRepairWorkshops);
                    dbContext.Add(permissionsSparePartsCenters);
                    dbContext.Add(permissionsWorkCompanies);
                    dbContext.Add(permissionsWorkDiary);
                    dbContext.Add(permissionsDriversDiary);
                    dbContext.Add(permissionsFuelProvider);
                    dbContext.Add(permissionsInputCompany);
                    dbContext.Add(permissionsTrafficViolations);
                    dbContext.Add(permissionsReportscCar);
                    dbContext.SaveChanges();

                     
                    return RedirectToAction("ScreenGeneralUser");
                }
            }
            return View();
        }
 //string car, string carLicense, string carInsurance, string companyDebts,string companyObligations,
        //                                                   string contracts, string customerDebts, string drivers, string expenses, string fuels, string monthly,
        //                                                   string payments, string repairWorkshops, string sparePartsCenters, string workCompanies, string workDiaries,
        public async Task<IActionResult> ScreenGeneralUser(string test, string Error)
        {
            ViewBag.briefs = test; 
            ViewBag.Error = Error;

            int IDMainUser = 0;
            if (!string.IsNullOrEmpty(HttpContext?.Session.GetString("IDMainUser")))
            {
                IDMainUser = int.Parse(HttpContext.Session.GetString("IDMainUser")!);
            }

            //ViewBag.car = car; ViewBag.carLicense = carLicense; ViewBag.carInsurance = carInsurance; ViewBag.companyDebts = companyDebts;
            //ViewBag.companyObligations = companyObligations; ViewBag.contracts = contracts; ViewBag.customerDebts = customerDebts; ViewBag.drivers = drivers;
            //ViewBag.expenses = expenses; ViewBag.fuels = fuels; ViewBag.monthly = monthly; ViewBag.payments = payments; ViewBag.repairWorkshops = repairWorkshops;
            //ViewBag.sparePartsCenters = sparePartsCenters; ViewBag.workCompanies = workCompanies; ViewBag.workDiaries = workDiaries;
            return View(await dbContext.generalUser.Where(x => x.IDMainUser == IDMainUser).ToListAsync());
        }
        public async Task<IActionResult>  EditConfirmedGeneralUser(int ID)
        {
            GeneralUser? generalUser = await dbContext.generalUser.Where(G=>G.ID == ID).FirstOrDefaultAsync();

            if (generalUser != null)
            {
                if(generalUser?.Confirmed == true)
                {
                    generalUser.Confirmed = false;
                    dbContext.Update(generalUser);
                    dbContext.SaveChanges();
                }else if (generalUser?.Confirmed ==false)
                {
                    generalUser.Confirmed = true;
                    dbContext.Update(generalUser);
                    dbContext.SaveChanges();
                }
            }


            return RedirectToAction("ScreenGeneralUser");
        }
        public async Task<IActionResult> DeleteGeneralUser(int ID)
        {
            GeneralUser? generalUser = await dbContext.generalUser.Where(G => G.ID == ID).FirstOrDefaultAsync();

            if (generalUser != null)
            {
                try

                {

                    IEnumerable<Briefs>? briefs = await dbContext.briefs.Where(B => B.IDGeneralUser == ID).ToListAsync(); // الايجازات
                    IEnumerable<Car>? car = await dbContext.car.Where(B => B.IDGeneralUser == ID).ToListAsync();// السيارات
                    IEnumerable<CarLicense>? carLicense = await dbContext.carLicense.Where(B => B.IDGeneralUser == ID).ToListAsync();// ترخيص السيارة
                    IEnumerable<CarInsurance>? carInsurance = await dbContext.carInsurance.Where(B => B.IDGeneralUser == ID).ToListAsync();// تامين السيارة
                    IEnumerable<CompanyDebts>? companyDebts = await dbContext.companyDebts.Where(B => B.IDGeneralUser == ID).ToListAsync();// ديون الشركة
                    IEnumerable<CompanyObligations>? companyObligations = await dbContext.companyObligations.Where(B => B.IDGeneralUser == ID).ToListAsync();// التزامات الشركة
                    IEnumerable<Contracts>? contracts = await dbContext.contracts.Where(B => B.IDGeneralUser == ID).ToListAsync(); // العقود
                    IEnumerable<CustomerDebts>? customerDebts = await dbContext.customerDebts.Where(C => C.IDGeneralUser == ID).ToListAsync();// ديون الزبائن
                    IEnumerable<Driver>? drivers = await dbContext.driver.Where(D => D.IDGeneralUser == ID).ToListAsync();// السائقين
                    IEnumerable<Expenses>? expenses = await dbContext.expenses.Where(E => E.IDGeneralUser == ID).ToListAsync(); // المصاريف
                    IEnumerable<Fuel>? fuels = await dbContext.fuel.Where(f => f.IDGeneralUser == ID).ToListAsync(); //الوقود
                    IEnumerable<Monthly>? monthly = await dbContext.monthly.Where(C => C.IDGeneralUser == ID).ToListAsync();// الشهريات
                    IEnumerable<Payments>? payments = await dbContext.payments.Where(D => D.IDGeneralUser == ID).ToListAsync();// المدفوعات
                    IEnumerable<RepairWorkshops>? repairWorkshops = await dbContext.repairWorkshops.Where(E => E.IDGeneralUser == ID).ToListAsync(); //  ورشات التصليح
                    IEnumerable<SparePartsCenters>? sparePartsCenters = await dbContext.sparePartsCenters.Where(S => S.IDGeneralUser == ID).ToListAsync();//مراكز قطع الغيار
                    IEnumerable<WorkCompanies>? workCompanies = await dbContext.workCompanies.Where(W => W.IDGeneralUser == ID).ToListAsync();// شركات العمل
                    IEnumerable<WorkDiary>? workDiaries = await dbContext.workDiary.Where(W => W.IDGeneralUser == ID).ToListAsync();//يوميات العمل
                    if (briefs.Count() != 0 || car.Count() != 0 || carLicense.Count() != 0 || carInsurance.Count() != 0 || carInsurance.Count() != 0 || companyDebts.Count() != 0 || companyObligations.Count() != 0 || contracts.Count() != 0 || drivers.Count() != 0 || expenses.Count() != 0 || fuels.Count() != 0 || monthly.Count() != 0 || payments.Count() != 0 || repairWorkshops.Count() != 0 || sparePartsCenters.Count() != 0 || workCompanies.Count() != 0 || workDiaries.Count() != 0)
                    {
                        string?  briefss =null , cars =null, carLicenses=null , carInsurances = null, companyDebtss = null, companyObligationss = null, contractss = null , customerDebtss = null, driverss = null , expensess = null , fuelss = null , monthlys = null, paymentss = null, repairWorkshopss = null, sparePartsCenterss = null, workCompaniess = null , workDiariess =null;
                        //"+car+"
                        //if (briefs?.Count() != 0) { briefss = "لا يمكن حذف المستخدم بسبب البيانات الي في اليجازات ويوجد في داخله من البيانات " + briefs?.Count() + " الصفوف"; }
                        //if (car?.Count() != 0) { cars = "لا يمكن حذف المستخدم بسبب البيانات الي في السيارات ويوجد في داخله من البيانات " + car?.Count() + " الصفوف"; }
                        //if (carLicense!.Any()) {carLicenses = "لا يمكن حذف المستخدم بسبب البيانات الي في  ترخيص السيارة ويوجد في داخله من البيانات " + carLicense?.Count() + " الصفوف"; }
                        //if (carInsurance!.Any()){carInsurances = "لا يمكن حذف المستخدم بسبب البيانات الي في  تامين السيارة ويوجد في داخله من البيانات " + carInsurance?.Count() + " الصفوف"; }
                        //if (companyDebts!.Any()) {companyDebtss = "لا يمكن حذف المستخدم بسبب البيانات الي في  ديون الشركة ويوجد في داخله من البيانات " + companyDebts?.Count() + " الصفوف"; }
                        //if (companyObligations!.Any()) {companyObligationss = "لا يمكن حذف المستخدم بسبب البيانات الي في  التزامات الشركة ويوجد في داخله من البيانات " + companyObligations?.Count() + " الصفوف"; }
                        //if (contracts!.Any()) {contractss = "لا يمكن حذف المستخدم بسبب البيانات الي في  العقود ويوجد في داخله من البيانات " + contracts?.Count() + " الصفوف"; }
                        //if (customerDebts!.Any()) {customerDebtss = "لا يمكن حذف المستخدم بسبب البيانات الي في  ديون الزبائن ويوجد في داخله من البيانات " + customerDebts?.Count() + " الصفوف"; }
                        //if (drivers!.Any()) {driverss = "لا يمكن حذف المستخدم بسبب البيانات الي في  السائقين ويوجد في داخله من البيانات " + drivers?.Count() + " الصفوف"; }
                        //if (expenses!.Any()) {expensess = "لا يمكن حذف المستخدم بسبب البيانات الي في  المصاريف ويوجد في داخله من البيانات " + expenses?.Count() + " الصفوف"; }
                        //if (fuels!.Any()) {fuelss = "لا يمكن حذف المستخدم بسبب البيانات الي في  الوقود ويوجد في داخله من البيانات " + fuels?.Count() + " الصفوف"; }
                        //if (monthly!.Any()) {monthlys = "لا يمكن حذف المستخدم بسبب البيانات الي في  الشهريات ويوجد في داخله من البيانات " + monthly?.Count() + " الصفوف"; }
                        //if (payments!.Any()) {paymentss = "لا يمكن حذف المستخدم بسبب البيانات الي في  المدفوعات ويوجد في داخله من البيانات " + payments?.Count() + " الصفوف"; }
                        //if (repairWorkshops!.Any()) {repairWorkshopss = "لا يمكن حذف المستخدم بسبب البيانات الي في  ورشات التصليح ويوجد في داخله من البيانات " + repairWorkshops?.Count() + " الصفوف"; }
                        //if (sparePartsCenters!.Any()) {sparePartsCenterss = "لا يمكن حذف المستخدم بسبب البيانات الي في  مراكز قطع الغيار ويوجد في داخله من البيانات " + sparePartsCenters?.Count() + " الصفوف"; }
                        //if (workCompanies!.Any()) {workCompaniess = "لا يمكن حذف المستخدم بسبب البيانات الي في  شركات العمل ويوجد في داخله من البيانات " + workCompanies?.Count() + " الصفوف"; }
                        //if (workDiaries.Any()) {workDiariess = "لا يمكن حذف المستخدم بسبب البيانات الي في  يوميات العمل ويوجد في داخله من البيانات " + workDiaries?.Count() + " الصفوف"; }
                        if (briefs?.Count() != 0) { briefss = "/اليجازات ("+briefs?.Count()+ ")/"; }
                        if (car?.Count() != 0) { cars = "/ السيارات (" + car?.Count() + ") /"; }
                        if (carLicense!.Any()) { carLicenses = "ترخيص  (" + carLicense?.Count() + ") /"; }
                        if (carInsurance!.Any()) { carInsurances = "تامين  (" + carInsurance?.Count() + ")/" ; }
                        if (companyDebts!.Any()) { companyDebtss = "ديون الشركة (" + companyDebts?.Count() + ")/" ; }
                        if (companyObligations!.Any()){ companyObligationss = "التزامات الشركة (" + companyObligations?.Count() + ")/" ; } 
                        if (contracts!.Any()){ contractss = "العقود (" + contracts?.Count() + ") /" ; }  
                        if (customerDebts!.Any()){ customerDebtss = "ديون (" + customerDebts?.Count() + ") /" ; }  
                        if (drivers!.Any()){ driverss = "السائقين (" + drivers?.Count() + ")  " ; }  
                        if (expenses!.Any()){ expensess = "المصاريف (" + expenses?.Count() + ") /" ; }  
                        if (fuels!.Any()){ fuelss = "الوقود (" + fuels?.Count() + ") /" ; }  
                        if (monthly!.Any()) { monthlys = "الشهريات (" + monthly?.Count() + ")/" ; }   
                        if (payments!.Any()){ paymentss = "المدفوعات (" + payments?.Count() + ") /" ; }   
                        if (repairWorkshops!.Any()){ repairWorkshopss = "ورشات التصليح (" + repairWorkshops?.Count() + ") /" ; }  
                        if (sparePartsCenters!.Any()) { sparePartsCenterss = "مراكز قطع الغيار (" + sparePartsCenters?.Count() + ") /" ; } 
                        if (workCompanies!.Any()){ workCompaniess = "شركات العمل (" + workCompanies?.Count() + ") /"  ; } 
                        if (workDiaries.Any()){ workDiariess = "يوميات (" + workDiaries?.Count() + ") /" ; }  
                        return RedirectToAction("ScreenGeneralUser", new 
                    {
                        test = "  لا يمكن حذف المستخدم بسبب هذا البيانات في مجلد"+ briefss + ""+ cars + ""+ carLicenses + ""+ carInsurances + ""+ companyDebtss + ""+ companyObligationss + ""+ contractss + ""+ customerDebtss + ""+ driverss + ""+ expensess+""+ fuelss+""+ monthlys+""+paymentss + ""+ repairWorkshopss + ""+ sparePartsCenterss + " "+ workCompaniess + " "+ workDiariess + ""


                    }); ;
                    }
                    else
                    {
                        dbContext.Remove(generalUser);
                        dbContext.SaveChanges();
                    }
                                     }
                //workDiaries = workDiariess,workCompanies = workCompaniess,sparePartsCenters = sparePartsCenterss,
                //        repairWorkshops = repairWorkshopss,payments = paymentss,monthly = monthlys,fuels = fuelss,
                //        expenses = expensess,drivers = driverss,customerDebts = customerDebtss,contracts = contractss,
                //        companyObligations = companyObligationss,companyDebts = companyDebtss,carInsurance = carInsurances,
                //        carLicenses = carLicense,briefs = briefss,car = cars

                catch

                {
                    return RedirectToAction("ScreenGeneralUser", new { Error = "هناك   خطاء ويبدو الخطاء بان هذا المستخدم مرتبط مع عدد بيانات في مجدلتات اخره" });

                }
                    
                
            }


            return RedirectToAction("ScreenGeneralUser");
        }

        public async Task<IActionResult> EditGeneralUser(int Id ,int ID)//ليسا بحاجه الى ارقم الاول وثاني فقط من اجل حفظ طريقة ارسال قيمتين على نفس الداله
        {
            try
            {
                GeneralUser? generalUser = await dbContext.generalUser.Where(G => G.ID == Id).FirstOrDefaultAsync();
                PagesPermissions? pagesPermissions = await dbContext.pagesPermissions.Where(B => B.IDUser == ID).FirstOrDefaultAsync();

                PermissionsBriefs? permissionBriefs = await dbContext.permissionsBriefs.Where(B => B.IDUser == ID).FirstOrDefaultAsync(); // الايجازات
                PermissionsCar? permissionsCar = await dbContext.permissionsCar.Where(B => B.IDUser == ID).FirstOrDefaultAsync();// السيارات
                PermissionsLicenseCar? permissionsCarLicense = await dbContext.permissionsLicenseCar.Where(B => B.IDUser == ID).FirstOrDefaultAsync();// ترخيص السيارة
                PermissionsInsuranceCar? permissionsCarInsurance = await dbContext.permissionsInsuranceCar.Where(B => B.IDUser == ID).FirstOrDefaultAsync();// تامين السيارة
                PermissionsCompanyDebts? permissionsCompanyDebts = await dbContext.permissionsCompanyDebts.Where(B => B.IDUser == ID).FirstOrDefaultAsync();// ديون الشركة
                PermissionsCompanyObligations? permissionsCompanyObligations = await dbContext.permissionsCompanyObligations.Where(B => B.IDUser == ID).FirstOrDefaultAsync();// التزامات الشركة
                PermissionsContracts? permissionsContracts = await dbContext.permissionsContracts.Where(B => B.IDUser == ID).FirstOrDefaultAsync(); // العقود
                PermissionsCustomerDebts? permissionsCustomerDebts = await dbContext.permissionsCustomerDebts.Where(C => C.IDUser == ID).FirstOrDefaultAsync();// ديون الزبائن
                PermissionsDriver? permissionsDriver = await dbContext.permissionsDriver.Where(D => D.IDUser == ID).FirstOrDefaultAsync();// السائقين
                PermissionsMemo? permissionsMemo = await dbContext.permissionsMemo.Where(D => D.IDUser == ID).FirstOrDefaultAsync();// المذكره
                PermissionsExpenses? permissionsExpenses = await dbContext.permissionsExpenses.Where(E => E.IDUser == ID).FirstOrDefaultAsync(); // المصاريف
                PermissionsFuel? permissionsFuel = await dbContext.PermissionsFuel.Where(f => f.IDUser == ID).FirstOrDefaultAsync(); //الوقود
                PermissionsMonthly? permissionsMonthly = await dbContext.permissionsMonthly.Where(C => C.IDUser == ID).FirstOrDefaultAsync();// الشهريات
                PermissionsPayments? PermissionsPayments = await dbContext.permissionsPayments.Where(D => D.IDUser == ID).FirstOrDefaultAsync();// المدفوعات
                PermissionsRepairWorkshops? permissionsRepairWorkshops = await dbContext.permissionsRepairWorkshops.Where(E => E.IDUser == ID).FirstOrDefaultAsync(); //  ورشات التصليح
                PermissionsSparePartsCenters? permissionssparePartsCenters = await dbContext.permissionsSparePartsCenters.Where(S => S.IDUser == ID).FirstOrDefaultAsync();//مراكز قطع الغيار
                PermissionsWorkCompanies? permissionsworkCompanies = await dbContext.permissionsWorkCompanies.Where(W => W.IDUser == ID).FirstOrDefaultAsync();// شركات العمل
                PermissionsWorkDiary? permissionsworkDiaries = await dbContext.permissionsWorkDiary.Where(W => W.IDUser == ID).FirstOrDefaultAsync();//يوميات العمل
                
                PermissionsDriversDiary? permissionsDriversDiary = await dbContext.permissionsDriversDiary.Where(W => W.IDUser == ID).FirstOrDefaultAsync();//يوميات العمل
                PermissionsFuelProvider? permissionsFuelProvider = await dbContext.permissionsFuelProvider.Where(W => W.IDUser == ID).FirstOrDefaultAsync();//يوميات العمل
                PermissionsInputCompany? permissionsInputCompany = await dbContext.permissionsInputCompany.Where(W => W.IDUser == ID).FirstOrDefaultAsync();//يوميات العمل
                PermissionsTrafficViolations? permissionsTrafficViolations = await dbContext.permissionsTrafficViolations.Where(W => W.IDUser == ID).FirstOrDefaultAsync();//يوميات العمل
                PermissionsReportscCar? permissionsReportscCar = await dbContext.permissionsReportscCar.Where(W => W.IDUser == ID).FirstOrDefaultAsync();//يوميات العمل
                if (pagesPermissions != null && permissionsDriversDiary != null)
                {
                    generalUser!.DriversDiary = pagesPermissions!.DriversDiary;
                    generalUser!.DriversDiaryAdd = permissionsDriversDiary!.Add;
                    generalUser!.DriversDiaryEdit = permissionsDriversDiary!.Edit;
                    generalUser!.DriversDiaryDelete = permissionsDriversDiary!.Delete;
                }
                if (pagesPermissions != null && permissionsFuelProvider != null)
                {
                    generalUser!.FuelProvider = pagesPermissions!.FuelProvider;
                    generalUser!.FuelProviderAdd = permissionsFuelProvider!.Add;
                    generalUser!.FuelProviderEdit = permissionsFuelProvider!.Edit;
                    generalUser!.FuelProviderDelete = permissionsFuelProvider!.Delete;
                }
                if (pagesPermissions != null && permissionsInputCompany != null)
                {
                    generalUser!.InputCompany = pagesPermissions!.InputCompany;
                    generalUser!.InputCompanyAdd = permissionsInputCompany!.Add;
                    generalUser!.InputCompanyEdit = permissionsInputCompany!.Edit;
                    generalUser!.InputCompanyDelete = permissionsInputCompany!.Delete;
                }
                if (pagesPermissions != null && permissionsTrafficViolations != null)
                {
                    generalUser!.TrafficViolations = pagesPermissions!.TrafficViolations;
                    generalUser!.TrafficViolationsAdd = permissionsTrafficViolations!.Add;
                    generalUser!.TrafficViolationsEdit = permissionsTrafficViolations!.Edit;
                    generalUser!.TrafficViolationsDelete = permissionsTrafficViolations!.Delete;
                }
                if (pagesPermissions != null && permissionsReportscCar != null)
                {
                    generalUser!.ReportscCar = pagesPermissions!.ReportscCar;
                    generalUser!.ReportscCarAdd = permissionsReportscCar!.Add;
                    generalUser!.ReportscCarEdit = permissionsReportscCar!.Edit;
                    generalUser!.ReportscCarDelete = permissionsReportscCar!.Delete;
                }
                if (pagesPermissions != null && permissionBriefs != null)
                {
                    generalUser!.Briefs = pagesPermissions!.Briefs;
                    generalUser!.BriefsAdd = permissionBriefs!.Add;
                    generalUser!.BriefsEdit = permissionBriefs!.Edit;
                    generalUser!.BriefsDelete = permissionBriefs!.Delete;
                }
                if (pagesPermissions != null && permissionsCar != null)
                {
                    generalUser!.Car = pagesPermissions!.Car;
                    generalUser!.CarAdd = permissionsCar!.Add;
                    generalUser!.CarEdit = permissionsCar!.Edit;
                    generalUser!.CarDelete = permissionsCar!.Delete;
                    
                }
                if (pagesPermissions != null && permissionsCarLicense != null)
                {
                generalUser!.CarLicense = pagesPermissions!.LicenseCar;
                generalUser!.CarLicenseAdd = permissionsCarLicense!.Add;
                generalUser!.CarLicenseEdit = permissionsCarLicense!.Edit;
                generalUser!.CarLicenseDelete = permissionsCarLicense!.Delete;
                }
                if (pagesPermissions != null && permissionsCarInsurance != null)
                {
                generalUser!.CarInsurance = pagesPermissions!.InsuranceCar;
                generalUser!.CarInsuranceAdd = permissionsCarInsurance!.Add;
                generalUser!.CarInsuranceEdit = permissionsCarInsurance!.Edit;
                generalUser!.CarInsuranceDelete = permissionsCarInsurance!.Delete;
                }
                if (pagesPermissions != null && permissionsCompanyDebts != null)
                {
                generalUser!.CompanyDebts = pagesPermissions!.CompanyDebts;
                generalUser!.CompanyDebtsAdd = permissionsCompanyDebts!.Add;
                generalUser!.CompanyDebtsEdit = permissionsCompanyDebts!.Edit;
                generalUser!.CompanyDebtsDelete = permissionsCompanyDebts!.Delete;
                }
                if (pagesPermissions != null && permissionsCompanyObligations != null)
                {
                generalUser!.CompanyObligations = pagesPermissions!.CompanyObligations;
                generalUser!.CompanyObligationsAdd = permissionsCompanyObligations!.Add;
                generalUser!.CompanyObligationsEdit = permissionsCompanyObligations!.Edit;
                generalUser!.CompanyObligationsDelete = permissionsCompanyObligations!.Delete;
                }
                if (pagesPermissions != null && permissionsContracts != null)
                {
                generalUser!.Contracts = pagesPermissions!.Contracts;
                generalUser!.ContractsAdd = permissionsContracts!.Add;
                generalUser!.ContractsEdit = permissionsContracts!.Edit;
                generalUser!.ContractsDelete = permissionsContracts!.Delete;
                }
                if (pagesPermissions != null && permissionsCustomerDebts != null)
                {
                generalUser!.CustomerDebts = pagesPermissions!.CustomerDebts;
                generalUser!.CustomerDebtsAdd = permissionsCustomerDebts!.Add;
                generalUser!.CustomerDebtsEdit = permissionsCustomerDebts!.Edit;
                generalUser!.CustomerDebtsDelete = permissionsCustomerDebts!.Delete;
                }
                if (pagesPermissions != null && permissionsDriver != null)
                {
                generalUser!.Driver = pagesPermissions!.Driver;
                generalUser!.DriverAdd = permissionsDriver!.Add;
                generalUser!.DriverEdit = permissionsDriver!.Edit;
                generalUser!.DriverDelete = permissionsDriver!.Delete;
                }
                if (pagesPermissions != null && permissionsMemo != null)
                {
                generalUser!.Memo = pagesPermissions!.Memo;
                generalUser!.MemoAdd = permissionsMemo!.Add;
                generalUser!.MemoEdit = permissionsMemo!.Edit;
                generalUser!.MemoDelete = permissionsMemo!.Delete;
                }
                if (pagesPermissions != null && permissionsExpenses != null)
                {
                generalUser!.Expenses = pagesPermissions!.Expenses;
                generalUser!.ExpensesAdd = permissionsExpenses!.Add;
                generalUser!.ExpensesEdit = permissionsExpenses!.Edit;
                generalUser!.ExpensesDelete = permissionsExpenses!.Delete;
                }
                if (pagesPermissions != null && permissionsFuel != null)
                {
                generalUser!.Fuel = pagesPermissions!.Fuel;
                generalUser!.FuelAdd = permissionsFuel!.Add;
                generalUser!.FuelEdit = permissionsFuel!.Edit;
                generalUser!.FuelDelete = permissionsFuel!.Delete;
                }
                if (pagesPermissions != null && permissionsMonthly != null)
                {
                generalUser!.Monthly = pagesPermissions!.Monthly;
                generalUser!.MonthlyAdd = permissionsMonthly!.Add;
                generalUser!.MonthlyEdit = permissionsMonthly!.Edit;
                generalUser!.MonthlyDelete = permissionsMonthly!.Delete;
                }
                if (pagesPermissions != null && PermissionsPayments != null)
                {
                generalUser!.Payments = pagesPermissions!.Payments;
                generalUser!.PaymentsAdd = PermissionsPayments!.Add;
                generalUser!.PaymentsEdit = PermissionsPayments!.Edit;
                generalUser!.PaymentsDelete = PermissionsPayments!.Delete;
                }
                if (pagesPermissions != null && permissionsRepairWorkshops != null)
                {
                generalUser!.RepairWorkshops = pagesPermissions!.RepairWorkshops;
                generalUser!.RepairWorkshopsAdd = permissionsRepairWorkshops!.Add;
                generalUser!.RepairWorkshopsEdit = permissionsRepairWorkshops!.Edit;
                generalUser!.RepairWorkshopsDelete = permissionsRepairWorkshops!.Delete;
                }
                if (pagesPermissions != null && permissionssparePartsCenters != null)
                {
                generalUser!.SparePartsCenters = pagesPermissions!.SparePartsCenters;
                generalUser!.SparePartsCentersAdd = permissionssparePartsCenters!.Add;
                generalUser!.SparePartsCentersEdit = permissionssparePartsCenters!.Edit;
                generalUser!.SparePartsCentersDelete = permissionssparePartsCenters!.Delete;
                }
                if (pagesPermissions != null && permissionsworkCompanies != null)
                {
                generalUser!.WorkCompanies = pagesPermissions!.WorkCompanies;
                generalUser!.WorkCompaniesAdd = permissionsworkCompanies!.Add;
                generalUser!.WorkCompaniesEdit = permissionsworkCompanies!.Edit;
                generalUser!.WorkCompaniesDelete = permissionsworkCompanies!.Delete;
                }
                if (pagesPermissions != null && permissionsworkDiaries != null)
                {
                generalUser!.WorkDiary = pagesPermissions!.WorkDiary;
                generalUser!.WorkDiaryAdd = permissionsworkDiaries!.Add;
                generalUser!.WorkDiaryEdit = permissionsworkDiaries!.Edit;
                generalUser!.WorkDiaryDelete = permissionsworkDiaries!.Delete;
                }                                                               
                //

                return View(generalUser);

            }
            catch
            {
                return RedirectToAction("ScreenGeneralUser", new { Error = "يوجد مشكلة في الصلاحيات " });

            }










            
        }
        [HttpPost]
        public async Task<IActionResult> EditGeneralUser(GeneralUser model)
        {
            GeneralUser? generalUser =await dbContext.generalUser.Where(G => G.ID == model.ID).FirstOrDefaultAsync();
            MainUser? mainUser = await dbContext.mainUser.Where(m => m.Name == model.Name).FirstOrDefaultAsync();
            MainUserTem? mainUserTem = await dbContext.mainUserTem.Where(m => m.Name == model.Name).FirstOrDefaultAsync();
            ProgramUser? programUser = await dbContext.programUser.Where(m => m.Name == model.Name).FirstOrDefaultAsync();
            if (programUser != null)
            {
                ModelState.AddModelError("Name", "هذا الاسم محجوز لا يمكن استخدامه");
                return View();
            }
            else if(mainUser != null)
            {
                ModelState.AddModelError("Name", "هذا الاسم محجوز لا يمكن استخدامه");
                return View();
            }
            else if (mainUserTem != null)
            {
                ModelState.AddModelError("Name", "هذا الاسم محجوز لا يمكن استخدامه");
                return View();
            }
            else if (generalUser != null)
            {
                GeneralUser? generalUserNew = await dbContext.generalUser.Where(G => G.Name == model.Name).FirstOrDefaultAsync();
                if (generalUser.Name != model.Name || generalUser.Password != model.Password)
                {

                   
                    if (generalUserNew != null )
                    {
                        if (generalUser.Name != model.Name)
                        {
                            generalUser.Name = model.Name; 
                            dbContext.Update(generalUser);
                        }
                        else if (generalUser.Password != model.Password)
                        {
                             
                            generalUser.Password = model.Password;
                            dbContext.Update(generalUser);
                        }
                        else
                        {
                            return RedirectToAction("ScreenGeneralUser");
                        }

                       

                    }
                    else
                    {
                        generalUser.Name = model.Name;
                        generalUser.Password = model.Password;
                        dbContext.Update(generalUser);
                    }
                    
                }
                


                PagesPermissions? pagesPermissions = await dbContext.pagesPermissions.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();//الصفحات
                if(pagesPermissions != null)
                {
                    pagesPermissions.Briefs = model.Briefs;
                    pagesPermissions.Car = model.Car;
                    pagesPermissions.Company = model.Companys;
                    pagesPermissions.CompanyDebts = model.CompanyDebts;
                    pagesPermissions.CompanyObligations = model.CompanyObligations;
                    pagesPermissions.Driver = model.Driver;
                    pagesPermissions.Contracts = model.Contracts;
                    pagesPermissions.CustomerDebts = model.CustomerDebts;
                    pagesPermissions.Expenses = model.Expenses;
                    pagesPermissions.Fuel = model.Fuel;
                    pagesPermissions.GeneralUser = model.GeneralUsers;
                    pagesPermissions.InsuranceCar = model.CarInsurance;
                    pagesPermissions.LicenseCar = model.CarLicense;
                    pagesPermissions.MainUser = false;
                    pagesPermissions.MainUserTem = false;
                    pagesPermissions.Memo = model.Memo;
                    pagesPermissions.Monthly = model.Monthly;
                    pagesPermissions.Payments = model.Payments;
                    pagesPermissions.ProgramUser = false;
                    pagesPermissions.RepairWorkshops = model.RepairWorkshops;
                    pagesPermissions.SparePartsCenters = model.SparePartsCenters;
                    pagesPermissions.WorkCompanies = model.WorkCompanies;
                    pagesPermissions.WorkDiary = model.WorkDiary;

                    pagesPermissions.DriversDiary = model.DriversDiary;
                    pagesPermissions.FuelProvider = model.FuelProvider;
                    pagesPermissions.InputCompany = model.InputCompany;
                    pagesPermissions.TrafficViolations = model.TrafficViolations;
                    pagesPermissions.ReportscCar = model.ReportscCar;



                    

                    dbContext.Update(generalUser);

                }
                else if (pagesPermissions == null)
                {
                    PagesPermissions? pagesPermissionsNew = new PagesPermissions();
                    pagesPermissionsNew!.Briefs = model.Briefs;
                    pagesPermissionsNew!.Car = model.Car;
                    pagesPermissionsNew!.Company = model.Companys;
                    pagesPermissionsNew!.CompanyDebts = model.CompanyDebts;
                    pagesPermissionsNew!.CompanyObligations = model.CompanyObligations;
                    pagesPermissionsNew!.Driver = model.Driver;
                    pagesPermissionsNew!.Contracts = model.Contracts;
                    pagesPermissionsNew!.CustomerDebts = model.CustomerDebts;
                    pagesPermissionsNew!.Expenses = model.Expenses;
                    pagesPermissionsNew!.Fuel = model.Fuel;
                    pagesPermissionsNew!.GeneralUser = model.GeneralUsers;
                    pagesPermissionsNew!.InsuranceCar = model.CarInsurance;
                    pagesPermissionsNew!.LicenseCar = model.CarLicense;
                    pagesPermissionsNew!.MainUser = false;
                    pagesPermissionsNew!.MainUserTem = false;
                    pagesPermissionsNew!.Memo = model.Memo;
                    pagesPermissionsNew!.Monthly = model.Monthly;
                    pagesPermissionsNew!.Payments = model.Payments;
                    pagesPermissionsNew!.ProgramUser = false;
                    pagesPermissionsNew!.RepairWorkshops = model.RepairWorkshops;
                    pagesPermissionsNew!.SparePartsCenters = model.SparePartsCenters;
                    pagesPermissionsNew!.WorkCompanies = model.WorkCompanies;
                    pagesPermissionsNew!.WorkDiary = model.WorkDiary;
                    pagesPermissionsNew!.DriversDiary = model.DriversDiary;
                    pagesPermissionsNew!.FuelProvider = model.FuelProvider;
                    pagesPermissionsNew!.InputCompany = model.InputCompany;
                    pagesPermissionsNew!.TrafficViolations = model.TrafficViolations;
                    pagesPermissionsNew!.ReportscCar = model.ReportscCar;
                    pagesPermissionsNew!.IDUser = model.ID;
                    dbContext.Add(pagesPermissionsNew);
                }
                                                 
                



                PermissionsDriversDiary? permissionsDriversDiary = await dbContext.permissionsDriversDiary.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();// يوميات السائقين
                if (permissionsDriversDiary != null)
                {
                    permissionsDriversDiary.Add = model.BriefsAdd;
                    permissionsDriversDiary.Edit = model.BriefsEdit;
                    permissionsDriversDiary.Delete = model.BriefsDelete;
                    dbContext.Update(permissionsDriversDiary);
                }
                else if (permissionsDriversDiary == null)
                {
                    PermissionsDriversDiary? permissionsDriversDiaryNew = new PermissionsDriversDiary();
                    permissionsDriversDiaryNew!.Add = model.DriversDiaryAdd;
                    permissionsDriversDiaryNew!.Edit = model.DriversDiaryEdit;
                    permissionsDriversDiaryNew!.Delete = model.DriversDiaryDelete;
                    permissionsDriversDiaryNew!.IDUser = model.ID;
                    dbContext.Add(permissionsDriversDiaryNew);
                }





                //==================================================
                PermissionsFuelProvider? permissionsFuelProvider = await dbContext.permissionsFuelProvider.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();// يوميات السائقين
                if (permissionsFuelProvider != null)
                {
                    permissionsFuelProvider.Add = model.FuelProviderAdd;
                    permissionsFuelProvider.Edit = model.FuelProviderEdit;
                    permissionsFuelProvider.Delete = model.FuelProviderDelete;
                    dbContext.Update(permissionsFuelProvider);
                }
                else if (permissionsDriversDiary == null)
                {
                    PermissionsFuelProvider? permissionsFuelProvideryNew = new PermissionsFuelProvider();
                    permissionsFuelProvideryNew!.Add = model.FuelProviderAdd;
                    permissionsFuelProvideryNew!.Edit = model.FuelProviderEdit;
                    permissionsFuelProvideryNew!.Delete = model.FuelProviderDelete;
                    permissionsFuelProvideryNew!.IDUser = model.ID;
                    dbContext.Add(permissionsFuelProvideryNew);
                }
                //==================================================





               
                                //==================================================
                PermissionsInputCompany? permissionsInputCompany = await dbContext.permissionsInputCompany.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();// يوميات السائقين
                if (permissionsInputCompany != null)
                {
                    permissionsInputCompany.Add = model.FuelProviderAdd;
                    permissionsInputCompany.Edit = model.FuelProviderEdit;
                    permissionsInputCompany.Delete = model.FuelProviderDelete;
                    dbContext.Update(permissionsInputCompany);
                }
                else if (permissionsDriversDiary == null)
                {
                    PermissionsInputCompany? permissionsInputCompanyNew = new PermissionsInputCompany();
                    permissionsInputCompanyNew!.Add = model.InputCompanyAdd;
                    permissionsInputCompanyNew!.Edit = model.InputCompanyEdit;
                    permissionsInputCompanyNew!.Delete = model.FuelProviderDelete;
                    permissionsInputCompanyNew!.IDUser = model.ID;
                    dbContext.Add(permissionsInputCompanyNew);
                }
                //==================================================




                 
                //==================================================
                PermissionsTrafficViolations? permissionsTrafficViolations = await dbContext.permissionsTrafficViolations.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();// يوميات السائقين
                if (permissionsTrafficViolations != null)
                {
                    permissionsTrafficViolations.Add = model.FuelProviderAdd;
                    permissionsTrafficViolations.Edit = model.FuelProviderEdit;
                    permissionsTrafficViolations.Delete = model.FuelProviderDelete;
                    dbContext.Update(permissionsTrafficViolations);
                }
                else if (permissionsTrafficViolations == null)
                {
                    PermissionsTrafficViolations? permissionsTrafficViolationsNew = new PermissionsTrafficViolations();
                    permissionsTrafficViolationsNew!.Add = model.TrafficViolationsAdd;
                    permissionsTrafficViolationsNew!.Edit = model.TrafficViolationsEdit;
                    permissionsTrafficViolationsNew!.Delete = model.TrafficViolationsDelete;
                    permissionsTrafficViolationsNew!.IDUser = model.ID;
                    dbContext.Add(permissionsTrafficViolationsNew);
                }
                //========

                //==================================================
                PermissionsReportscCar? permissionsReportscCar = await dbContext.permissionsReportscCar.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();// يوميات السائقين
                if (permissionsReportscCar != null)
                {
                    permissionsReportscCar.Add = model.ReportscCarAdd;
                    permissionsReportscCar.Edit = model.ReportscCarEdit;
                    permissionsReportscCar.Delete = model.FuelProviderDelete;
                    dbContext.Update(permissionsReportscCar);
                }
                else if (permissionsDriversDiary == null)
                {
                    PermissionsReportscCar? permissionsReportscCarNew = new PermissionsReportscCar();
                    permissionsReportscCarNew!.Add = model.ReportscCarAdd;
                    permissionsReportscCarNew!.Edit = model.ReportscCarEdit;
                    permissionsReportscCarNew!.Delete = model.ReportscCarDelete;
                    permissionsReportscCarNew!.IDUser = model.ID;
                    dbContext.Add(permissionsReportscCarNew);
                }
                //========




















                //==================================================
                PermissionsBriefs? permissionsBriefs = await dbContext.permissionsBriefs.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();// الايجازات
                if (permissionsBriefs != null)
                {
                    permissionsBriefs.Add = model.BriefsAdd;
                    permissionsBriefs.Edit = model.BriefsEdit;
                    permissionsBriefs.Delete = model.BriefsDelete;
                    dbContext.Update(permissionsBriefs);
                }
                else if(permissionsBriefs == null)
                {
                    PermissionsBriefs? permissionsBriefsNew = new PermissionsBriefs();
                    permissionsBriefsNew!.Add = model.BriefsAdd;
                    permissionsBriefsNew!.Edit = model.BriefsEdit;
                    permissionsBriefsNew!.Delete = model.BriefsDelete;
                    permissionsBriefsNew!.IDUser = model.ID;
                    dbContext.Add(permissionsBriefsNew);
                }
                //==================================================
                PermissionsCar? permissionsCar = await dbContext.permissionsCar.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();//السيارات
                if (permissionsCar != null)
                {
                    permissionsCar.Add = model.CarAdd;
                    permissionsCar.Edit = model.CarEdit;
                    permissionsCar.Delete = model.CarDelete;
                    dbContext.Update(permissionsCar);
                }
                else if (permissionsCar == null)
                {
                    PermissionsCar? permissionsCarNew = new PermissionsCar();
                    permissionsCarNew!.Add = model.CarAdd;
                    permissionsCarNew!.Edit = model.CarEdit;
                    permissionsCarNew!.Delete = model.CarDelete;
                    permissionsCarNew!.IDUser = model.ID;
                    dbContext.Add(permissionsCarNew);
                }
                //==================================================
                PermissionsCompany? permissionsCompany = await dbContext.permissionsCompany.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();// الشركة
                if (permissionsCompany != null)
                {
                    permissionsCompany.Add = model.CompanysAdd;
                    permissionsCompany.Edit = model.CompanysEdit;
                    permissionsCompany.Delete = model.CompanysDelete;
                    dbContext.Update(permissionsCompany);
                }
                else if (permissionsCompany == null)
                {
                    PermissionsCompany? permissionsCompanyNew = new PermissionsCompany();
                    permissionsCompanyNew!.Add = model.CompanysAdd;
                    permissionsCompanyNew!.Edit = model.CompanysEdit;
                    permissionsCompanyNew!.Delete = model.CompanysDelete;
                    permissionsCompanyNew!.IDUser = model.ID;
                    dbContext.Add(permissionsCompanyNew);
                }
                //==================================================
                PermissionsCompanyDebts? permissionsCompanyDebts = await dbContext.permissionsCompanyDebts.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();// ديون الشركة
                if (permissionsCompanyDebts != null)
                {
                    permissionsCompanyDebts.Add = model.CompanyDebtsAdd;
                    permissionsCompanyDebts.Edit = model.CompanyDebtsEdit;
                    permissionsCompanyDebts.Delete = model.CompanyDebtsDelete;
                    dbContext.Update(permissionsCompanyDebts);
                }
                else if (permissionsCompanyDebts == null)
                {
                    PermissionsCompanyDebts? permissionsCompanyDebtsNew = new PermissionsCompanyDebts();
                    permissionsCompanyDebtsNew!.Add = model.CompanyDebtsAdd;
                    permissionsCompanyDebtsNew!.Edit = model.CompanyDebtsEdit;
                    permissionsCompanyDebtsNew!.Delete = model.CompanyDebtsDelete;
                    permissionsCompanyDebtsNew!.IDUser = model.ID;
                    dbContext.Add(permissionsCompanyDebtsNew);
                }
                //==================================================
                PermissionsCompanyObligations? permissionsCompanyObligations = await dbContext.permissionsCompanyObligations.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();// التزامات الشركة
                if (permissionsCompanyObligations != null)
                {
                    permissionsCompanyObligations.Add = model.CompanyObligationsAdd;
                    permissionsCompanyObligations.Edit = model.CompanyObligationsEdit;
                    permissionsCompanyObligations.Delete = model.CompanyObligationsDelete;
                    dbContext.Update(permissionsCompanyObligations);
                }
                else if (permissionsCompanyObligations == null)
                {
                    PermissionsCompanyObligations? permissionsCompanyObligationsNew = new PermissionsCompanyObligations();
                    permissionsCompanyObligationsNew!.Add = model.CompanyObligationsAdd;
                    permissionsCompanyObligationsNew!.Edit = model.CompanyObligationsEdit;
                    permissionsCompanyObligationsNew!.Delete = model.CompanyObligationsDelete;
                    permissionsCompanyObligationsNew!.IDUser = model.ID;
                    dbContext.Add(permissionsCompanyObligationsNew);
                }
                //==================================================
                PermissionsContracts? permissionsContracts = await dbContext.permissionsContracts.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();// العقود
                if (permissionsContracts != null)
                {
                    permissionsContracts.Add = model.ContractsAdd;
                    permissionsContracts.Edit = model.ContractsEdit;
                    permissionsContracts.Delete = model.ContractsDelete;
                    dbContext.Update(permissionsContracts);
                }
                else if (permissionsContracts == null)
                {
                    PermissionsContracts? permissionsContractsNew = new PermissionsContracts();
                    permissionsContractsNew!.Add = model.ContractsAdd;
                    permissionsContractsNew!.Edit = model.ContractsEdit;
                    permissionsContractsNew!.Delete = model.ContractsDelete;
                    permissionsContractsNew!.IDUser = model.ID;
                    dbContext.Add(permissionsContractsNew);
                }
                //==================================================
                PermissionsCustomerDebts? permissionsCustomerDebts = await dbContext.permissionsCustomerDebts.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();// ديون الزبائن
                if (permissionsCustomerDebts != null)
                {
                    permissionsCustomerDebts.Add = model.CustomerDebtsAdd;
                    permissionsCustomerDebts.Edit = model.CustomerDebtsEdit;
                    permissionsCustomerDebts.Delete = model.CustomerDebtsDelete;
                    dbContext.Update(permissionsCustomerDebts);
                }
                else if (permissionsCustomerDebts == null)
                {
                    PermissionsCustomerDebts? permissionsCustomerDebtsNew = new PermissionsCustomerDebts();
                    permissionsCustomerDebtsNew!.Add = model.CustomerDebtsAdd;
                    permissionsCustomerDebtsNew!.Edit = model.CustomerDebtsEdit;
                    permissionsCustomerDebtsNew!.Delete = model.CustomerDebtsDelete;
                    permissionsCustomerDebtsNew!.IDUser = model.ID;
                    dbContext.Add(permissionsCustomerDebtsNew);
                }
                //==================================================
                PermissionsDriver? permissionsDriver =  await dbContext.permissionsDriver.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();// السائقين
                if (permissionsDriver != null)
                {
                    permissionsDriver.Add = model.DriverAdd;
                    permissionsDriver.Edit = model.DriverEdit;
                    permissionsDriver.Delete = model.DriverDelete;
                    dbContext.Update(permissionsDriver);
                }
                else if (permissionsDriver == null)
                {
                    PermissionsDriver? permissionsDriverNew = new PermissionsDriver();
                    permissionsDriverNew!.Add = model.DriverAdd;
                    permissionsDriverNew!.Edit = model.DriverEdit;
                    permissionsDriverNew!.Delete = model.DriverDelete;
                    permissionsDriverNew!.IDUser = model.ID;
                    dbContext.Add(permissionsDriverNew);
                }
                //==================================================
                PermissionsExpenses? permissionsExpenses = await dbContext.permissionsExpenses.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();// المصاريف
                if (permissionsExpenses != null)
                {
                    permissionsExpenses.Add = model.ExpensesAdd;
                    permissionsExpenses.Edit = model.ExpensesEdit;
                    permissionsExpenses.Delete = model.ExpensesDelete; 
                    dbContext.Update(permissionsExpenses);
                }
                else if (permissionsExpenses == null)
                {
                    PermissionsExpenses? permissionsExpensesNew = new PermissionsExpenses();
                    permissionsExpensesNew!.Add = model.ExpensesAdd;
                    permissionsExpensesNew!.Edit = model.ExpensesEdit;
                    permissionsExpensesNew!.Delete = model.ExpensesDelete;
                    permissionsExpensesNew!.IDUser = model.ID;
                    dbContext.Add(permissionsExpensesNew);
                }
                //==================================================
                PermissionsFuel? permissionsFuel = await dbContext.PermissionsFuel.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();//الوقود
                if (permissionsFuel != null)
                {
                    permissionsFuel.Add = model.FuelAdd;
                    permissionsFuel.Edit = model.FuelEdit;
                    permissionsFuel.Delete = model.FuelDelete;
                    dbContext.Update(permissionsFuel);
                }
                else if (permissionsFuel == null)
                {
                    PermissionsFuel? permissionsFuelNew = new PermissionsFuel();
                    permissionsFuelNew!.Add = model.FuelAdd;
                    permissionsFuelNew!.Edit = model.FuelEdit;
                    permissionsFuelNew!.Delete = model.FuelDelete;
                    permissionsFuelNew!.IDUser = model.ID;
                    dbContext.Add(permissionsFuelNew);
                }
                //=================================================
                PermissionsGeneralUser? permissionsGeneralUser = await dbContext.permissionsGeneralUser.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();// مستخدم عام
                if (permissionsGeneralUser != null)
                {
                    permissionsGeneralUser.Add = model.GeneralUsersAdd;
                    permissionsGeneralUser.Edit = model.GeneralUsersEdit;
                    permissionsGeneralUser.Delete = model.GeneralUsersDelete;
                    dbContext.Update(permissionsGeneralUser);
                }
                else if (permissionsGeneralUser == null)
                {
                    PermissionsGeneralUser? permissionsGeneralUsersNew = new PermissionsGeneralUser();
                    permissionsGeneralUsersNew!.Add = model.GeneralUsersAdd;
                    permissionsGeneralUsersNew!.Edit = model.GeneralUsersEdit;
                    permissionsGeneralUsersNew!.Delete = model.GeneralUsersDelete;
                    permissionsGeneralUsersNew!.IDUser = model.ID;
                    dbContext.Add(permissionsGeneralUsersNew);
                }
                //==================================================
                PermissionsInsuranceCar? permissionsInsuranceCar = await dbContext.permissionsInsuranceCar.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();// تامين السيارة
                if (permissionsInsuranceCar != null)
                {
                    permissionsInsuranceCar.Add = model.CarLicenseAdd;
                    permissionsInsuranceCar.Edit = model.CarLicenseEdit;
                    permissionsInsuranceCar.Delete = model.CarLicenseDelete;
                    dbContext.Update(permissionsInsuranceCar);
                }
                else if (permissionsInsuranceCar == null)
                {
                    PermissionsInsuranceCar? permissionsInsuranceCarNew = new PermissionsInsuranceCar();
                    permissionsInsuranceCarNew!.Add = model.CarLicenseAdd;
                    permissionsInsuranceCarNew!.Edit = model.CarLicenseEdit;
                    permissionsInsuranceCarNew!.Delete = model.CarLicenseDelete;
                    permissionsInsuranceCarNew!.IDUser = model.ID;
                    dbContext.Add(permissionsInsuranceCarNew);
                }
                //==================================================
                PermissionsLicenseCar? permissionsLicenseCar = await dbContext.permissionsLicenseCar.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();// ترخيص السيارة
                if (permissionsLicenseCar != null)
                {
                    permissionsLicenseCar.Add = model.CarLicenseAdd;
                    permissionsLicenseCar.Edit = model.CarLicenseEdit;
                    permissionsLicenseCar.Delete = model.CarLicenseDelete;
                    dbContext.Update(permissionsLicenseCar);
                }
                else if (permissionsLicenseCar == null)
                {
                    PermissionsLicenseCar? permissionsLicenseCarNew = new PermissionsLicenseCar();
                    permissionsLicenseCarNew!.Add = model.CarLicenseAdd;
                    permissionsLicenseCarNew!.Edit = model.CarLicenseEdit;
                    permissionsLicenseCarNew!.Delete = model.CarLicenseDelete;
                    permissionsLicenseCarNew!.IDUser = model.ID;
                    dbContext.Add(permissionsLicenseCarNew);
                }
                //==================================================
                PermissionsMainUser? permissionsMainUser = await dbContext.permissionsMainUser.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();//مستخدم رئيسي
                if (permissionsMainUser != null)
                {
                    permissionsMainUser.Add = false;
                    permissionsMainUser.Edit = false;
                    permissionsMainUser.Delete = false;
                    dbContext.Update(permissionsMainUser);
                }
                else if (permissionsMainUser == null)
                {
                    PermissionsMainUser? permissionsMainUserNew = new PermissionsMainUser();
                    permissionsMainUserNew!.Add = false;
                    permissionsMainUserNew!.Edit = false;
                    permissionsMainUserNew!.Delete = false;
                    permissionsMainUserNew!.IDUser = model.ID;
                    dbContext.Add(permissionsMainUserNew);
                }
                //==================================================
                PermissionsMainUserTem? permissionsMainUserTem = await dbContext.permissionsMainUserTem.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync(); // مستخدم مؤقت
                if (permissionsMainUserTem != null)
                {
                    permissionsMainUserTem.Add = false;
                    permissionsMainUserTem.Edit = false;
                    permissionsMainUserTem.Delete = false;
                    dbContext.Update(permissionsMainUserTem);
                }
                else if (permissionsMainUserTem == null)
                {
                    PermissionsMainUserTem? permissionsMainUserTemNew = new PermissionsMainUserTem();
                    permissionsMainUserTemNew!.Add =false;
                    permissionsMainUserTemNew!.Edit = false;
                    permissionsMainUserTemNew!.Delete = false;
                    permissionsMainUserTemNew!.IDUser = model.ID;
                    dbContext.Add(permissionsMainUserTemNew);
                }
                //==================================================
                PermissionsMemo? permissionsMemo = await dbContext.permissionsMemo.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();// المذكرة
                if (permissionsMemo != null)
                {
                    permissionsMemo.Add = model.MemoAdd;
                    permissionsMemo.Edit = model.MemoEdit;
                    permissionsMemo.Delete = model.MemoDelete;
                    dbContext.Update(permissionsMemo);
                }
                else if (permissionsMemo == null)
                {
                    PermissionsMemo? permissionsMemoNew = new PermissionsMemo();
                    permissionsMemoNew!.Add = model.MemoAdd;
                    permissionsMemoNew!.Edit = model.MemoEdit;
                    permissionsMemoNew!.Delete = model.MemoDelete;
                    permissionsMemoNew!.IDUser = model.ID;
                    dbContext.Add(permissionsMemoNew);
                }
                //==================================================
                PermissionsMonthly? permissionsMonthly = await dbContext.permissionsMonthly.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync(); // الشهريات
                if (permissionsMonthly != null)
                {
                    permissionsMonthly.Add = model.MonthlyAdd;
                    permissionsMonthly.Edit = model.MonthlyEdit;
                    permissionsMonthly.Delete = model.MonthlyDelete;
                    dbContext.Update(permissionsMonthly);
                }
                else if (permissionsMonthly == null)
                {
                    PermissionsMonthly? permissionsMonthlyNew = new PermissionsMonthly();
                    permissionsMonthlyNew!.Add = model.MonthlyAdd;
                    permissionsMonthlyNew!.Edit = model.MonthlyEdit;
                    permissionsMonthlyNew!.Delete = model.MonthlyDelete;
                    permissionsMonthlyNew!.IDUser = model.ID;
                    dbContext.Add(permissionsMonthlyNew);
                }
                //==================================================
                PermissionsPayments? permissionsPayments = await dbContext.permissionsPayments.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync(); ;// المدفوعات
                if (permissionsPayments != null)
                {
                    permissionsPayments.Add = model.PaymentsAdd;
                    permissionsPayments.Edit = model.PaymentsEdit;
                    permissionsPayments.Delete = model.PaymentsDelete;
                    dbContext.Update(permissionsPayments);
                }
                else if (permissionsPayments == null)
                {
                    PermissionsPayments? permissionsPaymentsNew = new PermissionsPayments();
                    permissionsPaymentsNew!.Add = model.PaymentsAdd;
                    permissionsPaymentsNew!.Edit = model.PaymentsEdit;
                    permissionsPaymentsNew!.Delete = model.PaymentsDelete;
                    permissionsPaymentsNew!.IDUser = model.ID;
                    dbContext.Add(permissionsPaymentsNew);
                }
                //==================================================
                PermissionsProgramUser? permissionsProgramUser = await dbContext.permissionsProgramUser.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();// مستخدم البرنامج
                if (permissionsProgramUser != null)
                {
                    permissionsProgramUser.Add = false;
                    permissionsProgramUser.Edit = false;
                    permissionsProgramUser.Delete = false;
                    dbContext.Update(permissionsProgramUser);
                }
                else if (permissionsProgramUser == null)
                {
                    PermissionsProgramUser? permissionsProgramUserNew = new PermissionsProgramUser();
                    permissionsProgramUserNew!.Add = false;
                    permissionsProgramUserNew!.Edit = false;
                    permissionsProgramUserNew!.Delete = false;
                    permissionsProgramUserNew!.IDUser = model.ID;
                    dbContext.Add(permissionsProgramUserNew);
                }
                //==================================================
                PermissionsRepairWorkshops? permissionsRepairWorkshops = await dbContext.permissionsRepairWorkshops.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync() ;// ورشات التصليح
                if (permissionsRepairWorkshops != null)
                {
                    permissionsRepairWorkshops.Add = model.RepairWorkshopsAdd;
                    permissionsRepairWorkshops.Edit = model.RepairWorkshopsEdit;
                    permissionsRepairWorkshops.Delete = model.RepairWorkshopsDelete;
                    dbContext.Update(permissionsRepairWorkshops);
                }
                else if (permissionsRepairWorkshops == null)
                {
                    PermissionsRepairWorkshops? permissionsRepairWorkshopsNew = new PermissionsRepairWorkshops();
                    permissionsRepairWorkshopsNew!.Add = model.RepairWorkshopsAdd;
                    permissionsRepairWorkshopsNew!.Edit = model.RepairWorkshopsEdit;
                    permissionsRepairWorkshopsNew!.Delete = model.RepairWorkshopsDelete;
                    permissionsRepairWorkshopsNew!.IDUser = model.ID;
                    dbContext.Add(permissionsRepairWorkshopsNew);
                }
                //==================================================
                PermissionsSparePartsCenters? permissionsSparePartsCenters = await dbContext.permissionsSparePartsCenters.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();//مراكز قطع الغيار
                if (permissionsSparePartsCenters != null)
                {
                    permissionsSparePartsCenters.Add = model.SparePartsCentersAdd;
                    permissionsSparePartsCenters.Edit = model.SparePartsCentersEdit;
                    permissionsSparePartsCenters.Delete = model.SparePartsCentersDelete;
                    dbContext.Update(permissionsSparePartsCenters);
                }
                else if (permissionsSparePartsCenters == null)
                {
                    PermissionsSparePartsCenters? permissionsSparePartsCentersNew = new PermissionsSparePartsCenters();
                    permissionsSparePartsCentersNew!.Add = model.SparePartsCentersAdd;
                    permissionsSparePartsCentersNew!.Edit = model.SparePartsCentersEdit;
                    permissionsSparePartsCentersNew!.Delete = model.SparePartsCentersDelete;
                    permissionsSparePartsCentersNew!.IDUser = model.ID;
                    dbContext.Add(permissionsSparePartsCentersNew);
                }
                //==================================================
                PermissionsWorkCompanies? permissionsWorkCompanies = await dbContext.permissionsWorkCompanies.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync();// شركات العمل
                if (permissionsWorkCompanies != null)
                {
                    permissionsWorkCompanies.Add = model.WorkCompaniesAdd;
                    permissionsWorkCompanies.Edit = model.WorkCompaniesEdit;
                    permissionsWorkCompanies.Delete = model.WorkCompaniesDelete;
                    dbContext.Update(permissionsWorkCompanies);
                }
                else if (permissionsWorkCompanies == null)
                {
                    PermissionsWorkCompanies? permissionsWorkCompaniesNew = new PermissionsWorkCompanies();
                    permissionsWorkCompaniesNew!.Add = model.WorkCompaniesAdd;
                    permissionsWorkCompaniesNew!.Edit = model.WorkCompaniesEdit;
                    permissionsWorkCompaniesNew!.Delete = model.WorkCompaniesDelete;
                    permissionsWorkCompaniesNew!.IDUser = model.ID;
                    dbContext.Add(permissionsWorkCompaniesNew);
                }
                //==================================================
                PermissionsWorkDiary? permissionsWorkDiary = await dbContext.permissionsWorkDiary.Where(G => G.IDUser == model.ID).FirstOrDefaultAsync(); //يوميات العمل
                if (permissionsWorkDiary != null)
                {
                    permissionsWorkDiary.Add = model.WorkDiaryAdd;
                    permissionsWorkDiary.Edit = model.WorkDiaryEdit;
                    permissionsWorkDiary.Delete = model.WorkDiaryDelete;
                    dbContext.Update(permissionsWorkDiary);
                }
                else if (permissionsWorkDiary == null)
                {
                    PermissionsWorkDiary? permissionsWorkDiaryNew = new PermissionsWorkDiary();
                    permissionsWorkDiaryNew!.Add = model.WorkDiaryAdd;
                    permissionsWorkDiaryNew!.Edit = model.WorkDiaryEdit;
                    permissionsWorkDiaryNew!.Delete = model.WorkDiaryDelete;
                    permissionsWorkDiaryNew!.IDUser = model.ID;
                    dbContext.Add(permissionsWorkDiaryNew);
                }

                //===========================================================================








                dbContext.SaveChanges();
                return RedirectToAction("ScreenGeneralUser");
            }
          
            return View();
        }
    }

    
}
//bool isPresent = monthly.Any(C => C.WorkingHours == 100);هاي طريق لتفقد اذا كان الصنف في الحدول يطابق الشرط سيرجع القيمة نعم او لا 