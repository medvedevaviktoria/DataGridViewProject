using DataGridViewProject.Models;

namespace Services.Contracts
{
    public interface IProductService
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
        public Task<ProductModel> GetProductById(Guid id);

        /// <summary>
        /// Получить общее количество всех товаров на складе
        /// </summary>
        public Task<int> GetProductCount();

        /// <summary>
        /// Получить общую стоимость всех товаров БЕЗ НДС
        /// </summary>
        public Task<decimal> GetTotalPrice();

        /// <summary>
        /// Получить общую стоимость всех товаров С НДС (20%)
        /// </summary>
        public Task<decimal> GetTotalPriceWithTax();

        /// <summary>
        /// Получить общую стоимость товара БЕЗ НДС (Цена * Количество)
        /// </summary>
        public Task<decimal> GetProductTotalPriceWithoutTax(Guid id);
    }
}
