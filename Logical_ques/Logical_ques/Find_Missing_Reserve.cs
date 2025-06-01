using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical_ques
{
    class Find_Missing_Reserve
    {




        public static void Missing()
        {
            int[] arr = new int[] { 34,23,26,28 };
            for (int i = 0; i < arr.Length - 1; i++)
            {

                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                    }

                }
            }
            Console.Write("Sorted Array ");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }


            Console.WriteLine("Missing number ");
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int cur = arr[i];
                int next = arr[i + 1];

                for (int mising = cur + 1; mising < next; mising++)
                {
                    Console.WriteLine(mising + " ");

                }

            }






        }
    }
}

