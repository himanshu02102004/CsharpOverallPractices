using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_Practices
{
    class Array_List_Ques5
    {

        public static void Ques5()
        {
            string[] element;

            while (true)
            {
                Console.WriteLine("Enter your number by separated comma");
                var input = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(input))
                {
                    element = input.Split(',');
                    if (element.Length >= 5)
                    {
                        break;
                    }
                    Console.WriteLine("invalid list");
                }
            }

            var numbers = new List<int>();

            foreach(var number in element)
            {
                numbers.Add(Convert.ToInt32(number));
            }

            var smallest = new List<int>();
            while(smallest.Count < 3)
            {
                var min=numbers[0];
                foreach(var number in numbers)
                {
                    if (number < min)
                    {
                        min = number;
                    }
                    smallest.Add(min);

                    numbers.Remove(min);

                    foreach(var number in smallest)
                    
                        Console.WriteLine(" your 3 smallest number is : ");
                    { 

                    
                        foreach (var number in smallest)
                        
                            Console.WriteLine(number);
                        }
                    
                }
            }

        }
    }
}
