namespace Accountant.Models.ViewModel
{
    public class CarToWorkDiayToWorkCom
    {
        public Car? Car_M { get; set; } = new Car();// المركبات نموذج
        public DriversDiary DriverDiary_M { get; set; } = new DriversDiary();// الساقين نموذج
        public List<Car> Car_List_L { get; set;} = new List<Car>(); // المركبات جدول
        public List<Driver> Driver_List_M { get; set; } = new List<Driver>();// السائقين  جدول
        public WorkDiary WorkDiary_M { get; set; }  = new WorkDiary(); //يوميات العمل نموذج
        public List<WorkDiary> WorkDiary_List_M { get; set; }  =new List<WorkDiary>();//يوميات العمل جدول
        public List<WorkCompanies> WorkCompanies_List_M { get;set; } = new List<WorkCompanies>(); // شركات العمل جدول
        public int StatusButtonCar { get; set; }// وضع الزر المركبة
        public int StatusButtonDrivr { get; set; } //وضع الزر السائق
        public bool PageStatus { get; set; } // حاله الصفحة
    }
}
