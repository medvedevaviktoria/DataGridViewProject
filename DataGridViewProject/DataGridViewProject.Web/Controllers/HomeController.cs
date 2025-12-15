using DataGridViewProject.Entities.Models;
using DataGridViewProject.Manager.Contracts;
using DataGridViewProject.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataGridViewProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductManager productManager;

        /// <summary>
        /// Инициализирует контроллер
        /// </summary>
        public HomeController(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        /// <summary>
        /// Отображает главную страницу со списком товаров и статистикой по складу
        /// </summary>
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

        /// <summary>
        /// Отображает страницу подтверждения удаления выбранного товара
        /// </summary>
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

        /// <summary>
        /// Выполняет удаление товара после подтверждения пользователем
        /// </summary>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await productManager.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает форму редактирования выбранного товара
        /// </summary>
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

        /// <summary>
        /// Принимает изменения товара из формы и сохраняет их
        /// </summary>
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

        /// <summary>
        /// Отображает пустую форму для добавления нового товара
        /// </summary>
        [HttpGet]
        public IActionResult Create()
        {
            var model = new ProductModel(); 
            return View(model);
        }

        /// <summary>
        /// Принимает данные нового товара из формы и добавляет его в хранилище
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(ProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await productManager.AddProduct(model);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает страницу с политикой конфиденциальности
        /// </summary>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Отображает страницу ошибки с информацией о текущем запросе
        /// </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
