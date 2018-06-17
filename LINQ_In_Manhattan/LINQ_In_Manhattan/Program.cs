using System;
using System.Linq;
using System.Collections.Generic;
using LINQ_In_Manhattan.Classes;

namespace LINQ_In_Manhattan
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Creates an IEnumerable<string> which stores the names of distinct neighborhoods
            var distinctHoods = FindDistinctNeighborhoods();
            Console.Clear();

            // Iterates through the IEnumerable<string> printing out each neighborhood
            foreach (var hood in distinctHoods)
            {
                Console.WriteLine(hood);
            }

            // Prints and empty line for formatting purposes
            Console.WriteLine();
        }

        /// <summary>
        /// Method to parse out distinct neighborhoods, omitting empty names, from a deserialized JSON object.
        /// </summary>
        /// <returns>IEnumerable<string></returns>
        public static IEnumerable<string> FindDistinctNeighborhoods()
        {
            // Creates the deserialized object
            Neighborhoods neighborObj = Neighborhoods.DeserializeJSON();

            // Declare a list to store all neighborhoods from the deserialized object
            List<string> hoodList = new List<string>();

            // Iterates through the deserialized object, adding each neighborhood to hoodList
            for (int i = neighborObj.Features.Count - 1; i > 0; i--)
            {
                hoodList.Add(neighborObj.Features[i].Properties.Neighborhood);
            }

            // Omit the lines in the hoodList where the neighborhood was left blank
            IEnumerable<string> hoods = from h in hoodList
                                        where h.Length > 0
                                        select h;

            // Stores only the distinct neighborhood names
            var distinctHoods = hoods.Distinct();

            // Returns the IEnumerable<string> storing distinct, non-empty, neighborhood names
            return distinctHoods;
        }


    }
}
