using System;
using System.Collections.Generic;
using System.Linq;
using Classs.Math;


namespace Classs
{
  


    class Program
    {
        static void Main(string[] args)
        {
            var joe = new Person();
            joe.FirstName = "hey";
            joe.LastName = "word";
            joe.Instructor();


            Calculator calculator = new Calculator();
            var result = calculator.Add(1, 2);
            Console.WriteLine(result);

        }
    }
}
