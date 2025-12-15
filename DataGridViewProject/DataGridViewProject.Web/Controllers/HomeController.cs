using DataGridViewProject.Entities.Models;
using DataGridViewProject.Manager;
using DataGridViewProject.Manager.Contracts;
using DataGridViewProject.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading;

namespace DataGridViewProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductManager productManager;

        public HomeController(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        public async Task<IActionResult> Index()
        {
            var products = await productManager.GetAllProducts();
            var statistics = await productManager.GetStatistics();

            var model = new IndexViewModel
            {
                Products = products.ToList(),
                Statistics = statistics
            };

            return View(model); 
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await productManager.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await productManager.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await productManager.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await productManager.UpdateProduct(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
