using DataGridViewProject.Infrostructure;
using DataGridViewProject.Models;

namespace DataGridViewProject.Forms
{
    public partial class ProductForm : Form
    {
        private readonly ProductModel targetProduct;
        private readonly ErrorProvider errorProvider = new ErrorProvider();
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

            
            comboBoxMaterial.AddBinding(x => x.SelectedItem, targetProduct, x => x.Material);
            textBoxProductName.AddBinding(x => x.Text, targetProduct, x => x.ProductName, errorProvider);
            textBoxProductSize.AddBinding(x => x.Text, targetProduct, x => x.ProductSize, errorProvider);
            numericUpDownQuantity.AddBinding(x => x.Value, targetProduct, x => x.Quantity);
            numericUpDownMinQuantity.AddBinding(x => x.Value, targetProduct, x => x.MinQuantity);
            numericUpDownPriceWithoutVAT.AddBinding(x => x.Value, targetProduct, x => x.PriceWithoutVAT, errorProvider);
        }

        public ProductModel CurrentProduct => targetProduct;

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }
    }
}
