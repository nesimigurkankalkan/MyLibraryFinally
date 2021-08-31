using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibraryFinally
{
    public class OtherMethods
    {
        //Using
        //SeperateWord("Gürkan Nesimi Kalkan");
        public static string SeperateWord(string word)
        {
            string[] s;
            s = word.Split(' ');
            string tamad = s[1] + " " + s[0] + " " + s[2];
            return tamad;
        }

    }
}
