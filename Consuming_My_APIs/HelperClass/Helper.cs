using System;
using System.Net.Http;
namespace Consuming_My_APIs.HelperClass
{
    public class EmployeeHelperClass
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7104/api/ControllerEmployee");
            return client;
        }
    }
}
