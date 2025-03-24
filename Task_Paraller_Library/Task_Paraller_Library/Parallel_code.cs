using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Paraller_Library
{
    class Parallel_code
    {
        public static void overall()
        {
            List<string> data = new List<string> { "hey", "himanshu", "mishra" };


            //// for parallel for each
            //Parallel.ForEach(data, ele =>
            //{


            //    Console.WriteLine($" Data => {ele} on thread :-   " +
            //        $"{System.Threading.Thread.CurrentThread.ManagedThreadId}" );













            //// paraller item

            //Parallel.ForEach(data, ele =>
            //{
            //    Console.WriteLine($" data => [{ele} ] on thread :- " +
            //        $"{System.Threading.Thread.CurrentThread.ManagedThreadId}");
            //});

            //// In the above code we use the Parallel.ForEach() method executes the data collection 
            ///on the separate thread as shown in the output and
            ///note that each time we run the program the output will be different each time.





            ///// parallel invoke


            Parallel.Invoke(

             () => Console.WriteLine($" data => [{data[1]}]  on thread is :- " +
                    $"{System.Threading.Thread.CurrentThread.ManagedThreadId}"),
             () => Console.WriteLine($" data => [{data[0]}] on thread is :- " +
                     $"{System.Threading.Thread.CurrentThread.ManagedThreadId} "),
            () => Console.WriteLine($" data => [{data[2]}] on thread is :- " +
                     $"{System.Threading.Thread.CurrentThread.ManagedThreadId} ")


             );

        }
    }
}
