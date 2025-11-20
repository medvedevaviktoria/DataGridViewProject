using DataGridViewProject.Constants;
using DataGridViewProject.Entities.Models;
using DataGridViewProject.Services.Contracts;

namespace DataGridViewProject.Services
{
    /// <summary>
    /// Сервис для доступа к товарам, хранящимся в памяти
    /// </summary>
    public class InMemoryStorage : IProductService
    {
        private readonly List<ProductModel> products;

        /// <summary>
        /// Инициализация экземпляра InMemoryStorage
        /// </summary>
        public InMemoryStorage()
        {
            // Начальные данные
            products =
            [
                new ProductModel
                {
                    ProductName = "Гвозди медные декоративные",
                    ProductSize = "2x40 мм",
                    Material = Material.Copper,
                    Quantity = 100,
                    MinQuantity = 45,
                    PriceWithoutTax = 1.25m
                },
                new ProductModel
                {
                    ProductName = "Гвозди строительные",
                    ProductSize = "3x70 мм",
                    Material = Material.Steel,
                    Quantity = 500,
                    MinQuantity = 100,
                    PriceWithoutTax = 0.75m
                },
                new ProductModel
                {
                    ProductName = "Гвозди антикоррозийные",
                    ProductSize = "4x90 мм",
                    Material = Material.Chrome,
                    Quantity = 300,
                    MinQuantity = 80,
                    PriceWithoutTax = 1.10m
                }
            ];
        }

        async Task<IEnumerable<ProductModel>> IProductService.GetAllProducts() => await Task.FromResult<IEnumerable<ProductModel>>(products);

        async Task IProductService.AddProduct(ProductModel product)
        {
            products.Add(product);
            await Task.CompletedTask;
        }

        async Task IProductService.UpdateProduct(ProductModel product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                return;
            }

            existingProduct.ProductName = product.ProductName;
            existingProduct.ProductSize = product.ProductSize;
            existingProduct.Material = product.Material;
            existingProduct.Quantity = product.Quantity;
            existingProduct.MinQuantity = product.MinQuantity;
            existingProduct.PriceWithoutTax = product.PriceWithoutTax;

            await Task.CompletedTask;
        }

        async Task IProductService.DeleteProduct(Guid id)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return;
            }
            products.Remove(existingProduct);

            await Task.CompletedTask;
        }

        async Task<ProductModel?> IProductService.GetProductById(Guid id) => await Task.FromResult(products.FirstOrDefault(p => p.Id == id));

        async Task<decimal> IProductService.GetProductTotalPriceWithoutTax(Guid id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return 0;
            }
            var totalPrice = product.PriceWithoutTax * product.Quantity;
            return await Task.FromResult(totalPrice);
        }

        async Task<ProductStatistics> IProductService.GetStatistics()
        {
            var products = await ((IProductService)this).GetAllProducts();
            var statistics = new ProductStatistics
            {
                ProductCount = products.Count(),
                TotalWithoutTax = products.Sum(p => p.PriceWithoutTax * p.Quantity),
                TotalWithTax = products.Sum(p => p.PriceWithoutTax * AppConstants.TaxRate * p.Quantity)
            };
            return statistics;
        }
    }
}
