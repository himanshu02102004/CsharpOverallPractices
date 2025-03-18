
using System;
using System.IO;
using System.Text.Json;



namespace Seriaiization_Demo
{
    class Program
    {
        public static void Main(String[] args)
        {
 //// json format
 ///

            // SERIALIZATION 

            //string path = @"C:\Users\Nimap\source\repos\CsharpOverall\Serailpart\Sampl.txt";
            //Employee emp = new Employee(241, "himanshu");
            //string jsonString = JsonSerializer.Serialize(emp);
            //File.WriteAllText(path, jsonString);

            //Console.WriteLine("file succesfully created " + path);
            //Console.ReadLine();




            // DE SERIALIZATION

          



            // using json
            string path = @"C:\Users\Nimap\source\repos\CsharpOverall\Serailpart\Sampl.txt";
            string jsonString = File.ReadAllText(path);
            Employee emp = JsonSerializer.Deserialize<Employee>(jsonString);

            Console.WriteLine("Employee ID" + emp.Id);
            Console.WriteLine("Employee Name " + emp.Name);
            Console.ReadLine();




        }
    }
}