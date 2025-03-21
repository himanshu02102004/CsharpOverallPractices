using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_Practices
{
    class Control
    {

        public static void Guess()
        {

             Random random = new Random();
            int numbers = random.Next(1, 10);

            int attempt = 4;
            while(attempt > 0)
            {
                Console.WriteLine("enter the number to guess ");
                var input = Console.ReadLine();

               if(!int.TryParse(input,out int num))
                {
                    Console.WriteLine("invalid no");
                    continue;
                }
                if (num == numbers)
                {
                    Console.WriteLine("valid no.");

                    break;
                }
                else
                {
                    attempt--;
                    if(attempt > 0)
                    {
                        Console.WriteLine( $" attempt left { attempt}");

                    }
                    else
                    {

                        if (attempt == 0)
                        {
                            Console.WriteLine( $" the random numbers are :{numbers} ");


                        }
                        Console.WriteLine("game over");
                    }
                }



            }

        }
        
    }
}
