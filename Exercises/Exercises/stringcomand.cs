using System;

namespace Exercises
{
    class stringcomand
    {
        public static void command()
        {

var fullName = "Himanshu Mishra";
            Console.WriteLine("trim :'{0}'" ,fullName.Trim());

            var index = fullName.IndexOf(' ');
            var firstName = fullName.Substring(0,index);
            var lastname = fullName.Substring(index + 1);

            Console.WriteLine("first name   " + firstName);
            Console.WriteLine("last  name  " + lastname);

            Console.WriteLine(fullName.Replace("Mishra", "pandey"));



        }
    }
}
