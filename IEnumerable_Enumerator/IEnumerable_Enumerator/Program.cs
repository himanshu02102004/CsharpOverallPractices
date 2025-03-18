using System;
using System.Collections.Generic;
using System.Data;

namespace IEnumerable_Enumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(9);
            list.Add(7);
            list.Add(8);

            foreach(int item in list)
            {
                Console.WriteLine("value from list " + item);
            }


            MyCollection<int> myCollection = new MyCollection<int>();
            myCollection.Add(7);
            myCollection.Add(8);
            myCollection.Add(9);
            foreach(int v in myCollection)
            {

                Console.WriteLine("VALUE FROM MYCOLLECTION " + v);
            }



            var enumerator = myCollection.GetEnumerator();
            while (enumerator.MoveNext()) 
            {
                Console.WriteLine(enumerator.Current);
            }

        }
    }
}