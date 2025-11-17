namespace DataGridViewProject
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStrip1 = new ToolStrip();
            AddButton = new ToolStripButton();
            DeleteButton = new ToolStripButton();
            EditButton = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            LabelQuantity = new ToolStripStatusLabel();
            LabelPriceWithTax = new ToolStripStatusLabel();
            LabelPriceWithoutTax = new ToolStripStatusLabel();
            dataGridView1 = new DataGridView();
            ProductName = new DataGridViewTextBoxColumn();
            ProductSize = new DataGridViewTextBoxColumn();
            Material = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            MinQuantity = new DataGridViewTextBoxColumn();
            PriceWithoutTax = new DataGridViewTextBoxColumn();
            TotalPriceWithoutTax = new DataGridViewTextBoxColumn();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { AddButton, DeleteButton, EditButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1044, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // AddButton
            // 
            AddButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            AddButton.Image = (Image)resources.GetObject("AddButton.Image");
            AddButton.ImageTransparentColor = Color.Magenta;
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(131, 22);
            AddButton.Text = "Добавление продукта";
            AddButton.Click += AddButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            DeleteButton.Image = (Image)resources.GetObject("DeleteButton.Image");
            DeleteButton.ImageTransparentColor = Color.Magenta;
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(116, 22);
            DeleteButton.Text = "Удаление продукта";
            DeleteButton.Click += DeleteButton_Click;
            // 
            // EditButton
            // 
            EditButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            EditButton.Image = (Image)resources.GetObject("EditButton.Image");
            EditButton.ImageTransparentColor = Color.Magenta;
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(126, 22);
            EditButton.Text = "Изменение продукта";
            EditButton.Click += EditButton_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { LabelQuantity, LabelPriceWithTax, LabelPriceWithoutTax });
            statusStrip1.Location = new Point(0, 563);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1044, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // LabelQuantity
            // 
            LabelQuantity.Name = "LabelQuantity";
            LabelQuantity.Size = new Size(122, 17);
            LabelQuantity.Text = "Количество товаров:";
            // 
            // LabelPriceWithTax
            // 
            LabelPriceWithTax.Name = "LabelPriceWithTax";
            LabelPriceWithTax.Size = new Size(235, 17);
            LabelPriceWithTax.Text = "Общая сумма товаров на складе(С НДС):";
            // 
            // LabelPriceWithoutTax
            // 
            LabelPriceWithoutTax.Name = "LabelPriceWithoutTax";
            LabelPriceWithoutTax.Size = new Size(247, 17);
            LabelPriceWithoutTax.Text = "Общая сумма товаров на складе(БЕЗ НДС):";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ProductName, ProductSize, Material, Quantity, MinQuantity, PriceWithoutTax, TotalPriceWithoutTax });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 25);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1044, 538);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            // 
            // ProductName
            // 
            ProductName.DataPropertyName = "ProductName";
            ProductName.HeaderText = "Наименование товара";
            ProductName.Name = "ProductName";
            ProductName.ReadOnly = true;
            // 
            // ProductSize
            // 
            ProductSize.DataPropertyName = "ProductSize";
            ProductSize.HeaderText = "Размер";
            ProductSize.Name = "ProductSize";
            ProductSize.ReadOnly = true;
            // 
            // Material
            // 
            Material.DataPropertyName = "Material";
            Material.HeaderText = "Материал";
            Material.Name = "Material";
            Material.ReadOnly = true;
            // 
            // Quantity
            // 
            Quantity.DataPropertyName = "Quantity";
            Quantity.HeaderText = "Количество на складе";
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            // 
            // MinQuantity
            // 
            MinQuantity.DataPropertyName = "MinQuantity";
            MinQuantity.HeaderText = "Минимальный предел количества";
            MinQuantity.Name = "MinQuantity";
            MinQuantity.ReadOnly = true;
            // 
            // PriceWithoutTax
            // 
            PriceWithoutTax.DataPropertyName = "PriceWithoutTax";
            PriceWithoutTax.HeaderText = "Цена за 1 шт.";
            PriceWithoutTax.Name = "PriceWithoutTax";
            PriceWithoutTax.ReadOnly = true;
            // 
            // TotalPriceWithoutTax
            // 
            TotalPriceWithoutTax.HeaderText = "Общая сумма товара(БЕЗ НДС)";
            TotalPriceWithoutTax.Name = "TotalPriceWithoutTax";
            TotalPriceWithoutTax.ReadOnly = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 585);
            Controls.Add(dataGridView1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Автоматизация склада гвоздей";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel LabelQuantity;
        private ToolStripStatusLabel LabelPriceWithTax;
        private ToolStripStatusLabel LabelPriceWithoutTax;
        private DataGridView dataGridView1;
        private ToolStripButton AddButton;
        private ToolStripButton DeleteButton;
        private ToolStripButton EditButton;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn ProductSize;
        private DataGridViewTextBoxColumn Material;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn MinQuantity;
        private DataGridViewTextBoxColumn PriceWithoutTax;
        private DataGridViewTextBoxColumn TotalPriceWithoutTax;
    }
}
