using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace OpenWeatherMap_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            Console.Write("Please enter your API Key: ");

            var api_Key = Console.ReadLine();

            while (true)
            {
                Console.WriteLine();
                Console.Write("Please enter the city name: ");
                var city_name = Console.ReadLine();
                Console.WriteLine();

                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&units=imperial&appid={api_Key}";
                var response = client.GetStringAsync(weatherURL).Result;
                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine($"The current Temperature is {JObject.Parse(formattedResponse).GetValue("temp")} degrees Fahrenheit");
                AddSpaces(2);
                Console.WriteLine("Would you like to exit?");
                var userInput = Console.ReadLine();
                AddSpaces(2);

                if (userInput.ToLower().Trim() == "yes")
                {
                    break;
                }

            }
            

            static void AddSpaces(int numberOfSpaces)
            {
                while (numberOfSpaces != 0)
                {
                    Console.WriteLine();
                    numberOfSpaces--;
                }
            }

        }
    }
}
