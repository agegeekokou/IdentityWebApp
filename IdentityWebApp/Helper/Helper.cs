using System;
using System.Net.Http;

namespace IdentityWebApp.Helper
{
    public class IdentityWebAPI
    {
        public HttpClient Initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:48667");

            return Client;
        }
    }
}
