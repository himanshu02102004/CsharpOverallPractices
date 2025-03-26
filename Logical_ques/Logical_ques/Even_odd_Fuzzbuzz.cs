using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical_ques
{
    class Even_odd_Fuzzbuzz
    {

      public static void Ques3()
        {
            for(int i=1; i <=29; i++)
            {
                if(i % 2 == 0)
                {
                    Console.WriteLine( $" fizz: {i} ");
                }
                else if (isPrime(i))
                {
                    Console.WriteLine( $"fizz prime  buzz {i}");
                }

                else if( i % 2 != 0 )
                {
                    Console.WriteLine($"buzz {i}");

                }
            }
        }

        public static bool isPrime(int number)
        {
            if(number <= 1) return false;
            if (number <= 3) return true;
            if (number % 2 == 0 || number % 3 == 0) return false;

            for(int i=5; i * i <=number; i++)
            {
                if (number % i == 0 || number % (i + 2)  == 0) return false;
            }

            return true;
        }




    }
}
