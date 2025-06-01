using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical_ques
{
    class Second_Larg_ques_1
    {

        public static void Ques1()
        {
            int[]  arr = { 12, 35, 1, 10,34,1, 35 };
            int length = int.MinValue;
            int seclen = int.MinValue;

            foreach(int num in arr)
            {
                if (num > length)
                {
                    
                    length = num;
                }
             }

            foreach (int num in arr)
            {
                if (num > seclen && num < length)
                {
                    seclen = num;
                }
            }

            Console.WriteLine("The second length is :" + seclen);

        }
    }
}



/// another method
/// 

// C# program to find the second largest element in the array
// using one traversal

//using System;

//class GfG
//{

//    // function to find the second largest element in the array
//    static int getSecondLargest(int[] arr)
//    {
//        int n = arr.Length;

//        int largest = -1, secondLargest = -1;

//        // finding the second largest element
//        for (int i = 0; i < n; i++)
//        {

//            // If arr[i] > largest, update second largest with
//            // largest and largest with arr[i]
//            if (arr[i] > largest)
//            {
//                secondLargest = largest;
//                largest = arr[i];
//            }

//            // If arr[i] < largest and arr[i] > second largest, 
//            // update second largest with arr[i]
//            else if (arr[i] < largest && arr[i] > secondLargest)
//            {
//                secondLargest = arr[i];
//            }
//        }
//        return secondLargest;
//    }

//    static void Main()
//    {
//        int[] arr = { 12, 35, 1, 10, 34, 1 };
//        Console.WriteLine(getSecondLargest(arr));
//    }
//}