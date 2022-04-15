using FizzBuzz.Models;
using FizzBuzz.Shared;
using FizzBuzz.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FizzBuzz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFizBuzz _fizBuzz;

        public HomeController(ILogger<HomeController> logger, IFizBuzz fizBuzz)
        {
            _logger = logger;
            _fizBuzz = fizBuzz;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(FizBuzzModel FizBuzzmodel)
        {
            string commaseparatedInputString = FizBuzzmodel.FizBuzzString;
            if (!string.IsNullOrWhiteSpace(commaseparatedInputString))
            {
                FizBuzzmodel.FizBuzzResult = _fizBuzz.ProcessAndReturn(commaseparatedInputString);
                FizBuzzmodel.IsFizBuzzStringError = false;
            }
            else
            {
                FizBuzzmodel.IsFizBuzzStringError = true;
                FizBuzzmodel.FizBuzzStringError = Constants.InvalidInputError;
            }

            return View(FizBuzzmodel);
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