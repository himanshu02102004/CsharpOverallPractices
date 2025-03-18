using System;
namespace Encapsulation_Demo
{


       // / EXAMPLE 1

    //    class Person
    //    {
    //        private String Name;
    //        private int Age;

    //        public void setName(string Name)
    //        {
    //            if (string.IsNullOrEmpty(Name) == true)
    //            {
    //                Console.WriteLine("name is reqired");
    //            }
    //            else
    //            {
    //                this.Name = Name;

    //            }




    //        }

    //        public void getName()
    //        {
    //            if (string.IsNullOrEmpty(this.Name) == true)
    //            {

    //            }
    //            else
    //            {

    //                Console.WriteLine("your name is :" + this.Name);
    //            }
    //        }


    //        public void setAge(int Age)
    //        {
    //            if(Age > 0)
    //            {
    //              this.Age = Age;
    //            }
    //            else
    //            {

    //                Console.WriteLine("age shouls not negative");
    //            }

    //        }

    //        public void getAge()
    //        {
    //            if (Age > 0)
    //            {
    //                Console.WriteLine("your age will be " + this.Age);
    //            }
    //            else
    //            {

    //            }
    //        }



    //    }




    //    class Program
    //    {

    //        public static void Main(String[] args)
    //        {

    //            Person p = new Person();
    //            p.setAge(-12);
    //            p.setName("hima");
    //            p.getName();

    //            p.getAge();

    //        }
    //    }





  ///// EXAMPLE 2


    class Account
    {
        private int account_number;
        private int accont_balance;
         

        public void setDeposit(int a)
        {
            if (a <= 0)
            {
                Console.WriteLine("money cannot be negative");
            }
            else
            {
                accont_balance = accont_balance + a;
                
            }
        }


        public void getDeposit()
        {
            Console.WriteLine("your deposit value will be " + accont_balance);
        }

    }


    class Program
    {

        public static void Main(String[] args)
        {
            Account a = new Account();
            
            a.setDeposit(100);
            a.getDeposit();
        }
    }








}
