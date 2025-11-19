using DataGridViewProject.Services.Contracts;
using DataGridViewProject.Services;
using DataGridViewProject.Forms;

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
            ApplicationConfiguration.Initialize();
            IProductService productService = new InMemoryStorage();
            Application.Run(new MainForm(productService));
        }
    }
}