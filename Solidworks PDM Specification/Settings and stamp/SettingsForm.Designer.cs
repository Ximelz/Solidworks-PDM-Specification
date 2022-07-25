namespace Solidworks_PDM_Specification
{
    partial class SettingsForm
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
            this.VaultsComboBox = new System.Windows.Forms.ComboBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SettingsPathTextBox = new System.Windows.Forms.TextBox();
            this.SettingsButtonBrowserPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.PrimaryApplicationComboBox = new System.Windows.Forms.ComboBox();
            this.ReferenceNumbComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.InvNumbDuplComboBox = new System.Windows.Forms.ComboBox();
            this.ReplacedInvNumbComboBox = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.InvNumbOriginComboBox = new System.Windows.Forms.ComboBox();
            this.LiteraComboBox = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.ApproverComboBox = new System.Windows.Forms.ComboBox();
            this.NormativeControlComboBox = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CheckerComboBox = new System.Windows.Forms.ComboBox();
            this.DeveloperComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ZoneComboBox = new System.Windows.Forms.ComboBox();
            this.NoteComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SectionComboBox = new System.Windows.Forms.ComboBox();
            this.DrawingPaperSizeComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DesignationComboBox = new System.Windows.Forms.ComboBox();
            this.NameComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.excelTemplateTextBox = new System.Windows.Forms.TextBox();
            this.openXltxPath = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // VaultsComboBox
            // 
            this.VaultsComboBox.FormattingEnabled = true;
            this.VaultsComboBox.Location = new System.Drawing.Point(12, 37);
            this.VaultsComboBox.Name = "VaultsComboBox";
            this.VaultsComboBox.Size = new System.Drawing.Size(141, 21);
            this.VaultsComboBox.TabIndex = 0;
            //this.VaultsComboBox.SelectedIndexChanged += new System.EventHandler(this.VaultsComboBox_SelectedIndexChanged);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(262, 461);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(181, 461);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // SettingsPathTextBox
            // 
            this.SettingsPathTextBox.Location = new System.Drawing.Point(12, 88);
            this.SettingsPathTextBox.Name = "SettingsPathTextBox";
            this.SettingsPathTextBox.Size = new System.Drawing.Size(245, 20);
            this.SettingsPathTextBox.TabIndex = 3;
            // 
            // SettingsButtonBrowserPath
            // 
            this.SettingsButtonBrowserPath.Location = new System.Drawing.Point(263, 85);
            this.SettingsButtonBrowserPath.Name = "SettingsButtonBrowserPath";
            this.SettingsButtonBrowserPath.Size = new System.Drawing.Size(75, 23);
            this.SettingsButtonBrowserPath.TabIndex = 4;
            this.SettingsButtonBrowserPath.Text = "Открыть...";
            this.SettingsButtonBrowserPath.UseVisualStyleBackColor = true;
            this.SettingsButtonBrowserPath.Click += new System.EventHandler(this.SettingsButtonBrowserPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Место положение файла с настройками";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Используемое хранилище";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.PrimaryApplicationComboBox);
            this.panel1.Controls.Add(this.ReferenceNumbComboBox);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.InvNumbDuplComboBox);
            this.panel1.Controls.Add(this.ReplacedInvNumbComboBox);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.InvNumbOriginComboBox);
            this.panel1.Controls.Add(this.LiteraComboBox);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.ApproverComboBox);
            this.panel1.Controls.Add(this.NormativeControlComboBox);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.CheckerComboBox);
            this.panel1.Controls.Add(this.DeveloperComboBox);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.ZoneComboBox);
            this.panel1.Controls.Add(this.NoteComboBox);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.SectionComboBox);
            this.panel1.Controls.Add(this.DrawingPaperSizeComboBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.DesignationComboBox);
            this.panel1.Controls.Add(this.NameComboBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 161);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 294);
            this.panel1.TabIndex = 7;
            this.panel1.Tag = "";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(80, 477);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 13);
            this.label20.TabIndex = 33;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 433);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Первич. прим.";
            // 
            // PrimaryApplicationComboBox
            // 
            this.PrimaryApplicationComboBox.FormattingEnabled = true;
            this.PrimaryApplicationComboBox.Location = new System.Drawing.Point(112, 430);
            this.PrimaryApplicationComboBox.Name = "PrimaryApplicationComboBox";
            this.PrimaryApplicationComboBox.Size = new System.Drawing.Size(193, 21);
            this.PrimaryApplicationComboBox.TabIndex = 31;
            // 
            // ReferenceNumbComboBox
            // 
            this.ReferenceNumbComboBox.FormattingEnabled = true;
            this.ReferenceNumbComboBox.Location = new System.Drawing.Point(112, 403);
            this.ReferenceNumbComboBox.Name = "ReferenceNumbComboBox";
            this.ReferenceNumbComboBox.Size = new System.Drawing.Size(193, 21);
            this.ReferenceNumbComboBox.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 406);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Справ. №";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 379);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Инв. № дубл.";
            // 
            // InvNumbDuplComboBox
            // 
            this.InvNumbDuplComboBox.FormattingEnabled = true;
            this.InvNumbDuplComboBox.Location = new System.Drawing.Point(112, 376);
            this.InvNumbDuplComboBox.Name = "InvNumbDuplComboBox";
            this.InvNumbDuplComboBox.Size = new System.Drawing.Size(193, 21);
            this.InvNumbDuplComboBox.TabIndex = 27;
            // 
            // ReplacedInvNumbComboBox
            // 
            this.ReplacedInvNumbComboBox.FormattingEnabled = true;
            this.ReplacedInvNumbComboBox.Location = new System.Drawing.Point(112, 349);
            this.ReplacedInvNumbComboBox.Name = "ReplacedInvNumbComboBox";
            this.ReplacedInvNumbComboBox.Size = new System.Drawing.Size(193, 21);
            this.ReplacedInvNumbComboBox.TabIndex = 26;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 352);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 13);
            this.label15.TabIndex = 25;
            this.label15.Text = "Взам. инв. №";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 325);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "Инв. № подл.";
            // 
            // InvNumbOriginComboBox
            // 
            this.InvNumbOriginComboBox.FormattingEnabled = true;
            this.InvNumbOriginComboBox.Location = new System.Drawing.Point(112, 322);
            this.InvNumbOriginComboBox.Name = "InvNumbOriginComboBox";
            this.InvNumbOriginComboBox.Size = new System.Drawing.Size(193, 21);
            this.InvNumbOriginComboBox.TabIndex = 23;
            // 
            // LiteraComboBox
            // 
            this.LiteraComboBox.FormattingEnabled = true;
            this.LiteraComboBox.Location = new System.Drawing.Point(112, 295);
            this.LiteraComboBox.Name = "LiteraComboBox";
            this.LiteraComboBox.Size = new System.Drawing.Size(193, 21);
            this.LiteraComboBox.TabIndex = 22;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(4, 298);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 13);
            this.label17.TabIndex = 21;
            this.label17.Text = "Литера";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 268);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 13);
            this.label18.TabIndex = 20;
            this.label18.Text = "Утвердил";
            // 
            // ApproverComboBox
            // 
            this.ApproverComboBox.FormattingEnabled = true;
            this.ApproverComboBox.Location = new System.Drawing.Point(112, 268);
            this.ApproverComboBox.Name = "ApproverComboBox";
            this.ApproverComboBox.Size = new System.Drawing.Size(193, 21);
            this.ApproverComboBox.TabIndex = 19;
            // 
            // NormativeControlComboBox
            // 
            this.NormativeControlComboBox.FormattingEnabled = true;
            this.NormativeControlComboBox.Location = new System.Drawing.Point(112, 241);
            this.NormativeControlComboBox.Name = "NormativeControlComboBox";
            this.NormativeControlComboBox.Size = new System.Drawing.Size(193, 21);
            this.NormativeControlComboBox.TabIndex = 18;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 241);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(88, 13);
            this.label19.TabIndex = 17;
            this.label19.Text = "Нормоконтроль";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Проверил";
            // 
            // CheckerComboBox
            // 
            this.CheckerComboBox.FormattingEnabled = true;
            this.CheckerComboBox.Location = new System.Drawing.Point(112, 214);
            this.CheckerComboBox.Name = "CheckerComboBox";
            this.CheckerComboBox.Size = new System.Drawing.Size(193, 21);
            this.CheckerComboBox.TabIndex = 15;
            // 
            // DeveloperComboBox
            // 
            this.DeveloperComboBox.FormattingEnabled = true;
            this.DeveloperComboBox.Location = new System.Drawing.Point(112, 187);
            this.DeveloperComboBox.Name = "DeveloperComboBox";
            this.DeveloperComboBox.Size = new System.Drawing.Size(193, 21);
            this.DeveloperComboBox.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 190);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Разработал";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Зона";
            // 
            // ZoneComboBox
            // 
            this.ZoneComboBox.FormattingEnabled = true;
            this.ZoneComboBox.Location = new System.Drawing.Point(112, 160);
            this.ZoneComboBox.Name = "ZoneComboBox";
            this.ZoneComboBox.Size = new System.Drawing.Size(193, 21);
            this.ZoneComboBox.TabIndex = 11;
            // 
            // NoteComboBox
            // 
            this.NoteComboBox.FormattingEnabled = true;
            this.NoteComboBox.Location = new System.Drawing.Point(112, 133);
            this.NoteComboBox.Name = "NoteComboBox";
            this.NoteComboBox.Size = new System.Drawing.Size(193, 21);
            this.NoteComboBox.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Примечание";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Раздел";
            // 
            // SectionComboBox
            // 
            this.SectionComboBox.FormattingEnabled = true;
            this.SectionComboBox.Location = new System.Drawing.Point(112, 106);
            this.SectionComboBox.Name = "SectionComboBox";
            this.SectionComboBox.Size = new System.Drawing.Size(193, 21);
            this.SectionComboBox.TabIndex = 7;
            // 
            // DrawingPaperSizeComboBox
            // 
            this.DrawingPaperSizeComboBox.FormattingEnabled = true;
            this.DrawingPaperSizeComboBox.Location = new System.Drawing.Point(112, 79);
            this.DrawingPaperSizeComboBox.Name = "DrawingPaperSizeComboBox";
            this.DrawingPaperSizeComboBox.Size = new System.Drawing.Size(193, 21);
            this.DrawingPaperSizeComboBox.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Формат";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Обозначение";
            // 
            // DesignationComboBox
            // 
            this.DesignationComboBox.FormattingEnabled = true;
            this.DesignationComboBox.Location = new System.Drawing.Point(112, 52);
            this.DesignationComboBox.Name = "DesignationComboBox";
            this.DesignationComboBox.Size = new System.Drawing.Size(193, 21);
            this.DesignationComboBox.TabIndex = 3;
            // 
            // NameComboBox
            // 
            this.NameComboBox.FormattingEnabled = true;
            this.NameComboBox.Location = new System.Drawing.Point(112, 25);
            this.NameComboBox.Name = "NameComboBox";
            this.NameComboBox.Size = new System.Drawing.Size(193, 21);
            this.NameComboBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Наименование";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Настройка переменных текущего хранилища";
            // 
            // excelTemplateTextBox
            // 
            this.excelTemplateTextBox.Location = new System.Drawing.Point(12, 134);
            this.excelTemplateTextBox.Name = "excelTemplateTextBox";
            this.excelTemplateTextBox.Size = new System.Drawing.Size(245, 20);
            this.excelTemplateTextBox.TabIndex = 8;
            // 
            // openXltxPath
            // 
            this.openXltxPath.Location = new System.Drawing.Point(262, 132);
            this.openXltxPath.Name = "openXltxPath";
            this.openXltxPath.Size = new System.Drawing.Size(75, 23);
            this.openXltxPath.TabIndex = 9;
            this.openXltxPath.Text = "Обзор";
            this.openXltxPath.UseVisualStyleBackColor = true;
            this.openXltxPath.Click += new System.EventHandler(this.openXltxPath_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(13, 116);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(174, 13);
            this.label21.TabIndex = 10;
            this.label21.Text = "Место положение шаблона Excel";
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(12, 461);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 11;
            this.ResetButton.Text = "Сброс";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(350, 535);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.openXltxPath);
            this.Controls.Add(this.excelTemplateTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SettingsButtonBrowserPath);
            this.Controls.Add(this.SettingsPathTextBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.VaultsComboBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox VaultsComboBox;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox SettingsPathTextBox;
        private System.Windows.Forms.Button SettingsButtonBrowserPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox PrimaryApplicationComboBox;
        private System.Windows.Forms.ComboBox ReferenceNumbComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox InvNumbDuplComboBox;
        private System.Windows.Forms.ComboBox ReplacedInvNumbComboBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox InvNumbOriginComboBox;
        private System.Windows.Forms.ComboBox LiteraComboBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox ApproverComboBox;
        private System.Windows.Forms.ComboBox NormativeControlComboBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CheckerComboBox;
        private System.Windows.Forms.ComboBox DeveloperComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox ZoneComboBox;
        private System.Windows.Forms.ComboBox NoteComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox SectionComboBox;
        private System.Windows.Forms.ComboBox DrawingPaperSizeComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox DesignationComboBox;
        private System.Windows.Forms.ComboBox NameComboBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox excelTemplateTextBox;
        private System.Windows.Forms.Button openXltxPath;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button ResetButton;
    }
}