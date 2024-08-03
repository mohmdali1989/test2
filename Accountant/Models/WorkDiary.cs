using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
    public class WorkDiary //يوميات العمل
    {
        [Key]
        public int Id { get; set; }
        //=================================================================================================

        [Required(ErrorMessage = "ما هو وسلة النقل")]
        [Display(Name = "وسلة النقل")]
        public string MeansTransportation { get; set; } = ""; // وسلة النقل
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

        [Required(ErrorMessage = "حقل سعر النقل فارغ")]
        [Display(Name = "سعر النقل")]
        [Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون سعر النقل أكبر من 0")]

        public int TransportationPrice { get; set; }  // سعر النقل
        //=================================================================================================
        
        [Required(ErrorMessage = "حقل التاريخ فارغ")]
        [Display(Name = "التاريخ")]
        public DateOnly CreatedDateOnly { get; set; } = DateOnly.FromDateTime(DateTime.Now);// التاريخ
        //=================================================================================================
        [Required(ErrorMessage = "حقل التاريخ فارغ")]
        [Display(Name = "التاريخ")]
        public TimeOnly CreatedDateTime { get; set; } = TimeOnly.FromDateTime(DateTime.Now);// التاريخ
        //=================================================================================================
         
        [Required(ErrorMessage = "حقل التاريخ فارغ")]
        [Display(Name = "التاريخ")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;// التاريخ

        //=================================================================================================
        [Required(ErrorMessage = "حقل عدد الحمولة فارغ")]
        [Display(Name = "عدد الحمولة")]
        [Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون عدد الحمولة أكبر من 0")]
        public int NumberLoad { get; set; }//عدد الحمولة
        //=================================================================================================

        [Required(ErrorMessage = "حقل الاسم فارغ")]
        [Display(Name = "نوع الدفع")]
        public string PaymentType { get; set; } = ""; // نوع الدفع
        [NotMapped]                                            //=================================================================================================
        public int Year { get; set; }
        [NotMapped]
        public int Month { get; set; }

        //=================================================================================================

        [NotMapped]
        public string? Error { get; set; }
        //-------------------------------------------------------------------------
        [NotMapped]
        public string Messages { get; set; } = "";

         
        //----------------------------------------------------
        public int? IDMainUser { get; set; }
        [ForeignKey("IDMainUser")]
        public MainUser? MainUser { get; set; }
        //------------------------------
        public int? IDGeneralUser { get; set; }
        [ForeignKey("IDGeneralUser")]
        public GeneralUser? GeneralUser { get; set; }
        //------------------------------
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }
        //------------------------------
        public int? CarId { get; set; }
        [ForeignKey("CarId")]
        public Car? car { get; set; }

        //------------------------------
        [Required(ErrorMessage = "من هو السائق")]
        [Display(Name = "السائق")]
        public int? DriverId { get; set; }
        [ForeignKey("DriverId")]
        public Driver? driver { get; set; }
        //------------------------------
        [Required(ErrorMessage = "ما هو المشغل")]
        [Display(Name = "المشغل")]
        public int? OperatorId { get; set; }  // المشغل
        [ForeignKey("OperatorId")]
        public WorkCompanies? workCompanies { get; set; }
                //------------------------------
        //------------------------------


    }
}
