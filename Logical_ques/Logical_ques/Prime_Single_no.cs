using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical_ques
{
    class Prime_Single_no
    {

       

        public static int isprime(int n)
        {
            int sum = 0;
            for (int i = 2; i <= n; i++)
            {
                int flag = 1;

                for (int j = 2; j <=  i / 2; j++)
                {
                    if (i % j == 0)
                    {
                        flag = 0;
                        break;
                    }
                }
                if (flag == 1)
                {
                    sum += i;
                }

            }

            return sum;
        }


        //public static void Main(string[] args)
        //{
        //    Console.WriteLine(isprime(10));
        //}
    }



}
