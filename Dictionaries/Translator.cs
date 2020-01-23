using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{
    enum VariantOfTranslation { OneWord, Phrase }

    public class Translator
    {
        public Translator() { }

        public string SplittingPhraseIntoWords(string word, Section section)
        {
            string result = word + " - ";
            if (word == "")
                return word;
            String[] words = result.Split(new char[] { ' ', ',', '.', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 1)
                result = Translate(VariantOfTranslation.OneWord, words, section, result);
            else
                result = Translate(VariantOfTranslation.Phrase, words, section, result);
            return result;
        }

        private string Translate(VariantOfTranslation value, String[] words, Section section, string result)
        {
            Word tempWord = new Word();
            switch (value)
            {
                case VariantOfTranslation.OneWord:
                    tempWord = section.WordSearch(words[0]);
                    try
                    {
                        for (int i = 0; i < tempWord.translations.Count; i++)
                            result += tempWord.translations.ElementAt(i) + ", ";
                    }
                    catch { result += words[0]; }
                    break;
                case VariantOfTranslation.Phrase:
                    for (int i = 0; i < words.Length; i++)
                    {
                        tempWord = section.WordSearch(words[i]);
                        try { result += tempWord.translations.ElementAt(0) + " "; }
                        catch { result += words[i] + " "; }
                    }
                    break;
            }
            return result;
        }
    }
}
