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
    public partial class SolidWorksPDMCreateForm : Form
    {
        public SolidWorksPDMCreateForm(IEdmVault5 vault)
        {
            InitializeComponent();
            this.vault = vault;
        }
        
        private string viewVault;
        private IEdmVault5 vault;
        public string path;

        private void SolidWorksPDMCreateForm_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    vault = new EdmVault5();
            //    IEdmVault8 vault1 = (IEdmVault8)vault;
            //    EdmViewInfo[] Views;

            //    vault1.GetVaultViews(out Views, false);
            //    bool flag = false;
            //    foreach (EdmViewInfo View in Views)
            //        if (View.mbsVaultName == viewVault)
            //            flag = true;

            //    if (flag)
            //        vault.LoginAuto(viewVault, this.Handle.ToInt32());
            //    else
            //    {
            //        MessageBox.Show("Указанное в настройках хранилище отсутствует");
            //        Dispose();
            //    }

            //}
            //catch (System.Runtime.InteropServices.COMException ex)
            //{
            //    MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.DialogResult dialogResult = default(System.Windows.Forms.DialogResult);
                dialogResult = openFileDialog1.ShowDialog();

                if((DialogResult == System.Windows.Forms.DialogResult.OK))
                    return;

                OpenFilePathTextBox.Text = openFileDialog1.FileName;
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
            path = OpenFilePathTextBox.Text;
            Close();
        }
        

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        
    }
}
