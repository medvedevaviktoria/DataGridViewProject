using DataGridViewProject.Forms;
using DataGridViewProject.Models;
using System.Diagnostics;

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
                PriceWithoutTax = 1.25m
            });
            products.Add(new ProductModel
            {
                Id = Guid.NewGuid(),
                ProductName = "Гвозди строительные",
                ProductSize = "3x70 мм",
                Material = Models.Material.Steel,
                Quantity = 500,
                MinQuantity = 100,
                PriceWithoutTax = 0.75m
            });
            products.Add(new ProductModel
            {
                Id = Guid.NewGuid(),
                ProductName = "Гвозди антикоррозийные",
                ProductSize = "4x90 мм",
                Material = Models.Material.Chrome,
                Quantity = 300,
                MinQuantity = 80,
                PriceWithoutTax = 1.10m
            });
            InitializeComponent();
            SetStatistic();
            dataGridView1.AutoGenerateColumns = false;

            bindingSource.DataSource = products;
            dataGridView1.DataSource = bindingSource;
        }

        /// <summary>
        /// Обработчик события форматирования ячеек DataGridView
        /// </summary>
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

        /// <summary>
        /// Метод обновоения общих данных о товарах
        /// </summary>
        private void SetStatistic()
        {
            LabelQuantity.Text = $"Количество товаров: {products.Count}";
            LabelPriceWithVAT.Text = $"Общая сумма товаров на складе(С НДС): {products.Sum(x => x.TotalPriceWithTax):F2} ₽";
            LabelPriceWithoutVat.Text = $"Общая сумма товаров на складе(БЕЗ НДС): {products.Sum(x => x.TotalPriceWithoutTax):F2} ₽";
        }

        /// <summary>
        /// Обработчик нажатия кнопки Добавить товар
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            var addForm = new ProductForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                products.Add(addForm.CurrentProduct);
                OnUpdate();
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Удалить товар
        /// </summary>
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

        /// <summary>
        /// Обработчик нажатия кнопки Редактировать товар
        /// </summary>
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

        /// <summary>
        /// Метод обновления всех данных на форме
        /// </summary>
        public void OnUpdate()
        {
            bindingSource.ResetBindings(false);
            SetStatistic();
        }
    }
}
