using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using TextManager;

namespace TestTextManager
{
    public class TestWeHappyFew
    {
        #region private attributes
        private WeHappyFew weHappyFew = null;
        private FileHelper fileHelper = null;
        private TextFormater textFormater = null;
        private List<string> dictionnary = null;
        private List<char> specialsChar = null;
        private readonly static string testMainFolderPath = Directory.GetCurrentDirectory() + @"/testFiles/";
        private readonly string testFolderPath = testMainFolderPath + @"text/";
        private readonly string backupFolderPath = testMainFolderPath + @"backup/";
        private readonly string TESTFILENAME = "wehappy_T001.txt";
        #endregion private attributes

        [SetUp]
        public void Setup()
        {
            this.dictionnary = new List<string> { "niquer", "ta gueule", "fils de pute", "putain" };
            this.specialsChar = new List<char> { '*', '@', '$', '#', '&' };

            this.fileHelper = new FileHelper();
            this.textFormater = new TextFormater(dictionnary, specialsChar);
            this.weHappyFew = new WeHappyFew(fileHelper,textFormater);
        }
        
        [TearDown]
        public void Teardown()
        {
            string pathToBackupFile = this.fileHelper.Import(this.backupFolderPath + "wehappy_T001_backup.txt");
            this.fileHelper.Export(this.testFolderPath + TESTFILENAME, pathToBackupFile);
        }
        
        #region Censor
        [Test]
        public void T001_SimpleLineCensor_Success()
        {
            //given
            string filePath = this.testFolderPath + TESTFILENAME;
            string expectedResult = this.fileHelper.Import(this.testFolderPath + "wehappy_T001_Res.txt");
            string actualResult;

            //when
            weHappyFew.censor(filePath);
            actualResult = this.fileHelper.Import(filePath);

            //then
            Assert.AreEqual(expectedResult.Substring(0, 29), actualResult.Substring(0, 29));
        }
        #endregion Censor

        #region Reverse
        [Test]
        public void T002_SimpleLineReverse_Success()
        {
            //given
            string filePath = this.testFolderPath + TESTFILENAME;
            string expectedResult = this.fileHelper.Import(this.testFolderPath + "wehappy_T002_Res.txt");
            string actualResult;

            //when
            weHappyFew.reverse(filePath);
            actualResult = this.fileHelper.Import(filePath);

            //then
            Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion Reverse
    }
}