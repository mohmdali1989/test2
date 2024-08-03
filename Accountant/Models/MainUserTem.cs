using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Accountant.Models
{
    [Index(nameof(MainUserTem.Name), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class MainUserTem // مستخدم مؤقت
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
        [Required(ErrorMessage = "حقل التاريخ غير معدل")]

        public DateTime CreatedDate { get; set; }// تاريخ الإنشاء
        //=================================================================================================

        
        [NotMapped]
        public string? Error { get; set; } 
        //-------------------------------------------------------------------------
        [NotMapped]
        public string Messages { get; set; } = "";
    }

}

