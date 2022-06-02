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
        private string currentDirectory;
        private Dictionary<string, int> idSection = new Dictionary<string, int>()
        {
            {"Документация", 0}, {"Комплексы", 0},
            { "Сборочные единицы", 0}, { "Детали", 0},
            { "Стандартные изделия", 0}, { "Прочие изделия", 0},
            { "Материалы", 0}, { "Комплекты", 0}
        };
        private Dictionary<string, List<Element>> nameSections;

        public SpecificationCreateForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            currentDirectory = Directory.GetCurrentDirectory();
            settings = new Settings(currentDirectory);
            stamp = new DrawingStamp();
            xml = new XML_Convert();
            Elements = new List<Element>();

            if (!File.Exists(currentDirectory + "\\PathWithSettings.xml"))
            {
                xml.Export(currentDirectory + "\\Settings.xml");
                if (!File.Exists(currentDirectory + "\\Settings.xml"))
                    xml.Export(settings, currentDirectory + "\\Settings.xml");
                return;
            }
            xml.Import(out string path);
            if (File.Exists(path))
                xml.Import(out settings, path);
            else
            {
                xml.Export(settings, currentDirectory + "\\Settings.xml");
                xml.Export(currentDirectory + "\\Settings.xml");
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
            UpdateDataGrid(Elements);
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

        private void UpdateDataGrid(List<Element> elements)
        {
            nameSections = new Dictionary<string, List<Element>>()
            {
                {"Документация", new List<Element>()}, {"Комплексы", new List<Element>()},
                {"Сборочные единицы", new List<Element>()}, {"Детали", new List<Element>()},
                {"Стандартные изделия", new List<Element>()}, {"Прочие изделия", new List<Element>()},
                {"Материалы", new List<Element>()}, {"Комплекты", new List<Element>()}
            };
            int count = 0;
            foreach (Element element in elements)
                if (nameSections.ContainsKey(element.Section))
                {
                    nameSections[element.Section].Add(element);
                    count++;
                }
            AddRows(nameSections, count);
        }
        private void AddRows(Dictionary<string, List<Element>> nameSections, int count)
        {
            int i = 0;
            dataGridView1.Rows.AddCopy(dataGridView1.Rows.Count - 1);
            foreach (KeyValuePair<string, List<Element>> keyValuePair in nameSections)
            {
                idSection[keyValuePair.Key] = dataGridView1.Rows.Count - 2;
                dataGridView1.Rows[dataGridView1.Rows.Count - 2]
                    .SetValues("", "", "", keyValuePair.Key);
                dataGridView1.Rows.AddCopy(dataGridView1.Rows.Count - 2);
                if (keyValuePair.Value.Count > 0)
                {
                    foreach (Element element in keyValuePair.Value)
                        AddNewRow(element);

                }
                i++;
            }
        }

        private void AddNewRow(Element element)
        {
            dataGridView1.Rows[dataGridView1.Rows.Count - 2].SetValues(element.DrawingPaperSize, element.Zone, 
                                    element.Designation, element.Name, element.Count.ToString(), element.Note);
            dataGridView1.Rows.AddCopy(dataGridView1.Rows.Count - 2);
        }

        private List<Element> GetNewListElements()
        {
            List<Element> elements = new List<Element>();
            int[] sections = new int[8];
            string[] nameSections = new string[8];
            int i = 0;
            foreach (KeyValuePair<string, int> keyValuePair in idSection)
            {
                sections[i] = keyValuePair.Value;
                nameSections[i] = keyValuePair.Key;
                i++;
            }
            i = 1;
            int rowsCount = dataGridView1.Rows.Count - 2;
            for (int j = 1; j < rowsCount; j++)
                if (i < 9)
                {
                    if (j < sections[i])
                    {
                        AddElementFromDataGrid(ref elements, j, nameSections[i - 1]);
                    }
                    else
                    {
                        i++;
                    }
                }

            return elements;
        }







        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Xml files(*.xml)|*.xml|All files(*.*)|*.*";
            XML_Convert xml = new XML_Convert();
            DialogResult DialogOpenResult;
            DialogOpenResult = openFileDialog1.ShowDialog();
            if (!(DialogOpenResult == DialogResult.OK))
                return;
            xml.Import(out Elements, out stamp, openFileDialog1.FileName);
            if (stamp.usePdmFlag)
                UpdateSpecificationButton.Enabled = true;
            else
                UpdateSpecificationButton.Enabled = false;
            UpdateDataGrid(Elements);
        }

        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Xml files(*.xml)|*.xml|All files(*.*)|*.*";
            XML_Convert xml = new XML_Convert();
            DialogResult DialogSaveResult;
            DialogSaveResult = saveFileDialog1.ShowDialog();
            if (!(DialogSaveResult == DialogResult.OK))
                return;
            xml.Export(GetNewListElements(), stamp, saveFileDialog1.FileName);
        }

        private void exportToExcelButton_Click(object sender, EventArgs e)
        {
           exportToExcel(GetNewListElements());
        }
        private void AddElementFromDataGrid(ref List<Element> Elements, int i, string section)
        {
            int currentIndex = Elements.Count;
            Elements.Add(new Element());
            Elements[currentIndex].DrawingPaperSize = dataGridView1.Rows[i].Cells[0].Value.ToString();
            Elements[currentIndex].Zone = dataGridView1.Rows[i].Cells[1].Value.ToString();
            Elements[currentIndex].Designation = dataGridView1.Rows[i].Cells[2].Value.ToString();
            Elements[currentIndex].Name = dataGridView1.Rows[i].Cells[3].Value.ToString();
            if (int.TryParse(dataGridView1.Rows[i].Cells[4].Value.ToString(), out int count))
                Elements[currentIndex].Count = count;
            else
                Elements[currentIndex].Count = 0;
            Elements[currentIndex].Note = dataGridView1.Rows[i].Cells[5].Value.ToString();
            Elements[currentIndex].Section = section;
        }

        private void exportToExcel(List<Element> elements)
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
            //using (var workbook = new Workbook($"{currentDirectory}\\Specification.xltx"))
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
                        cell = ws.Cells["AI" + cellIndex];
                        cell.PutValue(keyValuePair.Key);
                        Style style = cell.GetStyle();
                        style.HorizontalAlignment = TextAlignmentType.Center;
                        style.Font.Underline = FontUnderlineType.Single;
                        style.Font.IsBold = true;
                        cell.SetStyle(style);
                        cellIndex += 4;
                        int listCount = keyValuePair.Value.Count;
                        AddElementsOnSpecificationForm(ref ws, ref cellIndex, maxCellIndex, ref listCount, ref position,
                                                        keyValuePair.Value, ref Lists, workbook);
                    }
                }
                ws = workbook.Worksheets["Specification_sheet_1"];
                cell = ws.Cells["BH67"];
                cell.PutValue(Lists);
                WorksheetCollection wc = workbook.Worksheets;
                wc.RemoveAt(wc.Count - 1);
                saveFileDialog1.Filter = "Xls files(*.xls)|*.xls|All files(*.*)|*.*";
                if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                    return;
                string saveFileName = saveFileDialog1.FileName;
                string addFileFormat = saveFileName.Substring(saveFileName.Length - 4) == ".xls" ? "" : ".xls";
                workbook.Save(saveFileDialog1.FileName + addFileFormat);
            }
        }

        private void AddElementsOnSpecificationForm(ref Worksheet worksheet, ref int cellIndex, int maxIndex, ref int listCount, ref int position, List<Element> elements, ref int Lists, Workbook workbook)
        {
            Cell cell;
            int i = 0;
            while (listCount > i)
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
            else
                cell.PutValue(designation);
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
                cell.PutValue("АО НИИТМ");
            }
            else
            {
                cell = worksheet.Cells["Z69"];
                cell.PutValue(stamp.Name);

                cell = worksheet.Cells["BK70"];
                cell.PutValue(Lists);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows.InsertCopy(index, index + 1);
        }
    }
}
