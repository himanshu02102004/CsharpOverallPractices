using System;
using System.Collections.Generic;


namespace Practices
{
    class Stringbuilder4

    {
        public static void ques() {


            // NEW CASE FOR LOWER CASE AND UPPER CASE



            //var input = new List<String>();


            //while (true)
            //{

            //Console.WriteLine("enter the word for conversion");
            //var another = Console.ReadLine();


            //    if (string.IsNullOrEmpty(another)){
            //        Console.WriteLine("input is existing ");
            //        break;
            //    }


            //    String converted;

            //    if(another == another.ToLower())
            //    {
            //        converted = another.ToUpper();
            //    }
            //    else
            //    {
            //        converted= another.ToLower();
            //    }




            //    if (input.Contains(converted))
            //    {
            //        Console.WriteLine("word already contaim");
            //    }
            //    else
            //    {
            //       input.Add(converted);
            //        Console.WriteLine($" your converted word is : {converted}");
            //    }

            //}






            // STRING BUILDER 4 EXAMPLE




            Console.WriteLine("enter the word");
            string input = Console.ReadLine();

            if(string.IsNullOrEmpty(input))
            {
                Console.WriteLine("invalid input !");
                return;
            }

            string[] words=input.ToLower().Split(' ');

            string result = " ";

            foreach(string n in words)
            {
                result += char.ToUpper(n[0]) + n.Substring(1);
            }
            Console.WriteLine( $"your result will be coming is : { result}");


}  }   }    