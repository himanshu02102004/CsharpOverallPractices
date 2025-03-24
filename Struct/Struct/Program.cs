using System;

namespace Struct
{

    public struct Customer
    {
        private int _id;
        private string _name;


        public int ID
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public Customer (int Id,string Name)
        {
            this._id = Id;   // initialize the value
            this._name = Name;



        }

        public void Printdetail()
        {
            Console.WriteLine(" ID = {0}  &&  Name ={1} ", this._id , this._name );
        }

    }



    public class Program
    {
        public static void Main()
        {    // first method
            //Customer c1 = new Customer(101, "himanshu");
            //c1.Printdetail();


            // Second method  object intializers syntax

            Customer c2 = new Customer()
            {
                ID = 102,
                Name="root"

            };
            c2.Printdetail();



        }


    }
   

}
