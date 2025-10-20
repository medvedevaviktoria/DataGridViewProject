using System.ComponentModel.DataAnnotations;

namespace DataGridViewProject.Models
{

    /// <summary>
    /// Модель продукта
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование товара
        /// </summary>
        [Required(ErrorMessage = "Заполните наименование продукта")]
        [StringLength(255)]
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Размер
        /// </summary>
        [Required(ErrorMessage = "Заполните размер продукта")]
        [StringLength(50)]
        public string ProductSize { get; set; } = string.Empty;

        /// <inheritdoc cref="Models.Material"/>
        public Material Material { get; set; }

        /// <summary>
        /// Количество на складе
        /// </summary>
        [Range(0, 10000, ErrorMessage = "Количество должно быть от 0 до 10000")]
        public int Quantity { get; set; }

        /// <summary>
        /// Минимальный предел количества
        /// </summary>
        [Range(0, 10000, ErrorMessage = "Минимальный предел должен от 0 до 10000")]
        public int MinQuantity { get; set; }

        /// <summary>
        /// Цена без НДС
        /// </summary>
        [Range(0.01, 10000, ErrorMessage = "Цена должна быть в диапазоне от 0 до 10000")]
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
