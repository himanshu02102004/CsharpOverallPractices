using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ienumerable_Ienumerator
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> yrs = new List<int>();
            yrs.Add(2000);

            yrs.Add(2001);
            yrs.Add(2002);
            yrs.Add(2003);
            yrs.Add(2004);
            yrs.Add(2005);
            yrs.Add(2006);
            Console.WriteLine("------------------------------");




            IEnumerable<int> ienum = (IEnumerable<int>)yrs;
               Interate2001to2004(ienum);          //calling IEnumerable code
            //    foreach (int i in ienum)
            //    {
            //        Console.WriteLine(i);
            //    }







            //IEnumerator<int> ienumerat = yrs.GetEnumerator();          //calling Ienumerator code

            //Interate2001to2004(ienumerat);
            ////while(ienumerat.MoveNext())
            ////{
            ////    Console.WriteLine(ienumerat.Current.ToString());
            ////}
       Console.ReadLine();
        }














        //THIS IS THE CODE FOR IEnumerable
        static void Interate2001to2004(IEnumerable<int> o)
        {
            // intergrate from 2001 to 2004
            foreach (int i in o)
            {
                Console.WriteLine(i);
                if(i > 2004)
                {
                    Interate2004to2006(o);
                }
            }
        }

        static void Interate2004to2006(IEnumerable<int> o)
        {
            // interate from 2004 to 2006
            foreach (int i in o)
            {
                Console.WriteLine(i);
            }
        }























        // THIS IS THE CODE FOR IEnumerator



        //static void Interate2001to2004(IEnumerator<int> o)
        //{
        //    // intergrate from 2001 to 2004

        //    while (o.MoveNext())
        //    {
        //        Console.WriteLine(o.Current.ToString());
        //        if (Convert.ToInt16(o.Current) > 20003)
        //        {
        //            Interate2004to2006(o);
        //        }

        //    }
        //}

        //static void Interate2004to2006(IEnumerator<int> o)
        //{
        //    // interate from 2004 to 2006
        //    while (o.MoveNext())
        //    {
        //        Console.WriteLine(o.Current.ToString());
        //    }


        //}












    }
}
