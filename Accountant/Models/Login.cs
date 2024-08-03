using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
    public class Login
    {
        [Required(ErrorMessage = "حقل الاسم فارغ")]
        [Display(Name = "الاسم")]
        [NotMapped]
        public string? Name { get; set; }  
        [Required(ErrorMessage = "حقل الباسورد فارغ")]
        [Display(Name = "الباسورد")]
        [PasswordPropertyText]
        [NotMapped]
        public string? Passowrde {  get; set; }


        //-------------------------------------------------------------------------

        [NotMapped]
        public string? Error { get; set; }
        [NotMapped]
        public string Messages { get; set; } = "";

        //-------------------------------------------------------------------------


    }
}
