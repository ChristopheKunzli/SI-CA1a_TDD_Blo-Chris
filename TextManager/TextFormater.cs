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

            int comma = -1;
            for (int i = 0; i < splitted.Length; i++)
            {
                if (splitted[i].Contains(","))
                {
                    comma = i;
                    splitted[i] = splitted[i].Remove(splitted[i].Length - 1, 1);
                }
            }

            string empty = "";
            for (int i = splitted.Length -1; i >= 0; i--)
            {
                //If a commma has been found
                if(comma != -1) {
                    if (i == comma + 1)
                    {
                        empty += splitted[i] + ", ";
                    }
                    else
                    {
                        empty += splitted[i] + " ";
                    }
                }
                //If no comma was found
                else
                {
                    empty += splitted[i] + " ";
                }
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
                toFormat = toFormat.ToLower();
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
