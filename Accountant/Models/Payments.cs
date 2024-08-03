using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Accountant.Models
{
    public class Payments // المدفوعات
    {
        [Key]
        public int Id { get; set; }
        //=================================================================================================

        [Required(ErrorMessage = "من صاحب الدفعة")]
        [Display(Name = "صاحب الدفعة")]
        public string PaymentHolder { get; set; } = string.Empty;//  صاحب الدفعة
        //=================================================================================================

        [Required(ErrorMessage = "ما هو نوع الدفع")]
        [Display(Name = "نوع الدفع")]
        public string PaymentType { get; set; } = string.Empty; // نوع الدفع
        //=================================================================================================

        [Required(ErrorMessage = "ما هو مبلغ الدفع")]
        [Display(Name = "مبلغ الدفع")]
        [Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون مبلغ الدفع أكبر من 0")]

        public int PaymentAmount { get; set; } // مبلغ الدفع
        //=================================================================================================
 
        [Required(ErrorMessage = "ما هو تاريخ الدفع")]
        [Display(Name = "تاريخ الدفع")]

        public DateTime DatePayment { get; set; } // تاريخ الدفع
        //=================================================================================================


        //---------------------------------------------------
        public int? IDMainUser { get; set; }
        [ForeignKey("IDMainUser")]
        public MainUser? MainUser { get; set; }

        public int? IDGeneralUser { get; set; }
        [ForeignKey("IDGeneralUser")]
        public GeneralUser? GeneralUser { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }
        //---------------------------------------------------


    }
}
