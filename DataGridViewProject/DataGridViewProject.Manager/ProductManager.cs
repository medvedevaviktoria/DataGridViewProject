using DataGridViewProject.Constants;
using DataGridViewProject.Entities.Models;
using DataGridViewProject.Manager.Contracts;
using DataGridViewProject.MemoryStorage.Contracts;
using Serilog;
using System.Diagnostics;

namespace DataGridViewProject.Manager
{
    /// <summary>
    /// Класс управления хранилищем
    /// </summary>
    public class ProductManager : IProductManager
    {
        private readonly IProductStorage storage;

        /// <summary>
        /// Инициализирует экземпляр <see cref="<ProductManager>"/>
        /// </summary>
        public ProductManager(IProductStorage storage)
        {
            this.storage = storage;
        }

        async Task<IEnumerable<ProductModel>> IProductManager.GetAllProducts()
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var result = await storage.GetAllProducts();
                return result;
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("IProductManager.GetAllProducts выполнен за {ms:F6} мс", ms);
            }
        }

        async Task IProductManager.AddProduct(ProductModel product)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.AddProduct(product);
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("IProductManager.AddProduct выполнен за {ms:F6} мс", ms);
            }
        }

        async Task IProductManager.UpdateProduct(ProductModel product)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.UpdateProduct(product);
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("IProductManager.UpdateProduct выполнен за {ms:F6} мс", ms);
            }
        }

        async Task IProductManager.DeleteProduct(Guid id)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.DeleteProduct(id);
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("IProductManager.DeleteProduct выполнен за {ms:F6} мс", ms);
            }
        }

        async Task<ProductModel?> IProductManager.GetProductById(Guid id)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var result = await storage.GetProductById(id);
                return result;
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("IProductManager.GetProductById выполнен за {ms:F6} мс", ms);
            }
        }

        async Task<decimal> IProductManager.GetProductTotalPriceWithoutTax(Guid id)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var result = await storage.GetProductTotalPriceWithoutTax(id);
                return result;
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("IProductManager.GetProductTotalPriceWithoutTax выполнен за {ms:F6} мс", ms);
            }
        }

        async Task<ProductStatistics> IProductManager.GetStatistics()
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var products = await (storage).GetAllProducts();
                var statistics = new ProductStatistics
                {
                    ProductCount = products.Count(),
                    TotalWithoutTax = products.Sum(p => p.PriceWithoutTax * p.Quantity),
                    TotalWithTax = products.Sum(p => p.PriceWithoutTax * AppConstants.TaxRate * p.Quantity)
                };
                return statistics;
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("IProductManager.GetStatistics выполнен за {ms:F6} мс", ms);
            }

        }
    }
}
