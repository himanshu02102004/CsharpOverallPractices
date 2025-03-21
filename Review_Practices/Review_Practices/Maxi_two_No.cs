using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_Practices
{
    class Maxi_two_No
    {

        public static void Max()
        {
            Console.WriteLine("Enter the number 1");
            var number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the number 2");
            var number2 = Convert.ToInt32(Console.ReadLine());
            var max=(number1  > number1) ? number1: number2;
            Console.WriteLine("Max is " + max);

        }
    }
}
