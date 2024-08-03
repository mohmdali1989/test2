using Accountant.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Accountant.Models
{
    public class MonthlyType
    {
        [Key]
        public int id {  get; set; }

        public int MonthlyOrMemoirs {  get; set; } = 0;
        public string MonthlyOrMemoirsName { get; set; } = string.Empty;

        }
}
 