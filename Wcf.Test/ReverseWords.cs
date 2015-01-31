using System;
using System.Collections.Generic;
using NUnit.Framework;
using Wcf.BLL;
namespace Wcf.Test
{
    #region [Test]
    [TestFixture]
    public class ReverseWords
    {
        public struct Case
        {
            public string Input;
            public string Output;

            public Case(string input, string output)
            {
                Input = input;
                Output = output;
            }
        }

        public IEnumerable<Case> Cases
        {
            get
            {

                yield return new Case("Hello world", "olleH dlrow");

                yield return new Case("The quick brown fox jumps over the lazy hen!", "ehT kciuq nworb xof spmuj revo eht yzal !neh");

                yield return new Case("1234567890 ","0987654321 ");

                yield return new Case("Manuel  Henry  Villacruz  II", "leunaM  yrneH  zurcalliV  II");

                yield return new Case(" "," ");

                yield return new Case(" C O O L ", " C O O L ");

            }
        }

        [Test]
        [TestCaseSource("Cases")]
        public void ReverseWords_Test(Case test)
        {
            var actual = Readify.ReverseWords(test.Input);
            Assert.AreEqual(test.Output, actual);
        }
    }
    #endregion
}
