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
            var client = new HttpClient();

            for (int i = 0; i < 5; i++)
            {
                var kanyeResponse = client.GetStringAsync("https://api.kanye.rest").Result;
                var ronResponse = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

                Console.WriteLine($" Kanye West  - {kanyeQuote}");
                Console.WriteLine();
                Console.WriteLine($" Ron Swanson - {ronQuote}");
            }
            
        }
    }
}
