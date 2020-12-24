using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Task_1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Name program: Dictionary with key.");
            Console.WriteLine("Author's name: Halych Ivan.");
            Console.WriteLine("The user sees the console contains the dictionary of regional and regional settings." +
                " In case of errors in the work of the dictionary of regions," +
                " the user sees an error message on the console");
            Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
            int n = 0;
            while (true)
            {
                Console.WriteLine("Enter the number of N elements in the dictionary:");
                string input = Console.ReadLine();
                if (input == "Exit")
                    break;
                if(int.TryParse(input ,out n)&& n > 0)
                {
                    break;
                }
                Console.WriteLine("Input is invalid value");
            }
            try
            {
                for (int i = 0; i < n; i++)
                {
                    while (true)
                    {
                        string brand = EnterConsole($"Enter Brand from {i} element:");
                        string country = EnterConsole($"Enter Country from {i} element:");
                        string webSite = EnterConsoleWebSite($"Enter WebSite from {i} element:");
                        if (dictionary.TryAdd(new TKey(brand, country), new TValue(webSite)))
                            break;
                        Console.WriteLine("This item already exists.");
                    }
                }
            }
            catch(ExitException)
            { }
            dictionary.ToList().ForEach(d => Console.WriteLine($"Brand: {d.Key.Brand}\t Country: {d.Key.Country}\t WebSite: {d.Value.WebSite}"));
        }
        static string EnterConsole(string description)
        {
            Regex regex = new Regex(@"^[A-Z]+$");
            while (true)
            {
                Console.Write(description);
                string input = Console.ReadLine();
                if (input == "Exit")
                    throw new ExitException();
                if (regex.IsMatch(input))
                {
                    return input;
                }
            }
        }
        static string EnterConsoleWebSite(string description)
        {
            Regex regex = new Regex(@"^[a-z]+(\.[a-z]+)+$");
            while (true)
            {
                Console.Write(description);
                string input = Console.ReadLine();
                if (input == "Exit")
                    throw new ExitException();
                if (regex.IsMatch(input))
                {
                    return input;
                }
            }
        }

    }
}
