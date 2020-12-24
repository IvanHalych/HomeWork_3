using System;
using System.Collections.Generic;
using System.Linq;
using Task_1._2;

namespace Task_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Name program: Three sorts and one comparator.");
            Console.WriteLine("Author's name: Halych Ivan.");
            List<IPlayer> players = new List<IPlayer>();
            players.Add(new Player(29, "Ivan", "Ivanenko", PlayerRank.Captain));
            players.Add(new Player(19, "Peter", "Petrenko", PlayerRank.Private));
            players.Add(new Player(59, "Ivan", "Ivanov", PlayerRank.General));
            players.Add(new Player(52, "Ivan", "Snezko", PlayerRank.Lieutenant));
            players.Add(new Player(29, "Alex", "Zeshko", PlayerRank.Colonel));
            players.Add(new Player(29, "Ivan", "Ivanenko", PlayerRank.Captain));
            players.Add(new Player(19, "Peter", "Petrenko", PlayerRank.Private));
            players.Add(new Player(34, "Vasiliy", "Sokol", PlayerRank.Major));
            players.Add(new Player(31, "Alex", "Alexeenko", PlayerRank.Major));

            players.Sort(new PlayerName());
            players.Distinct(new Player()).ToList().ForEach(p => Console.WriteLine(p));
            Console.WriteLine();
            players.Sort(new PlayerAge());
            players.Distinct(new Player()).ToList().ForEach(p => Console.WriteLine(p));
            Console.WriteLine();
            players.Sort(new PlayerWithRank());
            players.Distinct(new Player()).ToList().ForEach(p => Console.WriteLine(p));

        }
    }
}
