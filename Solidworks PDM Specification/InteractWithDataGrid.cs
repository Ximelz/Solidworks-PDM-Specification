using System.Collections.Generic;
using System.Windows.Forms;

namespace Solidworks_PDM_Specification
{
    internal class InteractWithDataGrid
    {
        public InteractWithDataGrid(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
        }
        private Dictionary<string, List<Element>> nameSections = new Dictionary<string, List<Element>>()
            {
                {"Документация", new List<Element>()}, {"Комплексы", new List<Element>()},
                {"Сборочные единицы", new List<Element>()}, {"Детали", new List<Element>()},
                {"Стандартные изделия", new List<Element>()}, {"Прочие изделия", new List<Element>()},
                {"Материалы", new List<Element>()}, {"Комплекты", new List<Element>()}
            };
        private DataGridView dataGridView;

        public DataGridView UpdateDataGrid(List<Element> elements, ref Dictionary<string, int> idSection)
        {
            dataGridView.Rows.Clear();
            int count = 0;
            foreach (Element element in elements)
                if (nameSections.ContainsKey(element.Section))
                {
                    nameSections[element.Section].Add(element);
                    count++;
                }
            AddRows(ref idSection);
            return dataGridView;
        }

        private void AddRows(ref Dictionary<string, int> idSection)
        {
            int i = 0;
            foreach (KeyValuePair<string, List<Element>> keyValuePair in nameSections)
            {
                idSection[keyValuePair.Key] = dataGridView.Rows.Count - 1;
                dataGridView.Rows.Add("", "", "", keyValuePair.Key);
                if (keyValuePair.Value.Count > 0)
                {
                    foreach (Element element in keyValuePair.Value)
                        AddNewRow(element);
                }
                i++;
            }
        }

        private void AddNewRow(Element element)
        {
            dataGridView.Rows.Add(element.DrawingPaperSize, element.Zone, element.Designation, 
                                    element.Name, element.Count.ToString(), element.Note, element.nameFlag);
        }

        public List<Element> GetNewListElements(ref Dictionary<string, int> idSection)
        {
            List<Element> elements = new List<Element>();
            int[] sections = new int[8];
            string[] nameSections = new string[8];
            int i = 0;
            foreach (KeyValuePair<string, int> keyValuePair in idSection)
            {
                sections[i] = keyValuePair.Value;
                nameSections[i] = keyValuePair.Key;
                i++;
            }
            i = 0;
            int rowsCount = dataGridView.Rows.Count - 2;
            for (int j = 0; j < rowsCount; j++)
                if (i < 8)
                {
                    if (j < sections[i])
                    {
                        AddElementFromDataGrid(ref elements, j, nameSections[i - 1]);
                    }
                    else
                    {
                        i++;
                    }
                }

            return elements;
        }
        private void AddElementFromDataGrid(ref List<Element> Elements, int i, string section)
        {
            int currentIndex = Elements.Count;
            Elements.Add(new Element());
            Elements[currentIndex].DrawingPaperSize = dataGridView.Rows[i].Cells[0].Value.ToString();
            Elements[currentIndex].Zone = dataGridView.Rows[i].Cells[1].Value.ToString();
            Elements[currentIndex].Designation = dataGridView.Rows[i].Cells[2].Value.ToString();
            Elements[currentIndex].Name = dataGridView.Rows[i].Cells[3].Value.ToString();
            if (dataGridView.Rows[i].Cells[4].Value != null)
            {
                if (int.TryParse(dataGridView.Rows[i].Cells[4].Value.ToString(), out int count))
                    Elements[currentIndex].Count = count;
                else
                    Elements[currentIndex].Count = 0;
            }
            else
                Elements[currentIndex].Count = 0;

            Elements[currentIndex].Note = dataGridView.Rows[i].Cells[5].Value.ToString();
            Elements[currentIndex].nameFlag = (bool)dataGridView.Rows[i].Cells[6].Value;
            Elements[currentIndex].Section = section;
        }

        public DataGridView AddElementToDataGrid(int index, ref Dictionary<string, int> idSection)
        {
            dataGridView.Rows.InsertCopy(index, index + 1);
            dataGridView.Rows[index + 1].SetValues("", "", "", "", "", "", false);
            if (idSection["Документация"] > index)
                idSection["Документация"]++;
            if (idSection["Комплексы"] > index)
                idSection["Комплексы"]++;
            if (idSection["Сборочные единицы"] > index)
                idSection["Сборочные единицы"]++;
            if (idSection["Детали"] > index)
                idSection["Детали"]++;
            if (idSection["Стандартные изделия"] > index)
                idSection["Стандартные изделия"]++;
            if (idSection["Прочие изделия"] > index)
                idSection["Прочие изделия"]++;
            if (idSection["Материалы"] > index)
                idSection["Материалы"]++;
            if (idSection["Комплекты"] > index)
                idSection["Комплекты"]++;
            return dataGridView;
        }
    }
}
