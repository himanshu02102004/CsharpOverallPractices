using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/////WAP to reverse an integer without converting it to a string, without using any built-in methods. 

namespace Logical_ques
{
    class Reverse_int
    {

        public static void Ques2()
        {
            int num = 12345;
            int rev = 0;
            while (num > 0)
            {
                rev = rev * 10 + num % 10;
                num = num / 10;
            }
            Console.WriteLine("The reverse of the number is :" + rev);
        }
    }
}
