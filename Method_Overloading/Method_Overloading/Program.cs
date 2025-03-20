using System;
namespace Method_Overloading
{
    class Program
    {


        public void test()
        {
            Console.WriteLine("method 1");
        }
        public void test(int n)
        {
            Console.WriteLine("method 2");
        }

        public void test(string n)
        {
            Console.WriteLine("method 3");
        }

        public void test(int n,string r)
        {
            Console.WriteLine("method 4");
        }
        




        
        public static void Main(String[] args)
        {
            Program n = new Program();
            n.test();

        }
    }
}