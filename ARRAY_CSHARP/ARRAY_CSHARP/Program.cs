using System;
using System.Numerics;
namespace ARRAY_CSHARP
{
    class Program
    {
        public static void Main(String[] args)
        {
            //JAGGED ARRAY
            int[][] my_array = new int[3][];
            my_array[0] = new[] { 11, 12, 13, 14, 15, 16, 26 };
            my_array[1] = new[] { 21, 22, 23, 24, 34, 32 };
            my_array[2] = new[] { 34, 45, 76, 45, 89, 90 };


            foreach(int[] item in my_array)
            {
                foreach(int i in item)
                {
                    Console.WriteLine(i);
                }
                
            }




            //for(int i=0; i<my_array.GetLength(0); i++)
            //{
            //    for(int j=0; j < my_array[i].Length; j++)
            //    {
            //        Console.Write(my_array[i][j] + " ");
            //    }
            //    Console.WriteLine();
            //}



            //Console.WriteLine(my_array[0][4]);















            // REACTANGULAR MULTI DIMENSIONAL ARRAY
            //int[,] my_array = new int[3, 4]
            //{
            //    { 4,3,4,6 },
            //    { 5,8,9,10},
            //    {8,9,13,14 }

            //};

            //foreach(int item in my_array)
            //{
            //    Console.WriteLine(item);
            //}




            //for(int i=0; i< my_array.GetLength(0); i++)
            //{
            //    for(int j=0; j< my_array.GetLength(1); j++)
            //    {
            //        Console.Write(my_array[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            //Console.WriteLine(my_array[1,2]);
            //Console.WriteLine(my_array.GetLength(0));// row length
            //Console.WriteLine(my_array.GetLength(1));// col length
            //Console.WriteLine(my_array.Rank);// overall dimension
            Console.ReadLine();
        }
    }
}
