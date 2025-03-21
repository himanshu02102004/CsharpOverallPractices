using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_Practices
{
    class Control_exer2_3
    {
        public static void Exer3()
        {
            Console.WriteLine("enter the number for factorial");
            var num = Convert.ToInt32(Console.ReadLine());
            int fac = 1;
            for(int i=1; i<=num; i++)
            {
                fac *= i;
            }
            Console.WriteLine("your fac value is :" + fac);

        }
    }
}
