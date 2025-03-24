using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Paraller_Library
{
    class ttask_code
    {

        public static void Done()
        {
            Task task1 = Task.Run(() => printnum());
            Console.WriteLine("-------");
            Task task2 = Task.Run(() => reverse());

            Task.WhenAll(task1, task2).Wait();
        }

        public static void printnum()
        {

            for(int i=1; i<=3; i++)
            {
                Console.WriteLine(i);
            }

        }

        public static void reverse()
        {
            for(int i=3; i>=1; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}
