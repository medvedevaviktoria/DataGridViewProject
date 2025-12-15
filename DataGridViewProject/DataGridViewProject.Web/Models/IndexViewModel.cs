using DataGridViewProject.Entities.Models;
using DataGridViewProject.Manager.Contracts;

namespace DataGridViewProject.Web.Models
{
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
