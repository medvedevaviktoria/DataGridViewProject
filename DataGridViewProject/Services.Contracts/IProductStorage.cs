using DataGridViewProject.Entities.Models;

namespace DataGridViewProject.Services.Contracts
{
    /// <summary>
    /// Интерфейс сервиса для управления информации о товарах
    /// </summary>
    public interface IProductStorage
    {
        /// <summary>
        /// Получить все товары
        /// </summary>
        public Task<IEnumerable<ProductModel>> GetAllProducts();

        /// <summary>
        /// Добавить новый товар
        /// </summary>
        public Task AddProduct(ProductModel product);

        /// <summary>
        /// Обновить товар
        /// </summary>
        public Task UpdateProduct(ProductModel product);

        /// <summary>
        /// Удалить товар по ID
        /// </summary>
        public Task DeleteProduct(Guid id);

        /// <summary>
        /// Найти товар по ID
        /// </summary>
        public Task<ProductModel?> GetProductById(Guid id);

        /// <summary>
        /// Получить общую стоимость товара БЕЗ НДС (Цена * Количество)
        /// </summary>
        public Task<decimal> GetProductTotalPriceWithoutTax(Guid id);

    }
}
