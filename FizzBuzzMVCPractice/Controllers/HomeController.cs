using FizzBuzzMVCPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzzMVCPractice.Controllers
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

        [HttpGet]
        public IActionResult App()
        {
            FizzBuzz fizzbuzz = new();
            fizzbuzz.FizzValue = 3;
            fizzbuzz.BuzzValue = 5;
            return View(fizzbuzz);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult App(FizzBuzz FizzBuzzModel)
        {
            int fizzValue = FizzBuzzModel.FizzValue;
            int buzzValue = FizzBuzzModel.BuzzValue;
            bool fizz;
            bool buzz;

            for (int i = 1; i <= 100; i++)
            {
                fizz = (i % fizzValue) == 0;
                buzz = (i % buzzValue) == 0;
                if (fizz == true && buzz == true)
                {
                    FizzBuzzModel.results.Add("FizzBuzz");
                } else if (fizz == true)
                {
                    FizzBuzzModel.results.Add("fizz");
                } else if (buzz == true)
                {
                    FizzBuzzModel.results.Add("buzz");
                }
                else
                {
                    FizzBuzzModel.results.Add(i.ToString());
                }
            }
            return View(FizzBuzzModel);
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
