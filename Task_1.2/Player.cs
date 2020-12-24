using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Task_1._2
{
    public class Player : IPlayer,IEqualityComparer<IPlayer>
    {
        public Player()
        {
        }

        public Player(int age, string firstName, string lastName, PlayerRank rank)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
            Rank = rank;
        }

        public int Age { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public PlayerRank Rank { get; }

        public bool Equals(IPlayer x, IPlayer y)
        {
            if ((x.FirstName == y.FirstName) && (x.LastName == y.LastName) && (x.Age == y.Age) && (x.Rank == y.Rank))
                return true;
            return false;
        }

        public int GetHashCode(IPlayer obj)
        {
            return obj.FirstName.GetHashCode() ^ obj.LastName.GetHashCode() ^ obj.Age.GetHashCode() ^ obj.Rank.GetHashCode();
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, {Age} years, Rank {Rank} ";
        }
    }
}
