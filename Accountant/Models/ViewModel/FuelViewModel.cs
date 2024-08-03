namespace Accountant.Models.ViewModel
{
    public class FuelViewModel
    {
        public Fuel fuel_M { get; set; } = new Fuel();
        public List<Fuel> DataFuel_List { get; set; } =new List<Fuel>();
        public List<WorkDiary> workDiaries_List { get; set; } = new List<WorkDiary>();
        public List<FuelProvider> fuelProviders_List { get; set;} =new List<FuelProvider>();

        public List<Car> DataCar_List {  get; set; }= new List<Car>();
        public string? NameCar { get; set; } = string.Empty;
        public int? StatusButtonCar { get; set; } 
        public bool FuelEdit {  get; set; }


    }
}
