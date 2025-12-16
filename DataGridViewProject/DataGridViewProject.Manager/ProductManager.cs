using DataGridViewProject.Constants;
using DataGridViewProject.Entities.Models;
using DataGridViewProject.Manager.Contracts;
using DataGridViewProject.MemoryStorage.Contracts;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace DataGridViewProject.Manager
{
    /// <summary>
    /// Класс управления хранилищем
    /// </summary>
    public class ProductManager : IProductManager
    {
        private readonly IProductStorage storage;
        private readonly ILogger logger;

        /// <summary>
        /// Инициализирует экземпляр <see cref="<ProductManager>"/>
        /// </summary>
        public ProductManager(IProductStorage storage, ILoggerFactory loggerFactory)
        {
            this.storage = storage;
            logger = loggerFactory.CreateLogger<ProductManager>();
        }

        async Task<IEnumerable<ProductModel>> IProductManager.GetAllProducts(CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var result = await storage.GetAllProducts(cancellationToken);
                return result;
            }
            finally
            {
                sw.Stop();
                logger.LogInformation("GetAllProducts completed in {ElapsedMilliseconds} ms", sw.ElapsedMilliseconds);
            }
        }

        async Task IProductManager.AddProduct(ProductModel product, CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.AddProduct(product, cancellationToken);
            }
            finally
            {
                sw.Stop();
                logger.LogInformation("AddProduct completed in {ElapsedMilliseconds} ms", sw.ElapsedMilliseconds);
            }
        }

        async Task IProductManager.UpdateProduct(ProductModel product, CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.UpdateProduct(product, cancellationToken);
            }
            finally
            {
                sw.Stop();
                logger.LogInformation("UpdateProduct completed in {ElapsedMilliseconds} ms", sw.ElapsedMilliseconds);
            }
        }

        async Task IProductManager.DeleteProduct(Guid id, CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                await storage.DeleteProduct(id, cancellationToken);
            }
            finally
            {
                sw.Stop();
                logger.LogInformation("DeleteProduct completed in {ElapsedMilliseconds} ms", sw.ElapsedMilliseconds);
            }
        }

        async Task<ProductModel?> IProductManager.GetProductById(Guid id, CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var result = await storage.GetProductById(id, cancellationToken);
                return result;
            }
            finally
            {
                sw.Stop();
                logger.LogInformation("GetProductById completed in {ElapsedMilliseconds} ms", sw.ElapsedMilliseconds);
            }
        }

        async Task<decimal> IProductManager.GetProductTotalPriceWithoutTax(Guid id, CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var result = await storage.GetProductTotalPriceWithoutTax(id, cancellationToken);
                return result;
            }
            finally
            {
                sw.Stop();
                logger.LogInformation("GetProductTotalPriceWithoutTax completed in {ElapsedMilliseconds} ms", sw.ElapsedMilliseconds);
            }
        }

        async Task<ProductStatistics> IProductManager.GetStatistics(CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var products = await (storage).GetAllProducts(cancellationToken);
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
                logger.LogInformation("GetStatistics completed in {ElapsedMilliseconds} ms", sw.ElapsedMilliseconds);
            }

        }
    }
}
