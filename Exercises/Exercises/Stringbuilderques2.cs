using System;
using System.Collections.Generic;  
namespace Exercises
{
    public class Stringbuilderques2
    {
        public static void sec()
        {
            var numbers = new List<int>(); 

            while (true)
            {
                Console.WriteLine("Enter a number (or press Enter to exit): ");
                string press = Console.ReadLine();

              
                if (string.IsNullOrWhiteSpace(press))
                {
                    Console.WriteLine("Exiting...");
                    break;
                }

                
                if (!int.TryParse(press, out int number))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

              
                if (numbers.Contains(number))
                {
                    Console.WriteLine("Duplicate number!");
                }
                else
                {
                    numbers.Add(number);
                    Console.WriteLine($"Numbers so far: {string.Join(", ", numbers)}");
                }
            }
        }
    }
}
