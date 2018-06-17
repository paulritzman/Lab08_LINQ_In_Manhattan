using System;
using System.Collections.Generic;
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

            var distinctHoods = FindDistinctNeighborhoods();
            Console.Clear();

            foreach (var hood in distinctHoods)
            {
                Console.WriteLine(hood);
            }

            Console.WriteLine();
        }

        public static IEnumerable<string> FindDistinctNeighborhoods()
        {
            Neighborhoods neighborObj = Neighborhoods.DeserializeJSON();

            List<string> hoodList = new List<string>();

            for (int i = neighborObj.Features.Count - 1; i > 0; i--)
            {
                hoodList.Add(neighborObj.Features[i].Properties.Neighborhood);
            }

            IEnumerable<string> hoods = from h in hoodList
                                        where h.Length > 0
                                        select h;

            var distinctHoods = hoods.Distinct();

            return distinctHoods;
        }


    }
}
