﻿
using Contensive.BaseClasses;

namespace Contensive.Samples
{
    public class Html5H2Sample : AddonBaseClass
    {
        public override object Execute(CPBaseClass cp)
        {
            string innerHtml = "Hello World!";

            string H2 = cp.Html5.H2(innerHtml);

            return H2;
        }
    }
}