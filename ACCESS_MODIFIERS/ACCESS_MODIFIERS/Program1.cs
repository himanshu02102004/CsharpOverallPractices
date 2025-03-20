using System;
namespace ACCESS_MODIFIERS
{
    // *********************public class  example***********************************//





    //    public class class1
    //    {
    //        public void Show1()
    //        {
    //            Console.WriteLine("this is the public method");
    //        }

    //        //public void Show2()
    //        //{
    //        //    class1 c1 = new class1();
    //        //    c1.Show1();                           // member of same class can access each other

    //        //}


    //    }




    //    // child class  example


    //    class Program1:class1
    //    {
    //        public static void Main(String[] args)
    //        {

    //            Program1 c1 = new Program1();

    //            c1.Show1();
    //            Console.ReadLine();
    //        }
    //    }








    //    //class Program
    //    //{
    //    //    public static void Main(String[] args)
    //    //    {

    //    //        class1 c1 = new class1();
    //    //        //    c1.Show2();
    //    //        c1.Show1();
    //    //        Console.ReadLine();
    //    //     }
    //    //}
    //}

















    //    // **********************PRIVATE CLASS EXAMPLE ******************************//


    //    public class class1
    //    {
    //        private void show()
    //        {
    //            Console.WriteLine("this is public method..");
    //        }
    //    }


    //    //class Program1
    //    //{
    //    //    static void Main(string[] args)
    //    //    {
    //    //        class1 c1 = new class1();
    //    //        c1.show();
    //    //        Console.ReadLine(); 
    //    //    }
    //    //}









    //    //child class  example
    //    class Program1:class1
    //    {
    //        static void Main(string[] args)
    //        {
    //            Program1 c1 = new Program1();
    //            c1.show();
    //            Console.ReadLine();
    //        }
    //    }
    //}








    // *********************** PROTECTED CLASS EXAMPLE************************************************//




    //    public class class1
    //    {
    //        protected void show()
    //        {
    //            Console.WriteLine("  hey this is public method..");
    //        }
    //    }


    //    //class Program1
    //    //{
    //    //    static void Main(string[] args)
    //    //    {
    //    //        class1 c1 = new class1();
    //    //        c1.show();
    //    //        Console.ReadLine(); 
    //    //    }
    //    //}









    //    //child class  example
    //    //class Program1 : class1
    //    //{
    //    //    static void Main(string[] args)
    //    //    {
    //    //        Program1 c1 = new Program1();
    //    //        c1.show();
    //    //        Console.ReadLine();
    //    //    }
    //    //}
    //}












    //*******************************INTERNAL MODIFIERS***********************************************

    public class class1
    {
        internal  void show()
        {
            Console.WriteLine("  hey this is public method..");
        }
    }


    //class Program1
    //{
    //    static void Main(string[] args)
    //    {
    //        class1 c1 = new class1();
    //        c1.show();
    //        Console.ReadLine();
    //    }
    //}









  
  ///  child class example
 
    class Program1 : class1
    {
        static void Main(string[] args)
        {
            Program1 c1 = new Program1();
            c1.show();
            Console.ReadLine();
        }
    }
}