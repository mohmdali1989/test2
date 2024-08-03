using Accountant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml;


namespace Accountant.Data
{
    public class DataContextDB : DbContext
    {
        public DataContextDB(DbContextOptions<DataContextDB> options) : base(options)
        {

        }

        // الصلاحيات
        public DbSet<PagesPermissions> pagesPermissions { get; set; }
        public DbSet<PermissionsBriefs> permissionsBriefs { get; set; }
        public DbSet<PermissionsCar> permissionsCar { get; set; }
        public DbSet<PermissionsCompany> permissionsCompany { get; set; }
        public DbSet<PermissionsCompanyDebts> permissionsCompanyDebts { get; set; }
        public DbSet<PermissionsCompanyObligations> permissionsCompanyObligations { get; set; }
        public DbSet<PermissionsContracts> permissionsContracts { get; set; }
        public DbSet<PermissionsCustomerDebts> permissionsCustomerDebts { get; set; }
        public DbSet<PermissionsDriver> permissionsDriver { get; set; }
        public DbSet<PermissionsExpenses> permissionsExpenses { get; set; }
        public DbSet<PermissionsFuel> PermissionsFuel { get; set; }
        public DbSet<PermissionsGeneralUser> permissionsGeneralUser { get; set; }
        public DbSet<PermissionsInsuranceCar> permissionsInsuranceCar { get; set; }
        public DbSet<PermissionsLicenseCar> permissionsLicenseCar { get; set; }
        public DbSet<PermissionsMainUser> permissionsMainUser { get; set; }
        public DbSet<PermissionsMainUserTem> permissionsMainUserTem { get; set; }
        public DbSet<PermissionsMemo> permissionsMemo { get; set; }
        public DbSet<PermissionsMonthly> permissionsMonthly { get; set; }
        public DbSet<PermissionsPayments> permissionsPayments { get; set; }
        public DbSet<PermissionsProgramUser> permissionsProgramUser { get; set; }
        public DbSet<PermissionsRepairWorkshops> permissionsRepairWorkshops { get; set; }
        public DbSet<PermissionsSparePartsCenters> permissionsSparePartsCenters { get; set; }
        public DbSet<PermissionsWorkCompanies> permissionsWorkCompanies { get; set; }
        public DbSet<PermissionsWorkDiary> permissionsWorkDiary { get; set; }
        public DbSet<PermissionsDriversDiary> permissionsDriversDiary { get; set; }
        public DbSet<PermissionsFuelProvider> permissionsFuelProvider { get; set; }
        public DbSet<PermissionsInputCompany> permissionsInputCompany { get; set; }
        public DbSet<PermissionsReportscCar> permissionsReportscCar { get; set; }
        public DbSet<PermissionsTrafficViolations> permissionsTrafficViolations { get; set; }

        // ============================================================================================
        public DbSet<Briefs> briefs { get; set; }
        public DbSet<Car> car { get; set; }
        public DbSet<CarLicense> carLicense { get; set; }
        public DbSet<CarInsurance> carInsurance { get; set; }
        public DbSet<Company> company { get; set; }
        public DbSet<CompanyDebts> companyDebts { get; set; }
        public DbSet<CompanyObligations> companyObligations { get; set; }
        public DbSet<Contracts> contracts { get; set; }
        public DbSet<CustomerDebts> customerDebts { get; set; }
        public DbSet<Driver> driver { get; set; }
        public DbSet<DriversDiary> driversDiary { get; set; }
        public DbSet<Expenses> expenses { get; set; }
        public DbSet<Fuel> fuel { get; set; }
        public DbSet<GeneralUser> generalUser { get; set; }
        public DbSet<MainUser> mainUser { get; set; }
        public DbSet<MainUserTem> mainUserTem { get; set; }
        public DbSet<Monthly> monthly { get; set; }
        public DbSet<Payments> payments { get; set; }
         
        public DbSet<RepairWorkshops> repairWorkshops { get; set; }
        public DbSet<SparePartsCenters> sparePartsCenters { get; set; }
        public DbSet<WorkCompanies> workCompanies { get; set; }
        public DbSet<WorkDiary> workDiary { get; set; }
        public DbSet<InputCompany> inputCompany { get; set; }
        public DbSet<TrafficViolations> trafficViolations { get; set; }
        public DbSet<FuelProvider> fuelProvider { get; set; }
        
        public DbSet<MonthlyType> MonthlyTypes { get; set; }
        public DbSet<ProgramUser> programUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MonthlyType>()
                .Property(e => e.id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<MonthlyType>().HasData(
                new MonthlyType
                {
                    id = 1,
                    MonthlyOrMemoirs = 0,
                    MonthlyOrMemoirsName = "الشهريات"
                },
                new MonthlyType
                {
                    id = 2,
                    MonthlyOrMemoirs = 1,
                    MonthlyOrMemoirsName = "اليوميات"
                }
            );
            modelBuilder.Entity<ProgramUser>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ProgramUser>().HasData(
                new ProgramUser
                {
                    Id = 1,
                    Name = "mohmd",
                    Password = "123"
                }
               
            );
            modelBuilder.Entity<MainUser>().HasData(
                new MainUser
                {
                    Id = 1,
                    Name = "mohmdali",
                    Password = "123",
                    Confirmed = true
                }

            ) ;
        }
          

        //============================================================================================


    }
}
//add-migration Accountant  ياخذ اخر عمليات من المغيرات الى حصلت بعد اخر مايجريشن
//Remove-Migration             حذف اخر مايجريشن
//Remove-Migration -Force      واذا لم ينجح الحدذف نجرب هاي الطريقة    
//update-database              تطبيق المايجريشن  على الداتا بيز بعد المراجعه 
// اذا اردنا انشاء قاعده بيانات معينه يجب بعد كاتبه الامر انشاء نضع اسم الكلاس الذي نريد انشاىه

