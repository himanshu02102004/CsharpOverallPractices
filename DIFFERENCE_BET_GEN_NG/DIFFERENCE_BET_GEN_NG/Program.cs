using System;
using System.Collections;
using System.Collections.Generic;
namespace DIFFERENCE_BET_GEN_NG
{
    class Program
    {
        public static void Main(String[] args)
        {

            // GENERIC COLLECTION
            List<int> myNumer = new List<int>();
            myNumer.Add(24);
            myNumer.Add(34);
            myNumer.Add(57);
            Console.WriteLine(myNumer.Capacity);
            Console.WriteLine(myNumer.Count);





















            /// non generci collection
            ArrayList al = new ArrayList();
            al.Add("hima");
            al.Add(24);
            al.Add(5.10);
          
            Console.WriteLine(al.Capacity);
            al.Add('A');
            al.Add("Mishr");
            Console.WriteLine(al.Capacity);
           
        }
    }
}
