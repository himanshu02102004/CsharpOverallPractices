using System;
namespace Destructor
{


    class Person
    {
        public string Name;
        public int Age;

        public Person(String Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;

        }

       

        public string getName()
        {
            return this.Name ;
        } 
        public int getAge()
        {
            return this.Age;
        }

        ~Person()
        {
            Console.WriteLine("Destructor have been invoked !!");
        }



    }
    class Program
    {
        public static void Main(String[] args)
        {

            Person p = new Person("hima", 24);
            Person p1 = new Person("himan", 24);
            Console.WriteLine(p.getName());
            Console.WriteLine(p.getAge());

            Console.WriteLine("---------------");


            Console.WriteLine(p1.getAge());
            Console.WriteLine(p1.getName());


           // Console.ReadLine();


        }
    }
}

