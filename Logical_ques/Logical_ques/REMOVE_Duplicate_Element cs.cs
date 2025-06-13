using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical_ques
{
    class REMOVE_Duplicate_Element_cs
    {
        /// this is code for find duplicate element in an array using two approaches


        /////////   FIRST APPROACH USING LINQ //////////


        //static List<int> duplicate(List<int> arr)
        //{
        //    var freq = arr.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        //    var res = freq.Where(entry => entry.Value > 1).Select(entry => entry.Key).ToList();
        //    return res;
        //}

        ////public static void Main(string[] args)
        ////{
        ////    List<int> arr = new List<int> { 1, 1, 23, 45, 2, 2, 67, 8, 8, 99 };
        ////    List<int> result = duplicate(arr);
        ////    foreach(int num in result)
        ////    {
        ////        Console.WriteLine(num);
        ////    }
        ////}
        ///







      public  static List<int> duplicatess(List<int> arr)
        {
            var freq = arr.GroupBy(x => x).ToDictionary(g => g.Key , g => g.Count());
            var res = freq.Where(entry => entry.Value > 1).Select(entry => entry.Key).ToList();
            return res;

        }

      










        /////////   SECOND APPROACH USING NAIVE APPROACH //////////


        //        public static List<int> findduplicate(List<int>  arr)
        //        {
        //            List<int> res=new List<int>();
        //            for(int i=0; i<arr.Length-1; i++)
        //            {
        //                for(int j=i +1; j<arr.Length; j++)
        //                {
        //                    if (arr[i]== arr[j])
        //                    {
        //                        if (!res.Contains(arr[i]))
        //                        {
        //                            res.Add(arr[i]);
        //                        }


        //                        break;
        //                    }

        //                }
        //            }

        //            return res;
        //        }


        //        //public static void Main(string[] args)
        //        //{
        //        //    int[] arr = { 12, 1, 4, 56, 4, 12, 45, 12, 4, 1 };
        //        //    List<int> result = findduplicate(arr);
        //        //    foreach(int num in result)
        //        //    {
        //        //        Console.WriteLine(num);
        //        //    }
        //        //}

    }
}
