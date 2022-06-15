using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace TextManager
{
    public class WeHappyFew
    {
        #region private attributes
        private FileHelper fileHelper = null;
        private TextFormater textFormater = null;
        #endregion private attributes

        #region public methods
        public string Import(string filePath)
        {
            StreamReader Text;
            string result = "";
            try
            {
                using (Text = new StreamReader(filePath))
                {
                    result = Text.ReadToEnd();
                }
                Text.Close();

                return result;
            }
            catch (Exception e)
            {
                throw (e);
            }

        }
        #endregion public methods
    }
}
