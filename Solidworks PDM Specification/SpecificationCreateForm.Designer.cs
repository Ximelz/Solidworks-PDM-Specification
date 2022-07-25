namespace Solidworks_PDM_Specification
{
    partial class SpecificationCreateForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SettingsButton = new System.Windows.Forms.Button();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.CreateSpecification = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.UpdateSpecificationButton = new System.Windows.Forms.Button();
            this.StampButton = new System.Windows.Forms.Button();
            this.exportToExcelButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AddButton = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // SettingsButton
            // 
            this.SettingsButton.Location = new System.Drawing.Point(1053, 12);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(192, 23);
            this.SettingsButton.TabIndex = 0;
            this.SettingsButton.Text = "Настройки";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Location = new System.Drawing.Point(1053, 173);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(192, 23);
            this.SaveFileButton.TabIndex = 2;
            this.SaveFileButton.Text = "Сохранить спецификацию";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            this.SaveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.OpenFileButton.Location = new System.Drawing.Point(1053, 144);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(192, 23);
            this.OpenFileButton.TabIndex = 3;
            this.OpenFileButton.Text = "Открыть спецификацию";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CreateSpecification
            // 
            this.CreateSpecification.Location = new System.Drawing.Point(1053, 70);
            this.CreateSpecification.Name = "CreateSpecification";
            this.CreateSpecification.Size = new System.Drawing.Size(192, 23);
            this.CreateSpecification.TabIndex = 4;
            this.CreateSpecification.Text = "Создать спецификацию из PDM";
            this.CreateSpecification.UseVisualStyleBackColor = true;
            this.CreateSpecification.Click += new System.EventHandler(this.CreateSpecification_Click);
            // 
            // UpdateSpecificationButton
            // 
            this.UpdateSpecificationButton.Enabled = false;
            this.UpdateSpecificationButton.Location = new System.Drawing.Point(1053, 99);
            this.UpdateSpecificationButton.Name = "UpdateSpecificationButton";
            this.UpdateSpecificationButton.Size = new System.Drawing.Size(192, 23);
            this.UpdateSpecificationButton.TabIndex = 5;
            this.UpdateSpecificationButton.Text = "Обновить спецификацию из PDM";
            this.UpdateSpecificationButton.UseVisualStyleBackColor = true;
            this.UpdateSpecificationButton.Click += new System.EventHandler(this.UpdateSpecificationButton_Click);
            // 
            // StampButton
            // 
            this.StampButton.Location = new System.Drawing.Point(1053, 41);
            this.StampButton.Name = "StampButton";
            this.StampButton.Size = new System.Drawing.Size(192, 23);
            this.StampButton.TabIndex = 10;
            this.StampButton.Text = "Настройка штампа";
            this.StampButton.UseVisualStyleBackColor = true;
            this.StampButton.Click += new System.EventHandler(this.StampButton_Click);
            // 
            // exportToExcelButton
            // 
            this.exportToExcelButton.Location = new System.Drawing.Point(1053, 243);
            this.exportToExcelButton.Name = "exportToExcelButton";
            this.exportToExcelButton.Size = new System.Drawing.Size(192, 23);
            this.exportToExcelButton.TabIndex = 39;
            this.exportToExcelButton.Text = "Передать в Excel";
            this.exportToExcelButton.UseVisualStyleBackColor = true;
            this.exportToExcelButton.Click += new System.EventHandler(this.exportToExcelButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(10, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1035, 555);
            this.dataGridView1.TabIndex = 49;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(12, 12);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(142, 23);
            this.AddButton.TabIndex = 50;
            this.AddButton.Text = "Добавить элемент";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Формат";
            this.Column1.Name = "Column1";
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Зона";
            this.Column2.Name = "Column2";
            this.Column2.Width = 50;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Обозначение";
            this.Column4.Name = "Column4";
            this.Column4.Width = 300;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Наименование";
            this.Column5.Name = "Column5";
            this.Column5.Width = 300;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Количество";
            this.Column6.Name = "Column6";
            this.Column6.Width = 70;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Примечание";
            this.Column7.Name = "Column7";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Отсутствующее имя в карте данных";
            this.Column3.Name = "Column3";
            // 
            // SpecificationCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 613);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.exportToExcelButton);
            this.Controls.Add(this.StampButton);
            this.Controls.Add(this.UpdateSpecificationButton);
            this.Controls.Add(this.CreateSpecification);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.SaveFileButton);
            this.Controls.Add(this.SettingsButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpecificationCreateForm";
            this.Text = "Спецификация";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button CreateSpecification;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button UpdateSpecificationButton;
        private System.Windows.Forms.Button StampButton;
        private System.Windows.Forms.Button exportToExcelButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
    }
}

