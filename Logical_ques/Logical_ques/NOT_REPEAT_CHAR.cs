using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical_ques
{
    class NOT_REPEAT_CHAR
    {


        /// <summary>
        /// FIRST APPROACH  USING 
        /// </summary>
        /

        public static void NOTREPEAT(string[] args)
        {
            string str = "himah";
            bool isnotrepeat;

            for (int i = 0; i < str.Length; i++)
            {
                isnotrepeat = false;

                for (int j = 0; j < str.Length; j++)
                {
                    if (i != j && str[i] == str[j])
                    {

                        isnotrepeat = true;
                        break;
                    }

                }

                if (!isnotrepeat)
                {
                    Console.WriteLine(str[i]);
                }
            }



        }
    }
}

