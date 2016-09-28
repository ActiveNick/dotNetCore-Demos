using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Hello World on .NET Core";

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Type in your name and press ENTER:");

            Console.ForegroundColor = ConsoleColor.Gray;
            string username = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Hello {username}, welcome to .NET Core!");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadLine();
            Console.ResetColor();
        }
    }
}
