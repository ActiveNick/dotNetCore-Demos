using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld_Lib;
using OpenWeatherMap;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Hello World on .NET Core";

            // Say hello using a library built only for .NET Core
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Type in your name and press ENTER:");

            GreetingService gsvc = new GreetingService();

            Console.ForegroundColor = ConsoleColor.Gray;
            string username = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(gsvc.SayHello(username));

            // Give a weather update using an OpenWeatherMap.org library based on .NET Standard
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Where are you currently located? (type in a city & state then press ENTER)");

            Console.ForegroundColor = ConsoleColor.Gray;
            string location = Console.ReadLine();

            OpenWeatherMapService owms = new OpenWeatherMapService();
            Task.Run(async () =>
            {
                WeatherRoot wr = await owms.GetWeather(location);

                if (wr != null)
                {
                    string weatherText = $"The current temperature in {wr.Name} is {wr.MainWeather.Temp}°F, with a high today of {wr.MainWeather.MaximumTemp}° and a low of {wr.MainWeather.MinimumTemp}°.";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(weatherText);
                }
            }).Wait();

            // End of program
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadLine();
            Console.ResetColor();
        }
    }
}
