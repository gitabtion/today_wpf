﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace today_wpf.dto.request
{
    class GetComment:BaseRequest
    {
        public GetComment(long id)
        {
            this.method = RestSharp.Method.GET;
            this.router = "/calendar/" + id.ToString()+"/comment";
        }
    }
}