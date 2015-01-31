using System;
using System.Collections.Generic;
using NUnit.Framework;
using Wcf.BLL;
namespace Wcf.Test
{
    #region [Test]
    [TestFixture]
    public class WhatShapeIsThis
    {
        public struct Case
        {
            public int A;
            public int B;
            public int C;
            public Readify.TriangleType Type;

            public Case(int a, int b, int c, Readify.TriangleType type)
            {
                A = a;
                B = b;
                C = c;
                Type = type;
            }
        }

        public IEnumerable<Case> Cases
        {
            get
            {
                // Zeros
                yield return new Case(0, 0, 0, Readify.TriangleType.Error);
                yield return new Case(0, 0, 1, Readify.TriangleType.Error);
                yield return new Case(0, 1, 0, Readify.TriangleType.Error);
                yield return new Case(0, 1, 1, Readify.TriangleType.Error);
                yield return new Case(1, 0, 0, Readify.TriangleType.Error);
                yield return new Case(1, 0, 1, Readify.TriangleType.Error);
                yield return new Case(1, 1, 0, Readify.TriangleType.Error);

                // Negatives
                yield return new Case(1, 1, -1, Readify.TriangleType.Error);
                yield return new Case(1, -1, 1, Readify.TriangleType.Error);
                yield return new Case(1, -1, -1, Readify.TriangleType.Error);
                yield return new Case(-1, 1, 1, Readify.TriangleType.Error);
                yield return new Case(-1, 1, -1, Readify.TriangleType.Error);
                yield return new Case(-1, -1, 1, Readify.TriangleType.Error);
                yield return new Case(-1, -1, -1, Readify.TriangleType.Error);

                // Equilaterals
                yield return new Case(1, 1, 1, Readify.TriangleType.Equilateral);
                yield return new Case(10, 10, 10, Readify.TriangleType.Equilateral);

                // Isosceles
                yield return new Case(1, 2, 2, Readify.TriangleType.Isosceles);
                yield return new Case(2, 1, 2, Readify.TriangleType.Isosceles);
                yield return new Case(2, 2, 1, Readify.TriangleType.Isosceles);

                // Isosceles - Equal sides are less or equal to than 3rd side
                yield return new Case(4, 2, 2, Readify.TriangleType.Error);
                yield return new Case(5, 2, 2, Readify.TriangleType.Error);
                yield return new Case(2, 4, 2, Readify.TriangleType.Error);
                yield return new Case(2, 5, 2, Readify.TriangleType.Error);
                yield return new Case(2, 2, 4, Readify.TriangleType.Error);
                yield return new Case(2, 2, 5, Readify.TriangleType.Error);

                // Scalenes
                yield return new Case(3, 4, 6, Readify.TriangleType.Scalene);
                yield return new Case(3, 6, 4, Readify.TriangleType.Scalene);
                yield return new Case(4, 3, 6, Readify.TriangleType.Scalene);
                yield return new Case(4, 6, 3, Readify.TriangleType.Scalene);
                yield return new Case(6, 4, 3, Readify.TriangleType.Scalene);
                yield return new Case(6, 3, 4, Readify.TriangleType.Scalene);

                // Scalenes - Sides don't add up
                yield return new Case(1, 2, 3, Readify.TriangleType.Error);
                yield return new Case(1, 3, 2, Readify.TriangleType.Error);
                yield return new Case(2, 1, 3, Readify.TriangleType.Error);
                yield return new Case(2, 3, 1, Readify.TriangleType.Error);
                yield return new Case(3, 1, 2, Readify.TriangleType.Error);
                yield return new Case(3, 2, 1, Readify.TriangleType.Error);

            }
        }

        [Test]
        [TestCaseSource("Cases")]
        public void WhatShapeIsThis_Test(Case test)
        {
            var expected = test.Type;
            var actual = Readify.WhatShapeIsThis(test.A, test.B, test.C);
            Assert.AreEqual(expected, actual, "A:{0} B:{1} C:{2} = {3}, but received {4}", test.A, test.B, test.C, expected, actual);
        }
    }
    #endregion
}
