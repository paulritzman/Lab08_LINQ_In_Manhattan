using System;
using System.IO;
using System.Linq;
using LINQ_In_Manhattan.Classes;
using Newtonsoft.Json;

namespace LINQ_In_Manhattan
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Neighborhoods neighborObj = Neighborhoods.DeserializeJSON();

            Console.WriteLine(neighborObj.Features[0].Properties.City);

            Console.ReadLine();
        }


    }
}
