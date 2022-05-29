using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EPDM.Interop.epdm;

namespace Solidworks_PDM_Specification
{
    public partial class SolidWorksPDMForm : Form
    {
        public SolidWorksPDMForm(IEdmVault5 vault)
        {
            InitializeComponent();
            this.vault = vault;
        }
        
        private string viewVault;
        private IEdmVault5 vault;
        public string path;
        public bool closeFlag = true;
        public string configuration;
        
        
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.DialogResult dialogResult = default(System.Windows.Forms.DialogResult);
                dialogResult = openFileDialog1.ShowDialog();

                if((DialogResult == System.Windows.Forms.DialogResult.OK))
                    return;

                if (OpenFilePathTextBox.Text.Substring(openFileDialog1.FileName.Length - 7) != ".SLDASM")
                {
                    MessageBox.Show("Не был выбран файл сборки. Выберите заново!");
                    return;
                }
                OpenFilePathTextBox.Text = openFileDialog1.FileName;

                GetConfigurationsFile();
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            configuration = ConfigurationComboBox.Text;
            path = OpenFilePathTextBox.Text;
            closeFlag = false;
            Close();
        }
        

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void SolidWorksPDMCreateForm_Load(object sender, EventArgs e)
        {

        }

        private void GetConfigurationsFile()
        {
            IEdmFile17 file;
            IEdmVault7 vault2 = (IEdmVault7) vault;
            IEdmFolder5 ppoRetParentFolder;
            file = (IEdmFile17)vault2.GetFileFromPath(OpenFilePathTextBox.Text, out ppoRetParentFolder);
            EdmStrLst5 cfgList = default(EdmStrLst5);
            cfgList = file.GetConfigurations();

            IEdmPos5 pos = default(IEdmPos5);
            pos = cfgList.GetHeadPosition();
            string cfgName = null;
            while (!pos.IsNull)
            {
                cfgName = cfgList.GetNext(pos);
                ConfigurationComboBox.Items.Add(cfgName);
            }
            ConfigurationComboBox.Text = ConfigurationComboBox.Items[0].ToString();
        }

        private void ConfigurationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
