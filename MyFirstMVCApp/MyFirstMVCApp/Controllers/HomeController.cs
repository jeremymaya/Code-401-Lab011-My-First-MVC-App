using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVCApp.Models;

namespace MyFirstMVCApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(int yearFrom, int yearTo) => RedirectToAction("Results", new { yearFrom, yearTo });

        public IActionResult Results(int yearFrom, int yearTo)
        {
            List<TimePerson> list = TimePerson.GetPersons(yearFrom, yearTo);
            return View(list);
        }
    }
}

