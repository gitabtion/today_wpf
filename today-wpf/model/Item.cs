using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace today_wpf.model
{
    public class Item
    {
        public String name { get; set; }
        public List<String> items { get; set; }

        public Item()
        {
            this.items = new List<string>();
        }

        public String getItemString()
        {
            String res = "";
            for (int i=0;i<items.Count;i++)
            {
                res += items[i];
                res += " ";
            }
            return res;
        }
    }
}
