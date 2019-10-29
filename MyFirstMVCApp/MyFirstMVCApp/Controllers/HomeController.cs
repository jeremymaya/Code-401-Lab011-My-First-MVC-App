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
            return View();
        }

        [HttpPost]
        public IActionResult Index(int yearFrom, int yearTo)
        {
            TimePerson list = new TimePerson(yearFrom, yearTo);
            return RedirectToAction("Results", list);
        }

        public ViewResult Results(TimePerson list)
        {
            return View(list);
        }
    }
}
