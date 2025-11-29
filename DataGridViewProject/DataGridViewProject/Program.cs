using DataGridViewProject.Forms;
using DataGridViewProject.Manager;
using DataGridViewProject.Services;

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
            var products = new InMemoryStorage();
            var productManager = new ProductManager(products);
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(productManager));
        }
    }
}