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
            System.Threading.Thread.Sleep(1500);

            const string JSON_PATH = "../../../../../data.json";
            string jsonData = "";

            try
            {
                using (StreamReader strRead = new StreamReader(JSON_PATH))
                {
                    jsonData = strRead.ReadToEnd();
                    Neighborhoods deSerailObj = JsonConvert.DeserializeObject<Neighborhoods>(jsonData);

                    return deSerailObj;
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
