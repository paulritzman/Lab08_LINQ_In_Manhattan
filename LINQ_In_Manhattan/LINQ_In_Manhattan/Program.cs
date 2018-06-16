using System;
using System.IO;
using LINQ_In_Manhattan.Classes;
using Newtonsoft.Json;

namespace LINQ_In_Manhattan
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Deserializing JSON...");

            const string JSON_PATH = "../../../../../data.json";
            string jsonData = "";

            try
            {
                using (StreamReader strRead = new StreamReader(JSON_PATH))
                {
                    jsonData = strRead.ReadToEnd();
                    Neighborhoods testObj = JsonConvert.DeserializeObject<Neighborhoods>(jsonData);
                    Console.WriteLine(testObj.Features.Count);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured: {e.Message}");
            }

            Console.ReadLine();
        }


    }
}
