using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using wojciechtomala.Models;

namespace wojciechtomala.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Calculator(decimal num1, decimal num2, string operation)
        {
            decimal result = 0;
            switch (operation)
            {
                case "addition":
                    result = num1 + num2;
                    break;
                case "subtraction":
                    result = num1 - num2;
                    break;
                case "division":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        ViewBag.Error = "You can't divide by 0!";
                        return View();
                    }
                    break;
                case "multiplication":
                    result = num1 * num2;
                    break;
                default:
                    ViewBag.Error = "";
                    return View();
            }
            ViewBag.Result = Math.Round(result,2);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}