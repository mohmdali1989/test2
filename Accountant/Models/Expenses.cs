using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
    public class Expenses // المصاريف
    {
        [Key]
        public int Id { get; set; }
        //=================================================================================================

        [Required(ErrorMessage = "ما هو نوع السيارة")]
        [Display(Name = "نوع السيارة")]
        public string TypeCar { get; set; } = string.Empty;// نوع السيارة
        //=================================================================================================

        [Required(ErrorMessage = "ما هو نوع القطعة")]
        [Display(Name = "اسم القطعة")]
        public string NamePiece { get; set; } = string.Empty;//اسم القطعة 
        //=================================================================================================
        
        [Required(ErrorMessage = "ما هو سعر القطعة")]
        [Display(Name = "سعر القطعة")]
        [Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون سعر القطعة أكبر من 0")]
        
        public int UnitPrice{get; set;}
        //=================================================================================================


        [Required(ErrorMessage = "ما هو عدد القطع")]
        [Display(Name = "عدد القطع")]
        [Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون عدد القطع  أكبر من 0")]

        public int NumberPieces { get; set; } // عدد القطع 
        //=================================================================================================


        // الحقل الثالث الذي يجمع الحقلين
        public int TotalPrice{ get; set; }


        [Required(ErrorMessage = "ما هو سعر الصيانه")]
        [Display(Name = "تكلفة الصيانه")]
        [Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون تكلفة الصيانه أكبر من 0")]

        public int MaintenancePrice { get; set; } //تكلفة الصيانه
        //=================================================================================================



        public string? Image { get; set; }  //صورة
        //=================================================================================================



        [Required(ErrorMessage = "ما هو تاريخ الصرف")]
        [Display(Name = "تاريخ الصرف")]
        //[DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateOnly DateExchange { get; set; } = DateOnly.FromDateTime(DateTime.Now);// تاريخ الصرف
        //=================================================================================================
        [NotMapped]
        public int Total { get; set; }
        [NotMapped]
        public int Year { get; set; }
        [NotMapped]
        public int Month { get; set; }
        [NotMapped]
        public string? Error { get; set; }
        //-------------------------------------------------------------------------
        [NotMapped]
        public string? Messages { get; set; } 



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

        public int? CarId { get; set; }
        [ForeignKey("CarId")]
        public Car? car { get; set; } // السيارات

        [Required(ErrorMessage = "ما هو موقع شراء القطع")]
        [Display(Name = "موقع شراء القطع")]
        public int? PartsId { get; set; }
        [ForeignKey("PartsId")]

        public SparePartsCenters? sparePartsCenters { get; set; }//مراكز قطع الغيار
        [Required(ErrorMessage = "ما هو موقع الصيانه")]
        [Display(Name = "موقع الصيانه")]
        public int? WorkshopsID { get; set; }
        [ForeignKey("WorkshopsID")]
        public RepairWorkshops? repairWorkshops { get; set; }// ورشات التصليح






        //------------------------------------------------

    }
}
