using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
    [Index(nameof(ProgramUser.Name), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class ProgramUser // مستخدم البرنامج
    {
        [Key]
        public int Id { get; set; }
        //=================================================================================================
        public string? Name { get; set; }   
        //=================================================================================================
        public string? Password { get; set; }
        //=================================================================================================
        [NotMapped]
        [Display(Name = "اعاده كتابة الباسورد")]
        [Compare("Password", ErrorMessage = "الباسورد غير مطابق")]
        [Required(ErrorMessage = "حقل الباسورد فارغ")]
        [PasswordPropertyText]
        public string ConfirmedPaswword { get; set; } = ""; //تاكيد الباسورد


        //-------------------------------------------------------------------------

        [NotMapped]
        public string? Error { get; set; }
        [NotMapped]
        public string Messages { get; set; } = "";

        //-------------------------------------------------------------------------

    }
}
