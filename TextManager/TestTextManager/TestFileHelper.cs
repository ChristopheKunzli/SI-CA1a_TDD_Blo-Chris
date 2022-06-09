using NUnit.Framework;
using TextManager;

namespace TestTextManager
{
    public class TestFileHelper
    {
        #region private attributes
        private FileHelper fileHelper = null;
        #endregion private attributes

        [SetUp]
        public void Setup()
        {
            this.fileHelper = new FileHelper();
        }
        [TearDown]
        public void Teardown() { 
            this.fileHelper = null;
        }
        #region Single import
        [Test]
        public void T001_NominalCase_Success()
        {
            //given
            string filePath = "T001.txt";
            string expectedResult = "Il faut agir aussi vite que possible.";
            string actualResult;

            //when
            actualResult = (this.fileHelper.Import(filePath));

            //then
            Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion Single import
    }
}