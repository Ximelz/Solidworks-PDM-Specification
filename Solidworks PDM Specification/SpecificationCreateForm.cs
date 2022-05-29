using Aspose.Cells;
using EPDM.Interop.epdm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

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
            UpdateValuesInTextBoxes();
        }

        private void CreateSpecification_Click(object sender, EventArgs e)
        {
            (IEdmVault5, bool) vault;
            vault = LogginInVault();
            if (!vault.Item2)
            {
                MessageBox.Show("Искомый вид хранилища из настроек отсутсвует!");
                return;
            }
            SolidWorksPDMForm form = new SolidWorksPDMForm(vault.Item1);
            form.ShowDialog();
            if (form.closeFlag)
                return;
            stamp.FilePath = form.path;
            stamp.Configuration = form.configuration;
            form.Dispose();
            GetReferenceFiles(vault.Item1);
            UpdateSpecificationButton.Enabled = true;
        }

        private void UpdateSpecificationButton_Click(object sender, EventArgs e)
        {
            (IEdmVault5, bool) vault;
            vault = LogginInVault();
            if (vault.Item2)
            {
                MessageBox.Show("Искомый вид хранилища из настроек отсутсвует!");
                return;
            }
            GetReferenceFiles(vault.Item1);
        }

        private void GetReferenceFiles(IEdmVault5 vault)
        {
            ReferenceFiles refFiles = new ReferenceFiles(stamp.FilePath, settings, stamp, vault);
            Elements = refFiles.GetListElements();
            stamp = refFiles.stamp;
            UpdateSectionComboBox();
        }

        private (IEdmVault5, bool) LogginInVault()
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
                return (vault, flag);
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return (null, false);
        }

        private void SectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Elements.Count != 0)
                UpdateElementsListBox();
        }


        private void elementsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] parseString;
            string name;

            foreach (Element element in Elements)
            {
                if (element.Section == "Детали" || element.Section == "Сборочные единицы")
                {
                    name = element.Designation.Trim();
                    parseString = elementsListBox.SelectedItem.ToString().Trim().Split();
                }
                else
                {
                    name = element.Name.Trim();
                    parseString = new string[] { elementsListBox.SelectedItem.ToString().Trim() };
                }

                if (name == parseString[0])
                {
                    SelectElement = element;
                    UpdateValuesInTextBoxes();
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
            if (elementsListBox.Items.Count !=0)
                elementsListBox.SelectedItem = elementsListBox.Items[0];
        }

        private void UpdateValuesInTextBoxes()
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
            if (stamp.usePdmFlag)
                UpdateSpecificationButton.Enabled = true;
            else
                UpdateSpecificationButton.Enabled = false;
            UpdateSectionComboBox();
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

        private void exportToExcelButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, List<Element>> nameSections = new Dictionary<string, List<Element>>()
            {
                {"Документация", new List<Element>()}, {"Комплексы", new List<Element>()},
                {"Сборочные единицы", new List<Element>()}, {"Детали", new List<Element>()},
                {"Стандартные изделия", new List<Element>()}, {"Прочие изделия", new List<Element>()},
                {"Материалы", new List<Element>()}, {"Комплекты", new List<Element>()}
            };
            foreach (Element element in Elements)
                if (nameSections.ContainsKey(element.Section))
                    nameSections[element.Section].Add(element);

            using (var workbook = new Workbook(settings.excelTemplate))
            {
                Worksheet ws = workbook.Worksheets["Specification_sheet_1"];
                Cell cell;
                int cellIndex = 5;
                int position = 1;
                int maxCellIndex = 61;
                int Lists = 1;
                SetStamp(ws, Lists);
                foreach (KeyValuePair<string, List<Element>> keyValuePair in nameSections)
                {
                    if (keyValuePair.Value.Count > 0)
                    {

                        cellIndex += 2;
                        if (cellIndex < maxCellIndex)
                        {
                            cell = ws.Cells["AI" + cellIndex];
                            cell.PutValue(keyValuePair.Key);
                            Style style = cell.GetStyle();
                            style.HorizontalAlignment = TextAlignmentType.Center;
                            style.Font.Underline = FontUnderlineType.Single;
                            style.Font.IsBold = true;
                            cell.SetStyle(style);
                        }
                        cellIndex += 4;

                        int listCount = keyValuePair.Value.Count;
                        AddElementsOnSpecificationForm(ref ws, ref cellIndex, maxCellIndex, ref listCount, ref position, 
                                                        keyValuePair.Value, ref Lists, workbook);
                    }
                }

                ws = workbook.Worksheets["Specification_sheet_1"];
                cell = ws.Cells["BH67" + cellIndex];
                cell.PutValue(Lists);
                WorksheetCollection wc = workbook.Worksheets;
                wc.RemoveAt(wc.Count - 1);
                workbook.Save($"D:\\{stamp.Designation} {stamp.Name}.xls");
            }
        }

        private void AddElementsOnSpecificationForm(ref Worksheet worksheet, ref int cellIndex, int maxIndex, ref int listCount, ref int position, List<Element> elements, ref int Lists, Workbook workbook)
        {
            Cell cell;
            int i = 0;
            while (cellIndex <= maxIndex && listCount > i)
            {
                if (elements[i].Count / 27 + (elements[i].Count % 27 != 0 ? 1 : 0) > (maxIndex - cellIndex) / 2)
                {
                    WorksheetCollection wc = workbook.Worksheets;
                    Lists++;
                    wc.Add("Specification_sheet_" + (Lists + 1));
                    maxIndex = 67;
                    wc[wc.Count - 1].Copy(wc[wc.Count - 2]);
                    worksheet = workbook.Worksheets["Specification_sheet_" + Lists];
                    cellIndex = 7;
                    SetStamp(worksheet, Lists);
                }

                cell = worksheet.Cells["E" + cellIndex];
                cell.PutValue(elements[i].DrawingPaperSize);

                cell = worksheet.Cells["G" + cellIndex];
                cell.PutValue(elements[i].Zone);

                cell = worksheet.Cells["I" + cellIndex];
                cell.PutValue(position.ToString());

                cell = worksheet.Cells["AI" + cellIndex];
                cell.PutValue(elements[i].Name);

                cell = worksheet.Cells["BD" + cellIndex];
                cell.PutValue(elements[i].Count.ToString());

                cell = worksheet.Cells["BG" + cellIndex];
                cell.PutValue(elements[i].Note);

                cell = worksheet.Cells["L" + cellIndex];
                if (elements[i].Designation.Length > 27)
                    SplitDesignation(worksheet, ref cellIndex, elements[i].Designation, cell);
                else
                    cell.PutValue(elements[i].Designation);

                position++;
                i++;
                cellIndex += 2;
            }
        }

        private void SplitDesignation(Worksheet worksheet, ref int cellIndex, string designation, Cell cell)
        {
            cell.PutValue(designation.Substring(0, 27));
            cellIndex += 2;
            cell = worksheet.Cells["L" + cellIndex];
            if (designation.Remove(0, 27).Length > 27)
                SplitDesignation(worksheet, ref cellIndex, designation, cell);
        }

        private void SetStamp(Worksheet worksheet, int Lists)
        {
            Cell cell;
            cell = worksheet.Cells["C66"];
            cell.PutValue(stamp.InvNumbOrigin);

            cell = worksheet.Cells["C52"];
            cell.PutValue(stamp.ReferenceNumb);

            cell = worksheet.Cells["C37"];
            cell.PutValue(stamp.InvNumbDupl);

            if (Lists == 1)
            {
                cell = worksheet.Cells["K66"];
                cell.PutValue(stamp.Developer);
                cell = worksheet.Cells["W66"];
                cell.PutValue(stamp.DateDeveloper.ToString("dd.MM.yyyy"));

                cell = worksheet.Cells["K67"];
                cell.PutValue(stamp.Checker);
                cell = worksheet.Cells["W67"];
                cell.PutValue(stamp.DateChecker.ToString("dd.MM.yyyy"));

                cell = worksheet.Cells["K69"];
                cell.PutValue(stamp.NormativeControl);
                cell = worksheet.Cells["W69"];
                cell.PutValue(stamp.DateNormativeControl.ToString("dd.MM.yyyy"));
                
                cell = worksheet.Cells["K70"];
                cell.PutValue(stamp.Approver);
                cell = worksheet.Cells["W70"];
                cell.PutValue(stamp.DateApprover.ToString("dd.MM.yyyy"));

                cell = worksheet.Cells["Z66"];
                cell.PutValue(stamp.Name);

                cell = worksheet.Cells["Z63"];
                cell.PutValue(stamp.Designation);

                cell = worksheet.Cells["AY67"];
                cell.PutValue(stamp.Litera);

                cell = worksheet.Cells["AW68"];
                cell.PutValue("МАИ Кафедра 316");
            }
            else
            {
                cell = worksheet.Cells["Z69"];
                cell.PutValue(stamp.Name);

                cell = worksheet.Cells["BK70"];
                cell.PutValue(Lists);
            }
        }
    }
}
