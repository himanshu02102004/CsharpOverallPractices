using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical_ques
{
    class Missing_Sorted
    {

        public static void Missingg()
        {
            int[] arr = { 23, 26, 28, 30 };

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int curr = arr[i];
                int next = arr[i + 1];

                for (int missings = curr + 1; missings < next; missings++)
                {
                    Console.Write(missings + " ");
                }
            }
        }
    }
}