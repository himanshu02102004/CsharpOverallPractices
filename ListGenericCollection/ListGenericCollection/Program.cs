using System;
namespace ListGenericCollection
{
    class Program
    {
        public static void Main(String[] args)
        {

            Employee emp1 = new Employee()
            {
                name = "hima",
                age=24,
                destignation="supervisor"

            };

            Employee emp2 = new Employee()
            {
                name = "priyan",
                age=24,
                destignation="engi"
            };

            Employee emp3 = new Employee()
            {
                name = "prajwal",
                age=19,
                destignation="software"
            };




            // FOR EMPLOYEE FILE
            List<Employee> Empl= new List<Employee>();

            Empl.Add(emp1);
            Empl.Add(emp2);
            Empl.Add(emp3);






            // to array 
            Employee[] emps = Empl.ToArray();
            foreach(Employee emp in emps)   // emps main ja rha hai aur emp main save ho rha hai
            {
                Console.WriteLine(" Employee Name is {0} Age is : {1}  Desgination:{2} ",emp.name,emp.age,emp.destignation);
            }




            Console.WriteLine("-------------------------------------------------");




            List<Employee> myEmps= emps.ToList();

            foreach (Employee emp in myEmps)   // emps main ja rha hai aur emp main save ho rha hai
            {
                Console.WriteLine(" Employee Name is {0} Age is : {1}  Desgination:{2} ", emp.name, emp.age, emp.destignation);
            }





            // findIndex

            Console.WriteLine(Empl.FindIndex(emp => emp.age> 20));   //////  emp just humne variable name diya hai

            //find last inddex
            Console.WriteLine(Empl.FindLastIndex(emp => emp.age > 20));









            //find all

            //List<Employee> emps = Empl.FindAll(e => e.age > 20);

            //foreach (Employee emp in emps) {
            //    Console.WriteLine("Employee is : {0} age: {1}  designation : {2} ", emp.age, emp.age,emp.destignation);
            //}











            //            Employee emp = Empl.Find(e => e.age > 20); 
            //Employee emp = Empl.FindLast(e => e.age > 20);
            //Console.WriteLine(" Employee Name is {0} Age is : {1}  Desgination:{2} ",emp.name,emp.age,emp.destignation);






            /// checking througgh word exist or not
            //      Console.WriteLine(Empl.Exists(emp=>emp.name.StartsWith("r")));





            //foreach(Employee i in Empl)
            //{
            //    Console.WriteLine("  your name is :{0}  age:{1}  designation :{2} ",i.name,i.age,i.destignation);
            //}


            //emp1.RemoveAll(i => i.age > 20);

            //foreach (Employee i in Empl)
            //{
            //    Console.WriteLine("  your name is :{0}  age:{1}  designation :{2} ", i.name, i.age, i.destignation);
            //}


















            //// interger through List


            //List<int> mynum = new List<int>();
            //mynum.Add(101);
            //mynum.Add(102);
            //foreach(var i in mynum)
            //           {
            //               Console.WriteLine(i);
            //           }





            /// liSt through STRING


            //List<string> mystr = new List<string>();

            //mystr.Add("hey");
            //mystr.Add("himanshu");

            //foreach(var str in mystr)
            //{
            //    Console.WriteLine(str);
            //}


            Console.ReadKey();
        }
    }
}
