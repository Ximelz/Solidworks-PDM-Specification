using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Solidworks_PDM_Specification
{
    internal class SettingValues
    {
        public SettingValues()
        {
            ComparsionGlobalVariable = new Dictionary<string, string>();
        }
        public SettingValues(string currentDirectory)
        {
            ComparsionGlobalVariable = new Dictionary<string, string>();
            InitialDictionary(currentDirectory);
        }

        /// <summary>
        /// Исходное хранилище.
        /// </summary>
        public string Vault { get; set; }

        /// <summary>
        /// Словарь, сохраняющий сопоставленные переменные из программы глобальным переменным из SolidWorks PDM.
        /// </summary>
        public Dictionary<string, string> ComparsionGlobalVariable { get; set; }

        /// <summary>
        /// Путь к шаблону Excel.
        /// </summary>
        public string excelTemplate { set; get; }
        //public string standartSettingsPath { set; get; }

        /// <summary>
        /// Инициализация настроек.
        /// </summary>
        /// <param name="currentDirectory">Указанная директория.</param>
        private void InitialDictionary(string currentDirectory)
        {
            Vault = "PDM";
            //standartSettingsPath = currentDirectory + "\\SettingsStandart.xml";
            excelTemplate = currentDirectory + "\\Specification.xltx";
            ComparsionGlobalVariable.Add("Name", "Наименование");
            ComparsionGlobalVariable.Add("Designation", "Обозначение");
            ComparsionGlobalVariable.Add("DrawingPaperSize", "Формат");
            ComparsionGlobalVariable.Add("Section", "сп_Раздел");
            ComparsionGlobalVariable.Add("Note", "Примечания");
            ComparsionGlobalVariable.Add("Zone", "сп_Зона");
            ComparsionGlobalVariable.Add("Developer", "п_Разраб");
            ComparsionGlobalVariable.Add("Checker", "п_Пров");
            ComparsionGlobalVariable.Add("NormativeControl", "п_Н_контр");
            ComparsionGlobalVariable.Add("Approver", "п_Утв");
            ComparsionGlobalVariable.Add("Litera", "Лит");
            ComparsionGlobalVariable.Add("InvNumbOrigin", "а_п_Инв_№_подл");
            ComparsionGlobalVariable.Add("ReplacedInvNumb", "а_Взам_Инв_№");
            ComparsionGlobalVariable.Add("InvNumbDupl", "а_Инв_№_дубл");
            ComparsionGlobalVariable.Add("ReferenceNumb", "а_Справ_№");
            ComparsionGlobalVariable.Add("PrimaryApplication", "Перв_Примен");
        }
    }
}
