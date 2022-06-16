using NUnit.Framework;
using System.Collections.Generic;
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
        private List<char> specials = null;
        #endregion private attributes

        [SetUp]
        public void Setup()
        {
            dictionnary = new List<string> { "niquer", "ta gueule", "fils de pute", "putain" };
            specials = new List<char> { '*', '@', '$', '#', '&' };

            fileHelper = new FileHelper();
            textFormater = new TextFormater(dictionnary, specials);
            weHappyFew = new WeHappyFew(fileHelper,textFormater);
        }
        [TearDown]
        public void Teardown()
        {
            string backup = this.fileHelper.Import("..\\..\\..\\..\\..\\text\\wehappy_T001_backup.txt");
            this.fileHelper.Export("..\\..\\..\\..\\..\\text\\wehappy_T001.txt", backup);
        }
        #region Censor
        [Test]
        public void T001_SimpleLineCensor_Success()
        {
            //given
            string filePath = "..\\..\\..\\..\\..\\text\\wehappy_T001.txt";
            string expectedResult = this.fileHelper.Import("..\\..\\..\\..\\..\\text\\wehappy_T001_Res.txt");
            string actualResult;

            string temp = "Il faut agir aussi vite que putain de possible.";
            //when
            weHappyFew.censor(filePath);
            actualResult = this.fileHelper.Import(filePath);

            //then
            Assert.AreEqual(expectedResult.Substring(0, 29), actualResult.Substring(0, 29));

            //Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion Censor

        #region reverse
        [Test]
        public void T002_SimpleLineReverse_Success()
        {
            //given
            string filePath = "..\\..\\..\\..\\..\\text\\wehappy_T001.txt";
            string expectedResult = this.fileHelper.Import("..\\..\\..\\..\\..\\text\\wehappy_T002_Res.txt");
            string actualResult;

            
            //when
            weHappyFew.reverse(filePath);
            actualResult = this.fileHelper.Import(filePath);

            //then


            Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion reverse

    }
}