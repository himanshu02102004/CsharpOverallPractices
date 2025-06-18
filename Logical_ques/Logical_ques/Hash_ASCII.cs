using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// IF GIVEN STRING AB  THEN NEXT ALL STRING PRINT
namespace Logical_ques
{
    class Hash_ASCII
    {

        public static void nextstring()

        {
            string str = "ab";

            int[] hash = new int[26];

            for (int i = 0; i < str.Length; i++)
            {
                hash[(int)(str[i] - 97)]++;
            }

            for (int i = 0; i < hash.Length; i++)
            {
                if (hash[i] == 0)
                {
                    Console.WriteLine($"{(char)(i + 97)}");
                }

            }
      }
}
}
