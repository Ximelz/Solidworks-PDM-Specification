using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Aspose.Cells;

namespace Solidworks_PDM_Specification
{
    internal class ExcelSpecification
    {
        Settings settings;
        DrawingStamp stamp;
        public ExcelSpecification(Settings settings, DrawingStamp stamp)
        {
            this.settings = settings;
            this.stamp = stamp;
        }

        private Dictionary<string, List<Element>> nameSections = new Dictionary<string, List<Element>>()
            {
                {"Документация", new List<Element>()}, {"Комплексы", new List<Element>()},
                {"Сборочные единицы", new List<Element>()}, {"Детали", new List<Element>()},
                {"Стандартные изделия", new List<Element>()}, {"Прочие изделия", new List<Element>()},
                {"Материалы", new List<Element>()}, {"Комплекты", new List<Element>()}
            };

        private Worksheet ws;
        private Cell cell;
        private int cellIndex;
        private int position;
        private int maxCellIndex;
        private int Lists;
        private WorksheetCollection wc;
        private int listCount;


        public void exportToExcel(List<Element> elements, string saveFileName, string addFileFormat)
        {
            foreach (Element element in elements)
                if (nameSections.ContainsKey(element.Section))
                    nameSections[element.Section].Add(element);

            nameSections["Документация"] = SortList(nameSections["Документация"], "Документация");
            nameSections["Комплексы"] = SortList(nameSections["Комплексы"], "Комплексы");
            nameSections["Сборочные единицы"] = SortList(nameSections["Сборочные единицы"], "Сборочные единицы");
            nameSections["Детали"] = SortList(nameSections["Детали"], "Детали");
            nameSections["Стандартные изделия"] = SortList(nameSections["Стандартные изделия"], "Стандартные изделия");
            nameSections["Прочие изделия"] = SortList(nameSections["Прочие изделия"], "Прочие изделия");
            nameSections["Материалы"] = SortList(nameSections["Материалы"], "Материалы");
            nameSections["Комплекты"] = SortList(nameSections["Комплекты"], "Комплекты");

            using (var workbook = new Workbook(settings.excelTemplate))
            {
                ws = workbook.Worksheets["Specification_sheet_1"];
                cellIndex = 5;
                position = 1;
                maxCellIndex = 61;
                Lists = 1;
                //SetStamp(ws, Lists);
                SetStamp();
                foreach (KeyValuePair<string, List<Element>> keyValuePair in nameSections)
                {
                    if (keyValuePair.Value.Count > 0)
                    {
                        if (cellIndex + 6 > maxCellIndex)
                        {
                            wc = workbook.Worksheets;
                            Lists++;
                            wc.Add("Specification_sheet_" + (Lists + 1));
                            maxCellIndex = 67;
                            wc[wc.Count - 1].Copy(wc[wc.Count - 2]);
                            ws = workbook.Worksheets["Specification_sheet_" + Lists];
                            cellIndex = 7;
                            //SetStamp(ws, Lists);
                            SetStamp();
                        }
                        cellIndex += 2;
                        cell = ws.Cells["AI" + cellIndex];
                        cell.PutValue(keyValuePair.Key);
                        Style style = cell.GetStyle();
                        style.HorizontalAlignment = TextAlignmentType.Center;
                        style.Font.Underline = FontUnderlineType.Single;
                        style.Font.IsBold = true;
                        cell.SetStyle(style);
                        cellIndex += 4;
                        listCount = keyValuePair.Value.Count;
                        //AddElementsOnSpecificationForm(ref ws, ref cellIndex, ref maxCellIndex, ref listCount, ref position,
                        //                                keyValuePair.Value, ref Lists, workbook);
                        AddElementsOnSpecificationForm(keyValuePair.Value, workbook);
                    }
                }
                ws = workbook.Worksheets["Specification_sheet_1"];
                cell = ws.Cells["BH67"];
                cell.PutValue(Lists);
                wc = workbook.Worksheets;
                wc.RemoveAt(wc.Count - 1);
                try
                {
                    workbook.Save(saveFileName + addFileFormat);
                    Process.Start(saveFileName + addFileFormat);
                }
                catch
                {
                    MessageBox.Show("Файл открыт в другой программе");
                }
            }
        }
        //private void AddElementsOnSpecificationForm(ref Worksheet worksheet, ref int cellIndex, ref int maxIndex, ref int listCount, ref int position, List<Element> elements, ref int Lists, Workbook workbook)
        private void AddElementsOnSpecificationForm(List<Element> elements, Workbook workbook)
        {
            int i = 0;
            while (listCount > i)
            {
                if (elements[i].Count / 23 + (elements[i].Count % 23 != 0 ? 1 : 0) > (maxCellIndex - cellIndex) / 2)
                {
                    WorksheetCollection wc = workbook.Worksheets;
                    Lists++;
                    wc.Add("Specification_sheet_" + (Lists + 1));
                    maxCellIndex = 67;
                    wc[wc.Count - 1].Copy(wc[wc.Count - 2]);
                    ws = workbook.Worksheets["Specification_sheet_" + Lists];
                    cellIndex = 7;
                    SetStamp();
                    //SetStamp(ws, Lists);
                }
                cell = ws.Cells["E" + cellIndex];
                cell.PutValue(elements[i].DrawingPaperSize);

                cell = ws.Cells["G" + cellIndex];
                cell.PutValue(elements[i].Zone);

                cell = ws.Cells["I" + cellIndex];
                cell.PutValue(position.ToString());

                cell = ws.Cells["L" + cellIndex];
                cell.PutValue(elements[i].Designation);

                cell = ws.Cells["BD" + cellIndex];
                cell.PutValue(elements[i].Count.ToString());

                cell = ws.Cells["BG" + cellIndex];
                cell.PutValue(elements[i].Note);

                cell = ws.Cells["AI" + cellIndex];
                if (elements[i].Name.Length > 23)
                    //SplitDesignation(ws, ref cellIndex, elements[i].Name, cell, elements[i].nameFlag);
                    SplitDesignation(elements[i].Name, elements[i].nameFlag);
                else
                {
                    cell.PutValue(elements[i].Name);
                    if (elements[i].nameFlag)
                    {
                        Style style = cell.GetStyle();
                        style.Pattern = BackgroundType.Solid;
                        style.ForegroundColor = System.Drawing.Color.Red;
                        cell.SetStyle(style);
                    }
                }

                position++;
                i++;
                cellIndex += 2;
            }
        }
        //private void SplitDesignation(Worksheet worksheet, ref int cellIndex, string designation, Cell cell, bool nameFlag)
        private void SplitDesignation(string designation, bool nameFlag)
        {
            string[] designationSplit = designation.Split();
            int designationSplitLength = designationSplit.Length;
            designation = designationSplit[0];
            if (designationSplitLength == 1)
            {
                cell.PutValue(designation);
                if (nameFlag)
                {
                    Style style = cell.GetStyle();
                    style.Pattern = BackgroundType.Solid;
                    style.ForegroundColor = System.Drawing.Color.Red;
                    cell.SetStyle(style);
                }
                cell = ws.Cells["AI" + cellIndex];
                return;
            }
            for (int i = 1; i < designationSplitLength; i++)
            {
                if (designationSplit[i].Length + designation.Length + 1 < 23)
                {
                    designation += " " + designationSplit[i];
                    if (i + 1 == designationSplitLength)
                    {
                        cell.PutValue(designation);
                        if (nameFlag)
                        {
                            Style style = cell.GetStyle();
                            style.Pattern = BackgroundType.Solid;
                            style.ForegroundColor = System.Drawing.Color.Red;
                            cell.SetStyle(style);
                        }
                        cell = ws.Cells["AI" + cellIndex];
                        break;
                    }
                }
                else
                {
                    cell.PutValue(designation);
                    if (nameFlag)
                    {
                        Style style = cell.GetStyle();
                        style.Pattern = BackgroundType.Solid;
                        style.ForegroundColor = System.Drawing.Color.Red;
                        cell.SetStyle(style);
                    }
                    cellIndex += 2;
                    cell = ws.Cells["AI" + cellIndex];
                    designation = designationSplit[i];
                    for (int j = i + 1; j < designationSplitLength; j++)
                        designation += " " + designationSplit[j];
                    SplitDesignation(designation, nameFlag);
                    break;
                }
            }
        }
        //private void SetStamp(Worksheet worksheet, int Lists)
        private void SetStamp()
        {
            cell = ws.Cells["C66"];
            cell.PutValue(stamp.InvNumbOrigin);

            cell = ws.Cells["C52"];
            cell.PutValue(stamp.ReferenceNumb);

            cell = ws.Cells["C37"];
            cell.PutValue(stamp.InvNumbDupl);

            if (Lists == 1)
            {
                cell = ws.Cells["BC67"];
                cell.PutValue(1);

                cell = ws.Cells["K66"];
                cell.PutValue(stamp.Developer);
                cell = ws.Cells["W66"];
                if (stamp.DateDeveloper.ToString("dd.MM.yyyy") != "01.01.0001")
                    cell.PutValue(stamp.DateDeveloper.ToString("dd.MM.yyyy"));

                cell = ws.Cells["K67"];
                cell.PutValue(stamp.Checker);
                cell = ws.Cells["W67"];
                if (stamp.DateChecker.ToString("dd.MM.yyyy") != "01.01.0001")
                    cell.PutValue(stamp.DateChecker.ToString("dd.MM.yyyy"));

                cell = ws.Cells["K69"];
                cell.PutValue(stamp.NormativeControl);
                cell = ws.Cells["W69"];
                if (stamp.DateNormativeControl.ToString("dd.MM.yyyy") != "01.01.0001")
                    cell.PutValue(stamp.DateNormativeControl.ToString("dd.MM.yyyy"));

                cell = ws.Cells["K70"];
                cell.PutValue(stamp.Approver);
                cell = ws.Cells["W70"];
                if (stamp.DateApprover.ToString("dd.MM.yyyy") != "01.01.0001")
                    cell.PutValue(stamp.DateApprover.ToString("dd.MM.yyyy"));

                cell = ws.Cells["Z66"];
                cell.PutValue(stamp.Name);

                cell = ws.Cells["Z63"];
                cell.PutValue(stamp.Designation);

                cell = ws.Cells["AY67"];
                cell.PutValue(stamp.Litera);

                cell = ws.Cells["AW68"];
                cell.PutValue("АО НИИТМ");
            }
            else
            {
                cell = ws.Cells["Z69"];
                cell.PutValue(stamp.Designation);

                cell = ws.Cells["BK70"];
                cell.PutValue(Lists);
            }
        }

        private List<Element> SortList(List<Element> elements, string section)
        {
            List<Element> resultElements = new List<Element>();
            int index;
            if (section == "Детали" || section == "Сборочные единицы")
                index = 1;
            else
                index = 0;
            foreach (Element element in elements)
            {
                int resultElementsCount = resultElements.Count;
                int currentIndex = 0;
                bool flag = false;
                for (int i = 0; i < resultElementsCount; i++)
                    if (element.DesName[index].Equals(resultElements[i].DesName[index]) || ComparsionStrings(element.DesName[index], resultElements[i].DesName[index]))
                    {
                        flag = true;
                        currentIndex = i;
                        break;
                    }

                if (flag && resultElementsCount > 0)
                {
                    resultElements = AddElementInMidOfList(resultElements, element, currentIndex, resultElementsCount);
                }
                else
                    resultElements.Add(element);
            }
            return resultElements;
        }
        private List<Element> AddElementInMidOfList(List<Element> resultElements, Element element, int currentIndex, int resultElementsCount)
        {
            List<Element> tempElements = new List<Element>();
            int removeRangeCount = resultElementsCount - currentIndex;
            //if (resultElementsCount != 0)
            tempElements.AddRange(resultElements.GetRange(0, currentIndex));
            tempElements.Add(element);
            tempElements.AddRange(resultElements.GetRange(currentIndex, removeRangeCount));
            return tempElements;
        }
        private bool ComparsionStrings(string a, string b)
        {
            int minCountString = a.Length > b.Length ? b.Length : a.Length;

            for (int i = 0; i < minCountString; i++)
                if (a[i] < b[i])
                    return true;
                else if (a[i] > b[i])
                    return false;

            if (a.Length >= b.Length)
                return false;
            else
                return true;
        }
    }
}
