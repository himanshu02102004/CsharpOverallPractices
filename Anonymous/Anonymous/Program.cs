using System;

namespace Anonymous
{


    public delegate void myDelegate(int number);


       class  Program {

        //normal function  just but isme anonymous method nhi use kiya 

        //public static void Mymethod(int a)
        //{
        //    a += 10;
        //    Console.WriteLine(a);
        //}

        //public static void Main(String[] args)
        //{ 
        //    myDelegate Obj = new myDelegate(Program.Mymethod);
        //    Obj.Invoke(5);
        //    Console.ReadLine();


        //}












        ////normal anonymous function used
        //public  static void Main(string [] args)
        //{
        //    myDelegate obj = delegate (int a)
        //    {
        //        a += 10;
        //        Console.WriteLine(a);

        //        // return a              ///if delegate syntax which define have int
        //    };


        //    obj.Invoke(5);
        //    Console.ReadLine();
        //}











        // anonymous function can passed as parameter

        public static void Mymethod(myDelegate del, int a)
        {

            a += 10;// 15
            del.Invoke(a);

        }



        public static void Main(String[] args)
        {

            // annonymous function passed as paraameter
            Program.Mymethod(delegate (int b) { b += 10; Console.WriteLine(b); }, 5);    // int b passes 15 then print 25

            //}              (delegate(int b) { b+=10 .....  they are delegate function

        }
    }
}