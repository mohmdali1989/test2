using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
    public class Fuel //الوقود
    {
        [Key]
        public int id { get; set; }
        //=================================================================================================


        [Required(ErrorMessage = "ما هو تاريخ التزويد الوقود")]
        [Display(Name = "تاريخ التزويد الوقود")]

        public DateTime SupplyDate { get; set; } = DateTime.Now;// تاريخ التزويد
        //=================================================================================================
        public DateOnly SupplyDateOnly { get; set; } = DateOnly.FromDateTime(DateTime.Now);// التاريخ
        //=================================================================================================
        [Required(ErrorMessage = "حقل التاريخ فارغ")]
        [Display(Name = "التاريخ")]
        public TimeOnly SupplyTimeOnly { get; set; } = TimeOnly.FromDateTime(DateTime.Now);// التاريخ



        [Required(ErrorMessage = "ما هو كمية الوقود")]
        [Display(Name = "كمية الوقود")]
        [Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون كمية الوقود أكبر من 0")]

        public int FuelQuantity { get; set; } // كمية الوقود
        //=================================================================================================


        [Required(ErrorMessage = "ما هو نوع الوقود")]
        [Display(Name = "نوع الوقود")]
        public string FuelType { get; set; } = ""; // نوع الوقود
        //=================================================================================================


        //=================================================================================================

        [NotMapped]
        public int Year { get; set; }
        [NotMapped]
        public int Month { get; set; }

        [NotMapped]
        public string? Error { get; set; }
        //-------------------------------------------------------------------------
        [NotMapped]
        public string Messages { get; set; } = "";


        //--------------------------------------------------
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }
        public int? IDMainUser { get; set; }
        [ForeignKey("IDMainUser")]
        public MainUser? MainUser { get; set; }

        public int? IDGeneralUser { get; set; }
        [ForeignKey("IDGeneralUser")]
        public GeneralUser? GeneralUser { get; set; }
        public int? CarId { get; set; }
        [ForeignKey("CarId")]
        public Car? Car { get; set; }
        [Required(ErrorMessage = "من هو مزود الوقود")]
        [Display(Name = "مزود الوقود")]
        public int? FuelProviderID { get; set; }
        [ForeignKey("FuelProviderID")]
        public FuelProvider? Fuelprovider { get; set; }
        [Required(ErrorMessage = "ما هو تاريخ تزويد الوقود")]
        [Display(Name = "تاريخ تزويد الوقود")]
        public int? workDiaryID { get; set; }
        [ForeignKey("workDiaryID")]
        public WorkDiary? workDiary { get; set; }


        //--------------------------------------------------

    }
}
