using DataGridViewProject.Models;

namespace DataGridViewProject.Forms
{
    public partial class ProductForm : Form
    {
        private readonly ProductModel targetProduct;

        public ProductForm(ProductModel? sourceProduct = null)
        {
            InitializeComponent();
            if (sourceProduct != null)
            {
                targetProduct = new ProductModel
                {
                    Id = sourceProduct.Id,
                    ProductName = sourceProduct.ProductName,
                    ProductSize = sourceProduct.ProductSize,
                    Material = sourceProduct.Material,
                    Quantity = sourceProduct.Quantity,
                    MinQuantity = sourceProduct.MinQuantity,
                    PriceWithoutVAT = sourceProduct.PriceWithoutVAT
                };
                buttonAddProduct.Text = "Сохранить";
            }
            else
            {
                targetProduct = new ProductModel
                {
                    Id = Guid.NewGuid(),
                    ProductName = "",
                    ProductSize = "",
                    Material = Material.Unknown,
                    Quantity = 0,
                    MinQuantity = 0,
                    PriceWithoutVAT = 0
                };
            }
            comboBoxMaterial.DataSource = Enum.GetValues(typeof(Material));
        }

        public ProductModel CurrentProduct => targetProduct;
    }
}
