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
    }
}
