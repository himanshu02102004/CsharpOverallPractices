using System;
namespace Nested_IF
{
    class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("enter the email");
            String email = Console.ReadLine();
            if(email== "him@gmail.com")
            {
                Console.WriteLine("enter the password");
                string pwd = Console.ReadLine();
                if (pwd == "him")
                {
                    Console.WriteLine("succesfully login ");
                }
                else
                {
                    Console.WriteLine("enter the proper password");
                }
            }
            else
            {
                Console.WriteLine("invalid emaail");
            }

            Console.ReadLine();
        }
    }
}
