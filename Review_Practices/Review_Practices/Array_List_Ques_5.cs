using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_Practices
{
    class Array_List_Ques_5
    {
        public static void Ques5()
        {
            string[] elements;
           
            while (true)
            {
               Console.WriteLine("enter the element by separated with comma");
                var input = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid List");
                    continue;
                }
                else
                {
                    elements = input.Split(',');
                    if (elements.Length < 5)
                    {
                        Console.WriteLine("Invalid List");
                        continue;
                    }
                    else
                    {
                        break;
                    }
               
                }  
            }

            var numbers = new List<int>();
            foreach(var num in elements)
            {
                numbers.Add(Convert.ToInt32(num));
            }


            var smallest = new List<int>();
            while(smallest.Count < 3)
            {
               var min = numbers[0];
               foreach(var num in numbers)
                {
                    if (num < min)
                    {
                        min = num;
                    }
                }

                smallest.Add(min);
                numbers.Remove(min);

            }
            Console.WriteLine("your smallest number will be");
            foreach (var num in smallest)
            {
                Console.WriteLine(num);
            }









        }
    }
}
