//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Dependency_Injection
//{

//    class Savingaccount
//    {
//        public void printdetail()
//        {
//            Console.WriteLine("detail of saving account");
//        }
//    }

//    class currentaccount
//    {
//        public void printdetail()
//        {
//            Console.WriteLine("detail of current account");
//        }
//    }

//    class Account
//    {
//        currentaccount ca = new currentaccount();
//        Savingaccount sa = new Savingaccount();

//        public void PrintAccount()
//        {
//            ca.printdetail();
//            sa.printdetail();

            
//        }
//    }



//    class tightcoupling
//    {
//        static void Main(string[] args)
//        {

//            Account a = new Account();
//            a.PrintAccount();
//        }
//    }
//}
