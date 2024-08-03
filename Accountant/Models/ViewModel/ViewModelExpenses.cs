using System.ComponentModel.DataAnnotations;

namespace Accountant.Models.ViewModel
{
    public class ViewModelExpenses
    {
        public List<Expenses> Expenses { get; set; } = new List<Expenses>();
        public Expenses Expenses_M { get; set; } = new Expenses();

        public List<Car> car_List { get; set; } = new List<Car>();
        public Car car_M { get; set; } = new Car ();

        public int? StatusButtonCar { get; set; }// وضع الزر المركبة
        public string? NameTypeCar { get; set; }// وضع الزر المركبة
        public bool AddToEdit { get; set; }//حاله التاريخ 
        public int? IDCar { get; set; }// رقم السياره

               
        public DateOnly? StatusDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);    
         

        public List<SparePartsCenters> sparePartsCenters_List { get; set; } = new List<SparePartsCenters>();
        public List<RepairWorkshops> Workshops_List { get; set; } = new List<RepairWorkshops>();


    }
}
