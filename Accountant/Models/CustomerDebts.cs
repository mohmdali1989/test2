using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
    public class CustomerDebts// ديون الزبائن
    {
        [Key]
        public int Id { get; set; }
         
        public int? DriverID { get; set; } //رقم السائق
        [ForeignKey("DriverID")]
        public Driver? Driver { get; set; }
        //=================================================================================================

        [Required(ErrorMessage = "ما هو مبلغ الدين")]
        [Display(Name = "مبلغ الدين")]
        [Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون مبلغ الدين أكبر من 0")]

        public int AmountDebt { get; set; } //مبلغ الدين
        //=================================================================================================

        [Required(ErrorMessage = "ما هو تاريخ الدين")]
        [Display(Name = "تاريخ الدين")]
        public DateTime HistoryReligion { get; set; } //تاريخ الدين
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
