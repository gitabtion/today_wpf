using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace today_wpf.dto.request
{
    class AddCommentRequest:BaseRequest
    {
        public String comment { get; set; }
        public AddCommentRequest(long id,String comment)
        {
            this.method = RestSharp.Method.POST;
            this.comment = comment;
            this.router = "/calendar/" + id.ToString() + "/comment";
        }
    }
}
