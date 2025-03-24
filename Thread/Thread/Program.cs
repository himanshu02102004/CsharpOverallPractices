using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread
{
    class Program
    {
        public static void Main(string[] args)
        {
            Test1();
            Test2();


        }


        public static void Test2()
        {
            Console.WriteLine(" TEST 2");
        }
        public  static void Test1()
        {
            Console.WriteLine(" TEST 1" + 1);
        }
    }
}
