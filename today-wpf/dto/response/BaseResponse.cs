using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace today_wpf.dto.response
{
    class BaseResponse<T>
    {
        public int code { get;set; }
        public T data { get; set; }
    }
}
