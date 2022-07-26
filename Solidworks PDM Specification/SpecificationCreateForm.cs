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
        private string currentDirectory;
        private InteractWithDataGrid interactWithDataGrid;
        private Dictionary<string, int> idSection = new Dictionary<string, int>()
        {
            {"Документация", 0}, {"Комплексы", 0},
            { "Сборочные единицы", 0}, { "Детали", 0},
            { "Стандартные изделия", 0}, { "Прочие изделия", 0},
            { "Материалы", 0}, { "Комплекты", 0}
        };

        public SpecificationCreateForm()
        {
            InitializeComponent();
            interactWithDataGrid = new InteractWithDataGrid(dataGridView1);
            //dataGridView1.Rows.Add("0", "0", "0", "0", "0", "0", true);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            currentDirectory = Directory.GetCurrentDirectory();
            settings = new Settings(currentDirectory);
            stamp = new DrawingStamp();
            xml = new XML_Convert();
            Elements = new List<Element>();
            //dataGridView1.Rows.Add("0", "0", "0", "0", "0", "0", true);
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
            dataGridView1 = interactWithDataGrid.UpdateDataGrid(Elements, ref idSection);
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
            catch
            {
                return (null, false);
            }
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
            dataGridView1 = interactWithDataGrid.UpdateDataGrid(Elements, ref idSection);
        }
        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Xml files(*.xml)|*.xml|All files(*.*)|*.*";
            XML_Convert xml = new XML_Convert();
            DialogResult DialogSaveResult;
            DialogSaveResult = saveFileDialog1.ShowDialog();
            if (!(DialogSaveResult == DialogResult.OK))
                return;
            xml.Export(interactWithDataGrid.GetNewListElements(ref idSection), stamp, saveFileDialog1.FileName);
        }
        private void exportToExcelButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = stamp.Designation + " " + stamp.Name + ".xls";
            saveFileDialog1.Filter = "Xls files(*.xls)|*.xls|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            string saveFileName = saveFileDialog1.FileName;
            string addFileFormat = saveFileName.Substring(saveFileName.Length - 4) == ".xls" ? "" : ".xls";

            List<Element> newListElements = interactWithDataGrid.GetNewListElements(ref idSection);
            ExcelSpecification excelSpecification = new ExcelSpecification(settings, stamp);
            excelSpecification.exportToExcel(newListElements, saveFileName, addFileFormat);
        }


        //private void UpdateDataGrid(List<Element> elements)
        //{
        //    dataGridView1.Rows.Clear();
        //    nameSections = new Dictionary<string, List<Element>>()
        //    {
        //        {"Документация", new List<Element>()}, {"Комплексы", new List<Element>()},
        //        {"Сборочные единицы", new List<Element>()}, {"Детали", new List<Element>()},
        //        {"Стандартные изделия", new List<Element>()}, {"Прочие изделия", new List<Element>()},
        //        {"Материалы", new List<Element>()}, {"Комплекты", new List<Element>()}
        //    };
        //    int count = 0;
        //    foreach (Element element in elements)
        //        if (nameSections.ContainsKey(element.Section))
        //        {
        //            nameSections[element.Section].Add(element);
        //            count++;
        //        }
        //    AddRows(nameSections, count);
        //}
        //private void AddRows(Dictionary<string, List<Element>> nameSections, int count)
        //{
        //    int i = 0;
        //    dataGridView1.Rows.AddCopy(dataGridView1.Rows.Count - 1);
        //    foreach (KeyValuePair<string, List<Element>> keyValuePair in nameSections)
        //    {
        //        idSection[keyValuePair.Key] = dataGridView1.Rows.Count - 2;
        //        dataGridView1.Rows[dataGridView1.Rows.Count - 2]
        //            .SetValues("", "", "", keyValuePair.Key);
        //        dataGridView1.Rows.AddCopy(dataGridView1.Rows.Count - 2);
        //        if (keyValuePair.Value.Count > 0)
        //        {
        //            foreach (Element element in keyValuePair.Value)
        //                AddNewRow(element);
        //        }
        //        i++;
        //    }
        //}
        //private void AddNewRow(Element element)
        //{
        //    dataGridView1.Rows[dataGridView1.Rows.Count - 2].SetValues(element.DrawingPaperSize, element.Zone,
        //                            element.Designation, element.Name, element.Count.ToString(), element.Note, element.nameFlag); ;
        //    dataGridView1.Rows.AddCopy(dataGridView1.Rows.Count - 2);
        //}
        //private List<Element> GetNewListElements()
        //{
        //    List<Element> elements = new List<Element>();
        //    int[] sections = new int[8];
        //    string[] nameSections = new string[8];
        //    int i = 0;
        //    foreach (KeyValuePair<string, int> keyValuePair in idSection)
        //    {
        //        sections[i] = keyValuePair.Value;
        //        nameSections[i] = keyValuePair.Key;
        //        i++;
        //    }
        //    i = 1;
        //    int rowsCount = dataGridView1.Rows.Count - 2;
        //    for (int j = 1; j < rowsCount; j++)
        //        if (i < 8)
        //        {
        //            if (j < sections[i])
        //            {
        //                AddElementFromDataGrid(ref elements, j, nameSections[i - 1]);
        //            }
        //            else
        //            {
        //                i++;
        //            }
        //        }

        //    return elements;
        //}
        //private void AddElementFromDataGrid(ref List<Element> Elements, int i, string section)
        //{
        //    int currentIndex = Elements.Count;
        //    Elements.Add(new Element());
        //    Elements[currentIndex].DrawingPaperSize = dataGridView1.Rows[i].Cells[0].Value.ToString();
        //    Elements[currentIndex].Zone = dataGridView1.Rows[i].Cells[1].Value.ToString();
        //    Elements[currentIndex].Designation = dataGridView1.Rows[i].Cells[2].Value.ToString();
        //    Elements[currentIndex].Name = dataGridView1.Rows[i].Cells[3].Value.ToString();
        //    if (dataGridView1.Rows[i].Cells[4].Value != null)
        //    {
        //        if (int.TryParse(dataGridView1.Rows[i].Cells[4].Value.ToString(), out int count))
        //            Elements[currentIndex].Count = count;
        //        else
        //            Elements[currentIndex].Count = 0;
        //    }
        //    else
        //        Elements[currentIndex].Count = 0;

        //    Elements[currentIndex].Note = dataGridView1.Rows[i].Cells[5].Value.ToString();
        //    Elements[currentIndex].nameFlag = (bool)dataGridView1.Rows[i].Cells[6].Value;
        //    Elements[currentIndex].Section = section;
        //}        
        private void AddButton_Click(object sender, EventArgs e)
        {
            dataGridView1 = interactWithDataGrid.AddElementToDataGrid(dataGridView1.CurrentRow.Index, ref idSection);            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
