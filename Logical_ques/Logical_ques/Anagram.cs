using System;
using System.Collections.Generic;

namespace Logical_ques
{
    class Anagram
    {



        public static bool isAnagram(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;


            Dictionary<char, int> Charcount = new Dictionary<char, int>();

            foreach (char c in str1)
            {
                if (Charcount.ContainsKey(c))
                    Charcount[c]++;

                else
                    Charcount[c] = 1;

            }

            foreach (char c in str2)
            {

                if (!Charcount.ContainsKey(c))
                    return false;

                Charcount[c]--;

                if (Charcount[c] < 0)

                    return false;
            }
            return true;



        }



       
    }




}
