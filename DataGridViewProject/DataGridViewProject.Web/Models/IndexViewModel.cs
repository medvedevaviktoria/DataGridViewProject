using DataGridViewProject.Entities.Models;
using DataGridViewProject.Manager.Contracts;

namespace DataGridViewProject.Web.Models
{
    /// <summary>
    /// Модель продукта для главной страницы
    /// </summary>
    public class IndexViewModel
    {
        /// <summary>
        /// Таблица с данными
        /// </summary>
        public List<ProductModel> Products { get; set; } = [];

        /// <summary>
        /// Статистика по складу
        /// </summary>
        public ProductStatistics Statistics { get; set; } = new();
    }
}
