using System.Collections.Generic;
using System.IO;

namespace Solidworks_PDM_Specification
{
    /// <summary>
    /// Класс хранящий изначальные настройки программы.
    /// </summary>
    public class Settings
    {
        public Settings(string currentPath)
        {
            ComparsionGlobalVariable = new Dictionary<string, string>();
            Vault = "";
            standartSettingsPath = currentPath + "\\SettingsStandart.xml";
            excelTemplate = currentPath + "\\Specification.xltx";
            InitialDictionary();
        }

        public string Vault { get; set; }                                   //Переменная хранящая исходное хранилище
        public Dictionary<string, string> ComparsionGlobalVariable;         //Сопоставление переменных из программы глобальных переменным SolidWorks PDM
        public string excelTemplate { set; get; }
        public string standartSettingsPath { set; get; }

        private void InitialDictionary()
        {
            ComparsionGlobalVariable.Add("Name", "");
            ComparsionGlobalVariable.Add("Designation", "");
            ComparsionGlobalVariable.Add("DrawingPaperSize", "");
            ComparsionGlobalVariable.Add("Section", "");
            ComparsionGlobalVariable.Add("Note", "");
            ComparsionGlobalVariable.Add("Zone", "");
            ComparsionGlobalVariable.Add("Developer", "");
            ComparsionGlobalVariable.Add("Checker", "");
            ComparsionGlobalVariable.Add("NormativeControl", "");
            ComparsionGlobalVariable.Add("Approver", "");
            ComparsionGlobalVariable.Add("Litera", "");
            ComparsionGlobalVariable.Add("InvNumbOrigin", "");
            ComparsionGlobalVariable.Add("ReplacedInvNumb", "");
            ComparsionGlobalVariable.Add("InvNumbDupl", "");
            ComparsionGlobalVariable.Add("ReferenceNumb", "");
            ComparsionGlobalVariable.Add("PrimaryApplication", "");
        }

        public void ResetSetings()
        {
            ComparsionGlobalVariable = new Dictionary<string, string>();
            XML_Convert xml = new XML_Convert();
            Settings settings;
            xml.Import(out settings, standartSettingsPath);
            this.Vault = settings.Vault;
            if (File.Exists(settings.excelTemplate))
                this.excelTemplate = settings.excelTemplate;
            this.ComparsionGlobalVariable = settings.ComparsionGlobalVariable;
        }
    }
}
