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
            Neighborhoods.ReadJSONFromFile();

            Console.ReadLine();
        }


    }
}
