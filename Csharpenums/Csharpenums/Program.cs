using System;
using System.Data;

namespace Csharpnums
{ 
    enum Days
        {
        // by default 
        Monday,// 0  store in backend interger
        Tuesday,  //1
        Wednesday,   //2
        Thursday, //3
        Friday, //4
        Saturday//5



        // by assign interger and increment by 1

        //Monday=2,//2
        //Tuesday, //3
        //Wednesday,//4
        //Thursday,//5
        //Friday, //6
        //Saturday//7

    }
    class Program
    {

        public static void Main(String[] args)

        {


          //  Days mydays= Days.Tuesday;

            int mydays=(int)Days.Wednesday;
            switch (mydays)
            { 
                 case 1:
                    Console.WriteLine("this is Monday");
                    break;
                 case 2:
                    Console.WriteLine("This is Tuesday");
                    break;
                 case 3:
                    Console.WriteLine("This is wednesday");
                    break;
                 case 4:
                    Console.WriteLine("this is thursaday");
                    break;
                 case 5:
                    Console.WriteLine("this is fridays");
                    break;
                 case 6:
                    Console.WriteLine("This is satursday");
                    break;

                 default:
                    Console.WriteLine("invalid input");
                    break;
                        
            }


            // Enum conversion  for Integers

            //int[] val = (int[])Enum.GetValues(typeof(Days));
            //foreach(int values in val)
            //{
            //    Console.WriteLine(values);
            //}


            // Enum conversion for string

            //String[] members = (String[])Enum.GetNames(typeof(Days));
            //foreach(String member in members)
            //{
            //    Console.WriteLine(member);

            //}
                





            //Console.WriteLine("enter the name");
            //string name = Console.ReadLine();

            //Console.WriteLine("enter your day monday=1,tuesday=2,wednesday=3");
            //int value = int.Parse(Console.ReadLine());
            //Days val = (Days)value;

            //Console.WriteLine($"Your name is {name} and days was: {val} ");







            // type cast in integers

            //// enum to int
            //int num = (int)Days.Saturdays;
            //Console.WriteLine(num); 



            // type cast  days

            //Days myDay = (Days)1;   // explicity conversion
            //Console.WriteLine(myDay);

            //Days brth = Days.Saturdays;
            //Console.WriteLine(brth);

        //    Console.WriteLine(Days.Friday);// more readable

            //Console.BackgroundColor = ConsoleColor.Yellow;
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("himanshu mishra");

            Console.ReadKey();


          
        }
       
    }
}