using DataGridViewProject.Forms;
using DataGridViewProject.Models;

namespace DataGridViewProject
{
    public partial class MainForm : Form
    {
        private readonly List<ProductModel> products;
        private readonly BindingSource bindingSource = new();

        public MainForm()
        {
            products = new List<ProductModel>();
            products.Add(new ProductModel
            {
                Id = Guid.NewGuid(),
                ProductName = "Гвозди медные декоративные",
                ProductSize = "2x40 мм",
                Material = Models.Material.Copper,
                Quantity = 100,
                MinQuantity = 45,
                PriceWithoutVAT = 1.25m
            });
            products.Add(new ProductModel
            {
                Id = Guid.NewGuid(),
                ProductName = "Гвозди строительные",
                ProductSize = "3x70 мм",
                Material = Models.Material.Steel,
                Quantity = 500,
                MinQuantity = 100,
                PriceWithoutVAT = 0.75m
            });
            products.Add(new ProductModel
            {
                Id = Guid.NewGuid(),
                ProductName = "Гвозди антикоррозийные",
                ProductSize = "4x90 мм",
                Material = Models.Material.Chrome,
                Quantity = 300,
                MinQuantity = 80,
                PriceWithoutVAT = 1.10m
            });
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
                switch (product.Material)
                {
                    case Models.Material.Copper:
                        e.Value = "Медь";
                        break;
                    case Models.Material.Steel:
                        e.Value = "Сталь";
                        break;
                    case Models.Material.Iron:
                        e.Value = "Железо";
                        break;
                    case Models.Material.Chrome:
                        e.Value = "Хром";
                        break;
                    default:
                        e.Value = string.Empty;
                        break;
                }
            }
        }

        private void SetStatistic()
        {
            LabelQuantity.Text = $"Количество товаров: {products.Count}";
            LabelPriceWithVAT.Text = $"Общая сумма товаров на складе(С НДС): {products.Sum(x => x.TotalPriceWithVAT):F2} ₽";
            LabelPriceWithoutVat.Text = $"Общая сумма товаров на складе(БЕЗ НДС): {products.Sum(x => x.TotalPriceWithoutVAT):F2} ₽";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addForm = new ProductForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                products.Add(addForm.CurrentProduct);
                bindingSource.ResetBindings(false);
                SetStatistic();
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
                "Удаление студента",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                products.Remove(target);
                bindingSource.ResetBindings(false);
                SetStatistic();
            }
        }
    }
}
