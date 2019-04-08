using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQAAAAAAAAAAAA
{
    public class SeparatorDictionary
    {
        private Dictionary<char, Separator> dict;
        public SeparatorDictionary()
        {
            dict = new Dictionary<char, Separator>();
            dict.Add(',', new CommaSeparator(','));
            dict.Add(' ', new WhitespaceSeparator(' '));
        }
        public void Add(char c, Separator s)
        {
            dict.Add(c, s);
        }
        public Separator GetSeparator(char c) //Get
        {
           // if (dict.ContainsKey(c))
            //{
                return dict[c];
            //}
        }
    }
}