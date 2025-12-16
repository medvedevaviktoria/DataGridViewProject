using DataGridViewProject.Entities.Models;

namespace DataGridViewProject.MemoryStorage.Contracts
{
    /// <summary>
    /// Интерфейс сервиса для управления информации о товарах
    /// </summary>
    public interface IProductStorage
    {
        /// <summary>
        /// Получить все товары
        /// </summary>
        public Task<IEnumerable<ProductModel>> GetAllProducts(CancellationToken cancellationToken);

        /// <summary>
        /// Добавить новый товар
        /// </summary>
        public Task AddProduct(ProductModel product, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить товар
        /// </summary>
        public Task UpdateProduct(ProductModel product, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить товар по ID
        /// </summary>
        public Task DeleteProduct(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Найти товар по ID
        /// </summary>
        public Task<ProductModel?> GetProductById(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить общую стоимость товара БЕЗ НДС (Цена * Количество)
        /// </summary>
        public Task<decimal> GetProductTotalPriceWithoutTax(Guid id, CancellationToken cancellationToken);

    }
}
