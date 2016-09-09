﻿using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory() + "/wwwroot")
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
