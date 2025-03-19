using System;
namespace Nested_For
{
    class Program
    {
        public static void Main(String[] args)
        {
            for(int i=1; i<=5; i++)
            {
                for(int j=i; j>=1; j--)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            Console.WriteLine("your code have been executed");
            Console.ReadLine();
        }
    }
}