using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace today_wpf.dto.request
{
    public class UserLoginRequest:BaseRequest
    {
        public string name { get; set; }
        public string password { get; set; }
        public int client { get; set; }
        
        public UserLoginRequest(string name,string password)
        {
            this.name = name;
            this.password = password;
            this.client = 1;
            this.method = RestSharp.Method.POST;
            this.router = "/user/login";
        }

        
    }      
}

