using System;
using System.Collections;
using System.Threading.Channels;

namespace NGSTACK_DEMO
{
    class Program
    {
        public static void Main(string[] args)
        {
            Stack myStack = new Stack();
            myStack.Push("anil");
            myStack.Push(5);
            myStack.Push(5.11);
            myStack.Push(false);
            myStack.Push("mishra");
            myStack.Push(null);
            myStack.Push("mishra");


            //  Console.WriteLine(myStack.Peek());



            //// in other ways to store the value
            //string a = myStack.Peek().ToString();
            //Console.WriteLine(a);


            // for pop



            //foreach (object item in myStack)
            //{
            //    Console.WriteLine(item);
            //}

            //myStack.Pop();


            //foreach (object item in myStack)
            //{
            //    Console.WriteLine(item);
            //}


            // for contain
          //  Console.WriteLine(myStack.Contains("mishra"));

            //for clear
            myStack.Clear();
            foreach (object item in myStack)
            {
                Console.WriteLine(item);
            }



            // Console.WriteLine(myStack.Count);

            //foreach (object item in myStack)
            //{
            //    Console.WriteLine(item);
            //}
            Console.ReadLine();

        }
    }
}
