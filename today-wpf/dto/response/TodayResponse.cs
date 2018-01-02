using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using today_wpf.model;

namespace today_wpf.dto.response
{
    public class TodayResponse
    {
        public String calendarName { get; set; }
        public String calendarPicture { get; set; }
        public long calendarId { get; set; }
        public List<Activity> good { get; set; }
        public List<Activity> bad { get; set; }
        public List<Item> recommend { get; set; }

        public TodayResponse()
        {
            this.good = new List<Activity>();
            this.bad = new List<Activity>();
            this.recommend = new List<Item>();
        }

        public override string ToString()
        {
            return calendarName;
        }
    }
}
