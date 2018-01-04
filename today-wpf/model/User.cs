using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace today_wpf.model
{
    [Serializable]
    public class User
    {
        public String name { get; set; }
        public String signature { get; set; }
        public String avatar { get; set; }
        public int sex { get; set; }
        public long createdAt { get; set; }
        public long updatedAt { get; set; }


    }
}

