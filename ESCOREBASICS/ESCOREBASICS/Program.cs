

using ESCOREBASICS.Models;
using ESCOREBASICS.Data;
using Microsoft.EntityFrameworkCore;





//Insert manager details


using (var context = new AppDbContext())
{
    //var manager = new Manager();
    //manager.ManagerFirstName = "prajwal";
    //manager.ManagerLastName = "mishra";

    //context.Managers.Add(manager);
    //context.SaveChanges();


    /// added new data


    //var employeee = new Employee();
    //employeee.EmpFirstName = "yashssss";
    //employeee.EmpLastName = "guptssssa";
    //employeee.EmpSalary = 100;
    //employeee.ManagerId = 1;
    //context.Employees.Add(employeee);


    //context.SaveChanges();



    // Retrive and display all the employee
    //var employee = context.Employees.ToList();
    //foreach(var employees in employee)
    //{
    //    Console.WriteLine($" employee name :  {employees.EmpFirstName}    employee last name: {employees.EmpLastName}");
    //}


    ////  id based search
    //var emp = context.Employees.Single(e => e.ManagerId == 1);
    //Console.WriteLine($"emp name {emp.EmpFirstName} emp last name {emp.EmpLastName}");





    //// update the database
    //var emp = context.Employees.Single(e => e.EmployeeId== 1);
    //emp.EmpFirstName = "hima";
    //emp.EmpLastName = "mish";
    //context.SaveChanges();

    //Console.WriteLine($"emp name {emp.EmpFirstName} emp last name {emp.EmpLastName}");


    /// delete the table
    //var emp = context.Employees.Single(e => e.EmployeeId == 1);
    //context.Employees.Remove(emp);
    //context.SaveChanges();













    /// eager loading
    /// 
    //var employee = context.Employees.Include(e => e.EmployeeDetails).ToList();
    //foreach (var employees in employee)
    //{
    //    Console.WriteLine($" employee name :  {employees.EmpFirstName}    employee last name: {employees.EmpLastName}");
    //}


    //// eager loading for  Many to Many relatioship

    //Console.WriteLine("Eager loading many to many realtionship");
    //var projs = context.Projects.Include(e => e.EmployeeProjects).ThenInclude(e => e.Employee).ToList();
    //foreach(var proj in projs)
    //{
    //    Console.WriteLine($" project name: { proj.Name}");
    //    foreach(var empproj  in proj.EmployeeProjects)
    //    {
    //        Console.WriteLine($" employee : {empproj.Employee.EmpFirstName}");
    //    }

    //}














    /// Explicity Loading

    /// Loading main entity
    //var employee = context.Employees.ToList();

    //foreach(var emp in employee)
    //{
    //    // load related entity
    //    context.Entry(emp).Reference(e => e.EmployeeDetails).Load();

    //    Console.WriteLine($" id: {emp.EmployeeDetails.EmployeeId}  ; Name:{emp.EmpFirstName};");   


    //}


    /// explicity the one to many relationship
    //var manager = context.Managers.ToList();
    //foreach(var msg in manager)
    //{
    //    Console.WriteLine($"manager name: {msg.ManagerFirstName} manager lastname {msg.ManagerLastName}");
    //    context.Entry(msg).Collection(e => e.Employees).Load();
    //    if (msg.Employees.Any())
    //    {
    //        Console.WriteLine("employee :");
    //        foreach(var emp in msg.Employees)
    //        {
    //            Console.WriteLine($" {emp.EmpFirstName} {emp.EmpLastName}");
    //        }
    //    }
    
    
    //}



    //// Lazy Laoding concept
    var manager = context.Managers.ToList();
    foreach (var msg in manager)
    {
        Console.WriteLine($"manager name: {msg.ManagerFirstName} manager lastname {msg.ManagerLastName}");
        
        if (msg.Employees.Any())
        {
            Console.WriteLine("employee :");
            foreach (var emp in msg.Employees)
            {
                Console.WriteLine($" {emp.EmpFirstName} {emp.EmpLastName}");
            }
        }


    }



















    Console.ReadKey();
}   