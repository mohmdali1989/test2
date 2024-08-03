using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
    public class DriversDiary //يوميات السائقين
    {
        [Key]
        public int ID { get; set; }
        //=================================================================================================
        public int? DriverId { get; set; }
        [ForeignKey("DriverId")]
        public Driver? driver { get; set; }//بدل اسم السائق ربع مع حدول السائقين

        //=================================================================================================
        //[Required(ErrorMessage = "ما هو موقع النقل")]
        //[Display(Name = "موقع النقل")]
        //public int NumberOmoves { get; set; }//  عدد النقلات
        //=================================================================================================


        [Required(ErrorMessage = "ما هو موقع النقل")]
        [Display(Name = "موقع النقل")]
        public string TransportationLocation { get; set; } = ""; // موقع النقل
        //=================================================================================================

        [Required(ErrorMessage = "ما هو موقع التسليم")]
        [Display(Name = "موقع التسليم")]
        public string DeliveryLocation { get; set; } = ""; // موقع التسليم
        //=================================================================================================
        [Required(ErrorMessage = "ما هو نوع الحمولة")]
        [Display(Name = "نوع الحمولة")]
        public string LoadType { get; set; } = ""; // نوع الحمولة
        //=================================================================================================

        [Required(ErrorMessage = "حقل التاريخ فارغ")]
        [Display(Name = "التاريخ")]
        public DateOnly CreatedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);// التاريخ
        
        [Column(TypeName = "time(0)")]
        public TimeSpan CreatedTime {  get; set; } = new TimeSpan();
        //=================================================================================================


        //-------------------------------------------------------------------------
        [NotMapped]
        public int? TripCount { get; set; } // عدد الرحلات في داله تقوم بجمع الرحلات حسب التاريخ
        [NotMapped]
        public string? Error { get; set; }
        [NotMapped]
        public string? Messages { get; set; }
        //-------------------------------------------------------------------------

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
        public Car? car { get; set; }

        
    }
}
