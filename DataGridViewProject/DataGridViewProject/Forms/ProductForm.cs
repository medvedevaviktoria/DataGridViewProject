using DataGridViewProject.Infrastructure;
using DataGridViewProject.Models;
using System.ComponentModel.DataAnnotations;

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
                targetProduct = sourceProduct.Clone();
                buttonAddProduct.Text = "Сохранить";
            }
            else
            {
                targetProduct = new ProductModel();
            }
            comboBoxMaterial.DataSource = Enum.GetValues(typeof(Material));

            comboBoxMaterial.AddBinding(x => x.SelectedItem, targetProduct, x => x.Material, errorProvider1);
            textBoxProductName.AddBinding(x => x.Text, targetProduct, x => x.ProductName, errorProvider1);
            textBoxProductSize.AddBinding(x => x.Text, targetProduct, x => x.ProductSize, errorProvider1);
            numericUpDownQuantity.AddBinding(x => x.Value, targetProduct, x => x.Quantity, errorProvider1);
            numericUpDownMinQuantity.AddBinding(x => x.Value, targetProduct, x => x.MinQuantity, errorProvider1);
            numericUpDownPriceWithoutTax.AddBinding(x => x.Value, targetProduct, x => x.PriceWithoutTax, errorProvider1);
        }

        /// <summary>
        /// Текущий продукт формы
        /// </summary>
        public ProductModel CurrentProduct => targetProduct;

        /// <summary>
        /// Метод обработки клика кнопки "Добавить" или "Сохранить"
        /// </summary>
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            var context = new ValidationContext(targetProduct);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(targetProduct, context, results, true);

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
                        Control? control = memberName switch
                        {
                            nameof(ProductModel.ProductName) => textBoxProductName,
                            nameof(ProductModel.ProductSize) => textBoxProductSize,
                            nameof(ProductModel.Quantity) => numericUpDownQuantity,
                            nameof(ProductModel.MinQuantity) => numericUpDownMinQuantity,
                            nameof(ProductModel.PriceWithoutTax) => numericUpDownPriceWithoutTax,
                            nameof(ProductModel.Material) => comboBoxMaterial,
                            _ => null
                        };

                        if (control != null)
                        {
                            errorProvider1.SetError(control, validationResult.ErrorMessage);
                        }
                    }
                }
            }
        }
    }
}
