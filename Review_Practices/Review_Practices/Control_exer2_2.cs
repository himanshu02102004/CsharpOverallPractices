using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Review_Practices
{
    class Control_exer2_2
    {
        public static void Exer2()
        {
            var sum = 0;
            while (true)
            {
                Console.WriteLine("Enter the number for sum or enter ok for exit");
                var input = Console.ReadLine();
                if (input.ToLower() == "ok")
                {
                    break;
                }

                sum += Convert.ToInt32(input);
                Console.WriteLine($"your sum is :  {sum} ");


            }
        }
    }
}
