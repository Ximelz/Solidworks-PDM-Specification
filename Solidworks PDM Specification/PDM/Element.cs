namespace Solidworks_PDM_Specification
{
    /// <summary>
    /// Класс хранящий информацию об объекте.
    /// </summary>
    public class Element
    {
        public Element()
        {
            Name = "";
            Designation = "";
            DrawingPaperSize = "";
            Section = "";
            Note = "";
            Zone = "";
            Count = 1;
            nameFlag = false;
        }
        private string designation;
        private string name;
        public string Name 
        {
            set
            {
                name = value;
                DesName[0] = value;
            }
            get
            {
                return name;
            }
        }                                       //Наименование
        public string Designation 
        {
            set
            {
                designation = value;
                DesName[1] = value;
            }
            get
            {
                return designation;
            }
        }                                //Обозначение
        public string DrawingPaperSize { set; get; }                           //Формат размера чертежа (А3, А4 и т.д.)
        public string Section { set; get; }                                    //Раздел спецификации (Сборочная единица, стандартные изделия и т.д.)
        public string Note { set; get; }                                       //Примечание
        public string Zone { set; get; }                                       //Зона
        public int Count { set; get; }                                         //Количество элементов
        public string[] DesName = new string[2];
        public bool nameFlag { set; get; }
    }
}
