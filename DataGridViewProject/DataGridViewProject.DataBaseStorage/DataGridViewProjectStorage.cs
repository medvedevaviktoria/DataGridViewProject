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
        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            using var database = new DataGridViewProjectContext();
            return await database.Products.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Добавить новый товар
        /// </summary>
        public async Task AddProduct(ProductModel product)
        {
            using var database = new DataGridViewProjectContext();
            database.Products.Add(product);
            await database.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить товар
        /// </summary>
        public async Task UpdateProduct(ProductModel product)
        {
            using var database = new DataGridViewProjectContext();
            database.Products.Update(product);
            await database.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить товар по ID
        /// </summary>
        public async Task DeleteProduct(Guid id)
        {
            using var database = new DataGridViewProjectContext();
            var product = await database.Products.FindAsync(id);
            if (product != null)
            {
                database.Products.Remove(product);
                await database.SaveChangesAsync();
            }
        }


        /// <summary>
        /// Найти товар по ID
        /// </summary>
        public async Task<ProductModel?> GetProductById(Guid id)
        {
            using var database = new DataGridViewProjectContext();
            return await database.Products.FindAsync(id);
        }

        /// <summary>
        /// Получить общую стоимость товара БЕЗ НДС (Цена * Количество)
        /// </summary>
        public async Task<decimal> GetProductTotalPriceWithoutTax(Guid id)
        {
            using var database = new DataGridViewProjectContext();
            var product = await database.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            return product is null ? 0m : product.PriceWithoutTax * product.Quantity;
        }
    }
}
