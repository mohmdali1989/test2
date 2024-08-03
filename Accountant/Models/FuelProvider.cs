using System.ComponentModel.DataAnnotations.Schema;

namespace Accountant.Models
{
    public class FuelProvider
    {
        public  int Id { get; set; }

        public string NameFuelProvider { get; set; } = string.Empty;

        public string stationLocation { get; set; } = string.Empty;

        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }
        public int? IDMainUser { get; set; }
        [ForeignKey("IDMainUser")]
        public MainUser? MainUser { get; set; }

        public int? IDGeneralUser { get; set; }
        [ForeignKey("IDGeneralUser")]
        public GeneralUser? GeneralUser { get; set; }
    }
}
