using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace today_wpf.dto.request
{
     public class UserRegisterRequest : BaseRequest
    {
      
         public String name { get; set; }
       
         public String password { get; set; }

         public int sex = 1;

         public String signature { get; set; }

        
         public UserRegisterRequest(string name,string password,string signature)
        {
            this.name = name;
            this.password = password;
            this.signature = signature;
            this.method = RestSharp.Method.POST;
            this.router = "/user/register";
        }
           
    }
}
