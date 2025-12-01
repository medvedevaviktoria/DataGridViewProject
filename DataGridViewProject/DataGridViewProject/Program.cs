using DataGridViewProject.Forms;
using DataGridViewProject.Manager;
using DataGridViewProject.MemoryStorage;
using Microsoft.Extensions.Logging;
using Serilog;

namespace DataGridViewProject.App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           using var log = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.File("logs/log-.txt",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.Seq("http://localhost:5341",
                    apiKey: "ilGJHIZ2Pb05nGLsAXkJ")
                .CreateLogger();

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog(log);
            });

            var storage = new InMemoryStorage();
            var productManager = new ProductManager(storage, loggerFactory);


            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(productManager));
        }
    }
}