namespace Accountant.Models.ViewModel.ReportscVM
{
    public class ReportscCarViewModel
    {

        //=====================================================================================
        //=====================================================================================


        public int IDCar { get; set; }
        //=====================================================================================
        //=====================================================================================

        public List<DateOnly> DateYearMonth = new List<DateOnly>();

        //=====================================================================================
        //=====================================================================================
        public List<Car> Cars { get; set; } = new List<Car>();
        public int StatusButtonCar { get; set; }

        //=====================================================================================
        //=====================================================================================
        public List<WorkDiary> WorkDiary { get; set; } = new List<WorkDiary>();
        public List<WorkDiary> PluralPrice { get; set; } = new List<WorkDiary>();


        //=====================================================================================
        //=====================================================================================

        public List<Fuel> PluralFuelQuantity { get; set; } = new List<Fuel>();
        public List<Fuel> Fuel { get; set; } = new List<Fuel>();

        //=====================================================================================
        //=====================================================================================
        public List<Expenses> Expenses { get; set; }= new List<Expenses>();
        public List<Expenses> PluralExpenses { get; set; } = new List<Expenses>();
        public List<Expenses> ExpensesWork { get; set; } = new List<Expenses>();
        public List<Expenses> PluralExpensesWork { get; set; } = new List<Expenses>();


        //=====================================================================================
        //=====================================================================================
        public List<TrafficViolations>  trafficViolations { get; set; } = new List<TrafficViolations>();
        public List<TrafficViolations> PluraltrafficViolations { get; set; } = new List<TrafficViolations>();


        //=====================================================================================
        //=====================================================================================

        public List<combinedList> CombinedList { get; set;} = new List<combinedList>();
         
        //=====================================================================================
        //=====================================================================================







    }
}
