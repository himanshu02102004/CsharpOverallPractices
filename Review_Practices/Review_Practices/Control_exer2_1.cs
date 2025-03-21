using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_Practices
{
    class Control_exer2_1
    {

        public static void exer1()
        {
            Console.WriteLine("enter the num ");
            var num = Convert.ToInt32(Console.ReadLine());
            var count = 0;
           for(int i=1; i<=100; i++)
            {
                if (i % 3 == 0)
                {
                    count++;
                }
            }
            Console.WriteLine(count);

        }
    }
}
