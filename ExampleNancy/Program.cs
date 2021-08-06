using System;
using Nancy.Hosting.Self;

namespace ExampleNancy
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new NancyHost(new Uri("http://localhost:1234")))
            {
                host.Start();
                Console.WriteLine("running");
                Console.ReadKey();
            }
        }
    }
}
