using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
    [Index(nameof(Car.CarNumber), nameof(Car.CompanyId), IsUnique = true)] //لجعل الحقل لا يتكرر 
    public class Car // السيارات
    {
        [Key]
        public int Id { get; set; }
        //=================================================================================================

        [Required(ErrorMessage = "ما هو اسم السيارة")]
        [Display(Name = "اسم السيارة")]
        public string NameCar { get; set; } = ""; //اسم السيارة
        //=================================================================================================

        [Required(ErrorMessage = "ما هو رقم السيارة")]
        [Display(Name = "رقم السيارة")]
        public string CarNumber { get; set; } = ""; // رقم السيارة
        //=================================================================================================

        [Required(ErrorMessage = "ما هو اقصى حمولة للسيارة")]
        [Display(Name = "اقصى حمولة")]
        public string MaximumLoad { get; set; } = ""; // اقصى حمولة
        //=================================================================================================

        [Required(ErrorMessage = "ما هو وزن السيارة")]
        [Display(Name = "وزن السيارة")]
        public string CarWeight { get; set; } = ""; //وزن السيارة
        //=================================================================================================

        [Required(ErrorMessage = "ما هو موديل السيارة ")]
        [Display(Name = "موديل السيارة")]
        public string CarModel { get; set; } = ""; //موديل السيارة
        //=================================================================================================
        [Required(ErrorMessage = "ما هو نوع السيارة ")]
        [Display(Name = "نوع السيارة")]
        public string CarType { get; set; } = ""; //نوع السيارة
        //=================================================================================================

        [Required(ErrorMessage = "ما هو التاريخ")]
        [Display(Name = "تاريخ")]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; } // تاريخ الانشاء
        //=================================================================================================

        [NotMapped]
        public string InsuranceType { get; set; } = ""; //نوع التامين

        [NotMapped]
        [Required(ErrorMessage = "ما هو تاريخ بداية التامين")]
        [Display(Name = "تاريخ بداية التامين")]
        [DisplayFormat(DataFormatString = " - - ", ApplyFormatInEditMode = true)]


        public DateTime LicenseStartDate { get; set; } //تاريخ بداية التامين
        
        [NotMapped]
        [Required(ErrorMessage = " ما هو تاريخ انتهاء التامين")]
        [Display(Name = "تاريخ انتهاء التامين")]
         
        public DateTime LicenseExpirationDate { get; set; }  // تاريخ انتهاء التامين

        

        [NotMapped]
        public string Error { get; set; } = "";
        [NotMapped]
        public string Messages { get; set; } = "";

        //=================================================================================================

        public int? CompanyId { get; set; }// رقم الشركة
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }

        public int? IDMainUser { get; set; }// رقم المستخدم الرئيسي
        [ForeignKey("IDMainUser")]
        public MainUser? MainUser { get; set; }


        [Required(ErrorMessage = "من هو السائق  ")]
        [Display(Name = "سائق السيارة")]
        public int? IDDriver { get; set; }// رقم السائق الفتراضي
        [ForeignKey("IDDriver")]
        public Driver? driver { get; set; }

        public int? IDGeneralUser { get; set; }// رقم المستخدم الفرعي
        [ForeignKey("IDGeneralUser")]
        public GeneralUser? GeneralUser { get; set; }



        public ICollection<Expenses>? expensesNew { get; set; }
    }
}
