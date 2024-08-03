using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
    [Index(nameof(MainUser.Name), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class MainUser //مستخدم رئيسي
    {
        [Key]
        public int Id { get; set; }
        //=================================================================================================

        [Required(ErrorMessage = "حقل الاسم فارغ")]
        [Display(Name = "الاسم")]
        public string Name { get; set; } = ""; // الاسم
        //=================================================================================================

        [Required(ErrorMessage = "حقل الباسورد فارغ")]
        [Display(Name = "الباسورد")]
        [PasswordPropertyText]
        public string Password { get; set; } = ""; // الباسورد

        //=================================================================================================

        [NotMapped]
        [Display(Name = "اعاده كتابة الباسورد")]
        [Compare("Password", ErrorMessage = "الباسورد غير مطابق")]
        [Required(ErrorMessage = "حقل الباسورد فارغ")]
        [PasswordPropertyText]
        public string ConfirmedPassword { get; set; } = ""; // اعاده الباسورد
        //=================================================================================================


        [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = true)]
        [Display(Name = "تاريخ النشاء الحساب")]
         

        public DateTime CreatedDate { get; set; } // تاريخ انشاء
        //=================================================================================================

        public bool  Confirmed { get; set; } // حاله الحساب
        //=================================================================================================



        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }
         
        //-------------------------------------------------------------------------

        [NotMapped]
        public string? Error { get; set; }
               [NotMapped]
        public string Messages { get; set; } = "";

        //-------------------------------------------------------------------------



    }
}
