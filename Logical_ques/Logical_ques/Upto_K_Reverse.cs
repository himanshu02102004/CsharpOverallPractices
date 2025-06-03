//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Logical_ques
//{



//////////FIRST METHOD///////////////////////////





//    // Online C# Editor for free
//    // Write, Edit and Run your C# code using C# Online Compiler

//    using System;

//    public class HelloWorld
//    {
//        public static void Main(string[] args)
//        {
//            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
//            int k = 4;
//            for (int i = 0; i < k / 2; i++)
//            {
//                int temp = arr[i];
//                arr[i] = arr[k - 1];
//                arr[k - 1] = temp;

//            }
//            foreach (int i in arr)
//            {
//                Console.WriteLine(i);
//            }
//        }
//    //}
//}









//////////////////////////SECOND METHOD//////
///

// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

//using System;

//public class HelloWorld
//{
//    public static void Main(string[] args)
//    {
//        int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
//        int k = 4;
//        int i = 0;
//        while (i < k / 2)
//        {
//            int temp = arr[i];
//            arr[i] = arr[k - 1];
//            arr[k - 1] = temp;
//            i++;
//        }
//        foreach (int j in arr)
//        {
//            Console.WriteLine(j);
//        }
//    }
//}