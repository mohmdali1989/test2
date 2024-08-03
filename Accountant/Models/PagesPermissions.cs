using Accountant.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
    [Index(nameof(PagesPermissions.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PagesPermissions// صلاحيات الصفحات
    {
        [Key]
        public int Id { get; set; }
        public bool Briefs { get; set; }
        public bool Car { get; set; }
        public bool Company { get; set; }
        public bool CompanyDebts { get; set; }
        public bool CompanyObligations { get; set; }
        public bool Contracts { get; set; }
        public bool CustomerDebts { get; set; }
        public bool Driver { get; set; }
        public bool DriversDiary { get; set; }
        public bool Expenses { get; set; }
        public bool Fuel { get; set; }
        public bool FuelProvider { get; set; }
        public bool GeneralUser { get; set; }
        public bool InsuranceCar { get; set; }
        public bool LicenseCar { get; set; }
        public bool MainUser { get; set; }
        public bool MainUserTem { get; set; }
        public bool Memo { get; set; }
        public bool Monthly { get; set; }
        public bool Payments { get; set; }
        public bool ProgramUser { get; set; }
        public bool RepairWorkshops { get; set; }
        public bool SparePartsCenters { get; set; }
        public bool WorkCompanies { get; set; }
        public bool WorkDiary { get; set; }
        public bool InputCompany { get; set; }
        public bool TrafficViolations { get; set; }
        public bool ReportscCar { get; set; }


        public int IDUser { get; set; }
        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }
    }
    [Index(nameof(PermissionsTrafficViolations.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsTrafficViolations// مخالفات مرورية
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }
    }
    [Index(nameof(PermissionsReportscCar.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsReportscCar// التقارير الشهرية للسيارات
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }
    }
    [Index(nameof(PermissionsInputCompany.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsInputCompany// مدخلات الشركة
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }
    }
    [Index(nameof(PermissionsFuelProvider.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsFuelProvider// مصادر الوقود
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }
    }
    [Index(nameof(PermissionsDriversDiary.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsDriversDiary// يوميات السائقين
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }
    }
    [Index(nameof(PermissionsBriefs.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsBriefs// الايجازات
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }
    }
    [Index(nameof(PermissionsCar.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsCar//السيارات
    { 
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }
    }
    [Index(nameof(PermissionsCompany.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsCompany// الشركة
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }
    }
    [Index(nameof(PermissionsCompanyDebts.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsCompanyDebts// ديون الشركة
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }
    }
    [Index(nameof(PermissionsCompanyObligations.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsCompanyObligations// التزامات الشركة
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }
    }
    [Index(nameof(PermissionsContracts.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsContracts// العقود
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }
    }
    [Index(nameof(PermissionsCustomerDebts.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsCustomerDebts// ديون الزبائن
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }

       
       
        
    }
    [Index(nameof(PermissionsDriver.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsDriver// السائقين
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }


    }
    [Index(nameof(PermissionsExpenses.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsExpenses// المصاريف
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }
    }
    [Index(nameof(PermissionsFuel.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsFuel//الوقود
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }
    }
    [Index(nameof(PermissionsGeneralUser.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsGeneralUser// مستخدم عام
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }

    }
    [Index(nameof(PermissionsInsuranceCar.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsInsuranceCar// تامين السيارة
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }

    }
    [Index(nameof(PermissionsMainUser.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsLicenseCar// ترخيص السيارة
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }

    }
    [Index(nameof(PermissionsMainUser.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsMainUser//مستخدم رئيسي
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }

    }
    [Index(nameof(PermissionsMainUserTem.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsMainUserTem // مستخدم مؤقت
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }

    }
    [Index(nameof(PermissionsMemo.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsMemo// المذكرة
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }

    }
    [Index(nameof(PermissionsMonthly.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsMonthly // الشهريات
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }

    }
    [Index(nameof(PermissionsPayments.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsPayments// المدفوعات
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }

    }
    [Index(nameof(PermissionsProgramUser.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsProgramUser// مستخدم البرنامج
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }

    }
    [Index(nameof(PermissionsRepairWorkshops.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsRepairWorkshops// ورشات التصليح
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }

    }
    [Index(nameof(PermissionsSparePartsCenters.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsSparePartsCenters//مراكز قطع الغيار
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }

    }
    [Index(nameof(PermissionsWorkCompanies.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsWorkCompanies// شركات العمل
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }

    }
    [Index(nameof(PermissionsWorkDiary.IDUser), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class PermissionsWorkDiary //يوميات العمل
    {
        [Key]
        public int Id { get; set; }
        public int IDUser { get; set; }

        public bool Add { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

        [ForeignKey("IDUser")]
        public GeneralUser? IDUsers { get; set; }

    }

}
