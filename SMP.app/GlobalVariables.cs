using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace SMP
{
    public static class GlobalVariables
    {
        //public static string url = "http://localhost:3373/";
        public static string url = "http://accountinglab-001-site2.etempurl.com/";
        public static HttpClient client = new HttpClient();

        static GlobalVariables()
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}