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

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
        }

        private void SetStatistic()
        {
            toolStripStatusLabel1.Text = $"Количество товаров: {products.Count}";
            toolStripStatusLabel2.Text = $"Общая сумма товаров на складе(С НДС): {products.Sum(x => x.TotalPriceWithVAT):F2} ₽";
            toolStripStatusLabel3.Text = $"Общая сумма товаров на складе(БЕЗ НДС): {products.Sum(x => x.TotalPriceWithoutVAT):F2} ₽";
        }
    }
}
