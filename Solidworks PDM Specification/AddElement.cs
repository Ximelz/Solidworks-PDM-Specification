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
    public partial class AddElement : Form
    {
        private List<string> sections;
        public Element element = new Element();
        public bool closeFlag = true;
        public AddElement(List<string> sections)
        {
            InitializeComponent();
            this.sections = sections;
        }

        private void AddElement_Load(object sender, EventArgs e)
        {
            foreach (string section in sections)
                sectionComboBox.Items.Add(section);
            sectionComboBox.Text = sections[0];
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(countTextBox.Text, out int elementCount))
            {
                MessageBox.Show("Значение поля \"Количество\" не является числом");
                return;
            }

            element.Name = nameTextBox.Text;
            element.Designation = designationTextBox.Text;
            element.Note = noteTextBox.Text;
            element.DrawingPaperSize = drawingPaperSizeTextBox.Text;
            element.Zone = zoneTextBox.Text;
            element.Count = elementCount;
            element.Section = sectionComboBox.Text;

            closeFlag = false;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
