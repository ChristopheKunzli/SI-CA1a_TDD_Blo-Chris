using System;
using System.Collections.Generic;

namespace TextManager
{
    public class TextFormater
    {
        #region private attributes
        private List<char> punctuations = new List<char>{ '.', ',' };
        #endregion private attributes


        #region public methods
        public string Reverse(string textToReverse)
        {
            string textToReverseTemp = Format(textToReverse, true);
            
            //Reverse sentence
            string[] splitted = textToReverse.Split(" ");
            string[] punctuation = new string[splitted.Length];
            for (int i = 0; i < splitted.Length; i++)
            {
                foreach (char currentPunctuation in this.punctuations)
                {
                    if (splitted[i].Contains(currentPunctuation))
                    {
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
                toFormatTemp = toFormat.Remove(toFormatTemp.Length - 1, 1);
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
        #endregion private methods
    }
}
