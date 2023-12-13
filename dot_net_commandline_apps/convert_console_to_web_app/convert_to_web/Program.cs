using Microsoft.Extensions.Hosting;
using System;
namespace convert_to_web
{
    class Program
    {
        static void Main(string[] args){
            Console.WriteLine("Hello world!");
        }

        //creating a host builder method
        public static IHostBuilder CreateHostBuilder(string[] args){
            Host.CreateHostBuilder(args);
        } 
    }
}
