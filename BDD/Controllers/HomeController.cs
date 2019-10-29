using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BDD.Models;

namespace BDD.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpGet]
        public IActionResult Calculate()
        {
            ViewData["Message"] = "Sum 2 numbers";

            return View(new CalcModel());
        }

        [HttpPost]
        public IActionResult Calculate(CalcModel model)
        {
            model.Result = new Calculator
            {
                FirstNumber = model.FirstNumber,
                SecondNumber = model.SecondNumber
            }.Add();

            return View(model);
        }

        public IActionResult Privacy()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
