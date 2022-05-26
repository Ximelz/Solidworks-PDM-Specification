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

        public SpecificationCreateForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            settings = new Settings();
            stamp = new DrawingStamp();
            xml = new XML_Convert();

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

        private void CreateSpecification_Click(object sender, EventArgs e)
        {
            string path;
            IEdmVault5 vault = LogginInVault();
            SolidWorksPDMCreateForm form = new SolidWorksPDMCreateForm(vault);
            form.ShowDialog();
            path = form.path;
            ReferenceFiles refFiles = new ReferenceFiles(path, settings, stamp, vault);
            stamp = refFiles.stamp;
            Elements = refFiles.GetListElements();
            form.Dispose();
        }

        private void StampButton_Click(object sender, EventArgs e)
        {
            StampSettingsForm form = new StampSettingsForm(stamp);
            form.ShowDialog();
            stamp = form.stemp;
            form.Dispose();
        }

        private void UpdateSpecificationButton_Click(object sender, EventArgs e)
        {
            IEdmVault5 vault = LogginInVault();
            ReferenceFiles refFiles = new ReferenceFiles(stamp.FilePath, settings, stamp, vault);
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
    }
}
