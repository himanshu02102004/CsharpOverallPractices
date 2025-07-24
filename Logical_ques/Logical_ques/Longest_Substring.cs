//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Logical_ques
//{
//    class Longest_Substring
//    {
//    }


//    // Online C# Editor for free
//// Write, Edit and Run your C# code using C# Online Compiler

//using System;

//public class HelloWorld
//    {
//        public static void Main(string[] args)
//        {
//            string s1 = "aaabbcccddddeee";
//            int[] f1 = new int[26];
//            for (int i = 0; i < s1.Length; i++)
//            {
//                f1[s1[i] - 'a']++;
//            }
//            int max = 0;
//            char maxchar = 'a';
//            for (int j = 0; j < 26; j++)
//            {
//                if (max < f1[j])
//                {
//                    max = f1[j];
//                    maxchar = (char)(j + 'a');
//                }
//            }
//            Console.WriteLine("max " + max);
//            Console.WriteLine("freqchar " + maxchar);
//        }
//    }
//}
