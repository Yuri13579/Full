using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SharedAll.DTO;

namespace Back
{
    public class Program
    {
        public static void Main(string[] args)
            {
                BuildWebHost(args).Run();
            
        }
        
            public static IWebHost BuildWebHost(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseConfiguration(new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddCommandLine(args)
                        .Build())
                    .UseStartup<Startup>()
                    .Build();
        
    }
}
