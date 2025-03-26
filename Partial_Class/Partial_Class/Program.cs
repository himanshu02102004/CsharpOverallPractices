using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial_Class
{
    class Program
    {
        static void Main(string[] args)
        {

            Student_Partial  obj= new Student_Partial();
            obj.FirstName = " himanshu";
            obj.LastName = "mishra";

            Console.WriteLine(" your name is "+ obj.GetCompleteName());
            Console.ReadLine();

        }
    }
}
