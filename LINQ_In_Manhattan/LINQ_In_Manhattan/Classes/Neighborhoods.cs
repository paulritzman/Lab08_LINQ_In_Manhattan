using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace LINQ_In_Manhattan.Classes
{
    public class Neighborhoods
    {
        public List<Features> Features { get; set; }
        public string Type { get; set; }





        public static Neighborhoods DeserializeJSON()
        {
            Console.WriteLine("Deserializing JSON...");

            const string JSON_PATH = "../../../../../data.json";
            string jsonData = "";

            try
            {
                using (StreamReader strRead = new StreamReader(JSON_PATH))
                {
                    jsonData = strRead.ReadToEnd();
                    Neighborhoods parsedObj = JsonConvert.DeserializeObject<Neighborhoods>(jsonData);
                    
                    //string[] myString = new string[parsedObj.Features.Count];

                    return parsedObj;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured: {e.Message}");
                return null;
            }
        }
    }
}
