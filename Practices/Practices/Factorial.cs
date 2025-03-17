using System;

namespace Practices
{
    class Factorial
    { 
        public static void num()
        {
            Console.WriteLine("enter the number");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int inputs) && inputs >= 0)
            {
                var fac = 1;
                for (int i = inputs; i >= 1; i--)
                {
                    fac *= i;

                }
                Console.WriteLine(fac);
            }
            else
            {
                Console.WriteLine("invalid numebr");

            }





        }

    }
}
