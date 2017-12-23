using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace today_wpf.dto.response
{
    class CalendarDetailResponse
    {
        public long id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public long creatorId { get; set; }
        public string creatorName { get; set; }
        public string creatorAvator { get; set; }
        public string subscribed { get; set; }
        public string picture { get; set; }
        public long createdAt { get; set; }
        public long updatedAt { get; set; }
        public string password { get; set; }
        public int goodPick { get; set; }
        public int badPick { get; set; }
    }
}
