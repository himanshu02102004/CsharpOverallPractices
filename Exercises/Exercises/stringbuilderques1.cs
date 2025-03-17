using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    class stringbuilderques1
    {
        public static  void ques()
        {
            Console.WriteLine("enter the value in hypen");
            string input = Console.ReadLine();
            List<int> numbers = new List<int>();



            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("invalid input");
            }

            string[] parts = input.Split('-');
            foreach (var part in parts)
            {
                string trimmedPart = part.Trim(); 

                if (int.TryParse(trimmedPart, out int num))
                {
                    numbers.Add(num); 
                }
            }


            bool isIncreasing = true, isDecreasing = true;
            for(int i =1; i<numbers.Count; i++) 
            {
                if (numbers[i] != numbers[i-1] +1)
                {
                    isIncreasing = false;
                }
                if (numbers[i] != numbers[i - 1] - 1)
                {
                    isDecreasing = false;
                }
            }

            if(isIncreasing || isDecreasing)
             Console.WriteLine("consecutive");
            else
                Console.WriteLine("not consecutive");

            Console.ReadKey();

        }
    }
}
