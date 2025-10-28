using DataGridViewProject.Classes;
using DataGridViewProject.Forms;
using DataGridViewProject.Models;

namespace DataGridViewProject
{
    public partial class MainForm : Form
    {
        private readonly List<ProductModel> products;
        private readonly BindingSource bindingSource = [];

        public MainForm()
        {
            products =
            [
                new ProductModel
                {
                    Id = Guid.NewGuid(),
                    ProductName = "Гвозди медные декоративные",
                    ProductSize = "2x40 мм",
                    Material = Models.Material.Copper,
                    Quantity = 100,
                    MinQuantity = 45,
                    PriceWithoutTax = 1.25m
                },
                new ProductModel
                {
                    Id = Guid.NewGuid(),
                    ProductName = "Гвозди строительные",
                    ProductSize = "3x70 мм",
                    Material = Models.Material.Steel,
                    Quantity = 500,
                    MinQuantity = 100,
                    PriceWithoutTax = 0.75m
                },
                new ProductModel
                {
                    Id = Guid.NewGuid(),
                    ProductName = "Гвозди антикоррозийные",
                    ProductSize = "4x90 мм",
                    Material = Models.Material.Chrome,
                    Quantity = 300,
                    MinQuantity = 80,
                    PriceWithoutTax = 1.10m
                },
            ];
            InitializeComponent();
            SetStatistic();
            dataGridView1.AutoGenerateColumns = false;

            bindingSource.DataSource = products;
            dataGridView1.DataSource = bindingSource;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var col = dataGridView1.Columns[e.ColumnIndex];
            var product = (ProductModel)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            if (product == null)
            {
                return;
            }

            if (col.DataPropertyName == nameof(ProductModel.Material))
            {
                e.Value = product.Material switch
                {
                    Models.Material.Copper => "Медь",
                    Models.Material.Steel => "Сталь",
                    Models.Material.Iron => "Железо",
                    Models.Material.Chrome => "Хром",
                    _ => string.Empty,
                };
            }

            if (col.Name == "TotalPriceWithoutTax")
            {
                e.Value = product.PriceWithoutTax * product.Quantity;
            }
        }

        private void SetStatistic()
        {
            var totalWithoutTax = products.Sum(x => x.PriceWithoutTax * x.Quantity);// Расчёт общей суммы БЕЗ НДС
            var totalWithTax = totalWithoutTax * AppConstants.TaxRate;// Расчёт общей суммы C НДС

            LabelQuantity.Text = $"Количество товаров: {products.Count}";
            LabelPriceWithTax.Text = $"Общая сумма товаров на складе(С НДС): {totalWithTax:F2} ₽";
            LabelPriceWithoutTax.Text = $"Общая сумма товаров на складе(БЕЗ НДС): {totalWithoutTax:F2} ₽";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addForm = new ProductForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                products.Add(addForm.CurrentProduct);
                OnUpdate();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            var product = (ProductModel)dataGridView1.SelectedRows[0].DataBoundItem;
            var target = products.FirstOrDefault(x => x.Id == product.Id);
            if (target != null &&
                MessageBox.Show($"Вы действительно желаете удалить '{target.ProductName}'?",
                "Удаление продукта",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                products.Remove(target);
                OnUpdate();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return; 
            }

            var product = (ProductModel)dataGridView1.SelectedRows[0].DataBoundItem;

            var editForm = new ProductForm(product);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                var target = products.FirstOrDefault(x => x.Id == editForm.CurrentProduct.Id);
                if (target != null)
                {
                    target.ProductName = editForm.CurrentProduct.ProductName;
                    target.ProductSize = editForm.CurrentProduct.ProductSize;
                    target.Material = editForm.CurrentProduct.Material;
                    target.Quantity = editForm.CurrentProduct.Quantity;
                    target.MinQuantity = editForm.CurrentProduct.MinQuantity;
                    target.PriceWithoutTax = editForm.CurrentProduct.PriceWithoutTax;
                    OnUpdate();
                }
            }
        }

        private void OnUpdate()
        {
            bindingSource.ResetBindings(false);
            SetStatistic();
        }
    }
}
