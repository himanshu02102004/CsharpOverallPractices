using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_Practices
{
    class Array_List_Ques4
    {

        public static void Ques4()
        {
            var numbers=new List<int>();
            while (true)
            {
                Console.WriteLine("Enter the number");
                var input = Console.ReadLine();
                if (input.ToLower() == "quit")
                    break;


                numbers.Add(Convert.ToInt32(input));

            }

            var unique=new List<int>();
            foreach (var number in numbers)
            {
                if (!unique.Contains(number))
                {
                    unique.Add(number);
                }
            }

            Console.WriteLine("Unique numbers :");

            foreach (var num in unique)
            {
                Console.WriteLine(num);
            }
            {
                
            }
        }
    }
}
