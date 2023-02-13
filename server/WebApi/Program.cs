using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // NLog: setup the logger first to catch all errors
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("INIT MAIN");

                var host = CreateWebHostBuilder(args).Build();

                host.Run();

                logger.Debug("RUN EXITED");
            }
            catch (Exception ex)
            {
                //NLog: catch setup errors
                logger.Error(ex, "STOPPED PROGRAM BECAUSE OF EXCEPTION");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.UseKestrel(options => options.AddServerHeader = false)
                .CaptureStartupErrors(true)
                .UseSetting(WebHostDefaults.DetailedErrorsKey, "true")
                //.UseEnvironment(EnvironmentName.Development) // !!!
                .UseIISIntegration()
                .UseStartup<Startup>();
    }
}
