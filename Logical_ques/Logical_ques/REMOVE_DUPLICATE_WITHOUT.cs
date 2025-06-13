 using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logical_ques
{
    class REMOVE_DUPLICATE_WITHOUT
    {
        public static int[] removeduplicate(int [] arr)
        {
            int n = arr.Length;
            int[] result = new int[n];

            int index = 0;

            for(int i=0; i< n; i++)
            {
                bool isduplicate = false;

            

                for(int j=0; j< i; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        isduplicate = true;
                        break;
                    }
                }


                if (!isduplicate)
                {
                    result[index] = arr[i];
                    index++;
                }


            }


            return result;


        }
        
    }
}
