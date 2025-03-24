using System;


namespace Delegate
{
    class Program
    {



        //// delegate with Single-Cast Delegate 



        public delegate void PrintDelegate(string message);

        public static void PrintMessage(string msg)
        {
            Console.WriteLine(msg);
        }


        public static void Main(string[] args)
        {
            // when method printmesage is not static

            //Program obj = new Program();
            //PrintDelegate obj1 = new PrintDelegate(obj.PrintMessage);

            //obj1("hey");



            /// method become static printmesage
            /// 
           PrintDelegate obj= PrintMessage;
            obj("himanshu");












            // delegate with multiple method



            //public delegate void addnum(int a, int b);
            //    public delegate void subnum(int a, int b);


            //    public void sum(int a, int b)
            //    {
            //        Console.WriteLine(" (100 +40) = {0}", a+b);
            //    }

            //    public void subtract(int a,int b)
            //    {
            //        Console.WriteLine(" (100 -40) = {0}",a-b);

            //    }


            //    public static void Main(String[] args)
            //    {
            //        Program obj = new Program();

            //        addnum obj2 = new addnum(obj.sum);
            //        subnum obj3 = new subnum(obj.subtract);


            //        ///// pass the values to the methods by delegate object
            //        ///
            //        obj2(100, 50);
            //        obj3(100, 60);
        }
    }
}