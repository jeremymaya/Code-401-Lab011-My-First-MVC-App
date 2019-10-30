using System;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVCApp.Models;

namespace MyFirstMVCApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            var random = TimePerson.GetPersons(1950, 1960);
            return View();
        }

        [HttpPost]
        public IActionResult Index(int yearFrom, int yearTo)
        {
            var random = TimePerson.GetPersons(yearFrom, yearTo);
            return RedirectToAction("Results", random);
        }

        public ViewResult Results(TimePerson list)
        {
            return View(list);
        }
    }
}
