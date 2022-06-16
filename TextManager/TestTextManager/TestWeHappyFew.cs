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
            dictionnary = new List<string> { "niquer", "ta gueule", "fils de pute" };
            specials = new List<char> { '*', '@', '$', '#', '&' };

            fileHelper = new FileHelper();
            textFormater = new TextFormater(dictionnary, specials);
            weHappyFew = new WeHappyFew();
        }
        [TearDown]
        public void Teardown()
        {
            
        }
        #region Single import
        [Test]
        public void T001_SimpleLine_Success()
        {
            //given
            string filePath = "..\\..\\..\\..\\..\\text\\T001.txt";
            string expectedResult = "Il faut agir aussi vite que p_____ de possible.";
            string actualResult;

            //when
            actualResult =this.fileHelper.Import(filePath);

            //then
            Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion Single import

    }
}