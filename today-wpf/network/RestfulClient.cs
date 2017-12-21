using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using today_wpf.dto.request;
using today_wpf.dto.response;

namespace today_wpf.network
{
    class RestfulClient<T>
    {
        public T response { get; set; }
        public RestfulClient(BaseRequest baseRequest)
        {
            
            var client = new RestClient(Env.BASE_URL);
            var request = new RestRequest(baseRequest.router, baseRequest.method);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(baseRequest);
            IRestResponse<BaseResponse<T>> responseO = client.Execute<BaseResponse<T>>(request);
            this.response = responseO.Data.data;



        }



    }
}
