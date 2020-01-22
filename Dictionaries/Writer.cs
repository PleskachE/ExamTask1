using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{
    public class Writer
    {
        public Writer() { }

        public string CheckInput()
        {
            string input = Console.ReadLine();
            if (input == "")
            {
                Console.WriteLine("Вводимая строка не должна быть пустой!");
                input = CheckInput();
            }
            return input;
        }

    }
}
