using DataGridViewProject.Entities.Models;

namespace DataGridViewProject.Manager.Contracts
{
    /// <summary>
    /// Интерфейс сервиса для управления информации о товарах
    /// </summary>
    public interface IProductManager
    {
        /// <summary>
        /// Получить все товары
        /// </summary>
        public Task<IEnumerable<ProductModel>> GetAllProducts(CancellationToken cancellationToken = default);

        /// <summary>
        /// Добавить новый товар
        /// </summary>
        public Task AddProduct(ProductModel product, CancellationToken cancellationToken = default);

        /// <summary>
        /// Обновить товар
        /// </summary>
        public Task UpdateProduct(ProductModel product, CancellationToken cancellationToken = default);

        /// <summary>
        /// Удалить товар по ID
        /// </summary>
        public Task DeleteProduct(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Найти товар по ID
        /// </summary>
        public Task<ProductModel?> GetProductById(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить общую стоимость товара БЕЗ НДС (Цена * Количество)
        /// </summary>
        public Task<decimal> GetProductTotalPriceWithoutTax(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить статистику по продуктам на складе
        /// </summary>
        /// <returns></returns>
        public Task<ProductStatistics> GetStatistics(CancellationToken cancellationToken = default);
    }
}
