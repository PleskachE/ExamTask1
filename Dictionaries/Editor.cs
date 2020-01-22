using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{
    public class Editor
    {
        public AllSections allSections { get; set; }

        public Editor(AllSections allSections) { this.allSections = allSections; }

        public AllSections EditorSection(int index)
        {
            Console.Clear();
            string message = "Выберите действие:\n1 - Добавить новый словарь.\n2 - Удалить этот словарь\n" +
                "3 - Перейти к редактору слов.\n0 - Назад.";
            int choice = -1;
            do
            {
                choice = new MenuSelection().InputChoiceAndPrintMessage(3, message);
                if (choice == 0)
                    return allSections;
                else if (choice == 1)
                {
                    AddSection();
                    break;
                }
                else if (choice == 2)
                {
                    DeleteSection(index);
                    break;
                }
                else if (choice == 3)
                    EditorWord(index);
            }
            while (choice != 0);
            return allSections;
        }

        private void EditorWord(int index)
        {
            Console.Clear();
            string message = "Выберите следующее действие:\n1 - Добавить новое слово и перевод к нему.\n" +
                "2 - Выбрать слово и удалить его из словаря.\n3 - Выбрать слово и заменить его в словаре\n" +
                "4 - Перейти к редактору переводов.\n0 - Назад.";
            int nextChoice = new MenuSelection().InputChoiceAndPrintMessage(4, message);
            if (nextChoice == 0)
                EditorSection(index);
            else if (nextChoice == 1)
                AddWord(index);
            else if (nextChoice == 2)
                DeleteWord(index);
            else if (nextChoice == 3)
                ReplacementWord(index);
            else if (nextChoice == 4)
                EditorTranslate(index);
        }

        private void EditorTranslate(int index)
        {
            Console.Clear();
            string message = "Выберите следующее действие:\n1 - Добавить перевод к слову.\n2 - Удалить перевод слова.\n" +
                "3 - Заменить перевод слова.\n0 - Назад.";
            int nextChoice = new MenuSelection().InputChoiceAndPrintMessage(3, message);
            if (nextChoice == 0)
                EditorWord(index);
            else if (nextChoice == 1)
                AddTranslate(index);
            else if (nextChoice == 2)
                DeleteTranslate(index);
            else if (nextChoice == 3)
                ReplacementTranslate(index);
        }

        private void AddSection()
        {
            Console.Clear();
            Console.WriteLine("Введите название для нового словаря");
            string name = new Writer().CheckInput();
            bool check = true;
            try
            {
                for (int i = 0; i < allSections.sections.Count; i++)
                {
                    if (allSections.sections.ElementAt(i).name == name)
                    {
                        Console.WriteLine("Этот словарь уже есть в приложении.");
                        check = false;
                        break;
                    }
                }
            }
            catch { }
            if (check == true)
            {
                allSections.sections.Add(new Section(name));
                Console.WriteLine("Новый словарь добавлен!");
            }
        }

        private void DeleteSection(int index)
        {
            allSections.sections.RemoveAt(index);
        }

        private void AddWord(int index)
        {
            Console.Clear();
            Console.WriteLine("Введите переводимое слово");
            string name = new Writer().CheckInput();
            Console.WriteLine("Введите его перевод.");
            string newString = new Writer().CheckInput();
            if (allSections.sections.ElementAt(index).WordSearch(name) == null)
            {
                allSections.sections.ElementAt(index).words.Add(new Word(name, newString));
                Console.WriteLine("Новое слово и его перевод добавлены!");
            }
            else
                Console.WriteLine("Данное слово уже есть в словаре. Добавьте его перевод.");
            allSections.sections.ElementAt(index).words.Sort();
        }

        private void DeleteWord(int index)
        {
            Console.Clear();
            Console.WriteLine("Введите слово которое хотите удалить!");
            Word deleteWord = allSections.sections.ElementAt(index).WordSearch(new Writer().CheckInput());
            if (deleteWord != null)
            {
                allSections.sections.ElementAt(index).words.Remove(deleteWord);
                Console.WriteLine("Удалено!");
            }
            else
                Console.WriteLine("Введённого слова нет в словаре."); 
        }

        private void AddTranslate(int index)
        {
            Console.Clear();
            int indexWord = SearchWordIndex(index);
            if (indexWord == -1)
            {
                Console.WriteLine("Данного слова нет в словаре. Попробуйте изменить запрос или добавить его в словарь.");
                return;
            }
            Console.WriteLine("Введите добавляемый вариант перевода.");
            string newString = new Writer().CheckInput();
            allSections.sections.ElementAt(index).words.ElementAt(indexWord).translations.Add(newString); 
        }

        private void DeleteTranslate(int index)
        {
            Console.Clear();
            int indexWord = SearchWordIndex(index);
            Console.WriteLine("Введите удаляемый вариант перевода.");
            string newString = new Writer().CheckInput();
            try
            {
                if (allSections.sections.ElementAt(index).words.ElementAt(indexWord).translations.Count > 1)
                    allSections.sections.ElementAt(index).words.ElementAt(indexWord).translations.Remove(newString);
                else
                {
                    Console.WriteLine("Данный перевод является единственным у этого слова и его нельзя удалить.");
                    Console.ReadLine();
                }
            }
            catch
            {
                Console.WriteLine("Выбранное слово не имеет введённого перевода.");
                Console.ReadLine();
            }
        }

        private void ReplacementWord(int index)
        {
            Console.Clear();
            int indexWord = SearchWordIndex(index);
            if(indexWord == -1)
            {
                Console.WriteLine("Введённого слова нет в словаре.");
                return;
            }
            Console.WriteLine("Введите слово для замены.");
            string newString = new Writer().CheckInput();
            allSections.sections.ElementAt(index).words.ElementAt(indexWord).name = newString;  
            allSections.sections.ElementAt(index).words.Sort();
        }

        private void ReplacementTranslate(int index)
        {
            Console.Clear();
            int indexWord = SearchWordIndex(index);
            if(indexWord == -1)
            {
                Console.WriteLine("Введённого слова нет в словаре.");
                return;
            }
            Console.WriteLine("Введите заменяемый вариант перевода.");
            string newString = new Writer().CheckInput();
            try { allSections.sections.ElementAt(index).words.ElementAt(indexWord).translations.Remove(newString); }
            catch { Console.WriteLine("Данного перевода нет в словаре."); }
            Console.WriteLine("Введите новый вариант перевода");
            string newTranslate = new Writer().CheckInput();
            allSections.sections.ElementAt(index).words.ElementAt(indexWord).translations.Add(newTranslate);
            
        }

        private int SearchWordIndex(int index)
        {
            Word tempWord = new Word();
            Console.WriteLine("Введите слово которое будете редактировать.");
            string word = new Writer().CheckInput();
            try
            {
                tempWord = allSections.sections.ElementAt(index).WordSearch(word);
                return allSections.sections.ElementAt(index).words.IndexOf(tempWord);
            }catch { return -1; }
        }
    }
}
