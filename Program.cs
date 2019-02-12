using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace PruebaWithJsonParameter
{

    class ObjectPass
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<ObjectPass> hola = new List<ObjectPass>
            {
                new ObjectPass()
                {
                   Id = 1,
                   Name = "Hola mundo en Json desde C#"
                }
            };

            try
            {
                using (StreamWriter file = File.CreateText(Path.Combine(Directory.GetCurrentDirectory(), "pass.json")))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(file, hola);
                }
                Console.WriteLine("Se escribio en el archivo .json");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ha ocurrido un error :" + e);
            } 

            Console.ReadKey();
        }
    }
}
