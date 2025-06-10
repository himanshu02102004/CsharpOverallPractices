using System;

public class Class1
{
	

        
      public  static void SORTED()
        {
            int[] arr = { 5, 2, 9, 1, 5, 6 };
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++) // number of passes
            {
                for (int j = 0; j < n - i - 1; j++) // compare adjacent
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // swap arr[j] and arr[j+1]
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("Sorted array:");
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
    }
     
    
    for (int i = 0; i<arr.Length - 1; i++)
            {
                int curr = arr[i];
    int next = arr[i + 1];

                for (int missings = curr + 1; missings<next; missings++)
                {
                    Console.Write(missings + " ");
                }
            }





}
}
