//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Logical_ques
//{
//    class Palindrome
//    {
//    }
//}






//public class HelloWorld
//{
//    public static void Main(string[] args)
//    {
//        Console.Write("enter the number to check whether it is palindrome or not");

//        int num = int.Parse(Console.ReadLine());
//        int sum = 0;
//        int temp = num;

//        while (num > 0)
//        {
//            int nums = num % 10;
//            sum = sum * 10 + nums;

//            num = num / 10;
//        }

//        if (temp == sum)
//        {
//            Console.Write("it is num palindroem");
//        }
//        else
//        {
//            Console.Write("non");
//        }

//    }
//}




/////

////for string


////using System;

////public class HelloWorld
////{
////    public static void Main(string[] args)
////    {
////        Console.WrtieLine("enter the name for palindorme");
////        String name = Console.ReadLine();
////        String reverse = String.Empty;

////        for (i = name.Length - 1; i > 0; i--)
////        {
////            reverse = name[i];
////        }
////        if (reverse == name)
////        {
////            Console.Write("it is palindrome");
////        }
////        else
////        {
////            Console.Write("not palindrome");
////        }
////    }
////}
///



//////////  PALINDROME ORIGINAL SAVE 
//public class Solution
//{
//    public bool IsPalindrome(int x)
//    {
//        int rev = 0;
//        int org = x;
//        while (x > 0)
//        {
//            int dev = x % 10;
//            rev = rev * 10 + dev;
//            x = x / 10;


//        }
//        return rev == org;
//    }
//}