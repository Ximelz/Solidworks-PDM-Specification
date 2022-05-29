using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xaml;
using EPDM.Interop.epdm;

namespace Solidworks_PDM_Specification
{
    public partial class SpecificationCreateForm : Form
    {
        private Settings settings;
        private DrawingStamp stamp;
        private XML_Convert xml;
        public List<Element> Elements;
        private Element SelectElement;

        public SpecificationCreateForm()
        {
            InitializeComponent();
            NameOldName.Text = "";
            DesignationOldName.Text = "";
            NoteOldName.Text = "";
            ZoneOldName.Text = "";
            DrawingPaperSizeOldName.Text = "";
            countOldName.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            settings = new Settings();
            stamp = new DrawingStamp();
            xml = new XML_Convert();
            Elements = new List<Element>();

            if (!File.Exists(Directory.GetCurrentDirectory() + "\\PathWithSettings.xml"))
            {
                xml.Export(Directory.GetCurrentDirectory() + "\\Settings.xml");
                if (!File.Exists(Directory.GetCurrentDirectory() + "\\Settings.xml"))
                    xml.Export(settings, Directory.GetCurrentDirectory() + "\\Settings.xml");
                return;
            }

            xml.Import(out string path);
            if (File.Exists(path))
                xml.Import(out settings, path);
            else
            {
                xml.Export(settings, Directory.GetCurrentDirectory() + "\\Settings.xml");
                xml.Export(Directory.GetCurrentDirectory() + "\\Settings.xml");
            }

        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm(settings);
            form.ShowDialog();
            settings = form.settings;
            form.Dispose();
        }
        private void StampButton_Click(object sender, EventArgs e)
        {
            StampSettingsForm form = new StampSettingsForm(stamp);
            form.ShowDialog();
            stamp = form.stemp;
            form.Dispose();
        }

        private void CreateSpecification_Click(object sender, EventArgs e)
        {
            string path;
            IEdmVault5 vault = LogginInVault();
            SolidWorksPDMForm form = new SolidWorksPDMForm(vault);
            form.ShowDialog();
            if (form.closeFlag)
                return;
            path = form.path;
            stamp.Configuration = form.configuration;
            form.Dispose();
            GetReferenceFiles(vault);
            UpdateSpecificationButton.Enabled = true;
        }


        private void UpdateSpecificationButton_Click(object sender, EventArgs e)
        {
            IEdmVault5 vault = LogginInVault();
            GetReferenceFiles(vault);
        }

        private void GetReferenceFiles(IEdmVault5 vault)
        {
            ReferenceFiles refFiles = new ReferenceFiles(stamp.FilePath, settings, stamp, vault);
            stamp = refFiles.stamp;
            Elements = refFiles.GetListElements();
            UpdateSectionComboBox();
        }

        private IEdmVault5 LogginInVault()
        {
            try
            {
                IEdmVault5 vault = new EdmVault5();
                IEdmVault8 vault1 = (IEdmVault8)vault;
                EdmViewInfo[] Views;

                vault1.GetVaultViews(out Views, false);
                bool flag = false;
                foreach (EdmViewInfo View in Views)
                    if (View.mbsVaultName == settings.Vault)
                        flag = true;
                if (!vault1.IsLoggedIn)
                    vault.LoginAuto(settings.Vault, this.Handle.ToInt32());
                    
                return vault;

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        private void SectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Elements.Count != 0)
                UpdateElementsListBox();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (SelectElement == null)
                return;

            if (!int.TryParse(countTextBox.Text, out int elementCount))
            {
                MessageBox.Show("Значение поля \"Количество\" не является числом");
                return;
            }
            SelectElement.Name = nameTextBox.Text;
            SelectElement.Designation = designationTextBox.Text;
            SelectElement.DrawingPaperSize = drawingPaperSizeTextBox.Text;
            SelectElement.Zone = zoneTextBox.Text;
            SelectElement.Note = noteTextBox.Text;
            SelectElement.Count = elementCount;

            NameOldName.Text = SelectElement.Name;
            DesignationOldName.Text = SelectElement.Designation;
            NoteOldName.Text = SelectElement.Note;
            ZoneOldName.Text = SelectElement.Zone;
            DrawingPaperSizeOldName.Text = SelectElement.DrawingPaperSize;
            countOldName.Text = SelectElement.Count.ToString();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (SelectElement == null)
                return;
            UpdateValuesInTextBoxs();
        }

        private void elementsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] parseString = elementsListBox.SelectedItem.ToString().Split(' ');
            foreach (Element element in Elements)
            {
                if (element.Designation == parseString[0])
                {
                    SelectElement = element;
                    UpdateValuesInTextBoxs();
                    return;
                }
            }
        }

        private void UpdateSectionComboBox()
        {
            SectionComboBox.Items.Clear();
            SectionComboBox.Items.Add(Elements[0].Section);
            int countSectionComboBox = SectionComboBox.Items.Count;
            foreach (Element element in Elements)
            {
                bool flag = true;
                for (int i = 0; i < countSectionComboBox; i++)
                    if (SectionComboBox.Items[i].ToString() == element.Section)
                        flag = false;
                if (flag)
                {
                    SectionComboBox.Items.Add(element.Section);
                    countSectionComboBox++;
                }
            }
            SectionComboBox.Text = SectionComboBox.Items[0].ToString();
        }

        private void UpdateElementsListBox()
        {
            elementsListBox.Items.Clear();
            foreach (Element element in Elements)
                if (element.Section == SectionComboBox.Text)
                    elementsListBox.Items.Add(element.Designation + " " + element.Name);
            elementsListBox.SelectedItem = elementsListBox.Items[0];
        }

        private void UpdateValuesInTextBoxs()
        {
            nameTextBox.Text = SelectElement.Name;
            designationTextBox.Text = SelectElement.Designation;
            drawingPaperSizeTextBox.Text = SelectElement.DrawingPaperSize;
            zoneTextBox.Text = SelectElement.Zone;
            noteTextBox.Text = SelectElement.Note;
            countTextBox.Text = SelectElement.Count.ToString();

            NameOldName.Text = SelectElement.Name;
            DesignationOldName.Text = SelectElement.Designation;
            NoteOldName.Text = SelectElement.Note;
            ZoneOldName.Text = SelectElement.Zone;
            DrawingPaperSizeOldName.Text = SelectElement.DrawingPaperSize;
            countOldName.Text = SelectElement.Count.ToString();
        }

        private void addSection_Click(object sender, EventArgs e)
        {
            AddSection form = new AddSection();
            form.ShowDialog();
            
            if (!form.closeFlag)
            {
                bool exitFlag = false;
                foreach (var item in SectionComboBox.Items)
                    if (item.ToString() == form.section)
                    {
                        MessageBox.Show("Такой раздел уже существует");
                        exitFlag = true;
                    }

                if (!exitFlag)
                {
                    SectionComboBox.Items.Add(form.section);
                    if (SectionComboBox.Text == "")
                        SectionComboBox.Text = SectionComboBox.Items[0].ToString();
                }
            }
            form.Dispose();
        }

        private void addElementButton_Click(object sender, EventArgs e)
        {
            if (SectionComboBox.Items.Count == 0)
            {
                MessageBox.Show("Невозможно добавить элемент, так как небыли добавлены разделы.");
                return;
            }

            List<string> sections = new List<string>();
            foreach (var item in SectionComboBox.Items)
                sections.Add(item.ToString());
            AddElement form = new AddElement(sections);
            form.ShowDialog();
            if (!form.closeFlag)
            {
                Elements.Add(form.element);
                UpdateElementsListBox();
            }

            form.Dispose();
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Xml files(*.xml)|*.xml|All files(*.*)|*.*";
            XML_Convert xml = new XML_Convert();
            DialogResult DialogResult;
            DialogResult = openFileDialog1.ShowDialog();
            if (!(DialogResult == DialogResult.OK))
                return;
            xml.Import(out Elements, out stamp, openFileDialog1.FileName);
            UpdateSectionComboBox();
            if (stamp.usePdmFlag)
                UpdateSpecificationButton.Enabled = true;
            else
                UpdateSpecificationButton.Enabled = false;
        }

        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Xml files(*.xml)|*.xml|All files(*.*)|*.*";
            XML_Convert xml = new XML_Convert();
            DialogResult DialogResult;
            DialogResult = saveFileDialog1.ShowDialog();
            if (!(DialogResult == DialogResult.OK))
                return;
            xml.Export(Elements, stamp, saveFileDialog1.FileName);
        }
    }
}
