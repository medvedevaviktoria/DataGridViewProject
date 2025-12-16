using DataGridViewProject.Entities.Models;
using DataGridViewProject.MemoryStorage.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataGridViewProject.DataBaseStorage
{
    public class DataGridViewProjectStorage : IProductStorage
    {
        /// <summary>
        /// Получить все товары.
        /// </summary>
        public async Task<IEnumerable<ProductModel>> GetAllProducts(CancellationToken cancellationToken )
        {
            using var database = new DataGridViewProjectContext();
            return await database.Products.AsNoTracking().ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Добавить новый товар
        /// </summary>
        public async Task AddProduct(ProductModel product, CancellationToken cancellationToken)
        {
            using var database = new DataGridViewProjectContext();
            database.Products.Add(product);
            await database.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Обновить товар
        /// </summary>
        public async Task UpdateProduct(ProductModel product, CancellationToken cancellationToken)
        {
            using var database = new DataGridViewProjectContext();
            database.Products.Update(product);
            await database.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Удалить товар по ID
        /// </summary>
        public async Task DeleteProduct(Guid id, CancellationToken cancellationToken)
        {
            using var database = new DataGridViewProjectContext();
            var product = await database.Products.FindAsync(id, cancellationToken);
            if (product != null)
            {
                database.Products.Remove(product);
                await database.SaveChangesAsync(cancellationToken);
            }
        }


        /// <summary>
        /// Найти товар по ID
        /// </summary>
        public async Task<ProductModel?> GetProductById(Guid id, CancellationToken cancellationToken)
        {
            using var database = new DataGridViewProjectContext();
            return await database.Products.FindAsync(id, cancellationToken);
        }

        /// <summary>
        /// Получить общую стоимость товара БЕЗ НДС (Цена * Количество)
        /// </summary>
        public async Task<decimal> GetProductTotalPriceWithoutTax(Guid id, CancellationToken cancellationToken)
        {
            using var database = new DataGridViewProjectContext();
            var product = await database.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            return product is null ? 0m : product.PriceWithoutTax * product.Quantity;
        }
    }
}
