using System;
using System.Collections.Generic;
using NUnit.Framework;
using Wcf.BLL;
namespace Wcf.Test
{
    #region [Test]
    [TestFixture]
    public class Fibonacci
    {

        public struct Case
        {
            public int Index;
            public long Value;

            public Case(int index, long value)
            {
                Index = index;
                Value = value;
            }
        }

        public IEnumerable<Case> ValidCases
        {
            get
            {
                var count = Readify.sequence.Length - 1;

                for (var i = -count; i <= count; i++)
                {
                    yield return new Case(i, Readify.Fibonacci(i));
                }
            }
        }

        public IEnumerable<long> InValidCases
        {
            get
            {
                yield return 93;
                yield return -93;
                yield return 2147483647;
                yield return -2147483648;
                yield return 9223372036854775807;
                yield return -9223372036854775808;
            }
        }


        [Test]
        [TestCaseSource("ValidCases")]
        public void Fibonacci_Valid_Test(Case test)
        {

            var actual = Readify.Fibonacci(test.Index);
            NUnit.Framework.Assert.AreEqual(test.Value, actual, "Expected {0} At Index {1}, But Received {2}.", test.Value, test.Index, actual);
        }


        [Test]
        [TestCaseSource("InValidCases")]
        public void Fibonacci_InValid_Test(long index)
        {
            NUnit.Framework.Assert.Throws<ArgumentOutOfRangeException>(() => Readify.Fibonacci(index));
        }

    }
    #endregion
}
