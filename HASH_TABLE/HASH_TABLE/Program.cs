using System;
using System.Collections;

namespace HASH_TABLE
{
    class Program
    {
        public static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht.Add("ID", 1124);
            ht.Add("Name", "himanshu");
            ht.Add("designation", "engineer");
            ht.Add("Salary", 24555.00);
            ht.Add("Spouse", false);


            //   Console.WriteLine(ht.ContainsKey("ID"));  // CONTAIN RETURN TRUE NOT CONTAIN FALSE
            //   Console.WriteLine(ht.ContainsValue(1124));
            Console.WriteLine("himashu".GetHashCode());










            //foreach (object key in ht.Keys)
            //{
            //    Console.WriteLine(key + " : " + ht[key]);

            //}
            ////  ht.Remove("Salary");
           // ht.Clear();
            //Console.WriteLine("----------------------");

            //foreach (object key in ht.Keys)
            //{
            //    Console.WriteLine(key + " : " + ht[key]);

            //}








            //another method  in itertion

            //foreach(object value in ht.Values)
            //{
            //    Console.WriteLine(value);
            //}






            // different through no. we can arange
            //ht.Add(100, 1024);
            //ht.Add(101, "himanshu");
            //ht.Add(102, 25000);
            //ht.Add(103, "maanager");


          //  Console.WriteLine(ht[100]);




            //Hashtable ht = new Hashtable()
            //{
            //    {"ID", 123 },
            //    {"Name", "Himanshu" },
            //    {"Age",24}

            //};
            //Console.WriteLine(ht["Age"]);
            Console.ReadLine();
        }
    }
}
