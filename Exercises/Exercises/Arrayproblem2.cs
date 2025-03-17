using System;

namespace Exercises
{
    class Arrayproblem2
    {
        public static void second()
        {

            Console.WriteLine("enter the name");
            string name = Console.ReadLine();

            char[] charArray = name.ToCharArray();
            Array.Reverse(charArray);


            string reversename = new string(charArray);
            Console.WriteLine(reversename);






        }
    }
}
