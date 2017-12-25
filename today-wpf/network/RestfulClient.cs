using RestSharp;
using System;
using System.Threading.Tasks;
using today_wpf.dto.request;
using today_wpf.dto.response;
using today_wpf;
namespace today_wpf.network
{
    class RestfulClient<T>:IDisposable
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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<T> GetResponse()
        {
            request.AddHeader("token", "d07d3d8943404b36b1a029f0e0a9d10e");
            try
            {
                this.responseO = await client.ExecuteTaskAsync<BaseResponse<T>>(request);
            }
            catch (Exception e)
            {

                ShowSystemNotice("请求失败", "网络异常", 2);
                return default(T);
            }

            if (responseO.IsSuccessful == false)
            {
                 ShowSystemNotice("请求失败", "服务器异常", 2);
                return default(T);
            }
            else
            {
                if(responseO.Data.code != 0)
                {
                   
                    ShowSystemNotice("请求失败", responseO.Data.message, 2);
                    return default(T);
                }
            }
           
            this.response = responseO.Data.data;
            return this.response;
        }

       
        private void ShowSystemNotice(string title, string content, int timeOut)
        {
            MainWindow mainWindow = MainWindow.GetInstance();
           
            
            
            mainWindow.notifyIcon.BalloonTipTitle = title;
            mainWindow.notifyIcon.BalloonTipText = content;
            mainWindow.notifyIcon.ShowBalloonTip(timeOut);
            
          
           
           
        }
    }
}
