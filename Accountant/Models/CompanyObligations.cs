using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
    public class CompanyObligations// التزامات الشركة
    {
        [Key]
        public int Id { get; set; }
        //=================================================================================================

        [Required(ErrorMessage = "ما هو نوع الاتزام")]
        [Display(Name = "نوع الاتزام")]
        public string CommitmentType { get; set; } = string.Empty; // نوع الاتزام
        //=================================================================================================

        [Required(ErrorMessage = "ما هو مبلغ الدين")]
        [Display(Name = "مبلغ الدين")]
        [Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون مبلغ الدين أكبر من 0")]

        public int AmountDebt { get; set; } //مبلغ الدين 
        //=================================================================================================

        [Required(ErrorMessage = "ما هو تاريخ الدين")]
        [Display(Name = "تاريخ الدين")]
        public DateTime PaymentDate { get; set; } //تاريخ الدين
        //=================================================================================================

        [Required(ErrorMessage = "ما هو اخر تاريخ لدفعة")]
        [Display(Name = "اخر تاريخ لدفعة")]
        public DateTime LastDatePayment { get; set; } // اخر تاريخ لدفعة
        //=================================================================================================

        [Required(ErrorMessage = "ما هو نوع الدفع")]
        [Display(Name = "نوع الدفع")]
        public string PaymentType { get; set; } = string.Empty; // نوع الدفع
        //=================================================================================================

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
