using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace today_wpf.dto.request
{
    class GetSubscribedToday : BaseRequest
    {

        public GetSubscribedToday()
        {
            this.method = RestSharp.Method.GET;
            this.router = "/calendar/subscribed";
        }
    }
}
