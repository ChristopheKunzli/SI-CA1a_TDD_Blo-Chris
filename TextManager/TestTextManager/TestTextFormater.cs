using NUnit.Framework;
using System.Collections.Generic;
using TextManager;

namespace TestTextManager
{
    public class TestTextFormater
    {
        #region private attributes
        private TextFormater textFormater = null;
        private List<string> dictionnary = null;
        private List<char> specials = null;
        #endregion private attributes

        [SetUp]
        public void Setup()
        {

            dictionnary = new List<string> { "niquer", "ta gueule", "fils de pute" };
            specials = new List<char> { '*', '@', '$', '#', '&' };
            this.textFormater = new TextFormater(dictionnary, specials);
        }

        #region Single Sentence
        [Test]
        public void CensorSwear_SimpleSwear_Success()
        {
            //given
            string sentenceToReverse = "Du coup, il s'est fait niquer sa mère";
            string expectedResult = "Du coup, il s'est fait n_____ sa mère";
            string actualResult;

            //when
            actualResult = (this.textFormater.CensorSwear(sentenceToReverse));

            //then
            Assert.AreEqual(expectedResult.Substring(0, 24), actualResult.Substring(0, 24));
            Assert.AreEqual(expectedResult.Substring(29, (expectedResult.Length-1)-29), actualResult.Substring(29, (sentenceToReverse.Length - 1)-29));

            foreach (string word in dictionnary)
            {
                Assert.False(actualResult.Contains(word));
            }
        }

        [Test]
        public void CensorSwear_MultipleSwear_Success()
        {

            //given
            string sentenceToReverse = "Du coup, ta gueule il s'est fait niquer sa mère ta gueule";
            string expectedResult = "Du coup, t________ il s'est fait n_____ sa mère t________";
            string actualResult;
            //when
            actualResult = (this.textFormater.CensorSwear(sentenceToReverse));

            //then
            Assert.AreEqual(expectedResult.Substring(0, 10), actualResult.Substring(0, 10));
            Assert.AreEqual(expectedResult.Substring(18, 16), actualResult.Substring(18, 16));
            Assert.AreEqual(expectedResult.Substring(39, 10), actualResult.Substring(39, 10));

            foreach (string word in dictionnary)
            {
                Assert.False(actualResult.Contains(word));
            }
        }
        [Test]
        public void CensorSwear_FirstSwear_Success()
        {
            //given
            string sentenceToReverse = "Fils de pute, j'vais les manger !";
            string expectedResult = "Fils de pute, j'vais les manger !";
            string actualResult;

            //when
            actualResult = (this.textFormater.CensorSwear(sentenceToReverse));

            //then
            Assert.AreEqual(expectedResult.Substring(0,1), actualResult.Substring(0,1));
            Assert.AreEqual(expectedResult.Substring(12, 21), actualResult.Substring(12, 21));

            foreach (string word in dictionnary)
            {
                Assert.False(actualResult.Contains(word));
            }
        }

        [Test]
        public void T001_NominalCase_Success()
        {
            //given
            string sentenceToReverse = "Il faut agir aussi vite que possible.";
            string expectedResult = "Possible que vite aussi agir faut il.";
            string actualResult;

            //when
            actualResult = (this.textFormater.Reverse(sentenceToReverse));

            //then
            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test]
        public void T002_Reverse_SingleComa_Success()
        {
            //given
            string sentenceToReverse = "Il faut agir aussi vite que possible, mais aussi lentement que nécessaire.";
            string expectedResult = "Nécessaire que lentement aussi mais, possible que vite aussi agir faut il.";
            string actualResult;

            //when
            actualResult = (this.textFormater.Reverse(sentenceToReverse));

            //then
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void T003_Reverse_MultipleUpperCase_Success()
        {
            //Add word with UpperCase in the middle of sentence
            //Multiple comas

            //given
            string sentenceToReverse = "Netflix, is an over-the-top content platform and production company headquartered in Los Gatos.";
            string expectedResult = "Gatos Los in headquartered company production and platform content over-the-top an is, netflix.";
            string actualResult;

            //when
            actualResult = (this.textFormater.Reverse(sentenceToReverse));

            //then
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void T004_Reverse_MultipleComa_Success()
        {
            //Add word with UpperCase in the middle of sentence
            //Multiple comas

            //given
            string sentenceToReverse = "Il estime, en outre, que la directive sur la mise en décharge des déchets ne constitue pas un cadre approprié pour les déchets miniers.";
            string expectedResult = "Miniers déchets les pour approprié cadre un pas constitue ne déchets des décharge en mise la sur directive la que, outre en, estime il.";
            string actualResult;

            //when
            actualResult = (this.textFormater.Reverse(sentenceToReverse));

            //then
            Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion Single Sentence

        #region Multiple Sentences
        [Test]
        public void T005_Reverse_MultipleSentence_Success()
        {
            //given
            string sentenceToReverse = "Il faut agir aussi vite que possible, mais aussi lentement que nécessaire. Il faut agir aussi vite que possible, mais aussi lentement que nécessaire.";
            string expectedResult = "Nécessaire que lentement aussi mais, possible que vite aussi agir faut il. Nécessaire que lentement aussi mais, possible que vite aussi agir faut il.";
            string actualResult;

            //when
            actualResult = (this.textFormater.Reverse(sentenceToReverse));

            //then
            Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion Multiple Sentences

        [Test]
        public void T006_Reverse_UltimateTest_Success()
        {
            //Add word with UpperCase in the middle of sentence
            //Multiple comas

            //given
            string textToReverse = "The second sentence of the second subparagraph of Article 7 (a), a Member State proposes not to grant applicants the right to choose between an adaptation period and an aptitude test, it shall immediately communicate to the Commission the corresponding draft provision.";
            string expectedResult = "Provision draft corresponding the Commission the to communicate immediately shall it, test aptitude an and period adaptation an between choose to right the applicants grant to not proposes State Member a, (a) 7 Article of subparagraph second the of sentence second the.";
            string actualResult;

            //when
            actualResult = (this.textFormater.Reverse(textToReverse));

            //then
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}