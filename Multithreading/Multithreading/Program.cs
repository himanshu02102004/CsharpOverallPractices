using System;
using System.Threading;

namespace Multithreading
{
    class Program
    {
        public static void Test1()
        {
            for (int i = 1; i < 1000; i++)
            {
                Console.WriteLine($"Test1: {i}");
            }
        }

        public static void Test2()
        {
            for (int i = 1; i < 100; i++)
            {
                Console.WriteLine($"Test2: {i}");
            }
        }

        public static void Test3()
        {
            for (int i = 1; i < 100; i++)
            {
                Console.WriteLine($"Test3: {i}");
            }
        }

        public static void Main(string[] args)
        {
            Thread p1 = new Thread(Test1);
            Thread p2 = new Thread(Test2);
            Thread p3 = new Thread(Test3);

            p1.Start();
            p1.Join(); 

            Console.WriteLine("--------------------------------");

            p2.Start();
            p3.Start(); 

            p2.Join();
            p3.Join();  // used for proper execution of threads in sequence

            Console.WriteLine("All threads have completed.");
        }
    }
}
