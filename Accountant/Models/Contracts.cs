using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
    public class Contracts // العقود
    {
        [Key]

        public int Id { get; set; }
        //=================================================================================================

        [Required(ErrorMessage = "ما هو اسم الشركة")]
        [Display(Name = "اسم الشركة")]
        public string NameCompany { get; set; } = string.Empty; // اسم الشركة
        //=================================================================================================

        [Required(ErrorMessage = "ما هو عدد الساعات")]
        [Display(Name = "عدد الساعات")]
        [Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون عدد الساعات أكبر من 0")]

        public int NumberHours { get; set; } // عدد الساعات
        //=================================================================================================

        [Required(ErrorMessage = "ما هو عدد الأيام")]
        [Display(Name = "عدد الأيام")]
        [Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون عدد الأيام أكبر من 0")]

        public int NumberDays { get; set; } //عدد الأيام
        //=================================================================================================

        [Required(ErrorMessage = "ما هو سعر الساعة")]
        [Display(Name = "سعر الساعة")]
        [Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون سعر الساعة أكبر من 0")]

        public int WatchPrice {  get; set; } // سعر الساعة
        //=================================================================================================

        [Required(ErrorMessage = "ما هو موقع عمل الشركة")]
        [Display(Name = "موقع عمل الشركة")]
        public string CompanyWorkSite { get; set; } = string.Empty; //موقع عمل الشركة  
        //=================================================================================================

        [Required(ErrorMessage = "ما هو تاريخ انتهاء العقد")]
        [Display(Name = "تاريخ انتهاء العقد")]
        public DateTime ContractExpiryDate { get; set; } // تاريخ انتهاء العقد
        //=================================================================================================

        [Required(ErrorMessage = "ما هو تاريخ انتهاء العقد")]
        [Display(Name = "التاريخ")]
        public DateTime CreatedDate { get; set; } // تاريخ تسجيل البيانات
        //=================================================================================================
       
        [NotMapped]
        public string Error { get; set; } = "";
        [NotMapped]
        public string Messages { get; set; } = "";

        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }

        public int? IDMainUser { get; set; }
        [ForeignKey("IDMainUser")]
        public MainUser? MainUser { get; set; }

        public int? IDGeneralUser { get; set; }
        [ForeignKey("IDGeneralUser")]
        public GeneralUser? GeneralUser { get; set; }

    }
}
