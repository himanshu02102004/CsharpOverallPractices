using System;
using System.Collections.Generic;

namespace Exercises
{
    class Arrayexercises4
    {
        public static void four()
        {   
               
            List<int> numbers = new List<int>();
            while (true)
            {
                Console.WriteLine("enter the number or QUIT to exit page");
                string got = Console.ReadLine();
                if (got.ToLower() == "quit")
                {
                    break;
                }

                if (int.TryParse(got, out int num))
                {

                    if (numbers.Contains(num))
                    {
                        Console.WriteLine("no. already contain");
                    }
                    else
                    {
                        numbers.Add(num);
                    }
                }
                else
                {
                    Console.WriteLine("enter the valid number");
                }
            }



                Console.WriteLine("unique no. entered are");
                
                    Console.WriteLine(string.Join(" ",numbers));
                
            

        }
    }
}
