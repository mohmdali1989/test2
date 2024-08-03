namespace Accountant.Models.ViewModel
{
    public class BriefsViewModel
    {
        public Briefs Briefs_M { get; set; } = new Briefs();
        public List<Briefs> Briefs_List { get; set; } = new List<Briefs>();

        public List<Driver> Driver_List { get; set; } =new List<Driver> ();
        public int StatusButtonDriver { get; set; }
        public DateTime? previousDate {  get; set; }
         
        public int? ID_Driver { get; set; }
        public int? ID_Briefs { get; set; }
        public string? Name_Driver { get; set; }   
        public bool AddToEdit { get; set; }

    }
}
