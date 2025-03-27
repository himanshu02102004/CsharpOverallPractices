using System;
using System.Linq;
using System.Collections.Generic;
namespace IQueryable_Code
{

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }
    class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Salary = 60000 },
            new Employee { Id = 2, Name = "Bob", Salary = 45000 },
            new Employee { Id = 3, Name = "Charlie", Salary = 70000 }
        };

            // Converting List<Employee> to IQueryable<Employee>
            IQueryable<Employee> query = employees.AsQueryable();

            // Applying a LINQ query (Deferred execution)
            var highSalaryEmployees = query.Where(e => e.Salary > 50000);

            // Executing the query
            foreach (var emp in highSalaryEmployees)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Salary: {emp.Salary}");
            }
        }
    }
}