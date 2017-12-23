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
        private T response;
        private RestRequest request;
        private RestClient client;
        private IRestResponse<BaseResponse<T>> responseO;
        private string token;
        public RestfulClient(BaseRequest baseRequest)
        {
            this.client = new RestClient(Env.BASE_URL);
            this.request = new RestRequest(baseRequest.router, baseRequest.method);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(baseRequest);
        }
        
        public RestfulClient(string router)
        {
            this.client = new RestClient(Env.BASE_URL);
            this.request = new RestRequest(router,Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
        }

        public void AddParameter(string key,string value)
        {
            this.request.AddQueryParameter(key, value);
        }

        public void AddUrlSegment(string key,int value)
        {
            this.request.AddUrlSegment(key, value);
        }

        public T GetResponse()
        {
            if(responseO.IsSuccessful == false)
            {
                throw new Exception();
               
            }
            else
            {
                if(responseO.Data.code != 0)
                {
                    //toast
                    Console.WriteLine(responseO.Data.message);
                    return default(T);
                }
            }
           
            this.response = responseO.Data.data;
            return this.response;
        }

        public void Send()
        {
            request.AddHeader("token", "d07d3d8943404b36b1a029f0e0a9d10e");
            try
            {
            this.responseO = client.Execute<BaseResponse<T>>(request);
            }
            catch(Exception e)
            {

                //toast
                Console.WriteLine();
            }
           
        }
    }
}
