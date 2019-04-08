using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQAAAAAAAAAAAA
{
    public class CommaSeparator : Separator
    {
        public CommaSeparator(char c) : base(c)
        { }
        public override string[] Separate(string str)
        {
            string[] s = new string[2];
            s = str.Split(',');
            return s;
        }
    }
}