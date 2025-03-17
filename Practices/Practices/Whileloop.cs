using System;

namespace Practices
{
    class Whileloop
        {

        public static void whi()
        {
            while (true)
            {

                Console.WriteLine("enter the name");
                var input = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("@echo: " + input);
                    continue;
                }
                break;


            }
        }   }
}
