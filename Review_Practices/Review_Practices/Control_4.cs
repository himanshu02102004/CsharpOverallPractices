using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_Practices
{
    class Control_4

    {

        public static void four()
        {
            Console.WriteLine("Enter your speed limit");
            var limit = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the speed of car");
            var carspeed = Convert.ToInt32(Console.ReadLine());
            if(carspeed <limit)
            {
                Console.WriteLine(" ok");
            }

            else
            {
                const int dimeritpoint = 5;
                int vardimerit = (carspeed - limit) / dimeritpoint;

                if(vardimerit > 12)
                {
                    Console.WriteLine("license suspend");
                }
                else
                {
                    Console.WriteLine($" Demerit point are :" + vardimerit);
                }
            }




        }
    }
}
