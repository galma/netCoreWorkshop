using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace resolution
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()  
                .AddCommandLine(args)                
                .Build();

            var host = new WebHostBuilder()
                .UseKestrel()                
                .UseStartup<Startup>()
                .UseIISIntegration() 
                .UseContentRoot(Directory.GetCurrentDirectory()) //  The server’s content root determines where it searches for content files, like MVC View files. The default content 
                .UseConfiguration(config)                
                .Build();

            host.Run();
        }
    }
}
