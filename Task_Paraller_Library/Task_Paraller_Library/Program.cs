using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Paraller_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread o1=new Thread(RunMillioIteration());
            //o1.Start();

            Parallel.For(0,1000000, x=> RunMillionIteration());
            Console.Read();
        }



        private static void RunMillionIteration()
        {
            string x = " ";
            for(int iIndex=0; iIndex< 1000000; iIndex++)
            {
                x = x + " s"; 
            }
        }
    }
}
