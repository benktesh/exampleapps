using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Example.Models;

namespace MVC_Example.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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

        [HttpGet]
        public IActionResult Vehicle()
        {
            return View(new VehicleViewModel());
        }

        [HttpPost]
        public IActionResult Vehicle(VehicleViewModel vm)
        {
            
            if (ModelState.IsValid)
            {
                ModelState.Clear();
                return View(vm);
            }
            return View(new VehicleViewModel());
        }
    }
}
