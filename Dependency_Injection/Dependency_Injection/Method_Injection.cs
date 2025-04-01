using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{


    public interface IAccount
    {
        void printdetail();    /// abstract method
    }


    class SavingAccount : IAccount
    {
        public void printdetail()
        {
            Console.WriteLine("detail of saving Account");
        }
    }

    class CurrentAccount : IAccount
    {
        public void printdetail()
        {
            Console.WriteLine("detail of current Account ");
        }
    }



    class Account
    {
        public void PrintAccount(IAccount account)
        {

            account.printdetail();

        }
    }

    class Method_Injection
    {
        static void Main(string[] args)
        {


            Account sa = new Account();

            sa.PrintAccount(new SavingAccount());



            Account ca = new Account();

            ca.PrintAccount(new CurrentAccount());
            

            Console.ReadLine();

        }
    }
}
