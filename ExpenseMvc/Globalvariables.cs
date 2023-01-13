using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace ExpenseMVC
{
    static public class Globalvariables
    {
        public static HttpClient webApiClient = new HttpClient();
        static Globalvariables()
        {
            webApiClient.BaseAddress = new Uri("https://localhost:44366/api/");
            webApiClient.DefaultRequestHeaders.Clear();
            webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}