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

            /*
             * Code block which deserializes JSON file and prints all neighborhoods
            */

            // Creates an IEnumerable<string> which stores all neighborhoods
            var allNeighborhoodsFromJSON = FindAllNeighborhoods();
            Console.Clear();

            // Iterates through the IEnumerable<string> printing out each neighborhood
            PrintNeighborhoods(allNeighborhoodsFromJSON);

            // Prints message to the user and leaves message/neighborhoods on screen for 2 seconds
            Console.WriteLine("\nAll neighborhoods from JSON file are shown above. Removing blank entries...");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

            /*
             * Code block which parses out only the neighborhoods that have names from allNeighborhoodsFromJSON
            */

            // Creates an IEnumerable<string> which stores neighborhoods with names of length > 0
            var nonEmptyNeighborhoods = FindNonEmptyNeighborhoods(allNeighborhoodsFromJSON);

            // Iterates through the IEnumerable<string> printing out each neighborhood
            PrintNeighborhoods(nonEmptyNeighborhoods);

            // Prints message to the user and leaves message/neighborhoods on screen for 2 seconds
            Console.WriteLine("\nNon-empty neighborhoods are shown above. Removing duplicates...");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

            /*
             * Code block which parses out only distinct neighborhoods, removing duplicates from nonEmptyNeighborhoods
            */

            // Creates an IEnumerable<string> which stores neighborhoods, removing duplicates
            var distinctNeighborhoods = FindDistinctNeighborhoods(nonEmptyNeighborhoods);

            // Iterates through the IEnumerable<string> printing out each neighborhood
            PrintNeighborhoods(distinctNeighborhoods);

            // Prints message to the user and leaves message/neighborhoods on screen for 2 seconds
            Console.WriteLine("\nNon-empty, distinct neighborhoods are shown above. Finalizing data...");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

            /*
             * Code block which combines all prior queries into one, storing distince, non-empty neighborhoods
            */

            // Creates an IEnumerable<string> which stores dsitinct, non-empty neighborhoods
            var finalizedNeighborhoods = CombineLINQandLambdaQueries(allNeighborhoodsFromJSON);
            Console.WriteLine("All distinct, non-empty neighborhoods in Manhattan:\n");

            // Iterates through the IEnumerable<string> printing out each neighborhood
            PrintNeighborhoods(finalizedNeighborhoods);

            // Prints and empty line for formatting purposes
            Console.WriteLine();
        }

        /// <summary>
        /// Method which parses out all neighborhoods from the JSON data file.
        /// </summary>
        /// <returns>IEnumerable<string></returns>
        public static IEnumerable<string> FindAllNeighborhoods()
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

            return hoodList;
        }

        /// <summary>
        /// Method which parses out all neighborhoods that have names with length > 0, removing empty names
        /// </summary>
        /// <param name="allNeighborhoods"></param>
        /// <returns>IEnumerable<string></returns>
        public static IEnumerable<string> FindNonEmptyNeighborhoods(IEnumerable<string> allNeighborhoods)
        {
            IEnumerable<string> nonEmptyHoods = from h in allNeighborhoods
                                        where h.Length > 0
                                        select h;

            return nonEmptyHoods;
        }

        /// <summary>
        /// Method which parses out all neighborhoods that are distinct, removing duplicate names 
        /// </summary>
        /// <param name="nonEmptyHoods"></param>
        /// <returns>IEnumerable<string></returns>
        public static IEnumerable<string> FindDistinctNeighborhoods(IEnumerable<string> nonEmptyHoods)
        {
            // Stores only the distinct neighborhood names
            var distinctHoods = nonEmptyHoods.Distinct();

            // Returns the IEnumerable<string> storing distinct, non-empty, neighborhood names
            return distinctHoods;
        }

        /// <summary>
        /// Method which combines all prior LINQ and Lambda queries into one Lambda query
        /// parsing out all distinct, non-empty neighborhoods, removing empty names and duplicates
        /// </summary>
        /// <param name="allNeighborhoods"></param>
        /// <returns>IEnumerable<string></returns>
        public static IEnumerable<string> CombineLINQandLambdaQueries(IEnumerable<string> allNeighborhoods)
        {
            var validHoods = allNeighborhoods.Where(n => n.Length > 0)
                                                     .Distinct();

            return validHoods;
        }

        /// <summary>
        /// Helper method to iterate through IEnumberable<string> elements and print the contents to the console window.
        /// </summary>
        /// <param name="neighborhoods"></param>
        public static void PrintNeighborhoods(IEnumerable<string> neighborhoods)
        {
            // Iterates through the IEnumerable<string> printing out each neighborhood
            foreach (var hood in neighborhoods)
            {
                Console.WriteLine(hood);
            }
        }
    }
}
