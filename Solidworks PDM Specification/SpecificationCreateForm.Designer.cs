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
            this.SuspendLayout();
            // 
            // SettingsButton
            // 
            this.SettingsButton.Location = new System.Drawing.Point(1007, 12);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(192, 23);
            this.SettingsButton.TabIndex = 0;
            this.SettingsButton.Text = "Настройки";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Location = new System.Drawing.Point(1007, 173);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(192, 23);
            this.SaveFileButton.TabIndex = 2;
            this.SaveFileButton.Text = "Сохранить спецификацию";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.OpenFileButton.Location = new System.Drawing.Point(1007, 144);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(192, 23);
            this.OpenFileButton.TabIndex = 3;
            this.OpenFileButton.Text = "Открыть спецификацию";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CreateSpecification
            // 
            this.CreateSpecification.Location = new System.Drawing.Point(1007, 70);
            this.CreateSpecification.Name = "CreateSpecification";
            this.CreateSpecification.Size = new System.Drawing.Size(192, 23);
            this.CreateSpecification.TabIndex = 4;
            this.CreateSpecification.Text = "Создать спецификацию из PDM";
            this.CreateSpecification.UseVisualStyleBackColor = true;
            this.CreateSpecification.Click += new System.EventHandler(this.CreateSpecification_Click);
            // 
            // UpdateSpecificationButton
            // 
            this.UpdateSpecificationButton.Location = new System.Drawing.Point(1007, 99);
            this.UpdateSpecificationButton.Name = "UpdateSpecificationButton";
            this.UpdateSpecificationButton.Size = new System.Drawing.Size(192, 23);
            this.UpdateSpecificationButton.TabIndex = 5;
            this.UpdateSpecificationButton.Text = "Обновить спецификацию из PDM";
            this.UpdateSpecificationButton.UseVisualStyleBackColor = true;
            this.UpdateSpecificationButton.Click += new System.EventHandler(this.UpdateSpecificationButton_Click);
            // 
            // StampButton
            // 
            this.StampButton.Location = new System.Drawing.Point(1007, 41);
            this.StampButton.Name = "StampButton";
            this.StampButton.Size = new System.Drawing.Size(192, 23);
            this.StampButton.TabIndex = 10;
            this.StampButton.Text = "Настройка штампа";
            this.StampButton.UseVisualStyleBackColor = true;
            this.StampButton.Click += new System.EventHandler(this.StampButton_Click);
            // 
            // SpecificationCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 597);
            this.Controls.Add(this.StampButton);
            this.Controls.Add(this.UpdateSpecificationButton);
            this.Controls.Add(this.CreateSpecification);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.SaveFileButton);
            this.Controls.Add(this.SettingsButton);
            this.Name = "SpecificationCreateForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

