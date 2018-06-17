using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LINQ_In_Manhattan.Classes
{
    public class Neighborhoods
    {
        // Declare properties
        public List<Features> Features { get; set; }
        public string Type { get; set; }

        /// <summary>
        /// Method which deserializes a JSON object.
        /// </summary>
        /// <returns>Neighborhoods object</returns>
        public static Neighborhoods DeserializeJSON()
        {
            // Prints message to the user - leaves message in console window for 1 second
            Console.WriteLine("Deserializing JSON...");
            System.Threading.Thread.Sleep(1000);

            // Declare constant path to JSON data file
            const string JSON_PATH = "../../../../../data.json";
            string jsonData = "";

            try
            {
                // Deserializes JSON object - returns Neighborhoods object if successful
                using (StreamReader strRead = new StreamReader(JSON_PATH))
                {
                    jsonData = strRead.ReadToEnd();
                    Neighborhoods deSerailObj = JsonConvert.DeserializeObject<Neighborhoods>(jsonData);

                    return deSerailObj;
                }
            }
            catch (Exception e)
            {
                // Print message to the console window if deserialization is unsuccessful
                Console.WriteLine($"An error occured: {e.Message}");
                return null;
            }
        }
    }
}
