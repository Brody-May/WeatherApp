using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;

namespace OpenWeatherMap_Exercise 
{ 
    class Program 
    { 
        static void Main(string[] args) 
        { 
            var client = new HttpClient();

            var APIKey = "7df1d3eb764e5823d6a96ca295d7a31f";

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the city name: ");
                var city_name = Console.ReadLine();
                Console.WriteLine();

                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&appid={APIKey}";
                var response = client.GetStringAsync(weatherURL).Result;
                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine($"The current Temperature is {JObject.Parse(formattedResponse).GetValue("temp")} degrees Fahrenheit");
                
                Console.WriteLine("Would you like to exit?");
                var userInput = Console.ReadLine();

                if (userInput.ToLower().Trim() == "yes") 
                {
                    break;
                }

            }
}