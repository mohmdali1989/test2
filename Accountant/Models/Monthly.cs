using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;  
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Accountant.Models
{

    public class Monthly // الشهريات
    {
        [Key]
        public int id { get; set; }
        //=================================================================================================

        [Required(ErrorMessage = "ما هو اسم السائق")]
        [Display(Name = "اسم السائق")]
        public string DriverName { get; set; } = "";// اسم السائق
        //=================================================================================================

        [Required(ErrorMessage = "ما هو عدد ايام العمل")]
        [Display(Name = "عدد ايام العمل")]
        [Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون عدد ايام العمل أكبر من 0")]

        public int NumberWorkingDays { get; set; } //عدد ايام العمل
        //=================================================================================================

        //[Required(ErrorMessage = "ما هو عدد الساعات")]
        //[Display(Name = "عدد الساعات")]
        //[Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون عدد الساعات أكبر من 0")]

        //public int WorkingHours { get; set; } // عدد الساعات
      
        //=================================================================================================

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "المبلغ المحول ")]
        //[Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون مبلغ التحويل أكبر من 0")]


         
        public double? TransferAmount { get; set; } = 0; //مبلغ التحويل
        //=================================================================================================
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "المبلغ اتسليم بليد ")]
        //[Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون مبلغ تسليم باليد أكبر من 0")]

        public double? HandDeliveryAmount { get; set; } = 0;// مبلغ تسليم باليد
        //=================================================================================================
               //=================================================================================================


        //=================================================================================================
         [Required(ErrorMessage = "عدد أيام الإجازة")]
        [Display(Name = "عدد أيام الإجازة")]
        [Range(1, int.MaxValue, ErrorMessage = "يجب أن يكون عدد أيام الإجازة أكبر من 0")]


        public int NumberVacationDays { get; set; } //عدد أيام الإجازة
                                                    //[Required(ErrorMessage = "ما هي طريقة التسليم الشهرية")]
                                                    //[Display(Name = "طريقة التسليم الشهرية")]
                                                    //public string MonthlyDeliveryMethod { get; set; } = ""; //طريقة التسليم الشهرية
                                                    ////=================================================================================================
        [Required(ErrorMessage = "حقل التاريخ فارغ")]
        [Display(Name = "تاريخ استلام الشهرية")]
         
        public DateOnly MonthlyReceiptDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);//تاريخ استلام الشهرية
        //=================================================================================================
        [Required(ErrorMessage = "حقل التاريخ فارغ")]
        [Display(Name = "التاريخ")]
        public TimeOnly MonthlyReceiptTimer { get; set; } = TimeOnly.FromDateTime(DateTime.Now);// التاريخ
        //=================================================================================================


        //--------------------------------------------------
        public int monthlyTypeId { get; set; }// نوع الشهرية شهرية او يومي
        [ForeignKey("monthlyTypeId")]
        public MonthlyType? monthlyType { get; set; }

        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }


        public int? IDDriver { get; set; }
        [ForeignKey("IDDriver")]
        public Driver? driver { get; set; }


        public int? IDMainUser { get; set; }
        [ForeignKey("IDMainUser")]
        public MainUser? MainUser { get; set; }

        public int? IDGeneralUser { get; set; }
        [ForeignKey("IDGeneralUser")]
        public GeneralUser? GeneralUser { get; set; }
        //--------------------------------------------------


    }
}
