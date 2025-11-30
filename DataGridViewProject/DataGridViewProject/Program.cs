using DataGridViewProject.Forms;
using DataGridViewProject.Manager;
using DataGridViewProject.MemoryStorage;
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
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.File("logs/log-.txt",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.Seq("http://localhost:5341",
                    apiKey: "ilGJHIZ2Pb05nGLsAXkJ")
                .CreateLogger();

            Log.Debug("Тестовый лог в Debug окне");

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(new ProductManager(new InMemoryStorage())));
        }
    }
}