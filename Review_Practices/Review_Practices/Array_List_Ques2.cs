﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Review_Practices
{
    class Array_List_Ques2
    {
        public static void Ques2()
        {
 
            Console.WriteLine("enter the name for reverse ");
            var name = Console.ReadLine();
           
            var array = new char[ name.Length];

              for(var i=name.Length; i>0; i--)
            
               array[name.Length -i]= name[i -1];
               var reversed = new string(array);
              Console.WriteLine( "Your reverse array is : " + reversed);


       }
    }
}
