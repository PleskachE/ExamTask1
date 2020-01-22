using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "dictionaries.xml";
            AllSections allSections = new AllSections();
            MenuSelection menuSelection = new MenuSelection();
            allSections.DeserializeXml(path);
            int choiceStartMenu = 1;
            while (choiceStartMenu != 0)
            {
                choiceStartMenu = menuSelection.InputChoiceAndPrintMessage(2, "Выберите действие:\n1 - Перевод слов." +
                    "\n2 - Редактирование словарей.\n0 - Выход");
                if (choiceStartMenu == 0)
                    break;
                else
                    allSections = new Menu().MainMenu(choiceStartMenu, allSections);
            }
            allSections.SerializeXml(path);
        }
    }
}
