using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical_ques
{
    //class sum100
    //{
    //}

    // Online C# Editor for free
    // Write, Edit and Run your C# code using C# Online Compiler

    using System;
    using System.Collections.Generic;

    public class HelloWorld
    {
        static List<int> pair(int[] arr, int target)
        {

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == target)
                    {
                        return new List<int> { i, j };
                    }
                }
            }

            return new List<int>();


        }


        public static void Main(string[] args)
        {
            int[] arr = { 80, 60, 10, 50, 30, 100, 0, 50 };
            int target = 100;
            List<int> result = pair(arr, target);

            int indx1 = result[0];
            int indx = result[1];

            if (result.Count > 0)
            {

                Console.WriteLine("pair found at indices" + result[0] + "and" + result[1]);
                Console.WriteLine("value are " + arr[result[0]] + "and" + arr[result[1]]);
            }
            Console.WriteLine(result);

        }
    }
}



// second approach

///[Expected Approach] Using Hash Map or Dictionary - O(n) Time and O(n) Space




//using System;

//class GfG
//{

//    // Function to count all pairs whose sum is 
//    // equal to the given target value
//    static int countPairs(int[] arr, int target)
//    {
//        int n = arr.Length;
//        int cnt = 0;

//        // Iterate through each element in the array
//        for (int i = 0; i < n; i++)
//        {

//            // For each element arr[i], check every
//            // other element arr[j] that comes after it
//            for (int j = i + 1; j < n; j++)
//            {

//                // Check if the sum of the current pair
//                // equals the target
//                if (arr[i] + arr[j] == target)
//                {
//                    cnt++;
//                }
//            }
//        }
//        return cnt;
//    }

//    static void Main()
//    {
//        int[] arr = { 1, 5, 7, -1, 5 };
//        int target = 6;
//        Console.WriteLine(countPairs(arr, target));
//    }
//}


