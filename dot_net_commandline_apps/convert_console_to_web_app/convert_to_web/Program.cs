using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore;
using System;
namespace convert_to_web
{
    class Program
    {
        static void Main(string[] args){
            Console.WriteLine("Hello world!");
        }

        //creating a host builder method
        // public static IHostBuilder CreateHostBuilder(string[] args){
        //     Host.CreateHostBuilder(args);
        // }This may not work on some system becoz CreateHostBuilder function may not be present in IHostBuilder inside Microsoft.Extensions.Hosting;
        //
        public static WebHost CreateDefaultBuilder(string[] args){
            Host.CreateDefaultBuilder();
        }
    }
}
