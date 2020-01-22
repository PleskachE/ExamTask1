using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{
    [Serializable]
    public class Word : IComparable<Word>
    {
        public string name { get; set; }
        public List<string> translations { get; set; }

        public Word() { translations = new List<string>(); }

        public Word(string name, string translation)
        {
            this.name = name;
            this.translations = new List<string>();
            translations.Add(translation);
        }

        public void PrintTranslate()
        {
            for(int i = 0; i < translations.Count; i++)
                Console.WriteLine(translations.ElementAt(i));
        }

        public int CompareTo(Word obj)
        {
            if (obj != null)
                return name.CompareTo(obj.name);
            else
                return name.CompareTo(name);
        }
    }
}
