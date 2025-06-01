using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical_ques
{
    class N_Square_Prime_no
    {

        static bool isprime(int num)
        {
            if (num < 2) return false;
            for(int i=2; i * i <=num; i++)
            {
                if (num % i == 0)
                    return false;
            }

            return true;
        }



        public static int  sumofprimenumQues6(int n)
        {
            int count = 0;
            int sum = 0;
            int num = 2;

            while(count < n)
            {
                if (isprime(num))
                {
                    sum += num * num;
                    count++;
                }
                num++;
            }
            return sum;
        }

    }
}
