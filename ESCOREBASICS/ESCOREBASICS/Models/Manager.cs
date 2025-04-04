using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCOREBASICS.Models
{
   
       public  class Manager
    {


        public int ManagerId { get; set; }        /// Primary key
        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }



        /// <summary>
        /// one to many relationship  with employee 
        /// </summary>
        public virtual ICollection<Employee> Employees { get; set; }  //collection
                      //navigation property to represent the employeee  managed by manager
      
        
    }
}
