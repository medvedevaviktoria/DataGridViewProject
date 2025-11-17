using Constants;
using DataGridViewProject.Forms;
using DataGridViewProject.Models;
using Services;
using Services.Contracts;

namespace DataGridViewProject
{
    public partial class MainForm : Form
    {
        private readonly IProductService productService;
        private readonly BindingSource bindingSource = [];

        public MainForm(IProductService productService)
        {
            InitializeComponent();
            this.productService = productService;
            dataGridView1.AutoGenerateColumns = false;

        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var products = await productService.GetAllProducts();
            bindingSource.DataSource = products.ToList();
            dataGridView1.DataSource = bindingSource;
            await SetStatistic();
        }

        private async Task OnUpdate()
        {
            var products = await productService.GetAllProducts();  
            //bindingSource.Clear(); 
            bindingSource.DataSource = products.ToList();
            bindingSource.ResetBindings(false);
            await SetStatistic();
        }

        private async Task SetStatistic()
        {
            var productCount = await productService.GetProductCount(); // Количество всех товаров на складе
            var totalWithoutTax = await productService.GetTotalPrice();// Расчёт общей суммы БЕЗ НДС
            var totalWithTax = await productService.GetTotalPriceWithTax(); // Расчёт общей суммы C НДС

            LabelQuantity.Text = $"Количество товаров: {productCount}";
            LabelPriceWithTax.Text = $"Общая сумма товаров на складе(С НДС): {totalWithTax:F2} ₽";
            LabelPriceWithoutTax.Text = $"Общая сумма товаров на складе(БЕЗ НДС): {totalWithoutTax:F2} ₽";
        }

        private async void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
                var totalPriceWithoutTax = await productService.GetProductTotalPriceWithoutTax(product.Id);
                e.Value = totalPriceWithoutTax;
            }
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            var addForm = new ProductForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                await productService.AddProduct(addForm.CurrentProduct);
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
                await productService.DeleteProduct(product.Id);
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
                await productService.UpdateProduct(editForm.CurrentProduct);
                await OnUpdate();
            }
        }
    }
}
