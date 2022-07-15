using APINasa.Controllers;
using APINasa.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINasa
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var api = new API();
            ModelController nuevo = new ModelController(api);
            var ns = nuevo.GetTop3(3).Result.ToString();
            Console.ReadLine();
            CreateHostBuilder(args).Build().Run();
            
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
