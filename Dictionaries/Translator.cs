using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{
    public class Translator
    {
        public Translator() { }

        public string SplittingPhraseIntoWords(string word, Section section)
        {
            string result = word + " - ";
            if (word == "")
                return word;
            String[] words = result.Split(new char[] { ' ', ',', '.', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);
            return result = Translate(words, section, result);
        }

        private string Translate(String[] words, Section section, string result)
        {
            if (words.Length == 1)
            {
                Word tempWord = section.WordSearch(words[0]);
                try
                {
                    for (int i = 0; i < tempWord.translations.Count; i++)
                        result += tempWord.translations.ElementAt(i) + ", ";
                }
                catch { result += words[0]; }
            }
            else
            {
                for (int i = 0; i < words.Length; i++)
                {
                    Word tempWord = section.WordSearch(words[i]);
                    try { result += tempWord.translations.ElementAt(0) + " "; }
                    catch { result += words[i] + " "; }
                }
            }
            return result;
        }
    }
}
