using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Task_1._2
{
    public class PlayerAge : IComparer<IPlayer>
    {
        public int Compare(IPlayer x, IPlayer y)
        {
            if (x.Age == y.Age)
                return 0;
            else if(x.Age < y.Age)
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
