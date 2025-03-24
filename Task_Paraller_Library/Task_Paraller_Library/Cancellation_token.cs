// Implementation of Multithreading in C# using 
// Parallel.ForEach with CancellationToken support
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Task_Paraller_Library {
    class Cancellation_token
    {
        static void done()
        {
            List<string> data = new List<string> { "Hello", "Geek", "How", "Are", "You" };

            // Create a CancellationTokenSource
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            // Create a task that uses the CancellationToken
            Task.Run(() =>
            {
                try
                {
                    Console.WriteLine("Task started.");
                    Parallel.ForEach(data, new ParallelOptions { CancellationToken = token }, item =>
                    {
                        // Check for cancellation
                        token.ThrowIfCancellationRequested();
                        Console.WriteLine($"Data [{item}] on thread: {Thread.CurrentThread.ManagedThreadId}");

                    });
                    Console.WriteLine("Task completed.");
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Task was canceled.");
                }
            }, token);


            Task.Delay(200).Wait();

            // Cancel the task
            cts.Cancel();

            // Dispose the CancellationTokenSource
            cts.Dispose();

            Console.WriteLine("Main method completed");
        }
    }

}