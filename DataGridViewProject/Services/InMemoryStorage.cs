using DataGridViewProject.Models;
using Services.Contracts;

namespace Services
{
    /// <summary>
    /// Сервис для доступа к товарам, хранящимся в памяти
    /// </summary>
    public class InMemoryStorage : IProductService
    {
        private List<ProductModel> products;

        public InMemoryStorage()
        {
            // Инициализация тестовыми данными
            products = new List<ProductModel>
            {
                new ProductModel
                {
                    Id = Guid.NewGuid(),
                    ProductName = "Гвозди медные декоративные",
                    ProductSize = "2x40 мм",
                    Material = Material.Copper,
                    Quantity = 100,
                    MinQuantity = 45,
                    PriceWithoutTax = 1.25m
                },
                new ProductModel
                {
                    Id = Guid.NewGuid(),
                    ProductName = "Гвозди строительные",
                    ProductSize = "3x70 мм",
                    Material = Material.Steel,
                    Quantity = 500,
                    MinQuantity = 100,
                    PriceWithoutTax = 0.75m
                },
                new ProductModel
                {
                    Id = Guid.NewGuid(),
                    ProductName = "Гвозди антикоррозийные",
                    ProductSize = "4x90 мм",
                    Material = Material.Chrome,
                    Quantity = 300,
                    MinQuantity = 80,
                    PriceWithoutTax = 1.10m
                }
            };
        }

        /// <summary>
        /// Получить все товары
        /// </summary>
        public async Task<IEnumerable<ProductModel>> GetAllProducts() => await Task.FromResult<IEnumerable<ProductModel>>(products.ToList());

        /// <summary>
        /// Добавить новый товар
        /// </summary>
        public async Task AddProduct(ProductModel product)
        {
            products.Add(product);
            await Task.CompletedTask;
        }

        /// <summary>
        /// Обновить товар
        /// </summary>
        public async Task UpdateProduct(ProductModel product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);

            existingProduct.ProductName = product.ProductName;
            existingProduct.ProductSize = product.ProductSize;
            existingProduct.Material = product.Material;
            existingProduct.Quantity = product.Quantity;
            existingProduct.MinQuantity = product.MinQuantity;
            existingProduct.PriceWithoutTax = product.PriceWithoutTax;

            await Task.CompletedTask;
        }

        /// <summary>
        /// Удалить товар по ID
        /// </summary>
        public async Task DeleteProduct(Guid id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            products.Remove(product);

            await Task.CompletedTask;
        }

        /// <summary>
        /// Найти товар по ID
        /// </summary>
        public async Task<ProductModel> GetProductById(Guid id) => await Task.FromResult(products.FirstOrDefault(p => p.Id == id));

        /// <summary>
        /// Получить общее количество всех товаров на складе
        /// </summary>
        public async Task<int> GetProductCount() => await Task.FromResult(products.Count);

        /// <summary>
        /// Получить общую стоимость всех товаров БЕЗ НДС
        /// </summary>
        public async Task<decimal> GetTotalPrice()
        {
            var total = products.Sum(p => p.PriceWithoutTax * p.Quantity);
            return await Task.FromResult(total);
        }

        /// <summary>
        /// Получить общую стоимость всех товаров С НДС (20%)
        /// </summary>
        public async Task<decimal> GetTotalPriceWithTax()
        {
            var total = products.Sum(p => p.PriceWithoutTax * p.Quantity);
            var totalWithTax = total * 1.2m;
            return await Task.FromResult(totalWithTax);
        }
    }
}
