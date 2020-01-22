using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{
    public class Menu
    {
        public Menu() { }
      
        public AllSections MainMenu(int choiceStartMenu, AllSections allSections)
        {
            if (choiceStartMenu == -1)
                return allSections;
            int indexSection = ChoiceSection(allSections);
            if(indexSection == -1)
                return allSections; 
            else if (choiceStartMenu == 2)
            {
                Editor editor = new Editor(allSections);
                allSections = editor.EditorSection(indexSection);
            }
            else
            { 
                string result;
                Console.WriteLine("Введите слово которое хотите перевести.");
                result = new Writer().CheckInput();
                result = new Translator().SplittingPhraseIntoWords(result, allSections.sections.ElementAt(indexSection));
                Console.WriteLine(result);
                ChoicheInputFile(result);
            }
            return allSections;
        }

        private int ChoiceSection(AllSections allSections)
        {
            if (allSections.sections.Count == 0)
            {
                Console.WriteLine("В приложении нет ни одного словаря! Добавьте самостоятельно");
                return 2;
            }
            Console.WriteLine("Выберите словарь для работы");
            for (int i = 0; i < allSections.sections.Count; i++)
                Console.WriteLine((i + 1) + " - " + allSections.sections.ElementAt(i).name);
            Console.WriteLine("0 - назад");
            int choice = new MenuSelection().InputChoice(allSections.sections.Count);
            return choice - 1;
        }

        private void ChoicheInputFile(string result)
        {
            int choiceInputFile = new MenuSelection().InputChoiceAndPrintMessage(1, "Хотите сохранить результат перевода в отдельном файле?\n" +
                "1 - Да.\n0 - Нет.");
            if (choiceInputFile == 1)
            {
                try
                {
                    using (var stream = new FileStream("text.txt", FileMode.Truncate))
                    {
                        InputFile(result, stream);
                    }
                }
                catch
                {
                    using (var stream = new FileStream("text.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                    {
                        InputFile(result, stream);
                    }
                }
            }
        }

        private void InputFile(string result, FileStream stream)
        { 
            byte[] arr = Encoding.Default.GetBytes(result);
            stream.Write(arr, 0, arr.Length);
        }
    }
}
