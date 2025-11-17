using Services;
using Services.Contracts;

namespace DataGridViewProject
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            IProductService productService = new InMemoryStorage();
            Application.Run(new MainForm(productService));
        }
    }
}