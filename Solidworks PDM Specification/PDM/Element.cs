using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidworks_PDM_Specification
{
    /// <summary>
    /// Класс хранящий информацию об объекте.
    /// </summary>
    public class Element
    {
        public string Name { set; get; }                                       //Наименование
        public string Designation { set; get; }                                //Обозначение
        public string DrawingPaperSize { set; get; }                           //Формат размера чертежа (А3, А4 и т.д.)
        public string Section { set; get; }                                    //Раздел спецификации (Сборочная единица, стандартные изделия и т.д.)
        public string Note { set; get; }                                       //Примечание
        public string Zone { set; get; }                                       //Зона
        public string FilePath { set; get; }                                   //Путь к файлу текущего элемента
    }
}
