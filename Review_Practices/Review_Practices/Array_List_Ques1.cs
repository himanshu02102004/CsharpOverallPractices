using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_Practices
{
    class Array_List_Ques1
    {

        public static void Ques1()
        {
            var Name = new List<String>();
            while (true)
            {
                Console.WriteLine("enter your or hit enter to exit");
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    break;
                Name.Add(input);

            }

            if(Name.Count > 2)
                Console.WriteLine(" {0} , {1} {2} other like the post ", Name[0], Name[1], Name.Count-2);
            else if(Name.Count ==2)
                Console.WriteLine(" {0} {1} two person like the post", Name[0], Name[1]);
            else if(Name.Count==1)
                Console.WriteLine(" {0}  one person like the post " , Name[0]);
            else
                Console.WriteLine();



        }
    }
}
