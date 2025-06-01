using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical_ques
{
    class Fibo_Recursion
    {



       public  static void fiborecur(int a, int b, int count, int len)
        {
            if (count <= len)
            {
                Console.WriteLine(a + " ");
                fiborecur(b, a + b, count + 1, len);
            }
        }

        //public static void Main(string[] args)
        //{
        //    fiborecur(0, 1, 1, 5);

        //}
    }
}
