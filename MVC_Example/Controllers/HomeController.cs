using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Example.Models;
using Newtonsoft.Json;

namespace MVC_Example.Controllers
{
    public class HomeController : Controller
    {

        public class SendData
        {
            public string Name { get; set; }
            public String[] Movies { get; set; }
        }
        public IActionResult Index()
        {
            var client = new HttpClient();

            /*
            string key = "GetJoke";
            if(key.Equals("GetJoke", StringComparison.InvariantCultureIgnoreCase))
            {

                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "joke3.p.rapidapi.com");
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "c812b07f3cmshbed411ccb96b811p1f9e2ajsncf4b1584d198");
                var response = client.GetAsync("https://joke3.p.rapidapi.com/v1/joke");
                var content = response.Result.Content.ReadAsStringAsync();
                Console.WriteLine(content.Result);
            }*/

            var data = new SendData();
            data.Name = "Paul Rudd";
            data.Movies = new List<string> { "I Love You Man", "Role Models" }.ToArray();
            var url = "https://reqres.in/api/users";

            var jsonData = JsonConvert.SerializeObject(data);

            var httpContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, httpContent);
            var content = response.Result.Content.ReadAsStringAsync(); 
        
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
