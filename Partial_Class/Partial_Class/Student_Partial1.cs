using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial_Class
{
    public partial class Student_Partial
    {

        private string _FirstName;
        private string _LastName;

        public string FirstName
        {
            set
            {
                _FirstName = value;
            }


            get
            {
                return _FirstName;
            }
        }

        public string LastName
        {
            set
            {
                _LastName = value;
            }
            get
            {
                return _LastName;
            }
        }  

            \
    }
}
