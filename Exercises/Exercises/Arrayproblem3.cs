using System;
using System.Collections.Generic;

namespace Exercises
{
    class Arrayproblem3
    {
        public static void third()
        {
            Console.WriteLine("enter the number ");
            List<int> numbers = new List<int>();
            while (numbers.Count < 5)
            {
                if(int.TryParse(Console.ReadLine(),out int nums))
                {
                    if (numbers.Contains(nums))
                    {
                        
                        Console.WriteLine("number already contain");
                    }
                    else
                    {
                        numbers.Add(nums);
                    }
                }
                else
                {
                  Console.WriteLine("numbers are invalid please enter the proper numbers");
                }

            }
            numbers.Sort();
            Console.WriteLine($"your sorted number is " + string.Join(" ", numbers));



            }

        
        }
    }
