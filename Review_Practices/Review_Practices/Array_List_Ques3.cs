using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_Practices
{
    class Array_List_Ques3
    {

        public static void Ques3()
        {
            var numbers = new List<int>();
            while(numbers.Count < 5)
            {
                Console.WriteLine("Enter the uniques number");
                var number = Convert.ToInt32(Console.ReadLine());
                if (numbers.Contains(number))
                {
                    Console.WriteLine("number already contain");
                    continue;
                }
                else
                {
                    numbers.Add(number);

                }

                numbers.Sort();
                foreach(var i in numbers)
                {
                    Console.WriteLine(i);
                }


            }
        }
    }
}
