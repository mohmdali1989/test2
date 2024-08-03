using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
     
    public class TrafficViolations//مخالفات مرورية
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "ما هو مكان المخلفة")]
        [Display(Name = "مكان المخلفة ")]
        public string LocationOfViolation { get; set; } = string.Empty;// مكان المخلفة

        [Required(ErrorMessage = "ما هو تاريخ المخالفه")]
        [Display(Name = "تاريخ المخالفه ")]
        public DateOnly DateOfViolation { get; set; } = DateOnly.FromDateTime(DateTime.Now); //تاريخ المخالفه

        [Required(ErrorMessage = "ما هو وقت المخالفه")]
        [Display(Name = "وقت المخالفه ")]
        public TimeOnly TiemOfViolation { get; set; } = TimeOnly.FromDateTime(DateTime.Now); //وقت المخالفه

        [Required(ErrorMessage = "ما هو سبب المخالفة")]
        [Display(Name = "سبب المخالفة ")]
        public string reasonForViolation { get; set; } = string.Empty; //سبب المخالفة

        
       
         
        [Display(Name = "معفي عن الدفع ")]
        public bool PushStatus { get; set; }

        [Required(ErrorMessage = "ما هو مبلغ المخالفه")]
        [Display(Name = "مبلغ المخالفه")]
        public int AmountViolated { get; set; } //مبلغ المخالفه


        [Required(ErrorMessage = "ما هو اخر مهله لدفع المخالفه")]
        [Display(Name = "اخر مهله لدفع المخالفه ")]
        public DateOnly dateLastTimePayFine { get; set; } = DateOnly.FromDateTime(DateTime.Now); // تاريخ اخر فرصه لدفع المخالفه



        public int? IdDrivr { get; set; } // رقم الذي سيدفع المخالفه
        [ForeignKey("IdDrivr")]
        public Driver? driver { get; set; }

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
        public Car? car { get; set; }

        //=================================================================================================

        [NotMapped]
        public int Year { get; set; }
        [NotMapped]
        public int Month { get; set; }
        [NotMapped]
        public string? Error { get; set; }

        [NotMapped]
        public string Messages { get; set; } = "";
    }
}
  
