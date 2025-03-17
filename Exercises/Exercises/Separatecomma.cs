using System;
using System.Linq;


namespace Exercises
{
    class Separatecomma
    {
        public static void Sep()
        {
                

            // using inbuild function

            //Console.WriteLine("enter the number by comma");
            //var input = Console.ReadLine();
            //int maxnumber = input.Split(',')
            //               .Select(num => int.Parse(num.Trim()))
            //               .Max();

            //Console.WriteLine($"the maximum number is :{ maxnumber}");



            //without inbuild function



            // without inbuild method

            Console.WriteLine("enter the number");
            string input = Console.ReadLine();

            int maxNumber=int.MinValue;
            int currentnumber = 0;
            bool numeb = false;

            foreach(char ch in input + " ,")
            {
                if(ch >='0' && ch <= '9')
                {
                        currentnumber = currentnumber * 10 + (ch - '0');
                        numeb = true;
                }
                else if (ch == ',')
                {

                    if (numeb)
                    {
                        if(currentnumber > maxNumber)
                        {
                            maxNumber = currentnumber;
                        }
                        currentnumber = 0;
                        numeb = false;

                    }

                }
            }

            Console.WriteLine( $"the maximum is : {maxNumber}");


        }
    }
}
