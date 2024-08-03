namespace Accountant.Models.ViewModel
{
    public class ViewModelInputCompany
    {
        public List<InputCompany> inputCompanies_List {  get; set; } = new List<InputCompany>();
        public InputCompany inputCompany_M { get; set; } = new InputCompany();
        public List<WorkCompanies> workCompanies_List { get; set;} = new List<WorkCompanies>();


        public int StatusButtonworkCompaniesID { get; set; }
        
        public string? StatusButtonworkCompaniesName {  get; set; }

        public bool AddToEdit { get; set; }  

    }
}
