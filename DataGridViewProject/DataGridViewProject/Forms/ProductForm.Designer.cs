namespace DataGridViewProject.Forms
{
    partial class ProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            labelProductName = new Label();
            labelProductSize = new Label();
            labelMaterial = new Label();
            labelQuantity = new Label();
            labelMinQuantity = new Label();
            labelPriceWithoutTax = new Label();
            textBoxProductName = new TextBox();
            textBoxProductSize = new TextBox();
            comboBoxMaterial = new ComboBox();
            numericUpDownQuantity = new NumericUpDown();
            numericUpDownMinQuantity = new NumericUpDown();
            numericUpDownPriceWithoutTax = new NumericUpDown();
            buttonAddProduct = new Button();
            buttonCancel = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPriceWithoutTax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(128, 64, 64);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(592, 119);
            panel1.TabIndex = 0;
            // 
            // labelProductName
            // 
            labelProductName.AutoSize = true;
            labelProductName.Location = new Point(72, 194);
            labelProductName.Name = "labelProductName";
            labelProductName.Size = new Size(133, 15);
            labelProductName.TabIndex = 1;
            labelProductName.Text = "Наименование товара:";
            // 
            // labelProductSize
            // 
            labelProductSize.AutoSize = true;
            labelProductSize.Location = new Point(72, 252);
            labelProductSize.Name = "labelProductSize";
            labelProductSize.Size = new Size(50, 15);
            labelProductSize.TabIndex = 2;
            labelProductSize.Text = "Размер:";
            // 
            // labelMaterial
            // 
            labelMaterial.AutoSize = true;
            labelMaterial.Location = new Point(72, 313);
            labelMaterial.Name = "labelMaterial";
            labelMaterial.Size = new Size(65, 15);
            labelMaterial.TabIndex = 3;
            labelMaterial.Text = "Материал:";
            // 
            // labelQuantity
            // 
            labelQuantity.AutoSize = true;
            labelQuantity.Location = new Point(72, 363);
            labelQuantity.Name = "labelQuantity";
            labelQuantity.Size = new Size(131, 15);
            labelQuantity.TabIndex = 4;
            labelQuantity.Text = "Количество на складе:";
            // 
            // labelMinQuantity
            // 
            labelMinQuantity.AutoSize = true;
            labelMinQuantity.Location = new Point(72, 415);
            labelMinQuantity.Name = "labelMinQuantity";
            labelMinQuantity.Size = new Size(201, 15);
            labelMinQuantity.TabIndex = 5;
            labelMinQuantity.Text = "Минимальный предел количества:";
            // 
            // labelPriceWithoutTax
            // 
            labelPriceWithoutTax.AutoSize = true;
            labelPriceWithoutTax.Location = new Point(72, 469);
            labelPriceWithoutTax.Name = "labelPriceWithoutTax";
            labelPriceWithoutTax.Size = new Size(95, 15);
            labelPriceWithoutTax.TabIndex = 6;
            labelPriceWithoutTax.Text = "Цена (без НДС):";
            // 
            // textBoxProductName
            // 
            textBoxProductName.Location = new Point(279, 191);
            textBoxProductName.Name = "textBoxProductName";
            textBoxProductName.Size = new Size(251, 23);
            textBoxProductName.TabIndex = 7;
            // 
            // textBoxProductSize
            // 
            textBoxProductSize.Location = new Point(279, 249);
            textBoxProductSize.Name = "textBoxProductSize";
            textBoxProductSize.Size = new Size(251, 23);
            textBoxProductSize.TabIndex = 8;
            // 
            // comboBoxMaterial
            // 
            comboBoxMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMaterial.FormattingEnabled = true;
            comboBoxMaterial.Location = new Point(279, 310);
            comboBoxMaterial.Name = "comboBoxMaterial";
            comboBoxMaterial.Size = new Size(168, 23);
            comboBoxMaterial.TabIndex = 9;
            // 
            // numericUpDownQuantity
            // 
            numericUpDownQuantity.Location = new Point(279, 363);
            numericUpDownQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownQuantity.Name = "numericUpDownQuantity";
            numericUpDownQuantity.Size = new Size(168, 23);
            numericUpDownQuantity.TabIndex = 10;
            // 
            // numericUpDownMinQuantity
            // 
            numericUpDownMinQuantity.Location = new Point(279, 413);
            numericUpDownMinQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownMinQuantity.Name = "numericUpDownMinQuantity";
            numericUpDownMinQuantity.Size = new Size(168, 23);
            numericUpDownMinQuantity.TabIndex = 11;
            // 
            // numericUpDownPriceWithoutTax
            // 
            numericUpDownPriceWithoutTax.DecimalPlaces = 2;
            numericUpDownPriceWithoutTax.Location = new Point(279, 467);
            numericUpDownPriceWithoutTax.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownPriceWithoutTax.Name = "numericUpDownPriceWithoutTax";
            numericUpDownPriceWithoutTax.Size = new Size(168, 23);
            numericUpDownPriceWithoutTax.TabIndex = 12;
            // 
            // buttonAddProduct
            // 
            buttonAddProduct.Location = new Point(339, 584);
            buttonAddProduct.Name = "buttonAddProduct";
            buttonAddProduct.Size = new Size(87, 23);
            buttonAddProduct.TabIndex = 13;
            buttonAddProduct.Text = "Добавить";
            buttonAddProduct.UseVisualStyleBackColor = true;
            buttonAddProduct.Click += ButtonAddProduct_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(444, 584);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(86, 23);
            buttonCancel.TabIndex = 14;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // ProductForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            CancelButton = buttonCancel;
            ClientSize = new Size(592, 643);
            Controls.Add(buttonCancel);
            Controls.Add(buttonAddProduct);
            Controls.Add(numericUpDownPriceWithoutTax);
            Controls.Add(numericUpDownMinQuantity);
            Controls.Add(numericUpDownQuantity);
            Controls.Add(comboBoxMaterial);
            Controls.Add(textBoxProductSize);
            Controls.Add(textBoxProductName);
            Controls.Add(labelPriceWithoutTax);
            Controls.Add(labelMinQuantity);
            Controls.Add(labelQuantity);
            Controls.Add(labelMaterial);
            Controls.Add(labelProductSize);
            Controls.Add(labelProductName);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProductForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Параметры продукта";
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPriceWithoutTax).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label labelProductName;
        private Label labelProductSize;
        private Label labelMaterial;
        private Label labelQuantity;
        private Label labelMinQuantity;
        private Label labelPriceWithoutTax;
        private TextBox textBoxProductName;
        private TextBox textBoxProductSize;
        private ComboBox comboBoxMaterial;
        private NumericUpDown numericUpDownQuantity;
        private NumericUpDown numericUpDownMinQuantity;
        private NumericUpDown numericUpDownPriceWithoutTax;
        private Button buttonAddProduct;
        private Button buttonCancel;
        private ErrorProvider errorProvider1;
    }
}