
using System;

namespace Exercises
{
    class Prevsums
    {
        static static void sumss()
        {
            int sum = 0;
            string input;

            do
            {
                Console.Write("Enter a number (or type 'ok' to exit): ");
                input = Console.ReadLine();

                if (input.ToLower() != "ok")
                {
                    if (int.TryParse(input, out int number)) 
                    {
                        sum += number; 
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }

            } while (input.ToLower() != "ok");

       
            Console.WriteLine($"Total sum of entered numbers: {sum}");
        }
    }
}
