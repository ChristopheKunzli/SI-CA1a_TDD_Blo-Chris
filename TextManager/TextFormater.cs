using System;
using System.Collections.Generic;


namespace TextManager
{
    public class TextFormater
    {
        #region private attributes
        private List<char> punctuations = new List<char>{ '.', ',' };
        private List<char> special;
        private List<string> swear_words;
        #endregion private attributes

        #region public methods
        public TextFormater(List<string> dictionnary, List <char> specials)
        {
            this.swear_words = dictionnary;
            this.special = specials;
        }

        public string Reverse(string textToReverse)
        {
            string textToReverseTemp = Format(textToReverse, true);
            
            //Reverse sentence
            string[] splitted = textToReverseTemp.Split(" ");
            string[] punctuation = new string[splitted.Length];
            for (int i = 0; i < splitted.Length-1; i++)
            {
                foreach (char currentPunctuation in this.punctuations)
                {
                    if (splitted[i].Contains(currentPunctuation))
                    {
                        //add the current punctuation sign in the next array cell cause
                        //read backward it will be in the right place
                        punctuation[i + 1] = currentPunctuation.ToString();
                        if (currentPunctuation == punctuations[0])
                        {
                            splitted[i] = Format(splitted[i], false);
                        }
                        splitted[i] = splitted[i].Remove(splitted[i].Length - 1, 1);
                    }
                }

                if (splitted[i].Contains(punctuations[0]))
                {
                    punctuation[i + 1] = punctuations[0].ToString();
                    
                    splitted[i] = splitted[i].Remove(splitted[i].Length - 1, 1);
                }
            }

            string empty = "";
            for (int i = splitted.Length -1; i >= 0; i--)
            {
                if (punctuation[i] == punctuations[0].ToString())
                {
                    splitted[i] = Format(splitted[i] + " ", true);
                }
                empty += splitted[i] + punctuation[i] + " ";
            }
            empty = Format(empty, false);
            return empty;
        }

        public string CensorSwear(string toRemove)
        {
            string res = toRemove;
            foreach (string word in this.swear_words)
            {
                string capsWord = char.ToUpper(word[0]) + word;
                capsWord = capsWord.Remove(1, 1);
                res = res.Replace(word, Stars(word));
                res = res.Replace(capsWord, Stars(capsWord));
            }

            return res;
        }
        #endregion public methods

        #region private methods
        private string Format(string toFormat, bool lower)
        {
            string toFormatTemp = toFormat;

            //Remove extra space
            toFormatTemp = toFormatTemp.Remove(toFormat.Length - 1, 1);

            if (lower)
            {
                //Remove last dot, everything to lowerCase
                toFormatTemp = char.ToLower(toFormatTemp[0]) + toFormatTemp;
            }
            else
            {               
                //Add first letter capitalized
                toFormatTemp = char.ToUpper(toFormat[0]) + toFormatTemp;
            }

            toFormatTemp = toFormatTemp.Remove(1, 1);

            if (!lower)
            {
                //Append dot
                toFormatTemp += ".";
            }

            return toFormatTemp;
        }
        private string Stars(string word)
        {
            string res = "" + word[0];
            for (int i = 0; i < word.Length - 1; i++)
            {
                var rand = new Random();
                int index = rand.Next(this.special.Count);
                res += this.special[index];
            }

            return res;
        }
        #endregion private methods
    }
}
