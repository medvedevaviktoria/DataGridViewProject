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
            toolStrip1 = new ToolStrip();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            dataGridView1 = new DataGridView();
            ProductName = new DataGridViewTextBoxColumn();
            ProductSize = new DataGridViewTextBoxColumn();
            Material = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            MinQuantity = new DataGridViewTextBoxColumn();
            PriceWithoutVAT = new DataGridViewTextBoxColumn();
            TotalPriceWithoutVAT = new DataGridViewTextBoxColumn();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1044, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2, toolStripStatusLabel3 });
            statusStrip1.Location = new Point(0, 563);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1044, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(118, 17);
            toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(118, 17);
            toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ProductName, ProductSize, Material, Quantity, MinQuantity, PriceWithoutVAT, TotalPriceWithoutVAT });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 25);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(1044, 538);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.CellPainting += dataGridView1_CellPainting;
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
            // PriceWithoutVAT
            // 
            PriceWithoutVAT.DataPropertyName = "PriceWithoutVAT";
            PriceWithoutVAT.HeaderText = "Цена (без НДС)";
            PriceWithoutVAT.Name = "PriceWithoutVAT";
            PriceWithoutVAT.ReadOnly = true;
            // 
            // TotalPriceWithoutVAT
            // 
            TotalPriceWithoutVAT.DataPropertyName = "TotalPriceWithoutVAT";
            TotalPriceWithoutVAT.HeaderText = "Общая сумма товара";
            TotalPriceWithoutVAT.Name = "TotalPriceWithoutVAT";
            TotalPriceWithoutVAT.ReadOnly = true;
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
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Автоматизация склада гвоздей";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn ProductSize;
        private DataGridViewTextBoxColumn Material;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn MinQuantity;
        private DataGridViewTextBoxColumn PriceWithoutVAT;
        private DataGridViewTextBoxColumn TotalPriceWithoutVAT;
    }
}
