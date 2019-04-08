using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQAAAAAAAAAAAA
{
    public class Separator
    {
        public Separator(char c)
        {
            Character = c;
        }
        public char Character { get; }
        public virtual string[] Separate(string str)
        {
            string[] s = new string[1];
            s[0] = "";
            return s;
        }
    }
}