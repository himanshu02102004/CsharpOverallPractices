using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logical_ques
{
    class Remove_duplicate_witoutinbuilt
    {

        public static void Duplicate()
        {
            int[] arr = { 12, 12, 13, 15, 56, 67,89,90 };

            int n = arr.Length;

            int[] space = new int[n];

            int uniquecount = 0;
            for (int i = 0; i < n; i++) {

                bool isunique = false;
            for(int j=0; j < uniquecount; j++)
                {

                    if (arr[i]== space[j])
                    {
                        isunique = true;
                        break;
                    }

                }


             if(!isunique)
                {
                    space[uniquecount]= arr[i];
                    uniquecount++;
                }

            }

           for(int i=0;i < uniquecount; i++)
            {
                Console.WriteLine(space[i]);
            }




        }
    }
}
