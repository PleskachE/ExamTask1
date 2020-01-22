using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{
    public class MenuSelection
    {
        public MenuSelection() { }

        public int InputChoiceAndPrintMessage(int counter, string message)
        {
            int choice = -1;
            while ((choice < 0) | (choice > counter))
            {
                Console.WriteLine(message);
                try { choice = int.Parse(Console.ReadLine()); }
                catch { Console.WriteLine("Вводите целые числа!"); }
                if ((choice < 0) | (choice > counter))
                {
                    Console.WriteLine("Вводите внимательнее!\nНажмите любую клавишу что бы продолжить.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            return choice;
        }

        public int InputChoice(int counter)
        {
            int choice = -1;
            while ((choice < 0) | (choice > counter))
            {
                try { choice = int.Parse(Console.ReadLine()); }
                catch { Console.WriteLine("Вводите целые числа!"); }
                if ((choice < 0) | (choice > counter))
                    Console.WriteLine("Вводите внимательнее!\n Повторите ввод.");
            }
            return choice;
        }
    }
}
