using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld_Lib
{
    public class GreetingService
    {
        public GreetingService()
        {
            // Empty constructor
        }

        public string SayHello(string username)
        {
            return $"Hello {username}, welcome to .NET Core!";
        }
    }
}
