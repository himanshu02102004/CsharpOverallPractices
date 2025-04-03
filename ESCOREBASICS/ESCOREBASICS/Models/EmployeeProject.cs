using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ESCOREBASICS.Models
{


    // juction table entity
   public class EmployeeProject
    {

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }   // reference navigation property

        public int ProjectId { get; set; }

        public Project Project { get; set; }    /// reference navigation property



    }
}
