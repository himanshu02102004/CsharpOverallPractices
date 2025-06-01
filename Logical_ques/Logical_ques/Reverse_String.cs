using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical_ques
{
    class Reverse_String
    {

        public static void Ques4()
        {
            String name = "himanshu";
            String rev = " ";

            for(int i=name.Length -1; i>=0; i--)
            {
                rev +=name[i];
            }

            Console.WriteLine("The reverse of the string is :" + rev.Trim());

        }
    }
}
