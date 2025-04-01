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

//        private IAccount account;   // interface ko private kiya

//      public Account( IAccount account)  /// parameterized constructor
//      {
//            this.account = account;       //// account(joo parametrize hai) vo jayega this.account mein jo ki upar private declare kiya hai usme save hoga


//      }

//        public void PrintAccount()
//        {
//            account.printdetail();
//        }

//    }


//    class Program   
//    {
//        static void Main(string[] args)
//        {

//            IAccount ca = new CurrentAccount();

//            Account a1 = new Account(ca);

//            a1.PrintAccount();


//            IAccount sa = new  SavingAccount();

//            Account a2 = new Account(sa);

//            a2.PrintAccount();


//            Console.ReadLine();

//        }
//    }
//}
