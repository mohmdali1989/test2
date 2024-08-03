namespace Accountant.Models.ViewModel
{
    public class ViewModelWorkCompanies
    {
        public List<WorkCompanies> workCompanies {  get; set; } = new List<WorkCompanies>();
        public  PermissionsWorkCompanies? permissionsWorkCompanies { get; set; } = new PermissionsWorkCompanies();
        public int IDMainUser { get; set; }
         public int IDProgramUser { get; set; }
        public int IDGeneralUser { get; set; }
        public int id {  get; set; }
         
    }
}
