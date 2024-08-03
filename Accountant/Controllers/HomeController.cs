using Accountant.Data;
using Accountant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
namespace Accountant.Controllers
{ 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContextDB dbContext;

        public HomeController(ILogger<HomeController> logger , DataContextDB dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult ScreenHome()
        {
            HttpContext.Session.SetString("CountMainUserTem", dbContext.mainUserTem.Count().ToString());
            
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
