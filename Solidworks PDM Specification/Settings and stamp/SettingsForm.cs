using EPDM.Interop.epdm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Solidworks_PDM_Specification
{
    public partial class SettingsForm : Form
    {
        //private bool changeSettings;
        public Settings settings;
        private IEdmVault5 vault;
        private XML_Convert xml;
        private bool saveResult = true;
        private bool pdmIsNotLogged = false;

        public SettingsForm(Settings settings)
        {
            InitializeComponent();

            xml = new XML_Convert();
            xml.Import(out string pathSettings);
            SettingsPathTextBox.Text = pathSettings;

            this.settings = settings;

            xml.Import(out settings, pathSettings);
            LoadComboBoxesFromSettings();

            excelTemplateTextBox.Text = settings.excelTemplate;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            pdmIsNotLogged = GetViewVaults();
            PdmLoad();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            SaveSettingsInObject();
            if (saveResult)
                Close();
            saveResult = true;
        }

        private void SettingsButtonBrowserPath_Click(object sender, EventArgs e)
        {
            DialogResult DialogResult;
            DialogResult = openFileDialog1.ShowDialog();

            if (!(DialogResult == DialogResult.OK))
                return;

            SettingsPathTextBox.Text = openFileDialog1.FileName;
        }

        /// <summary>
        /// Метод сохраняющий текущие настройки в файл.
        /// </summary>
        private void SaveSettingsInObject()
        {
            if (!File.Exists(SettingsPathTextBox.Text))
            {
                MessageBox.Show("Указанного файла настроек не существует. Проверьте правильность указанного файла.");
                saveResult = false;
                return;
            }

            Dictionary<string, string> tempDictionary = new Dictionary<string, string>();

            tempDictionary.Add("Name", NameComboBox.Text);
            tempDictionary.Add("Designation", DesignationComboBox.Text);
            tempDictionary.Add("DrawingPaperSize", DrawingPaperSizeComboBox.Text);
            tempDictionary.Add("Section", SectionComboBox.Text);
            tempDictionary.Add("Note", NoteComboBox.Text);
            tempDictionary.Add("Zone", ZoneComboBox.Text);
            tempDictionary.Add("Developer", DeveloperComboBox.Text);
            tempDictionary.Add("Checker", CheckerComboBox.Text);
            tempDictionary.Add("NormativeControl", NormativeControlComboBox.Text);
            tempDictionary.Add("Approver", ApproverComboBox.Text);
            tempDictionary.Add("Litera", LiteraComboBox.Text);
            tempDictionary.Add("InvNumbOrigin", InvNumbOriginComboBox.Text);
            tempDictionary.Add("ReplacedInvNumb", ReplacedInvNumbComboBox.Text);
            tempDictionary.Add("InvNumbDupl", InvNumbDuplComboBox.Text);
            tempDictionary.Add("ReferenceNumb", ReferenceNumbComboBox.Text);
            tempDictionary.Add("PrimaryApplication", PrimaryApplicationComboBox.Text);

            settings.ComparsionGlobalVariable = tempDictionary;
            settings.Vault = VaultsComboBox.Text;

            xml = new XML_Convert();
            xml.Export(settings, SettingsPathTextBox.Text);
            xml.Export(SettingsPathTextBox.Text);
        }

        private bool GetViewVaults()
        {
            try
            {
                vault = new EdmVault5();
                IEdmVault8 viewVault = (IEdmVault8)vault;
                EdmViewInfo[] Views = null;

                bool vaultInSettingsFlag = false;

                viewVault.GetVaultViews(out Views, false);
                VaultsComboBox.Items.Clear();
                foreach (EdmViewInfo View in Views)
                {
                    VaultsComboBox.Items.Add(View.mbsVaultName);
                    if (View.mbsVaultName == settings.Vault)
                        vaultInSettingsFlag = true;
                }

                if (vaultInSettingsFlag)
                {
                    VaultsComboBox.Text = settings.Vault;
                    LoadComboBoxesFromSettings();
                }
                else if (VaultsComboBox.Items.Count > 0)
                    VaultsComboBox.Text = (string)VaultsComboBox.Items[0];
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        private void VaultsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComboBoxesFromSettings();
        }

        private void LoadComboBoxesFromSettings()
        {
            NameComboBox.Text = settings.ComparsionGlobalVariable["Name"];
            DesignationComboBox.Text = settings.ComparsionGlobalVariable["Designation"];
            DrawingPaperSizeComboBox.Text = settings.ComparsionGlobalVariable["DrawingPaperSize"];
            SectionComboBox.Text = settings.ComparsionGlobalVariable["Section"];
            NoteComboBox.Text = settings.ComparsionGlobalVariable["Note"];
            ZoneComboBox.Text = settings.ComparsionGlobalVariable["Zone"];
            DeveloperComboBox.Text = settings.ComparsionGlobalVariable["Developer"];
            CheckerComboBox.Text = settings.ComparsionGlobalVariable["Checker"];
            NormativeControlComboBox.Text = settings.ComparsionGlobalVariable["NormativeControl"];
            ApproverComboBox.Text = settings.ComparsionGlobalVariable["Approver"];
            LiteraComboBox.Text = settings.ComparsionGlobalVariable["Litera"];
            InvNumbOriginComboBox.Text = settings.ComparsionGlobalVariable["InvNumbOrigin"];
            ReplacedInvNumbComboBox.Text = settings.ComparsionGlobalVariable["ReplacedInvNumb"];
            InvNumbDuplComboBox.Text = settings.ComparsionGlobalVariable["InvNumbDupl"];
            ReferenceNumbComboBox.Text = settings.ComparsionGlobalVariable["ReferenceNumb"];
            PrimaryApplicationComboBox.Text = settings.ComparsionGlobalVariable["PrimaryApplication"];
        }

        private void PdmLoad()
        {
            vault.LoginAuto(VaultsComboBox.Text, this.Handle.ToInt32());
            IEdmVariableMgr5 VarMgr = (IEdmVariableMgr5)vault;
            IEdmPos5 VarPos = VarMgr.GetFirstVariablePosition();
            while (!VarPos.IsNull)
            {
                IEdmVariable5 Var = default(IEdmVariable5);
                Var = VarMgr.GetNextVariable(VarPos);
                AddItemsInComboBoxes(Var.Name);
            }
        }

        private void AddItemsInComboBoxes(string value)
        {
            NameComboBox.Items.Add(value);
            DesignationComboBox.Items.Add(value);
            DrawingPaperSizeComboBox.Items.Add(value);
            SectionComboBox.Items.Add(value);
            NoteComboBox.Items.Add(value);
            ZoneComboBox.Items.Add(value);
            DeveloperComboBox.Items.Add(value);
            CheckerComboBox.Items.Add(value);
            NormativeControlComboBox.Items.Add(value);
            ApproverComboBox.Items.Add(value);
            LiteraComboBox.Items.Add(value);
            InvNumbOriginComboBox.Items.Add(value);
            ReplacedInvNumbComboBox.Items.Add(value);
            InvNumbDuplComboBox.Items.Add(value);
            ReferenceNumbComboBox.Items.Add(value);
            PrimaryApplicationComboBox.Items.Add(value);
        }

        private void openXltxPath_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = openFileDialog1.ShowDialog();
            if (!(DialogResult == DialogResult.OK))
                return;

            excelTemplateTextBox.Text = openFileDialog1.FileName;

        }
    }
}
