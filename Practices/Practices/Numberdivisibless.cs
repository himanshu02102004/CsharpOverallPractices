using System;
namespace Practices
{
    class Numberdivisibless
    {
        public static void Divisibles()
        {
            var count = 0;
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    count++;
                }
             }

                Console.WriteLine($"Total no. is divisible by 3 is:  {count}");
           
        }
    }
}
