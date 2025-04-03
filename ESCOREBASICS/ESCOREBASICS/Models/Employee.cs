 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCOREBASICS.Models
{ 
   public class Employee
    {

        [Key]

        public int  EmployeeId { get; set; } // primary key
        public string EmpFirstName { get; set; }
        public string  EmpLastName { get; set; }

        public long  EmpSalary{ get; set; }


        // public ICollection<EmployeeProject> EmployeeProjects { get; set; }// collection navigation property


      





        ///one to many relationship with manager

        public int ManagerId { get; set; }  /// foreign key property
        public Manager Manager { get; set; }   /// navigation properties to represent the manager










        /// one to one relationship with employeedetail
        public EmployeeDetails EmployeeDetails { get; set; } // Reference navigation to dependent entity relatioanship with model

        








        /// many to many relationship
        
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }  // collection navigation property


    }
}
