namespace DataGridViewProject.Models
{

    /// <summary>
    /// Модель продукта
    /// </summary>
    internal class ProductModel
    {
        /// <summary>
        /// Наименование товара
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Размер
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Материал 
        /// </summary>
        public Material Material { get; set; }

        /// <summary>
        /// Количество на складе
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Минимальный предел количества
        /// </summary>
        public int MinQuantity { get; set; }

        /// <summary>
        /// Цена без НДС
        /// </summary>
        public decimal PriceWithoutVAT { get; set; }

        /// <summary>
        /// Общая цена без НДС
        /// </summary>
        public decimal TotalPriceWithoutVAT
        {
            get { return PriceWithoutVAT * Quantity; }
        }

        /// <summary>
        /// Общая цена с НДС
        /// </summary>
        public decimal TotalPriceWithVAT
        {
            get { return TotalPriceWithoutVAT * 1.2m; } // 20% НДС 
        }
    }
}
