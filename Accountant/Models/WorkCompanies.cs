using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Accountant.Models
{
    /*[Index(nameof(WorkCompanies.CompanyName), IsUnique = true)]*/ //لجعل الحقل لا يتكرر 
    [Index(nameof(WorkCompanies.CompanyName), nameof(WorkCompanies.CompanyId), IsUnique = true)]

    public class WorkCompanies // شركات العمل
    {
        [Key]
        public int Id { get; set; }
        //=================================================================================================

        [Required(ErrorMessage = "ما هيو اسم الشركة")]
        [Display(Name = "اسم الشركة")]
        public string CompanyName { get; set; } = "";// اسم الشركة

        //=================================================================================================

        [Required(ErrorMessage = "ما هو رقم الهاتف")]
        [Display(Name = "رقم الهاتف")]
        public string phoneNumber { get; set; } = ""; // رقم الهاتف

        //=================================================================================================

        [Required(ErrorMessage = "ما هي عدد الساعات الافتراضية")]
        [Display(Name = "عدد الساعات الافتراضية")]
        public string NumberVirtualHours { get; set; } = "";//عدد الساعات الافتراضية

        //=================================================================================================
        
        [Required(ErrorMessage = "ما هو سعر الساعة")]
        [Display(Name = "سعر الساعة")]
        [Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون الساعة أكبر من 0")]

        public int WatchPrice { get; set; } // سعر الساعة
        //=================================================================================================

        [Required(ErrorMessage = "ما هي عدد الأيام الافتراضية")]
        [Display(Name = "عدد الأيام الافتراضية")]
        public string DefaultNumberDays { get; set; } = ""; //عدد الأيام الافتراضية
        //=================================================================================================

        [Required(ErrorMessage = "ما هو موقع عمل الشركة")]
        [Display(Name = "موقع عمل الشركة")]
        public string CompanyWorkSite { get; set; } = string.Empty; //موقع عمل الشركة
        //=================================================================================================

         
        [Display(Name = "صورة من العقد")]
        public string? PictureOfCntract { get; set; } = string.Empty; //صوره من العقد
        //=================================================================================================

        [Required(ErrorMessage = "ما هو تاريخ انتهاء العقد")]
        [Display(Name = "تاريخ انتهاء العقد")]
        public DateTime ContractExpiryDate { get; set; } // تاريخ انتهاء العقد
        //=================================================================================================

        [Required(ErrorMessage = "ما هو التاريخ")]
        [Display(Name = "التاريخ")]
        public DateTime CreatedDate { get; set; }// التاريخ

        //=================================================================================================
 
        //------------------------------------------------
        public int? IDMainUser { get; set; }
        [ForeignKey("IDMainUser")]
        public MainUser? MainUser { get; set; }

        public int? IDGeneralUser { get; set; }
        [ForeignKey("IDGeneralUser")]
        public GeneralUser? GeneralUser { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }

        //------------------------------------------------

        [NotMapped]
        public string? Error { get; set; }
        //-------------------------------------------------------------------------
        [NotMapped]
        public string Messages { get; set; } = "";
    }
}
 