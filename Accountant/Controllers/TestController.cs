using Accountant.Data;
using Accountant.Models;
using Accountant.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Accountant.Controllers
{
    public class TestController : Controller
    {

        private readonly DataContextDB dbContext;

        public TestController(DataContextDB dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Test()
        {
            return View();
        }
    }
}