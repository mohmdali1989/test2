using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
    public class SparePartsCenters //مراكز قطع الغيار
    {
        [Key]
        public int Id { get; set; }
        //=================================================================================================

        [Required(ErrorMessage = "ما هو اسم المركز")]
        [Display(Name = "اسم المركز")]
        public string NameCenter { get; set; } = string.Empty; // اسم المركز
        //=================================================================================================

        [Required(ErrorMessage = "ما هو موقع المركز")]
        [Display(Name = "موقع المركز")]

        public string CentrLocation {  get; set; } = string.Empty; // موقع المركز
        //=================================================================================================

        [Required(ErrorMessage = "ما هي تخصيص المركز")]
        [Display(Name = "تخصيص المركز")]
        public string CenterSpecialty { get; set;} = string.Empty; //مركز التخصص
        //=================================================================================================

        [Required(ErrorMessage = "ما هي مواعيد عمل المركز")]
        [Display(Name = "مواعيد عمل المركز")]
        [Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون مواعيد عمل المركز أكبر من 0")]

        public int CenterWorkingHours { get; set; } // مواعيد عمل المركز
        //=================================================================================================
        
        [NotMapped]
        public string? Error { get; set; }
        //-------------------------------------------------------------------------
        [NotMapped]
        public string Messages { get; set; } = "";

        //----------------------------------------------------

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
