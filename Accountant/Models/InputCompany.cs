using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
    public class InputCompany //مدخلات الشركة

    {
        [Key]
        public int Id { get; set; }

        public int IDWorkCompanies { get; set; }//رقم الشركه العمل
        [ForeignKey("IDWorkCompanies")]
        public WorkCompanies? workCompanies { get; set; }


        [Required(ErrorMessage = "ما هو المبلغ المالي المستلم ")]
        [Display(Name = "المبلغ المالي المستلم ")]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0.01, int.MaxValue, ErrorMessage = "يجب أن يكون سعر الصيانة أكبر من 0")]

        public decimal AmountMoneyReceived { get; set; } = 0; //المبلغ المالي المستلم 


        [Required(ErrorMessage = "ما هو التاريخ الستلام")]
        [Display(Name = "التاريخ الستلام ")]
        public DateOnly DateReceiptMoney { get; set; } = DateOnly.FromDateTime(DateTime.Now);


        //=================================================================================================

        public int? IDMainUser { get; set; }
        [ForeignKey("IDMainUser")]
        public MainUser? MainUser { get; set; }

        public int? IDGeneralUser { get; set; }
        [ForeignKey("IDGeneralUser")]
        public GeneralUser? GeneralUser { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }

        //=================================================================================================

        [NotMapped]
        public string? Error { get; set; }
        
        [NotMapped]
        public string Messages { get; set; } = "";
    }
}
