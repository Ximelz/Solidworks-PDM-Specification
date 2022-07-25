using System.Collections.Generic;
using System.IO;

namespace Solidworks_PDM_Specification
{
    /// <summary>
    /// Класс хранящий изначальные настройки программы.
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="standartDirectory">Исходная директория программы.</param>
        public Settings(string standartDirectory)
        {
            GetSetingsPath(standartDirectory);
            
            if (!File.Exists(currentPath))
            {
                settings = new SettingValues(standartDirectory);
                xml.Export(settings, currentPath);
            }
            else
                xml.Import(out settings, currentPath);

            if (!File.Exists(settings.excelTemplate))
                settings.excelTemplate = standartDirectory + "\\Specification.xltx";
        }

        #region Поля и свойства
        /// <summary>
        /// Исходное хранилище.
        /// </summary>
        public string Vault
        {
            get
            {
                return settings.Vault;
            }
            set
            {
                settings.Vault = value;
            }
        }

        /// <summary>
        /// Словарь, сохраняющий сопоставленные переменные из программы глобальным переменным из SolidWorks PDM.
        /// </summary>
        public Dictionary<string, string> ComparsionGlobalVariable
        {
            get
            {
                return settings.ComparsionGlobalVariable;
            }
            set
            {
                settings.ComparsionGlobalVariable = value;
            }
        }         

        /// <summary>
        /// Путь к шаблону Excel.
        /// </summary>
        public string excelTemplate 
        {
            get
            {
                return settings.excelTemplate;
            }
            set
            {
                settings.excelTemplate = value; 
            }
        }

        /// <summary>
        /// Путь к файлу с настройками.
        /// </summary>
        public string currentPath { get; private set; }

        /// <summary>
        /// Путь к файлу, хранящий путь к настройкам.
        /// </summary>
        private string pathWithSettings;

        /// <summary>
        /// Объект, хранящий настройки программы.
        /// </summary>
        private SettingValues settings;

        /// <summary>
        /// Объект, необходимый для сохранения/загрузки настроек в/из файла.
        /// </summary>
        private readonly XML_Convert xml = new XML_Convert();

        //public string standartSettingsPath
        //{
        //    get
        //    {
        //        return settings.standartSettingsPath;
        //    }
        //    set
        //    {
        //        settings.standartSettingsPath = value;
        //    }
        //}
        #endregion

        #region Методы
        /// <summary>
        /// Метод получения пути к файлу настроек.
        /// </summary>
        /// <param name="directory">Исходная директория программы.</param>
        private void GetSetingsPath(string directory)
        {
            pathWithSettings = directory + "\\PathWithSettings.xml";

            if (File.Exists(pathWithSettings))
            {
                xml.Import(out string path);
                currentPath = path;
                return;
            }
            currentPath = directory + "\\Settings.xml";
            xml.Export(currentPath);
        }

        /// <summary>
        /// Сброс настроек.
        /// </summary>
        public void ResetSetings()
        {
            xml.Import(out settings, currentPath);
        }
    
        /// <summary>
        /// Сохранение настроек.
        /// </summary>
        /// <param name="path">Путь к файлу настроек.</param>
        public void SaveSettings(string path)
        {
            currentPath = path;
            xml.Export(currentPath);
            xml.Export(settings, currentPath);
        }
        #endregion
    }
}