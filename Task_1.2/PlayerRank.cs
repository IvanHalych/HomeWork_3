using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Task_1._2
{
    public class PlayerWithRank:IComparer<IPlayer>
    {
        public int Compare(IPlayer x, IPlayer y)
        {
            if (x.Rank == y.Rank)
                return 0;
            else if (x.Rank < y.Rank)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
