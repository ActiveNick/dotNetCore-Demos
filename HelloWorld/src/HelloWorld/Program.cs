using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Console.OutputEncoding = Encoding.UTF8; // Switch to UTF8 so we can print unicode characters like degrees (°)

            // Say hello using a library built only for .NET Core
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Type in your name and press ENTER:");

            GreetingService gsvc = new GreetingService();

            Console.ForegroundColor = ConsoleColor.Gray;
            string username = Console.ReadLine();  // Read the user's name from the console

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(gsvc.SayHello(username));

            // Give a weather update using an OpenWeatherMap.org library based on .NET Standard
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Where are you currently located? (type in a city & state then press ENTER)");

            Console.ForegroundColor = ConsoleColor.Gray;
            string location = Console.ReadLine();  // Read the user's location from the console

            // Instantiate the OpenWeatherMap service object
            OpenWeatherMapService owms = new OpenWeatherMapService();

            // We need to run this insiode of an asyn task sionce GetWeather in the OpenWeatherMap service
            // object runs as an async task. Otherwise, we wouldn't be able to await it
            Task.Run(async () =>
            {
                WeatherRoot wr = await owms.GetWeather(location);

                if (wr != null)
                {
                    // Prepare a weather message and displkay it on the console
                    string weatherText = $"The current temperature in {wr.Name} is {(int)wr.MainWeather.Temp}°F, with a high today of {(int)wr.MainWeather.MaximumTemp}° and a low of {(int)wr.MainWeather.MinimumTemp}°.";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(weatherText);
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Oops! Somewthing went wrong when retrieving the weather for your location.");
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
