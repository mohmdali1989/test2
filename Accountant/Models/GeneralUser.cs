using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Accountant.Models
{
    [Index(nameof(GeneralUser.Name), nameof(GeneralUser.CompanyId), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class GeneralUser// مستخدم عام
    {
        [Key]
        public int ID { get; set; }
        //=================================================================================================

        [Required(ErrorMessage = "حقل الاسم فارغ")]
        [Display(Name = "الاسم")]
        public string Name { get; set; } = ""; // الاسم المستخدم
        //=================================================================================================

        [Required(ErrorMessage = "حقل الباسورد فارغ")]
        [Display(Name = "الباسورد")]
        [PasswordPropertyText]
        public string Password { get; set; } = ""; //الباسورد 
        //=================================================================================================

        [NotMapped]
        [Display(Name = "اعاده كتابة الباسورد")]
        [Compare("Password", ErrorMessage = "الباسورد غير مطابق")]
        [Required(ErrorMessage = "حقل الباسورد فارغ")]
        [PasswordPropertyText]
        public string ConfirmedPaswword { get; set; } = ""; //تاكيد الباسورد
        //=================================================================================================

        [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = true)]
        [Display(Name = "تاريخ النشاء الحساب")]
        [Required(ErrorMessage = "حقل التاريخ غير معدل")]
        public DateTime CreatedDate { get; set; } // التاريخ
        //=================================================================================================
        public bool Confirmed { get; set; } //الحاله الحساب
        //=================================================================================================
        public int IDMainUser { get; set; }
        [ForeignKey("IDMainUser")]
        public MainUser? MainUser { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }


        [NotMapped]
        public string Error { get; set; } = "";
        [NotMapped]
        public string Messages { get; set; } = "";

        //[Required(ErrorMessage = "اختر احد الصلاخيات")]
        [NotMapped]
         
        public string? Validity { get; set; }
        // ==========================================
        [NotMapped]
        [Display(Name = "اليجازات")]
        public bool Briefs { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool BriefsAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool BriefsEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool BriefsDelete { get; set; }

        //===========================================

        // ==========================================
        [NotMapped]
        [Display(Name = "سيارات")]
        public bool Car { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool CarAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool CarEdit { get; set; }
        [NotMapped]
        [Display(Name = "خذف")]
        public bool CarDelete { get; set; }

        //===========================================

        // ==========================================
        [NotMapped]
        [Display(Name = "تامين السيارات")]
        public  bool CarInsurance { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool CarInsuranceAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool CarInsuranceEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public  bool CarInsuranceDelete { get; set; }

        //===========================================

        // ==========================================
        [NotMapped]
        [Display(Name = "ترخيص اليسارات")]
        public bool CarLicense { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool CarLicenseAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool CarLicenseEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool CarLicenseDelete { get; set; }

        //===========================================

        // ==========================================
        [NotMapped]
        [Display(Name = "اضافة شركات")]
        public bool Companys { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool CompanysAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool CompanysEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool CompanysDelete { get; set; }

        //===========================================

        // ==========================================
        [NotMapped]
        [Display(Name = "ديون الشركات")]
        public bool CompanyDebts { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool CompanyDebtsAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool CompanyDebtsEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool CompanyDebtsDelete { get; set; }

        //===========================================

        // ==========================================
        [NotMapped]
        [Display(Name = "التزامات الشركة")]
        public bool CompanyObligations { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool CompanyObligationsAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool CompanyObligationsEdit { get; set; }
        [NotMapped]
        [Display(Name = "خذف")]
        public bool CompanyObligationsDelete { get; set; }

        //===========================================

        // ==========================================
        [NotMapped]
        [Display(Name = "العقود")]
        public bool Contracts { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool ContractsAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool ContractsEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool ContractsDelete { get; set; }

        //===========================================

        // ==========================================
        [NotMapped]
        [Display(Name = "ديون الزبائن")]
        public bool CustomerDebts { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool CustomerDebtsAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool CustomerDebtsEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool CustomerDebtsDelete { get; set; }

        //===========================================

        // ==========================================
        [NotMapped]
        [Display(Name = "السائقين")]
        public bool Driver { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool DriverAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool DriverEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool DriverDelete { get; set; }

        //===========================================

        // ==========================================
        [NotMapped]
        [Display(Name = "المصاريف")]
        public bool Expenses { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool ExpensesAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool ExpensesEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool ExpensesDelete { get; set; }

        //===========================================

        // ==========================================
        [NotMapped]
        [Display(Name = "الوقود")]
        public bool Fuel { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool FuelAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool FuelEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool FuelDelete { get; set; }


        // ==========================================
        [NotMapped]
        [Display(Name = "المستخدين")]
        public bool GeneralUsers { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool GeneralUsersAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool GeneralUsersEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool GeneralUsersDelete { get; set; }

        //===========================================

        // ==========================================
        [NotMapped]
        [Display(Name = "المستخدم الرئيسي")]
        public bool MainUsers { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool MainUsersAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool MainUsersEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool MainUsersDelete { get; set; }

        //===========================================

        // ==========================================
        [NotMapped]
        public bool MainUserTem { get; set; }
        [NotMapped]
        public bool MainUserTemAdd { get; set; }
        [NotMapped]
        public bool MainUserTemEdit { get; set; }
        [NotMapped]
        public bool MainUserTemDelete { get; set; }

        //===========================================

        // ==========================================
        [NotMapped]
        [Display(Name = "المذكرة")]
        public bool Memo { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool MemoAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool MemoEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool MemoDelete { get; set; }

        //===========================================

        // ==========================================
        [NotMapped]
        [Display(Name = "الشهريات")]
        public bool Monthly { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool MonthlyAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool MonthlyEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool MonthlyDelete { get; set; }

        //===========================================

        // ==========================================
        [NotMapped]
        [Display(Name = "المدفوعات")]
        public bool Payments { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool PaymentsAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool PaymentsEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool PaymentsDelete { get; set; }

        //===========================================

        // ==========================================
        [NotMapped]
        [Display(Name = "مستخدم مسؤول البرنامج")]
        public bool ProgramUser { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool ProgramUserAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool ProgramUserEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool ProgramUserDelete { get; set; }

        //===========================================

        // ==========================================
        [NotMapped]
        [Display(Name = "ورشات التصليح")]
        public bool RepairWorkshops { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool RepairWorkshopsAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool RepairWorkshopsEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool RepairWorkshopsDelete { get; set; }

        //===========================================

        // ==========================================
        [NotMapped]
        [Display(Name = "مراكز الغيار")]
        public bool SparePartsCenters { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool SparePartsCentersAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool SparePartsCentersEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool SparePartsCentersDelete { get; set; }

        //===========================================

        // ==========================================
        [NotMapped]
        [Display(Name = "شركات العمل")]
        public bool WorkCompanies { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool WorkCompaniesAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool WorkCompaniesEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool WorkCompaniesDelete { get; set; }


        // ==========================================
        [NotMapped]
        [Display(Name = "يوميات العمل")]
        public bool WorkDiary { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool WorkDiaryAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool WorkDiaryEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool WorkDiaryDelete { get; set; }

        //===========================================
        // ==========================================
        [NotMapped]
        [Display(Name = "يوميات السائقين")]
        public bool DriversDiary { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool DriversDiaryAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool DriversDiaryEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool DriversDiaryDelete { get; set; }

        //===========================================
        // ==========================================
        [NotMapped]
        [Display(Name = "مزود الوقود")]
        public bool FuelProvider { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool FuelProviderAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool FuelProviderEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool FuelProviderDelete { get; set; }

        //===========================================
        [NotMapped]
        [Display(Name = "مدخلات الشركة")]
        public bool InputCompany { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool InputCompanyAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool InputCompanyEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool InputCompanyDelete { get; set; }

        //===========================================
        [NotMapped]
        [Display(Name = "مخالفات")]
        public bool TrafficViolations { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool TrafficViolationsAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool TrafficViolationsEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool TrafficViolationsDelete { get; set; }

        //===========================================
        [NotMapped]
        [Display(Name = "تقارير الشهريه")]
        public bool ReportscCar { get; set; }
        [NotMapped]
        [Display(Name = "اضافة")]
        public bool ReportscCarAdd { get; set; }
        [NotMapped]
        [Display(Name = "تعديل")]
        public bool ReportscCarEdit { get; set; }
        [NotMapped]
        [Display(Name = "حذف")]
        public bool ReportscCarDelete { get; set; }

        //===========================================
    }
}
