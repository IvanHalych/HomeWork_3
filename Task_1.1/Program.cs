using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Name program: LINQ array statistics.");
            Console.WriteLine("Author's name: Halych Ivan.");
            while (true)
            {
                Console.WriteLine("Enter a string with a set of integers separated by commas.");
                string input = Console.ReadLine();
                if(input == "Exit")
                {
                    break;
                }
                try
                {
                    int[] array = input.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(p => int.Parse(p)).ToArray();
                    Console.WriteLine("Min: "+array.Min());
                    Console.WriteLine("Max: "+array.Max());
                    Console.WriteLine("Sum: "+array.Sum());
                    double avarage = array.Average();
                    Console.WriteLine("Acarage: "+avarage);
                    double standardDeviation = Math.Sqrt( array.Select(p=>Math.Pow( p-avarage,2)).Sum()/ array.Length);
                    Console.WriteLine("Standard Deviation: "+standardDeviation);
                    array =array.Distinct().OrderBy(p=>p).ToArray();
                    array.ToList().ForEach(p => Console.WriteLine(p+" ")); 
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
