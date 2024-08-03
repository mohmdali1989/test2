using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
    
    [Index(nameof(Driver.Name), nameof(Driver.CompanyId), IsUnique = true) ] //لجعل الحقل لا يتكرر 
     
    public class Driver // السائقين
    {
        [Key]
        public int Id { get; set; }
        //=================================================================================================

        [Required(ErrorMessage = "ما هو الاسم السائق")]
        [Display(Name = "الاسم السائق")]
        public string Name { get; set; } = ""; //  الاسم السائق
        //=================================================================================================

        [Required(ErrorMessage = "ما هو رقم الهواية")]
        [Display(Name = "رقم الهواية")]
        public string HobbyNumber { get; set; } = ""; // رقم الهواية
        //=================================================================================================

        [Required(ErrorMessage = "ما هو رقم الهاتف")]
        [Display(Name = "رقم الهاتف")]
        public string PhoneNumber { get; set; } = ""; // رقم الهاتف

        //=================================================================================================

        [Required(ErrorMessage = "ما هو تاريخ انتهاء الترخيص")]
        [Display(Name = "تاريخ انتهاء الترخيص")]

        public DateTime LicenseExpirationDate { get; set; } // تاريخ انتهاء الترخيص
        //=================================================================================================

        [Required(ErrorMessage = "ما هو تاريخ")]
        [Display(Name = "تاريخ")]
        public DateTime CreatedDate { get; set; } // تاريخ الأنشاء
        //=================================================================================================
        [Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون عدد ايام العمل أكبر من 0")]
        [Required(ErrorMessage = " ما هو عدد ايام العمل")]
        [Display(Name = " عدد ايام العمل")]
        public int? NumberWorkingDays { get; set; } = 0; //عدد ايام العمل 
        //=================================================================================================
        [Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون كمية الشهرية أكبر من 0")]
        [Column(TypeName = "decimal(18, 2)")]

        [Required(ErrorMessage = " ما هو البلغ الشهرية" )]
        [Display(Name = " المبلغ الشهرية")]
        public decimal? Amount { get; set; } = 0; //المبلغ الشهرية 
        //=================================================================================================
        [NotMapped]
        public string Error { get; set; } = "";
        [NotMapped]
        public string Messages { get; set; } = "";

        //=================================================================================================
        public int monthlyTypeId { get; set; }// نوع الشهرية شهرية او يومي

       
        [ForeignKey("monthlyTypeId")]
        public MonthlyType? monthlyType { get; set; }
        public int? IDMainUser { get; set; }
        [ForeignKey("IDMainUser")]
        public MainUser? MainUser { get; set; }

        public int? IDGeneralUser { get; set; }
        [ForeignKey("IDGeneralUser")]
        public GeneralUser? GeneralUser { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }


        

    }
}
