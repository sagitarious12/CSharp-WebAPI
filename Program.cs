using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using _Logger;

namespace Web_API_Test
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Logger log = new Logger();
      log.Success(args);
      CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
  }
}
