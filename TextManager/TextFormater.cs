using System;
using System.Collections.Generic;

namespace TextManager
{
    public class TextFormater
    {
        #region public methods
        public string Reverse(string textToReverse)
        {
            //Format
            textToReverse = textToReverse.Remove(textToReverse.Length - 1, 1);
            textToReverse = textToReverse.ToLower();

            //Reverse sentence
            string[] splitted = textToReverse.Split(" ");
            string empty = "";
            for (int i = splitted.Length -1; i >= 0; i--)
            {
                empty += splitted[i] + " ";
            }

            //Remove extra space
            empty = empty.Remove(empty.Length - 1, 1);

            empty = char.ToUpper(empty[0]) + empty;
            empty = empty.Remove(1, 1);
            empty += ".";
            return empty;
        }
        #endregion public methods

        #region private methods
        #endregion private methods
    }
}
