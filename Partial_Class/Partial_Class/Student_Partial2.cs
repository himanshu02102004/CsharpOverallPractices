using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial_Class
{
   public partial   class Student_Partial
    {

        public string GetCompleteName()
        {
            return _FirstName + " " + _LastName;
        } 
    }
}
