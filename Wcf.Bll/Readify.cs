using System;
using System.Numerics;
namespace Wcf.BLL
{
    public static class Readify
    {
        #region [Fibonacci]
        
        #region [Fib Memory]
        public static long[] sequence ={
		   0,1,1,2,3,5,8,13,21,34,55,89,144,233,377,610,987,1597,2584,4181,6765,10946,17711,28657,46368,75025,121393,196418,317811, 514229, 832040, 
           1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169, 63245986, 102334155, 165580141, 267914296, 433494437, 701408733, 
           1134903170, 1836311903, 2971215073, 4807526976, 7778742049, 12586269025, 20365011074, 32951280099, 53316291173, 86267571272, 139583862445, 225851433717, 
           365435296162, 591286729879, 956722026041, 1548008755920, 2504730781961, 4052739537881, 6557470319842, 10610209857723, 17167680177565, 27777890035288, 
           44945570212853, 72723460248141, 117669030460994, 190392490709135, 308061521170129, 498454011879264, 806515533049393, 1304969544928657, 2111485077978050, 
           3416454622906707, 5527939700884757, 8944394323791464, 14472334024676221, 23416728348467685, 37889062373143906, 61305790721611591, 99194853094755497, 
           160500643816367088, 259695496911122585, 420196140727489673, 679891637638612258, 1100087778366101931, 1779979416004714189, 2880067194370816120, 
           4660046610375530309, 7540113804746346429
	    };
     
        public static long Fibonacci2(long value)
        {

            if (value < -92)
                throw new ArgumentOutOfRangeException("value", "Fib(<92) will cause a 64-bit integer overflow.");

            if (value > 92)
                throw new ArgumentOutOfRangeException("value", "Fib(>92) will cause a 64-bit integer overflow.");

            var seqFib = sequence[Math.Abs(value)];
            if (Math.Abs(value) % 2 == 0 && value < 0)
                return -seqFib;
            else
                return seqFib;
        }
        #endregion

        #region [Fib Sequence]
        public static long Fibonacci(long value)
        {
            if (value < -92)
                throw new ArgumentOutOfRangeException("value", "Fib(<92) will cause a 64-bit integer overflow.");

            if (value > 92)
                throw new ArgumentOutOfRangeException("value", "Fib(>92) will cause a 64-bit integer overflow.");


            if (value == 0) return 0;
            if (value == 1) return 1;


            long prevPrev = 0;
            long prev = 1;
            long result = 0;

            for (int i = 2; i <= value; i++)
            {
                result = prev + prevPrev;
                prevPrev = prev;
                prev = result;
            }

            return result;
        }


        #endregion
        #endregion

        #region[ReverseWords]
        public static string ReverseWords(string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                char[] charArray = new char[value.Length];
                int startOfWordIndex = 0;

                do
                {
                    int endOfWordIndex = IndexOfFirstEndOfWord(value, startOfWordIndex);

                    int WordLen = endOfWordIndex - startOfWordIndex;


                    for (int i = 0; i <= WordLen; i++)
                    {
                        charArray[startOfWordIndex + i] = value[endOfWordIndex - i];
                    }

                    if (endOfWordIndex < value.Length - 1)
                    {
                        endOfWordIndex++;
                        charArray[endOfWordIndex] = value[endOfWordIndex];
                    }


                    startOfWordIndex = endOfWordIndex + 1;
                }
                while (startOfWordIndex < value.Length);

                return new string(charArray);
            }
            return "";
        }

        private static int IndexOfFirstEndOfWord(string value, int StartIndex)
        {
            for (int index = StartIndex; index < value.Length; index++)
            {
                if (Char.IsWhiteSpace(value[index]))
                    return --index;
            }

            return value.Length - 1;
        }
        #endregion

        #region [WhatShapeIsThis]
        public enum TriangleType
        {
            Error = 0,
            Equilateral = 1,
            Isosceles = 2,
            Scalene = 3,
        }

        public static TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            TriangleType value;

            if (a <= 0 || b <= 0 || c <= 0)
                value = TriangleType.Error;
            else if ((a + b <= c) || (b + c <= a) || (a + c <= b))
                value = TriangleType.Error;
            else if ((a == b) && (b == c))
                value = TriangleType.Equilateral;
            else if ((a == b) || (b == c) || (a == c))
                value = TriangleType.Isosceles;
            else
                value = TriangleType.Scalene;

            return value;
        }
        #endregion
    }
}
