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
            this.SectionComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NameOldName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.zoneTextBox = new System.Windows.Forms.TextBox();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.drawingPaperSizeTextBox = new System.Windows.Forms.TextBox();
            this.designationTextBox = new System.Windows.Forms.TextBox();
            this.ZoneOldName = new System.Windows.Forms.Label();
            this.NoteOldName = new System.Windows.Forms.Label();
            this.DrawingPaperSizeOldName = new System.Windows.Forms.Label();
            this.DesignationOldName = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.elementsListBox = new System.Windows.Forms.ListBox();
            this.addSection = new System.Windows.Forms.Button();
            this.addElementButton = new System.Windows.Forms.Button();
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.countOldName = new System.Windows.Forms.Label();
            this.exportToExcelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SettingsButton
            // 
            this.SettingsButton.Location = new System.Drawing.Point(380, 12);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(192, 23);
            this.SettingsButton.TabIndex = 0;
            this.SettingsButton.Text = "Настройки";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Location = new System.Drawing.Point(380, 173);
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
            this.OpenFileButton.Location = new System.Drawing.Point(380, 144);
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
            this.CreateSpecification.Location = new System.Drawing.Point(380, 70);
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
            this.UpdateSpecificationButton.Location = new System.Drawing.Point(380, 99);
            this.UpdateSpecificationButton.Name = "UpdateSpecificationButton";
            this.UpdateSpecificationButton.Size = new System.Drawing.Size(192, 23);
            this.UpdateSpecificationButton.TabIndex = 5;
            this.UpdateSpecificationButton.Text = "Обновить спецификацию из PDM";
            this.UpdateSpecificationButton.UseVisualStyleBackColor = true;
            this.UpdateSpecificationButton.Click += new System.EventHandler(this.UpdateSpecificationButton_Click);
            // 
            // StampButton
            // 
            this.StampButton.Location = new System.Drawing.Point(380, 41);
            this.StampButton.Name = "StampButton";
            this.StampButton.Size = new System.Drawing.Size(192, 23);
            this.StampButton.TabIndex = 10;
            this.StampButton.Text = "Настройка штампа";
            this.StampButton.UseVisualStyleBackColor = true;
            this.StampButton.Click += new System.EventHandler(this.StampButton_Click);
            // 
            // SectionComboBox
            // 
            this.SectionComboBox.FormattingEnabled = true;
            this.SectionComboBox.Location = new System.Drawing.Point(12, 14);
            this.SectionComboBox.Name = "SectionComboBox";
            this.SectionComboBox.Size = new System.Drawing.Size(121, 21);
            this.SectionComboBox.TabIndex = 12;
            this.SectionComboBox.SelectedIndexChanged += new System.EventHandler(this.SectionComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 425);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Наименование";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 451);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Обозначение";
            // 
            // NameOldName
            // 
            this.NameOldName.AutoSize = true;
            this.NameOldName.Location = new System.Drawing.Point(356, 421);
            this.NameOldName.Name = "NameOldName";
            this.NameOldName.Size = new System.Drawing.Size(150, 13);
            this.NameOldName.TabIndex = 15;
            this.NameOldName.Text = "Сохраненное наименование";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 390);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Новое значение";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(443, 390);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Старое значение";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 525);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Зона";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 499);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Примечание";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 473);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Формат";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(101, 418);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(249, 20);
            this.nameTextBox.TabIndex = 21;
            // 
            // zoneTextBox
            // 
            this.zoneTextBox.Location = new System.Drawing.Point(101, 522);
            this.zoneTextBox.Name = "zoneTextBox";
            this.zoneTextBox.Size = new System.Drawing.Size(249, 20);
            this.zoneTextBox.TabIndex = 23;
            // 
            // noteTextBox
            // 
            this.noteTextBox.Location = new System.Drawing.Point(101, 496);
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(249, 20);
            this.noteTextBox.TabIndex = 24;
            // 
            // drawingPaperSizeTextBox
            // 
            this.drawingPaperSizeTextBox.Location = new System.Drawing.Point(101, 470);
            this.drawingPaperSizeTextBox.Name = "drawingPaperSizeTextBox";
            this.drawingPaperSizeTextBox.Size = new System.Drawing.Size(249, 20);
            this.drawingPaperSizeTextBox.TabIndex = 25;
            // 
            // designationTextBox
            // 
            this.designationTextBox.Location = new System.Drawing.Point(101, 444);
            this.designationTextBox.Name = "designationTextBox";
            this.designationTextBox.Size = new System.Drawing.Size(249, 20);
            this.designationTextBox.TabIndex = 26;
            // 
            // ZoneOldName
            // 
            this.ZoneOldName.AutoSize = true;
            this.ZoneOldName.Location = new System.Drawing.Point(356, 525);
            this.ZoneOldName.Name = "ZoneOldName";
            this.ZoneOldName.Size = new System.Drawing.Size(100, 13);
            this.ZoneOldName.TabIndex = 27;
            this.ZoneOldName.Text = "Сохраненная зона";
            // 
            // NoteOldName
            // 
            this.NoteOldName.AutoSize = true;
            this.NoteOldName.Location = new System.Drawing.Point(356, 499);
            this.NoteOldName.Name = "NoteOldName";
            this.NoteOldName.Size = new System.Drawing.Size(137, 13);
            this.NoteOldName.TabIndex = 28;
            this.NoteOldName.Text = "Сохраненное примечание";
            // 
            // DrawingPaperSizeOldName
            // 
            this.DrawingPaperSizeOldName.AutoSize = true;
            this.DrawingPaperSizeOldName.Location = new System.Drawing.Point(356, 473);
            this.DrawingPaperSizeOldName.Name = "DrawingPaperSizeOldName";
            this.DrawingPaperSizeOldName.Size = new System.Drawing.Size(117, 13);
            this.DrawingPaperSizeOldName.TabIndex = 29;
            this.DrawingPaperSizeOldName.Text = "Сохраненный формат";
            // 
            // DesignationOldName
            // 
            this.DesignationOldName.AutoSize = true;
            this.DesignationOldName.Location = new System.Drawing.Point(356, 447);
            this.DesignationOldName.Name = "DesignationOldName";
            this.DesignationOldName.Size = new System.Drawing.Size(141, 13);
            this.DesignationOldName.TabIndex = 30;
            this.DesignationOldName.Text = "Сохраненное обозначение";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(101, 574);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 31;
            this.applyButton.Text = "Применить";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(275, 574);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 32;
            this.resetButton.Text = "Сброс";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // elementsListBox
            // 
            this.elementsListBox.FormattingEnabled = true;
            this.elementsListBox.Location = new System.Drawing.Point(139, 12);
            this.elementsListBox.Name = "elementsListBox";
            this.elementsListBox.Size = new System.Drawing.Size(235, 355);
            this.elementsListBox.TabIndex = 33;
            this.elementsListBox.SelectedIndexChanged += new System.EventHandler(this.elementsListBox_SelectedIndexChanged);
            // 
            // addSection
            // 
            this.addSection.Location = new System.Drawing.Point(12, 315);
            this.addSection.Name = "addSection";
            this.addSection.Size = new System.Drawing.Size(121, 23);
            this.addSection.TabIndex = 34;
            this.addSection.Text = "Добавить раздел";
            this.addSection.UseVisualStyleBackColor = true;
            this.addSection.Click += new System.EventHandler(this.addSection_Click);
            // 
            // addElementButton
            // 
            this.addElementButton.Location = new System.Drawing.Point(12, 344);
            this.addElementButton.Name = "addElementButton";
            this.addElementButton.Size = new System.Drawing.Size(121, 23);
            this.addElementButton.TabIndex = 35;
            this.addElementButton.Text = "Добавить элемент";
            this.addElementButton.UseVisualStyleBackColor = true;
            this.addElementButton.Click += new System.EventHandler(this.addElementButton_Click);
            // 
            // countTextBox
            // 
            this.countTextBox.Location = new System.Drawing.Point(101, 548);
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(249, 20);
            this.countTextBox.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 551);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Количество";
            // 
            // countOldName
            // 
            this.countOldName.AutoSize = true;
            this.countOldName.Location = new System.Drawing.Point(356, 551);
            this.countOldName.Name = "countOldName";
            this.countOldName.Size = new System.Drawing.Size(105, 13);
            this.countOldName.TabIndex = 38;
            this.countOldName.Text = "Сохраненное число";
            // 
            // exportToExcelButton
            // 
            this.exportToExcelButton.Location = new System.Drawing.Point(380, 243);
            this.exportToExcelButton.Name = "exportToExcelButton";
            this.exportToExcelButton.Size = new System.Drawing.Size(192, 23);
            this.exportToExcelButton.TabIndex = 39;
            this.exportToExcelButton.Text = "Передать в Excel";
            this.exportToExcelButton.UseVisualStyleBackColor = true;
            this.exportToExcelButton.Click += new System.EventHandler(this.exportToExcelButton_Click);
            // 
            // SpecificationCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 613);
            this.Controls.Add(this.exportToExcelButton);
            this.Controls.Add(this.countOldName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.countTextBox);
            this.Controls.Add(this.addElementButton);
            this.Controls.Add(this.addSection);
            this.Controls.Add(this.elementsListBox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.DesignationOldName);
            this.Controls.Add(this.DrawingPaperSizeOldName);
            this.Controls.Add(this.NoteOldName);
            this.Controls.Add(this.ZoneOldName);
            this.Controls.Add(this.designationTextBox);
            this.Controls.Add(this.drawingPaperSizeTextBox);
            this.Controls.Add(this.noteTextBox);
            this.Controls.Add(this.zoneTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NameOldName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SectionComboBox);
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
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ComboBox SectionComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NameOldName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox zoneTextBox;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.TextBox drawingPaperSizeTextBox;
        private System.Windows.Forms.TextBox designationTextBox;
        private System.Windows.Forms.Label ZoneOldName;
        private System.Windows.Forms.Label NoteOldName;
        private System.Windows.Forms.Label DrawingPaperSizeOldName;
        private System.Windows.Forms.Label DesignationOldName;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.ListBox elementsListBox;
        private System.Windows.Forms.Button addSection;
        private System.Windows.Forms.Button addElementButton;
        private System.Windows.Forms.TextBox countTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label countOldName;
        private System.Windows.Forms.Button exportToExcelButton;
    }
}

