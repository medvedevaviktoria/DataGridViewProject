namespace DataGridViewProject.Manager.Contracts
{
    /// <summary>
    /// Класс для хранения статистики продуктов
    /// </summary>
    public class ProductStatistics
    {
        /// <summary>
        /// Всего товаров на складе
        /// </summary>
        public int ProductCount { get; set; }

        /// <summary>
        /// Общая сумма без НДС
        /// </summary>
        public decimal TotalWithoutTax { get; set; }

        /// <summary>
        /// Общая сумма с НДС
        /// </summary>
        public decimal TotalWithTax { get; set; }
    }
}
