using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solidworks_PDM_Specification
{
    public partial class AddSection : Form
    {
        public bool closeFlag = true;
        public string section;
        public AddSection()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            closeFlag = false;
            section = sectionTextBox.Text;
            Close();
        }

        private void AddSection_Load(object sender, EventArgs e)
        {

        }
    }
}
