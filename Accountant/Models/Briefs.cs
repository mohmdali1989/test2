using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
    public class Briefs // الايجازات
    {
        [Key]
        public int id {  get; set; }
        //=================================================================================================

        [Required(ErrorMessage = "ما هو  اسم السائق ")]
        [Display(Name = "اسم السائق")]
        public string DriverName { get; set; } = "";// اسم السائق
        //=================================================================================================

        [Required(ErrorMessage = "ما هو تاريخ الايجازه  ")]
        [Display(Name = "تاريخ الايجازه")]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = true)]

        public DateTime VacationDate { get; set; } = DateTime.Now;// تاريخ الايجازه
        //=================================================================================================

        [Required(ErrorMessage = "يجب اختيار اذا كان مدفوع الراتب ام غير مدفوع")]
        [Display(Name = "مدفوع الايجازه")]
        public bool PushStatus { get; set; }  //حاله الدفع يعني الايجازه مدفوعة او لا 
        //=================================================================================================

        [Required(ErrorMessage = "ما هو سبب الايجازه")]
        [Display(Name = "سبب الايجازه")]
        public string PushStatusDescription { get; set; } = "";  //سبب الايجازه
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

        public int? IDDriver { get; set; }
        [ForeignKey("IDDriver")]
        public Driver? Drivers { get; set; }

        public int? IDGeneralUser { get; set; }
        [ForeignKey("IDGeneralUser")]
        public GeneralUser? GeneralUser { get; set; }

    }
}
