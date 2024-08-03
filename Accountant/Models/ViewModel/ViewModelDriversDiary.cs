namespace Accountant.Models.ViewModel
{
    public class ViewModelDriversDiary
    {
        public List<DriversDiary> DriversDiary_List { get; set; } = new List<DriversDiary>();
        public DriversDiary DriversDiary_M { get; set; } = new DriversDiary();
        public List<Driver> Driver_List { get; set; } = new List<Driver>();
        public int? StatusButtonDriver { get; set; }// وضع الزر السائق
        public bool AddToEdit { get; set; } //الحاله اضافة او تعديل
        

        public DateOnly? StatusDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
