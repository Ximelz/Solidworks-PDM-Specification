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
    public partial class StampSettingsForm : Form
    {
        public DrawingStamp stemp;
        public StampSettingsForm(DrawingStamp stemp)
        {
            InitializeComponent();
            this.stemp = stemp;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            stemp.Name = NameTextBox.Text;
            stemp.Designation = DesignationTextBox.Text;
            stemp.Developer = DeveloperTextBox.Text;
            stemp.Checker = CheckerTextBox.Text;
            stemp.NormativeControl = NormativeControlTextBox.Text;
            stemp.Approver = ApproverTextBox.Text;
            stemp.Litera = LiteraTextBox.Text;
            stemp.InvNumbOrigin = InvNumbOriginTextBox.Text;
            stemp.ReplacedInvNumb = ReplacedInvNumbTextBox.Text;
            stemp.InvNumbDupl = InvNumbDuplTextBox.Text;
            stemp.ReferenceNumb = ReferenceNumbTextBox.Text;
            stemp.PrimaryApplication = PrimaryApplicationTextBox.Text;
            Close();
        }

        private void StampSettingsForm_Load(object sender, EventArgs e)
        {
            NameTextBox.Text = stemp.Name;
            DesignationTextBox.Text = stemp.Designation;
            DeveloperTextBox.Text = stemp.Developer;
            CheckerTextBox.Text = stemp.Checker;
            NormativeControlTextBox.Text = stemp.NormativeControl;
            ApproverTextBox.Text = stemp.Approver;
            LiteraTextBox.Text = stemp.Litera;
            InvNumbOriginTextBox.Text = stemp.InvNumbOrigin;
            ReplacedInvNumbTextBox.Text = stemp.ReplacedInvNumb;
            InvNumbDuplTextBox.Text = stemp.InvNumbDupl;
            ReferenceNumbTextBox.Text = stemp.ReferenceNumb;
            PrimaryApplicationTextBox.Text = stemp.PrimaryApplication;
        }
    }
}
