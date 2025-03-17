using System;

namespace projects44
{     


    // reference example no.2  age class
    public class Person1
    {
        public int Age;
    }


    class valueandreference
    {

        // static void Main(string[] args)
        //  {

        // reference example no.1

        //var a = 10;
        //var b = a;
        //b++;
        //Console.WriteLine(string.Format("a:  {0}, b:{1} ",a,b));


        //var array1 = new int[3] { 1, 2, 3 };
        //var array2 = array1;
        //array1[0] = 0;
        //Console.WriteLine("array1[0]: {0}, array1[0] : {1} ", array1[0], array2[0]);




        // reference example no.2



        static void Main(string[] args)
        {
            var number = 1;
            increment(number);
            Console.WriteLine(number);

            var person = new Person1() { Age = 20 };
            MakeOld(person);
            Console.WriteLine(person.Age);
        }


        public static void increment(int number)
        {
            number += 10;
        }


        public static void MakeOld(Person1 person)
        {
            person.Age += 10;
        }
    
     
    
    

        
    }
}
