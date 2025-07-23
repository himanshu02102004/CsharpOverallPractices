//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;




//1299. Replace Elements with Greatest Element on Right Side

//namespace Logical_ques
//{
//    class Leetcode_1299
//    {

//        public class Solution
//        {
//            public int[] ReplaceElements(int[] arr)
//            {
//                for (int i = 0; i < arr.Length - 1; i++)
//                {

//                    int max = int.MinValue;
//                    for (int j = i + 1; j < arr.Length; j++)
//                    {
//                        if (arr[j] > max)
//                        {
//                            max = arr[j];
//                        }
//                        arr[i] = max;
//                    }
//                }
//                arr[arr.Length - 1] = -1;
//                return arr;

//            }
//        }
//    }
//}
