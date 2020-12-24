using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Task_1._2
{
    public class PlayerName : IComparer<IPlayer>
    {
        public int Compare(IPlayer x, IPlayer y)
        {
            return string.Compare(x.FirstName + x.LastName, y.FirstName + y.LastName);
        }
    }
}
