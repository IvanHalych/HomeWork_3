using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1._3
{
    class TValue : IRegionSettings
    {
        public TValue(string webSite)
        {
            WebSite = webSite;
        }

        public string WebSite { get; }
    }
}
