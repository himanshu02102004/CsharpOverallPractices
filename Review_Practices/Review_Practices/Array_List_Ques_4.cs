using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_Practices
{
    class Array_List_Ques_4
    {

        public static void Ques4()
        {
            var numbers = new List<int>();
            while (true)
            {
                Console.Write("Enter the num OR Type QUIT to exist");
                var input = Console.ReadLine();

                if (input.ToLower() == "quit")
                    break;

                numbers.Add(Convert.ToInt32(input));
            }

            var another = new List<int>();
            foreach (var num in numbers)
            {
                if (!another.Contains(num))
                {
                    another.Add(num);
                }
            }


            foreach (var num in another)
            {
                Console.WriteLine(num);
            }


            //var numbers = new List<int>();

            //while (true)
            //{
            //    Console.Write("Enter a number (or 'Quit' to exit): ");
            //    var input = Console.ReadLine();

            //    if (input.ToLower() == "quit")
            //        break;

            //    numbers.Add(Convert.ToInt32(input));
            //}

            //var uniques = new List<int>();
            //foreach (var number in numbers)
            //{
            //    if (!uniques.Contains(number))
            //        uniques.Add(number);
            //}


            //Console.WriteLine("Unique numbers:");
            //foreach (var number in uniques)
            //    Console.WriteLine(number);
        }
    }
}


