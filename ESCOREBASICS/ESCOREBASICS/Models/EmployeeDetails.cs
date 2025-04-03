using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCOREBASICS.Models
{
     public class EmployeeDetails
    {

        [Key]
        public int EmployeeIds { get; set; }   
        public string Email { get; set; }

        public string  phonenum { get; set; }

        public string Adress { get; set; }



        //// one to one relatioship
        //public int EmployeeId { get; set; } /// Foreign key
        //public Employee Employee { get; set; }  //refrence Navigation property
     
    }
}
