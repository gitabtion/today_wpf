using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace today_wpf.dto.request
{
    public class BaseRequest
    {
        public string router { set; get; }
        public Method method { set; get; }
    }
}
