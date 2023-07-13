using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace LaW
{
    public class Word
    {

        private string word;
        private string translation;
        private string information = "Additional Information";
        public string WordText
        {
            set { word = value; }
            get { return word; }
        }
        public string Translation
        {
            get { return translation; }
            set { translation = value; }
        }
        public string AdditionalInformation
        {
            get { return information; }
            set
            {
                information = value;
            }
        }
        public Word(String _word, String _translation)
        {
            word = _word;
            translation = _translation;
        }
        public static void RandomSort<T>(ref List<T> sources)
        {
                Random rd = new Random();
                int index = 0;
                T temp;
                for (int i = 0; i < sources.Count; i++)
                {
                    index = rd.Next(0, sources.Count - 1);
                    if (index != i)
                    {
                        temp = sources[i];
                        sources[i] = sources[index];
                        sources[index] = temp;
                    }
                }
        }
        public static void FillWordFromFile(ref List<Word> _words, string _file)
        {
            _words.Clear();
            string[] wordsrings = Regex.Split(_file, @"\r?\n|\r");
            int wordCount = 0;
            if (wordsrings.Length > 0)
                foreach (var word in wordsrings)
                {
                    //Debugger.Log(1, "Count", word);

                    string[] OriginandTranslation = System.Text.RegularExpressions.Regex.Split(word, @"\s+");
                    if (OriginandTranslation[0] != "" && OriginandTranslation[1] != "")
                        _words.Add(new Word(OriginandTranslation[0], OriginandTranslation[1]));
                    if (word.IndexOf("#") != -1)
                    {
                        _words[wordCount].AdditionalInformation = word.Substring(word.IndexOf("#") + 1).Replace("|", "\n");

                        wordCount++;
                    }
                    else
                    {
                        wordCount++;
                    }
                }
        }
    }
}
