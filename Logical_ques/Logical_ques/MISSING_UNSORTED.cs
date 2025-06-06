using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace Logical_ques
{
    class MISSING_UNSORTED
    {

        public static int Missingunsort(int [] arr)
        {
       
             
            int n = arr.Length + 1;

            int[] hash = new int[n + 1];

            for( int i =0; i< n-1; i++)
            {
                hash[arr[i]]++;
            }

            for (int i = 1; i <= n; i++)
            {
                if (hash[i] == 0)
                {
                    return i;
                }

            }

            return -1;

        }
    }
}
