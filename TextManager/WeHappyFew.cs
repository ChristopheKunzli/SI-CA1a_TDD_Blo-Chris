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
        public WeHappyFew(FileHelper fileHelper, TextFormater textFormater)
        {
            this.fileHelper = fileHelper;
            this.textFormater = textFormater;
        }

        public void censor(string filePath)
        {
            string imported = this.fileHelper.Import(filePath);
            string censored = this.textFormater.CensorSwear(imported);
            this.fileHelper.Export(filePath, censored); 
        }
        public void reverse(string filePath)
        {
            string imported = this.fileHelper.Import(filePath);
            string reversed = this.textFormater.Reverse(imported);
            this.fileHelper.Export(filePath, reversed);
        }
        #endregion public methods
    }
}
