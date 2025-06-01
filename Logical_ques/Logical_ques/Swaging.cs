using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical_ques
{
    class Swaging
    {

        public static  void Ques5()
        {
            int a = 3;
            int b = 5;
            a = a + b;
            b = a - b;
            a = a - b;

            Console.WriteLine("The values of a is " + a);
            Console.WriteLine("The values of b is " + b);


            // using multiplication and division

            a = a * b
;
            b = a / b;
            a = a / b;
            Console.WriteLine("The values of a is " + a);
            Console.WriteLine("The values of b is " + b);
            // using bitwise XOR
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
            Console.WriteLine("The values of a is " + a);
            Console.WriteLine("The values of b is " + b);

        }
    }
}
