using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EPDM.Interop.epdm;

namespace Solidworks_PDM_Specification
{
    public partial class ChangeVault : Form
    {
        private EdmViewInfo[] Views;
        private IEdmVault5 vault;
        public bool closeFlag = false;
        public ChangeVault(EdmViewInfo[] Views,ref IEdmVault5 vault)
        {
            InitializeComponent();
            this.Views = Views;
            this.vault = vault;
        }

        private void ChangeVault_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (EdmViewInfo View in Views)
                {
                    VaultsComboBox.Items.Add(View.mbsVaultName);
                }

                if (VaultsComboBox.Items.Count > 0)
                {
                    VaultsComboBox.Text = (string) VaultsComboBox.Items[0];
                }
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

        private void OKbutton_Click(object sender, EventArgs e)
        {
            if (vault == null)
                vault = new EdmVault5();
            if (!vault.IsLoggedIn)
            {
                vault.LoginAuto(VaultsComboBox.Text, this.Handle.ToInt32());
            }
            Dispose();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            closeFlag = true;
            Close();
        }
        
    }
}
