using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestJsonInWeb.Models;
using static System.Net.WebRequestMethods;

namespace TestJsonInWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        public IActionResult Index()
        {
            /*usando la libreria Json.Net(Newtonsoft.json in Nuget)
             * luego usamos la clase StreamWriter para posterior mente tomar el path
             * el paso siguiente es usar JsonWriter para entonces escribir en el archivo
             * y con jsonSerializer entonces serializamos el json le pasamos los datos necesarios
             * 
            */
            using (StreamWriter sw = new StreamWriter(Path.Combine(_hostingEnvironment.WebRootPath, "pass.json")))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(writer, new ObjectPass
                {
                    Id = 1,
                    Name = "Hola mundo desde C#"
                });

            }

            ViewBag.Hola = "Hey escritura Exitosa!!!!! wiiii";

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


     internal class ObjectPass
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
