using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace today_wpf.Squre
{
    public class CalendarModel
    {
        public String title { get; set; }
        public long id { get; set; }
        public String picture { get; set; }
        public int subscribed { get; set; }
        public bool isSubcribed { get; set; }
        public String description { get; set; }
        public long creatorId { get; set; }
        public long createdAt { get; set; }
        public long updatedAt { get; set; }
        public int isPublic { get; set; }
        public String password { get; set; }
        public int goodPick { get; set; }
        public int badPick { get; set; }
    }
}
