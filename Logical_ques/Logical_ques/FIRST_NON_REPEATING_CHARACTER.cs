using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical_ques
{
    class FIRST_NON_REPEATING_CHARACTER
    {
    

       public static char repeatingcharacter(string str)
        {
            Dictionary<Char, int> charcount = new Dictionary<char, int>();

            foreach(char s in str)
            {
                if (charcount.ContainsKey(s))
                {
                    charcount[s]++;
                }

                else
                {
                    charcount[s] = 1;
                }


            }


            foreach(char c in str) {
                if (charcount[c] == 1)
                {
                    return c;   
                }
            }
            return '\0';
            
        }


    }
}
