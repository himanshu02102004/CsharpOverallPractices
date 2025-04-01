//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;







////// THIS IS CODE   CONSTRUCTOR INJECTION  






//namespace Dependency_Injection
//{


//    public interface IAccount
//    {
//        void printdetail();
//    }


//    class SavingAccount : IAccount
//    {
//        public void printdetail()
//        {
//            Console.WriteLine("detail of saving Account");
//        }
//    }

//    class CurrentAccount : IAccount
//    {
//        public void printdetail()
//        {
//            Console.WriteLine("detail of current Account ");
//        }
//    }



//    class Account
//    {

//        public  IAccount account { get; set; }   // Iaccount mein daata set karega get karega

//        public void PrintAccount()
//        {
//            account.printdetail();
//        }

//    }


//    class Property_Injection
//    {
//        static void Main(string[] args)
//        {


//            Account sa = new Account();
//            sa.account = new SavingAccount();
//            sa.PrintAccount();


//            Account ca = new Account();
//            sa.account = new CurrentAccount();
//            sa.PrintAccount();

//            Console.ReadLine();

//        }
//    }
//}
