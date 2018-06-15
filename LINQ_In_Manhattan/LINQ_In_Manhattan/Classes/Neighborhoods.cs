using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace LINQ_In_Manhattan.Classes
{
    public class Neighborhoods
    {
        public List<Features> Features { get; set; }

        public static void ReadJSONFromFile()
        {
            Console.WriteLine("Parsing JSON...");

            const string JSON_PATH = "../../../../../data.json";
            string jsonData = "";

            try
            {
                using (StreamReader strRead = new StreamReader(JSON_PATH))
                {
                    jsonData = strRead.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured: {e.Message}");
            }

            var locationFromJSON = JsonConvert.DeserializeObject<Features>(jsonData);
        }



    }
}
