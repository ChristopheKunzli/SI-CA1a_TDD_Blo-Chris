using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace TextManager
{
    public class FileHelper
    {
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
            catch(Exception e) 
            {
                throw(e);
            }
            
        }
        public void Export(string filePath, string textToWritte)
        {
             StreamWriter Text;
            try
            {
                using (Text = new StreamWriter(filePath))
                {
                   Text.Write(textToWritte);
                }
                Text.Close();

                
            }
            catch(Exception e) 
            {
                throw(e);
            }



        }
        #endregion public methods
    }
}
