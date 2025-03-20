using System;
using System.Collections;
using System.Net.Http.Headers;
namespace NG_QueueDemo
{
    class Program
    {
        public static void Main (String[] args)
        {
            Queue myQueue = new Queue();
            myQueue.Enqueue("ALI");
            myQueue.Enqueue(24.5);
            myQueue.Enqueue('r');
            myQueue.Enqueue(false);

            Console.WriteLine(myQueue.Count);

            while(myQueue.Count > 0)
            {
                Console.WriteLine(myQueue.Dequeue());
            }
            Console.WriteLine(myQueue.Count);



            Console.WriteLine(myQueue.Contains("ALI"));

            myQueue.Clear();

            foreach (object item in myQueue)
            {
                Console.WriteLine(item);
            }

       //     Console.WriteLine(myQueue.Count);

            //myQueue.Dequeue();

            //Console.WriteLine("---------------------------");


            //foreach (object item in myQueue)
            //{
            //    Console.WriteLine(item);
            //}


            //myQueue.Dequeue();

            //Console.WriteLine("---------------------------");

            //foreach (object item in myQueue)
            //{
            ////    Console.WriteLine(item);
            //}


            Console.ReadLine();
        }
    }
}