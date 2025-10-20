using DataGridViewProject.Infrostructure;
using DataGridViewProject.Models;
using System.ComponentModel.DataAnnotations;

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
            textBoxProductName.AddBinding(x => x.Text, targetProduct, x => x.ProductName);
            textBoxProductSize.AddBinding(x => x.Text, targetProduct, x => x.ProductSize);
            numericUpDownQuantity.AddBinding(x => x.Value, targetProduct, x => x.Quantity);
            numericUpDownMinQuantity.AddBinding(x => x.Value, targetProduct, x => x.MinQuantity);
            numericUpDownPriceWithoutVAT.AddBinding(x => x.Value, targetProduct, x => x.PriceWithoutVAT);


        }

        public ProductModel CurrentProduct => targetProduct;

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            var context = new ValidationContext(targetProduct);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(targetProduct, context, results, true);

            if (isValid)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                foreach (var validationResult in results)
                {
                    foreach (var memberName in validationResult.MemberNames)
                    {
                        Control control = memberName switch
                        {
                            nameof(ProductModel.ProductName) => textBoxProductName,
                            nameof(ProductModel.ProductSize) => textBoxProductSize,
                            nameof(ProductModel.Quantity) => numericUpDownQuantity,
                            nameof(ProductModel.MinQuantity) => numericUpDownMinQuantity,
                            nameof(ProductModel.PriceWithoutVAT) => numericUpDownPriceWithoutVAT,
                            nameof(ProductModel.Material) => comboBoxMaterial,
                            _ => null
                        };

                        if (control != null)
                        {
                            errorProvider.SetError(control, validationResult.ErrorMessage);
                        }
                    }
                }
            }
        }
    }
}
