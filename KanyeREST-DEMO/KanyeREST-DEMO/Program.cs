using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Net.Http;

namespace KanyeREST_DEMO
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var client = new HttpClient();

            //for (int i = 0; i < 5; i++)
            //{
            //    var kanyeResponse = client.GetStringAsync("https://api.kanye.rest").Result;
            //    var ronResponse = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
            //    var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            //    var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

            //    Console.WriteLine($" Kanye West  - {kanyeQuote}");
            //    Console.WriteLine($" Ron Swanson - {ronQuote}");
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}

            var client = new RestClient("https://call-of-duty-modern-warfare.p.rapidapi.com/warzone-matches/Amartin743/psn");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "call-of-duty-modern-warfare.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "074ffd9f62mshfab1a752b7e2342p1f409fjsnbc7bc16069e0");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

        }
    }
}
