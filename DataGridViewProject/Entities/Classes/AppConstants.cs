namespace Entities.Classes
{
    public class AppConstants
    {
        /// <summary>
        /// Минимальный лимит для количества продукта
        /// </summary>
        public const int QuantityMin = 0;

        /// <summary>
        /// Максимальный лимит для количества продукта
        /// </summary>
        public const int QuantityMax = 10000;

        /// <summary>
        /// Минимальный лимит для минимального количества продукта
        /// </summary>
        public const int MinQuantityMin = 0;

        /// <summary>
        /// Максимальный лимит для минимального количества продукта
        /// </summary>
        public const int MinQuantityMax = 10000;

        /// <summary>
        /// Минимальный лимит для цены на продукт
        /// </summary>
        public const double PriceMin = 0.01;

        /// <summary>
        /// Максимальный лимит для цены на продукт
        /// </summary>
        public const double PriceMax = 10000;

        /// <summary>
        /// Максимальная длина имени продукта
        /// </summary>
        public const int ProductNameMaxLength = 255;

        /// <summary>
        /// Максимальная длина размера продукта
        /// </summary>
        public const int ProductSizeMaxLength = 50;

        /// <summary>
        /// Ставка НДС (налога), коэффициент
        /// </summary>
        public const decimal TaxRate = 1.2m; // 20% НДС
    }
}
