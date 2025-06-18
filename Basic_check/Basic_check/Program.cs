using System;
using System.Security.Cryptography.X509Certificates;

namespace Basic_check
{

    class Program
    {

        public static void Main(String[] args)
        {

            ////int a = 10;

            ////int b = a;

            //object f = 12;
            //object g = f;

            //Console.WriteLine($"  {g} ");

            ///  pass by value
            ///  
            //    int num = 100;
            //    Console.WriteLine("before cal  " + num);
            //    add(num);
            //    Console.WriteLine("after cal   " + num);

            //    Console.WriteLine("press any key");
            //    Console.ReadLine();




            //}
            //static void add(int x) {

            //    x = x + 5;
            //    Console.WriteLine("vaue inside the function "+ x);

            //}




            ////passs by reference
            ///


            //int x = 50;
            //Console.WriteLine("before cal" + x);
            //add(ref x);
            //Console.WriteLine("after cal " + x);
            //Console.WriteLine("press any key to exit");
            //Console.ReadLine();




            //static void add(ref int num)
            //{

            //    num = num * num;
            //    Console.WriteLine("value inside function " + num);

            //}


            /// use out return multiple
            

            //void display(int a,int b, out int quotient,out int remainder) {


            //    quotient = a / b;
            //    remainder = a % b;


            //}

            //int r, q;
            //display(10, 3, out r, out q);
            //Console.WriteLine($"queo{ r}  remain {q}");





            // same method with ref 

            //void display(int a,int b , ref int quo,ref int rem)
            //{

            //    quo = a / b;
            //    rem = a * b;

            //}

            //int s = 0, r = 0;
            //display(18, 3, ref s, ref r);
            //Console.WriteLine($" quo {s}  rem { r}");   same output 


            /// ref another value
            /// 

            void addbonus(ref int salary)
            {
                salary += 10;
            }
            int s = 100;
            addbonus(ref  s);
            Console.WriteLine($" {s}");













        }

    }
}