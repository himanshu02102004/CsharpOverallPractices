using System;

namespace Exercises
{
    class Presums
    {
        public static void sums()
        {

            Console.WriteLine("enter the value or type OK to exit");
            int total = 0;
            string input;
            
            do
            {
                  input=Console.ReadLine();
             
                if(input.ToLower()!= "ok")
                {
                    if (int.TryParse(input, out int number)){
                        total += number;
                    }
                    else
                    {
                        Console.WriteLine("number is invalid");
                    }
                }

            } while( input.ToLower() !=  "ok");
            Console.WriteLine($"total sum of entered number: {total} ");


        }
    }
}
