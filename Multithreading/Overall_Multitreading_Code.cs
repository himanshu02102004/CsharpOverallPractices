//////////////////         Using Thread Class
using System;
using System.Threading;

class Program
{
	static void PrintNumbers()
	{
		for (int i = 1; i <= 5; i++)
		{
			Console.WriteLine($"Thread: {i}");
			Thread.Sleep(500); // Simulates work
		}
	}

	static void Main()
	{
		Thread t1 = new Thread(PrintNumbers);
		t1.Start(); // Start a new thread
		t1.Join();  // Wait for t1 to finish before continuing

		Console.WriteLine("Main thread finished.");
	}
}



////////////////////////////////////  Using Task 

/////Task (from System.Threading.Tasks) provides a higher-level way to run and manage threads.


using System;
using System.Threading.Tasks;

class Program
{
	static async Task PrintNumbersAsync()
	{
		await Task.Run(() =>
		{
			for (int i = 1; i <= 5; i++)
			{
				Console.WriteLine($"Task: {i}");
			}
		});
	}

	static async Task Main()
	{
		await PrintNumbersAsync();
		Console.WriteLine("Main method completed.");
	}
}



///////////////////////////   Parallel Processing with Parallel
///////////  For CPU-bound tasks, Parallel.ForEach() and Parallel.For() execute iterations in parallel.

using System;
using System.Threading.Tasks;

class Program
{
	static void Main()
	{
		Parallel.For(1, 6, i =>
		{
			Console.WriteLine($"Parallel Task: {i}");
		});

		Console.WriteLine("Main completed.");
	}
}
