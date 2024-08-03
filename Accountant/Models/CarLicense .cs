using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
    [Index(nameof(CarLicense.NumberCar), nameof(CarLicense.CompanyId) , IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class CarLicense // ترخيص السيارة
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

        [Required(ErrorMessage = "ما هو تاريخ بدء الترخيص")]
        [Display(Name = "تاريخ بدء الترخيص")]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = false)]

        public DateTime LicenseStartDate { get; set; } //تاريخ بدء الترخيص
        //=================================================================================================

        [Required(ErrorMessage = "ما هو تاريخ انتهاء الترخيص")]
        [Display(Name = "الاسمتاريخ انتهاء الترخيص")]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = false)]

        public DateTime LicenseExpirationDate { get; set; } //تاريخ انتهاء الترخيص
        //=================================================================================================

        [Required(ErrorMessage = "ما هو التاريخ")]
        [Display(Name = "تاريخ")]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = true)]

        public DateTime CreatedDate { get; set; } // تاريخ انشاء
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
        //---------------------------------------------



    }
}
