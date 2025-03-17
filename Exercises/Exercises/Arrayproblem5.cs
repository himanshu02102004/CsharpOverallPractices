using System;
using System.Globalization;
using System.Linq;

namespace Exercises
{



    partial class Arayexercises
    {
        class Arrayproblem5
        {
            public static void five()
            {

                while (true) {
                    Console.WriteLine("enter the number alteast 5 number in comma format");
                    var input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("invalid number please try again ");
                        continue;
                    }

                    var number = input.Split(',')
                              .Select(s => s.Trim())
                              .Where(s => int.TryParse(s, out _))
                              .Select(int.Parse)
                              .ToList();

                    if (number.Count < 5)
                    {
                        Console.WriteLine("invalid no. you must have to enter at least five number");
                        continue;
                    }


                    var smallestnumber = number.OrderBy(n => n).Take(3);
                    Console.WriteLine("the smallest number is " + string.Join(" ", smallestnumber));
                    break;


                }
            }
        }
    }
}
