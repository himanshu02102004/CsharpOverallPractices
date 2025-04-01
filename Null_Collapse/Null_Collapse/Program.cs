using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Null_Collapse
{
    class Program
    {
        static void Main(string[] args)
        {
            /// example no.1
            //    string name = "hims";
            //    string result = name  ?? "mishra";   // name mein store toh theek vrna mishra print kro ye hai concept null collapse 
            //        Console.WriteLine(result);
            //


            /// example no.2
            string fruit1 = "mango";
            string fruit2 = "grapes";
            string fruit3 = "orange";

            string result = fruit1 ?? fruit2 ?? fruit3;
            Console.WriteLine(result);    // jp pehle ata hai vhi print hota hai



        }
    }
}
