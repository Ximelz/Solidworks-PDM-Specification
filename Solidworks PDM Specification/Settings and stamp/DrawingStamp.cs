using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidworks_PDM_Specification
{
    /// <summary>
    /// Класс хранящий данные о штампе основной надписи.
    /// </summary>
    public class DrawingStamp : Element
    {

        private string developer = "";               //Разработал
        private string checker = "";                 //Проверил
        private string normativeControl = "";        //Нормоконтороль
        private string approver = "";                //Утвердил
        public string Litera = "";                   //Литера

        public string InvNumbOrigin = "";            //Инвентарный номер подлинника по ГОСТ 2.501
        public string ReplacedInvNumb = "";          //Инвентарный номер подлинника, взамен которого выпущен данный подлинник по ГОСТ 2.503
        public string InvNumbDupl = "";              //Инвентарный номер дубликата по ГОСТ 2.502;

        public string ReferenceNumb = "";            //Обозначение документа, взамен или на основании которого выпущен данный документ;
        public string PrimaryApplication = "";       //Первичное применение

        public DateTime DateDeveloper;              //Дата разработки
        public DateTime DateChecker;                //Дата проверки
        public DateTime DateNormativeControl;       //Дата проверки нормоконтролем
        public DateTime DateApprover;               //Дата утверждения

        public string Developer
        {
            set
            {
                if (DateDeveloper == null)
                    DateDeveloper = DateTime.Now;
                developer = value;
            }
            get
            {
                return developer;
            }
        }

        public string Checker
        {
            set
            {
                if (DateChecker == null)
                    DateChecker = DateTime.Now;
                checker = value;
            }
            get
            {
                return checker;
            }
        }

        public string NormativeControl
        {
            set
            {
                if (DateNormativeControl == null)
                    DateNormativeControl = DateTime.Now;
                normativeControl = value;
            }
            get
            {
                return normativeControl;
            }
        }

        public string Approver
        {
            set
            {
                if (DateApprover == null)
                    DateApprover = DateTime.Now;
                approver = value;
            }
            get
            {
                return approver;
            }
        }
    }
    
}
