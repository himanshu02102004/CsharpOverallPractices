using System;
using ACCESS_MODIFIERS;
namespace Access_modifier2
{



    // child class example
    class Program2 : class1
    {
        public static void Main(String[] args)
        {
            Program2 c1 = new Program2();
            c1.show();
            Console.ReadLine();
        }
    }


    //class Program2
    //{
    //    public static void Main(String[] args)
    //    {
    //        class1 c1 = new class1();
    //        c1.Show1();
    //        Console.ReadLine();
    //    }
    //}
}
