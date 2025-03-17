using System;

namespace Practices
{
     class Stringbuilder3
     {
        public static void ques()
        {
            Console.WriteLine("Enter the time ");
            string input = Console.ReadLine();

            if (IsValidTime(input))
            {
                Console.WriteLine("Ok");
            }
            else
            {
                Console.WriteLine("Invalid Time");
            }
        }

        private static bool IsValidTime(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            string[] timeParts = input.Split(':');

            if (timeParts.Length != 2)
                return false;

            if (int.TryParse(timeParts[0], out int hours) && int.TryParse(timeParts[1], out int minutes))
            {
                return hours >= 0 && hours < 24 && minutes >= 0 && minutes < 60;
            }

            return false;
        }



     }
}
