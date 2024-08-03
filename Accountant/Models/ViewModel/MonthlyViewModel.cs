 

namespace Accountant.Models.ViewModel
{
    public class MonthlyViewModel
    {
        public List<Monthly> Monthly_L { get; set; } =new List<Monthly>();

        public Monthly Monthly_M { get; set; } = new Monthly();

        public List<Driver> Drivers_L { get; set;} =new List<Driver>();

        public List<DriversDiary> driversDiary_L { get; set; } = new List<DriversDiary>();
        public List<Briefs> Briefs_L { get; set; }= new List<Briefs>();
        public List<Briefs> briefsPushStatus_L { get; set; }= new List<Briefs>();
        public int? MonthlyAmount { get; set; } = 0;
        public int? NumberWorkingDays { get; set; } = 0;
        public bool Edit_Month { get; set; }
        public string? Month_Y { get; set; }
        public string? Month_M { get; set; }
        public string? Month_D { get; set; }
         
        public int? CountBriefs { get; set; }

        
        public int? monthlyTypeId { get; set; }

        public int? AmountANDWorkingDays{ get; set; }
        public int? AfterDiscount{ get; set;}
        //public int? AmountANDWorkingDays
        //{
        //    get
        //    {
        //        return (MonthlyAmount / NumberWorkingDays) * CountBriefs;
        //    }

        //}
        //public int? AfterDiscount
        //{
        //    get
        //    {
        //        return   MonthlyAmount - AmountANDWorkingDays;
        //    }

        //}


        public int? ID_Driver { get; set; }
        public int? StatusButtonDrivers { get; set; }

        public int? ID_Monthly { get; set; }
         
        public bool AddToEdit { get; set; }
        public string Error { get; set; } = string.Empty;

    }
}
