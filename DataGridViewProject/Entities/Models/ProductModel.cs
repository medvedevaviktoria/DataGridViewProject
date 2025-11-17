using Constants;
using System.ComponentModel.DataAnnotations;

namespace DataGridViewProject.Models
{

    /// <summary>
    /// Модель продукта
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Наименование продукта
        /// </summary>
        [Display(Name = "Наименование продукта")]
        [Required(ErrorMessage = "{0} обязательно для заполнения")]
        [StringLength(AppConstants.ProductNameMaxLength, ErrorMessage = "{0} должен быть меньше {1} символов")]
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Размер
        /// </summary>
        [Display(Name = "Размер продукта")]
        [Required(ErrorMessage = "{0} обязателен для заполнения")]
        [StringLength(AppConstants.ProductSizeMaxLength, ErrorMessage = "{0} должен быть меньше {1} символов")]
        public string ProductSize { get; set; } = string.Empty;

        /// <inheritdoc cref="Models.Material"/>
        public Material Material { get; set; } = Material.Unknown;

        /// <summary>
        /// Количество на складе
        /// </summary>
        [Display(Name = "Количество продуктов на складе")]
        [Range(AppConstants.QuantityMin, AppConstants.QuantityMax, ErrorMessage = "{0} должно быть между {1} и {2}")]
        public int Quantity { get; set; }

        /// <summary>
        /// Минимальный предел количества
        /// </summary>
        [Display(Name = "Минимальный предел количества продукта")]
        [Range(AppConstants.MinQuantityMin, AppConstants.MinQuantityMax, ErrorMessage = "{0} должен быть между {1} и {2}")]
        public int MinQuantity { get; set; }

        /// <summary>
        /// Цена без НДС
        /// </summary>
        [Display(Name = "Цена за продукт без НДС")]
        [Range(AppConstants.PriceMin, AppConstants.PriceMax, ErrorMessage = "{0} должна быть в диапазоне от {1} до {2}")]
        public decimal PriceWithoutTax { get; set; }
    }
}
