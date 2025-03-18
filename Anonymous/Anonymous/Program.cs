using System;

namespace Anonymous
{


    public delegate void myDelegate(int number);


       class  Program {
    
        //normal function 

        //public static void Mymethod(int a)
        //{
        //    a += 10;
        //    Console.WriteLine(a);
        //}



        // anonymous fucntion can pased as parameter

        public static void Mymethod(myDelegate del,int a)
        {

            a += 10;// 15
            del.Invoke(a);

        }



        public static void Main(String[] args)
        {

            // annonymous function passed as paraameter
            Program.Mymethod(delegate (int b) { b += 10; Console.WriteLine(b); }, 5);// int b passes 15 then print 25
















            //myDelegate obj = delegate (int a)  // anonymous method
            //{

            //    a += 10;
            //    Console.WriteLine(a
            //        );

            //};
            //obj.Invoke(5);
            //Console.ReadLine();
        }
    }
}