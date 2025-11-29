using DataGridViewProject.Entities.Models;
using DataGridViewProject.Manager.Contracts;

namespace DataGridViewProject.Forms
{
    /// <summary>
    /// Главная форма программы
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly IProductManager productManager;
        private readonly BindingSource bindingSource = [];

        /// <summary>
        /// Инициализирует экземпляр <see cref="<MainForm>"/>
        /// </summary>
        public MainForm(IProductManager productManager)
        {
            InitializeComponent();
            this.productManager = productManager;
            dataGridView1.AutoGenerateColumns = false;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var products = await productManager.GetAllProducts();
            bindingSource.DataSource = products.ToList();
            dataGridView1.DataSource = bindingSource;
            await SetStatistic();
        }

        private async Task OnUpdate()
        {
            var products = await productManager.GetAllProducts();
            bindingSource.DataSource = products.ToList();
            bindingSource.ResetBindings(false);
            await SetStatistic();
        }

        private async Task SetStatistic()
        {
            var statistics = await productManager.GetStatistics();
            LabelQuantity.Text = $"Количество товаров: {statistics.ProductCount}";
            LabelPriceWithTax.Text = $"Общая сумма товаров на складе(С НДС): {statistics.TotalWithTax:F2} ₽";
            LabelPriceWithoutTax.Text = $"Общая сумма товаров на складе(БЕЗ НДС): {statistics.TotalWithoutTax:F2} ₽";
        }

        private async void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
                    Entities.Models.Material.Copper => "Медь",
                    Entities.Models.Material.Steel => "Сталь",
                    Entities.Models.Material.Iron => "Железо",
                    Entities.Models.Material.Chrome => "Хром",
                    _ => string.Empty,
                };
            }

            if (col.Name == "TotalPriceWithoutTax")
            {
                var totalPriceWithoutTax = await productManager.GetProductTotalPriceWithoutTax(product.Id);
                e.Value = totalPriceWithoutTax;
            }
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            var addForm = new ProductForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                await productManager.AddProduct(addForm.CurrentProduct);
                await OnUpdate();
            }
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            var product = (ProductModel)dataGridView1.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"Удалить '{product.ProductName}'?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await productManager.DeleteProduct(product.Id);
                await OnUpdate();

            }
        }

        private async void EditButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            var product = (ProductModel)dataGridView1.SelectedRows[0].DataBoundItem;

            var editForm = new ProductForm(product);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                await productManager.UpdateProduct(editForm.CurrentProduct);
                await OnUpdate();
            }
        }
    }
}
