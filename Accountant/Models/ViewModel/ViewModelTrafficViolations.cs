namespace Accountant.Models.ViewModel
{
    public class ViewModelTrafficViolations
    {
        public TrafficViolations TrafficViolations_M { get; set; } = new TrafficViolations();
        public List<TrafficViolations> TrafficViolations_List { get; set; } = new List<TrafficViolations>();

        public List<Driver> Driver_List { get; set; } = new List<Driver>();
        public List<Car> Car_List { get; set; } = new List<Car>();
        public int StatusButtonCar { get; set; }
        public string? CarName { get; set; }
        public DateTime? previousDate { get; set; }

        public int? ID_Driver { get; set; }
        public int? TrafficViolations { get; set; }
        public string? Name_Driver { get; set; }
        public bool AddToEdit { get; set; }
    }
}
