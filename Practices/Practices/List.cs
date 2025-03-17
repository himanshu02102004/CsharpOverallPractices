using System;
using System.Collections.Generic;
using System.Globalization;



namespace Practices
{
    class List
    {

        public static void Ques()
        {
            //var number = new[]  { 1, 2, 7 ,4,5};

            //Console.WriteLine("number length " + number.Length);


            //// indexo
            //var index = Array.IndexOf(number, 5);
            //Console.WriteLine("index at 9:" + index);



            ////clear

            //Array.Clear(number,0, 2);
            //Console.WriteLine("effect of clear");
            //foreach(int n in number)
            //{
            //    Console.WriteLine(n);
            //}


            //// sorting
            //Array.Sort(number);
            //Console.WriteLine("elements after sorting");
            //foreach(int n in number)
            //{
            //    Console.WriteLine(n);
            //}






            //Lists

            var number = new List<int>() { 1, 2, 3, 1 };
            number.Add(4);
            number.AddRange(new int[3] { 34, 56, 77, });
            foreach (int n in number)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine("index of 1 is  :" + number.IndexOf(3));
            Console.WriteLine("last index is :" + number.LastIndexOf(4));


            for (int i = 0; i < number.Count; i++)
            {
                if (number[i] == 1)
                {
                    number.Remove(number[i]);
                }
            }

            foreach (var n in number)
                Console.WriteLine(n);


            number.Clear();
            Console.WriteLine(number.Count);

            Console.ReadKey();  // Waits for a key press

        }
    }
}
