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
            this.vault = (IEdmVault7)vault;
        }
        
        private IEdmVault7 vault;
        public string path;
        public bool closeFlag = true;
        public string configuration;
        
        
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(openFileDialog1.ShowDialog() != DialogResult.OK)
                    return;
                if (openFileDialog1.FileName.Substring(openFileDialog1.FileName.Length - 7) != ".SLDASM")
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
            IEdmFolder5 ppoRetParentFolder;
            EdmStrLst5 cfgList = default(EdmStrLst5);
            IEdmPos5 pos = default(IEdmPos5);
            string cfgName = null;
            file = (IEdmFile17)vault.GetFileFromPath(OpenFilePathTextBox.Text, out ppoRetParentFolder);
            cfgList = file.GetConfigurations();
            pos = cfgList.GetHeadPosition();
            while (!pos.IsNull)
            {
                cfgName = cfgList.GetNext(pos);
                if (cfgName != "@")
                    ConfigurationComboBox.Items.Add(cfgName);
            }
            ConfigurationComboBox.Text = ConfigurationComboBox.Items[0].ToString();
        }

        private void ConfigurationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
