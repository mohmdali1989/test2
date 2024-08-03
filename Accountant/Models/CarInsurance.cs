using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
    [Index(nameof(CarInsurance.NumberCar), nameof(CarLicense.CompanyId), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class CarInsurance  // تامين السيارة
    {
        [Key]
        public int Id { get; set; }
        //=================================================================================================

        [Required(ErrorMessage = "ما هو رقم السيارة")]
        [Display(Name = "رقم السيارة")]
        public string NumberCar { get; set; } = ""; //رقم السيارة
        //=================================================================================================

        [Required(ErrorMessage = "ما هو نوع السيارة")]
        [Display(Name = "نوع السيارة")]
        public string CarType { get; set; } = ""; // نوع السيارة
        //=================================================================================================

        [Required(ErrorMessage = "ما هو موديل السيارة")]
        [Display(Name = "موديل السيارة")]
        public string CarModel { get; set; } = ""; //موديل السيارة
        //=================================================================================================

        [Required(ErrorMessage = "ما هو نوع التامين")]
        [Display(Name = "نوع التامين")]
        public string InsuranceType { get; set; } = ""; //نوع التامين
        //=================================================================================================

        [Required(ErrorMessage = "ما هو تاريخ بداية التامين")]
        [Display(Name = "تاريخ بداية التامين")]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = false)]

        public DateTime LicenseStartDate { get; set; } // تاريخ بداية التامين
        //=================================================================================================

        [Required(ErrorMessage = "ما هو تاريخ انتهاء التامين")]
        [Display(Name = "تاريخ انتهاء التامين")]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = false)]

        public DateTime LicenseExpirationDate { get; set; } // تاريخ انتهاء التامين
        //=================================================================================================

        [Required(ErrorMessage = "ما هو التاريخ")]
        [Display(Name = "تاريخ")]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = false)]

        public DateTime CreatedDate { get; set; } // تاريخ تسحيل البيانات
        //=================================================================================================


        //-----------------------------------------------
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
        public Car? Car { get; set; }
        //-----------------------------------------------


    }
}
