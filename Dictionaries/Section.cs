using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{
    [Serializable]
    public class Section
    {
        public string name { get; set; }
        public List<Word> words { get; set; }

        public Section() { words = new List<Word>(); }

        public Section(string name)
        {
            this.name = name;
            words = new List<Word>();
        }

        public Section(string name, List<Word> words)
        {
            this.name = name;
            this.words = new List<Word>();
            this.words = words;
        }

        public Word WordSearch(string word)
        {
            Word tempWord = new Word();
            tempWord = null;
            for (int i = 0; i < words.Count; i++)
            {
                if(words.ElementAt(i).name.ToLower() == word.ToLower())
                {
                    tempWord = words.ElementAt(i);
                    break;
                }
            }
            return tempWord;
        }
    }
}
