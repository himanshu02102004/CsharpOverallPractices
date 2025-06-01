using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical_ques
{
    class Even_check
    {

        public static void Evens()
        {
            List<int> number = new List<int>() { 23, 34, 12, 8, 13, 17 };
            Console.WriteLine("Even number in this list are ");
            foreach (int num in number)
            {
                if (num % 2 == 0)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }

        }
    }   }
