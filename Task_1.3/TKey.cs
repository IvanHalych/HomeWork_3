using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1._3
{
    public class TKey : IRegion
    {
        public TKey(string brand, string country)
        {
            Brand = brand;
            Country = country;
        }
        public string Brand { get; }
        public string Country { get; }

        public override bool Equals(object obj)
        {
            return obj is TKey key &&
                   Brand == key.Brand &&
                   Country == key.Country;
        }

        public override int GetHashCode()
        {
            return Brand.GetHashCode() ^ Country.GetHashCode();
        }
    }
}
