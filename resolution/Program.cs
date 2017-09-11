using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

namespace resolution
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .Configure(app => app.Run(context => context.Response.WriteAsync("Hello World, from ASP.NET!"))) 
                //.UseStartup<Startup>()
                //.UseIISIntegration() 
                //.UseContentRoot(Directory.GetCurrentDirectory()) //  The server’s content root determines where it searches for content files, like MVC View files. The default content 
                .Build();

            host.Run();
        }
    }
}
