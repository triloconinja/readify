using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Wcf.ServiceReference1;
using Wcf.BLL;
using System.Configuration;
namespace Wcf
{
    public class Service1 : IRedPill
    {
        public Guid WhatIsYourToken()
        {
            if (bool.Parse(ConfigurationManager.AppSettings["UseToken"]))
                return new Guid(ConfigurationManager.AppSettings["Token"]);
            else
                return new Guid();
        }

        public long FibonacciNumber(long n)
        {

            return Readify.Fibonacci(n);
        }

        public string ReverseWords(string input)
        {

            return Readify.ReverseWords(input);
        }

        public TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            return (TriangleType)Readify.WhatShapeIsThis(a, b, c);
        }
    }
}
