using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical_ques
{
    class Second_Larg_ques_1
    {

        public static void Ques1()
        {
            int[]  arr = { 12, 35, 1, 10,34,1, 35 };
            int length = int.MinValue;
            int seclen = int.MinValue;

            foreach(int num in arr)
            {
                if (num > length)
                {
                    
                    length = num;
                }
             }

            foreach (int num in arr)
            {
                if (num > seclen && num < length)
                {
                    seclen = num;
                }
            }

            Console.WriteLine("The second length is :" + seclen);

        }
    }
}
