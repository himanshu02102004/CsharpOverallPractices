using System;
namespace OPERATOR_OVERLOADING
{




    class Newclass
    {
        public string str;
        public int num;

        public static Newclass operator +(Newclass obj1 , Newclass obj2)
        {
            Newclass obj3 = new Newclass();
            obj3.str = obj1.str + obj2.str;

            obj3.num = obj1.num + obj2.num;
            return obj3;
        }
    }
    class Program
    {
        public static void Main(String[] args)
        {

            Newclass obj1 = new Newclass();
            obj1.str = "himanshu";
            obj1.num = 23;


            Newclass obj2 = new Newclass();
            obj2.num = 25;
            obj2.str = "mishra";

            Newclass obj3 = new Newclass();
            obj3 = obj1 + obj2;

            Console.WriteLine(obj3.str);
            Console.WriteLine(obj3.num);
            Console.ReadLine();


        }
    }
}