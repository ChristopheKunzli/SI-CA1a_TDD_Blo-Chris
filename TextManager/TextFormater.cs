using System;
using System.Collections.Generic;

namespace TextManager
{
    public class TextFormater
    {
        #region public methods
        public string Reverse(string textToReverse)
        {
            textToReverse = Format(textToReverse, true);
            //Reverse sentence
            string[] splitted = textToReverse.Split(" ");
            string[] punctuation = new string[splitted.Length];
            for (int i = 0; i < splitted.Length; i++)
            {
                if (splitted[i].Contains(","))
                {
                    punctuation[i + 1] = ",";
                    splitted[i] = splitted[i].Remove(splitted[i].Length - 1, 1);
                }
                if (splitted[i].Contains("."))
                {
                    punctuation[i + 1] = ".";
                    splitted[i] = Format(splitted[i], false);
                    splitted[i] = splitted[i].Remove(splitted[i].Length - 1, 1);
                }
            }

            string empty = "";
            for (int i = splitted.Length -1; i >= 0; i--)
            {
                if (punctuation[i] == ".")
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
            if (lower)
            {
                //Remove last dot, everything to lowerCase
                toFormat = toFormat.Remove(toFormat.Length - 1, 1);
                toFormat = char.ToLower(toFormat[0]) + toFormat;
                toFormat = toFormat.Remove(1, 1);
            }
            else
            {
                //Remove extra space
                toFormat = toFormat.Remove(toFormat.Length - 1, 1);
                //Add first letter capitalized
                toFormat = char.ToUpper(toFormat[0]) + toFormat;
                toFormat = toFormat.Remove(1, 1);
                //Append dot
                toFormat += ".";
            }
            return toFormat;
        }
        #endregion private methods
    }
}
