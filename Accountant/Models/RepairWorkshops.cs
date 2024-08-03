using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
    [Index(nameof(RepairWorkshops.NameRepairShop), nameof(RepairWorkshops.CompanyId), IsUnique = true)  ] //لجعل الحقل لا يتكرر 

    public class RepairWorkshops // ورشات التصليح
    {
        [Key] 
        public int Id { get; set; }
        //=================================================================================================

        [Required(ErrorMessage = "ما هو اسم ورشه التصليخ")]
        [Display(Name = "اسم ورشه التصليخ")]
        public string NameRepairShop { get; set; } = string.Empty; //اسم ورشه التصليخ
        //=================================================================================================

        [Required(ErrorMessage = "ما هو موقع الورشة")]
        [Display(Name = "موقع الورشة")]
        public string WorkshopLocation { get; set; } = string.Empty; //موقع الورشة
        //=================================================================================================

        [Required(ErrorMessage = "ما هو تخصص الورشة العمل")]
        [Display(Name = "تخصص الورشة العمل")]
        public string WorkshopSpecialty {  get; set; } = string.Empty;// تخصص الورشة العمل
        //=================================================================================================

        [Required(ErrorMessage = "ما هو ساعات الدوام الورشة")]
        [Display(Name = "ساعات الدوام الورشة")]
        [Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون ساعات الدوام الورشة أكبر من 0")]

        public int WorkingHours {  get; set; }//ساعات الدوام الورشة
        //=================================================================================================
        [NotMapped]
        public string? Error { get; set; }
        //-------------------------------------------------------------------------
        [NotMapped]
        public string Messages { get; set; } = "";

        //-------------------------------------------------
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }

        public int? IDMainUser { get; set; }
        [ForeignKey("IDMainUser")]
        public MainUser? MainUser { get; set; }

        public int? IDGeneralUser { get; set; }
        [ForeignKey("IDGeneralUser")]
        public GeneralUser? GeneralUser { get; set; }
        //-------------------------------------------------



    }
}
