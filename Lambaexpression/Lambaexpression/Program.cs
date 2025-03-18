using System;

namespace Lambaexpression
{
    //   public delegate int  myDelegate(int number);
    public delegate int myDelegate(int num1, int num2); 
    class Program
    {
        public static void Main(String[] args)
        {
            // example for two parameter
            myDelegate obj = (a, b) => a + b;
            Console.WriteLine(obj.Invoke(6,7));



            //example for expression
            //myDelegate obj = (a) => a * a;

            //myDelegate obj1 = (a) => a * a * a;

           // Console.WriteLine(obj1.Invoke(5));
           // Console.WriteLine(obj.Invoke(5));





            /// example for statement

            //myDelegate obj = (a) =>
            //{
            //    a += 10;
            //    Console.WriteLine(a);
            //};


            //obj.Invoke(5);
            //Console.ReadLine();


        }

    }
}
