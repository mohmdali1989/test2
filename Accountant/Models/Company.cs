using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
    [Index(nameof(Company.CompanyName), IsUnique = true)] //لجعل الحقل لا يتكرر 

    public class Company// الشركة
    {
        [Key]
        public int Id { get; set; }
        //=================================================================================================

        [Required(ErrorMessage = "ما هو اسم الشركة")]
        [Display(Name = "اسم الشركة")]
        public string CompanyName { get; set; } = ""; // اسم الشركة
        //=================================================================================================

        [Required(ErrorMessage = "ما هو التاريخ")]
        [Display(Name = "تاريخ")]
        public DateTime CreatedDate { get; set; } // تاريخ انشاء
        //=================================================================================================

        [Required(ErrorMessage = "ما هي وظيفة الشركة")]
        [Display(Name = "وظيفة الشركة")]
        public string CompanyFunction { get; set; } = ""; // وظيفة الشركة
        //=================================================================================================

        [NotMapped]
        public string Error { get; set; } = "";
        [NotMapped]
        public string Messages { get; set; } = "";





    }
}
