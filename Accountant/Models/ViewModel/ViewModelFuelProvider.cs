namespace Accountant.Models.ViewModel
{
    public class ViewModelFuelProvider
    {
        public FuelProvider FuelProvider_M { get; set; } = new FuelProvider();    
        public List<FuelProvider> FuelProvider_List { get; set; } = new List<FuelProvider>();

        public bool EditFuelProvider { get; set; }
    }
}
