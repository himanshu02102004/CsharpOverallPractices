using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCOREBASICS.Models
{
   public  class Project
    {


        public int ProjectId { get; set; }   // primary key
        public string  Name { get; set; }


        public ICollection<EmployeeProject> EmployeeProjects { get; set; }  // collection navigation property
    }
}
