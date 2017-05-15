using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MyClient
    {
        private static string API_TOKEN_NAME = "X-Auth-Token";
        private static string API_TOKEN_VALUE = "4939b002b9e94cf987ca8a2e9c2bbf6e";
        private static string API_RESPONSE_CONTROL = "X-Response-Control";
        private static string API_RESPONSE_CONTROL_FULL = "full";
        private static string API_RESPONSE_CONTROL_MINIFIED = "minified";
        private static string API_RESPONSE_CONTROL_COMPRESSED = "compressed";

        private static string API_URL = "http://api.football-data.org/";

        public static HttpClient GetClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(API_URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add(API_TOKEN_NAME, API_TOKEN_VALUE);
            client.DefaultRequestHeaders.Add(API_RESPONSE_CONTROL, API_RESPONSE_CONTROL_MINIFIED);
            return client;
        }
    }
}
