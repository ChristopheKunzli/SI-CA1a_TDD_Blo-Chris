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

            this.fileHelper.Export("..\\..\\..\\..\\..\\text\\T002.txt", "");
            this.fileHelper = null;



        }
        #region Single import
        [Test]
        public void T001_SimpleImport_Success()
        {
            //given
            string filePath = "..\\..\\..\\..\\..\\text\\T001.txt";
            string expectedResult = "Il faut agir aussi vite que possible.";
            string actualResult;

            //when
            actualResult = (this.fileHelper.Import(filePath));

            //then
            Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion Single import
       
        #region Single export
         [Test]
        public void T002_SimpleExport_Success()
        {
            //given
            string filePath = "..\\..\\..\\..\\..\\text\\T002.txt";
            string fileResult= "..\\..\\..\\..\\..\\text\\TResult.txt";
            string TextExport = "Il faut agir aussi vite que possible.";
            
            string expectedResult = this.fileHelper.Import(fileResult);

            //when
            this.fileHelper.Export(filePath, TextExport);
            string actualResult = this.fileHelper.Import(filePath);


            //then
            Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion Single export
    }
}