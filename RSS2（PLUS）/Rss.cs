using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS阅读器2
{
    class Rss
    {
        public struct Channel
        {
            public string title;
            public Hashtable Item;
        }

        public struct Item
        {
            public string title;
            public string description;
            public string link;
            public string author;
            public string pubdate;
        }
    }
}
