using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Review_Practices
{
    class Land_Portrait
    {

        public static void port()
        {
            Console.WriteLine("enter the value of width");
            var width = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the value of height");
            var landscape = Convert.ToInt32(Console.ReadLine());

           if(width > landscape)
            {
                Console.WriteLine("your image is landscape");
            }
            else
            {
                Console.WriteLine("image is portrait ");
            }


        }
    }
}
