using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Mvc
{
    public static class GlobalVariables
    {
        public static HttpClient wepApiClient = new HttpClient();

        static GlobalVariables()
        {
            wepApiClient.BaseAddress = new Uri("https://localhost:44368/api/");
            wepApiClient.DefaultRequestHeaders.Clear();
            wepApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}