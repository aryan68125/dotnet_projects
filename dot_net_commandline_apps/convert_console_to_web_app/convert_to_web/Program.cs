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

        // //creating a host builder method. This is not working on my laptop because IHostbuilder doesn't have a 
        //method called CreateHostBuilder
        // public static IHostBuilder CreateHostBuilder(string[] args){
        //     Host.CreateHostBuilder(args);
        // }
        // This may not work on some system becoz CreateHostBuilder function may not be present in IHostBuilder inside Microsoft.Extensions.Hosting;

//This code will create a host builder 
 public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                // remove the hosted service
                // services.AddHostedService<Worker>();

                // register your services here.
            });
    }
}
