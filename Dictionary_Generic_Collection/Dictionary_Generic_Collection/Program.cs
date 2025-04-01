using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Generic_Collection
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> mydec = new Dictionary<string, string>();
            mydec.Add("active", "helo word");
            mydec.Add("name", " hima");
           // Console.WriteLine(mydec["active"]);


            // overall key and value access

           //foreach(KeyValuePair<string,string> item in mydec)
           // {
           //     Console.WriteLine(" key is :" + item.Key + "  value is :" + item.Value);
           // }



            /// for key access
             
            //foreach (string key in mydec.Keys)
            //{
            //    Console.WriteLine(key);
            //}


            /// for key access

            foreach (string key in mydec.Values)
            {
                Console.WriteLine(key);
            }


            Console.ReadLine();
        }
    }
}
