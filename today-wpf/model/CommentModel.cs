using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace today_wpf.model
{
    class CommentModel
    {
        public String userName { get; set; }
        public String userAvatar { get; set; }
        public String comment { get; set; }
        public long createdAt { get; set; }
    }
}
