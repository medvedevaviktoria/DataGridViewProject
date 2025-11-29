using DataGridViewProject.Constants;
using DataGridViewProject.Entities.Models;
using DataGridViewProject.Manager.Contracts;
using DataGridViewProject.MemoryStorage.Contracts;

namespace DataGridViewProject.Manager
{
    /// <summary>
    /// Класс управления хранилищем
    /// </summary>
    public class ProductManager(IProductStorage storage) : IProductManager
    {
        private IProductStorage Storage { get; } = storage;

        Task<IEnumerable<ProductModel>> IProductManager.GetAllProducts() => Storage.GetAllProducts();

        Task IProductManager.AddProduct(ProductModel product) => Storage.AddProduct(product);

        Task IProductManager.UpdateProduct(ProductModel product) => Storage.UpdateProduct(product);

        Task IProductManager.DeleteProduct(Guid id) => Storage.DeleteProduct(id);

        Task<ProductModel?> IProductManager.GetProductById(Guid id) => Storage.GetProductById(id);

        Task<decimal> IProductManager.GetProductTotalPriceWithoutTax(Guid id) => Storage.GetProductTotalPriceWithoutTax(id);

        async Task<ProductStatistics> IProductManager.GetStatistics()
        {
            var products = await (Storage).GetAllProducts();
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
