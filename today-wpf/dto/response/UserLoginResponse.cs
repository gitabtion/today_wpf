using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using today_wpf.model;

namespace today_wpf.dto.response
{
    [Serializable]
    class UserLoginResponse
    {
        public String token { get; set; }
        public User user { get; set; }
    }
}
