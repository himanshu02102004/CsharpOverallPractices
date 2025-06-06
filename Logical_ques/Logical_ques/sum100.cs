//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Logical_ques
//{
//    //class sum100
//    //{
//    //}

//    // Online C# Editor for free
//    // Write, Edit and Run your C# code using C# Online Compiler

//    using System;
//    using System.Collections.Generic;

//    public class HelloWorld
//    {
//        static List<int> pair(int[] arr, int target)
//        {

//            for (int i = 0; i < arr.Length - 1; i++)
//            {
//                for (int j = i + 1; j < arr.Length; j++)
//                {
//                    if (arr[i] + arr[j] == target)
//                    {
//                        return new List<int> { i, j };
//                    }
//                }
//            }

//            return new List<int>();


//        }


//        public static void Main(string[] args)
//        {
//            int[] arr = { 80, 60, 10, 50, 30, 100, 0, 50 };
//            int target = 100;
//            List<int> result = pair(arr, target);

//            int indx1 = result[0];
//            int indx = result[1];

//            if (result.Count > 0)
//            {

//                Console.WriteLine("pair found at indices" + result[0] + "and" + result[1]);
//                Console.WriteLine("value are " + arr[result[0]] + "and" + arr[result[1]]);
//            }
//            Console.WriteLine(result);

//        }
//    }
//}



//// second approach

/////[Expected Approach] Using Hash Map or Dictionary - O(n) Time and O(n) Space




///// C# Program to count pairs with given sum using Hash Map

//using System;
//using System.Collections.Generic;

//class GfG
//{

//    // Returns number of pairs in arr[0...n-1] with sum 
//    // equal to 'target'
//    static int countPairs(int[] arr, int target)
//    {
//        Dictionary<int, int> freq =
//                              new Dictionary<int, int>();
//        int cnt = 0;

//        for (int i = 0; i < arr.Length; i++)
//        {

//            // Check if the complement (target - arr[i])
//            // exists in the map. If yes, increment count
//            if (freq.ContainsKey(target - arr[i]))
//            {
//                cnt += freq[target - arr[i]];
//            }

//            // Increment the frequency of arr[i]
//            if (freq.ContainsKey(arr[i]))
//                freq[arr[i]]++;
//            else
//                freq[arr[i]] = 1;
//        }
//        return cnt;
//    }

//    public static void Main(
//    {
//        int[] arr = { 1, 5, 7, -1, 5 };
//        int target = 6;
//        Console.WriteLine(countPairs(arr, target));
//    }
//}