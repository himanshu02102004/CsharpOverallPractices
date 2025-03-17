using System;
using System.Drawing;


namespace projects44
{
    class question
    {

       static void Main(string[] args)
        {
            // question for valid and invalid 


            //Console.WriteLine("enter the number");
            //string input = Console.ReadLine();

            //if(int.TryParse(input,out int number)  && number>=1 && number <= 10)
            //{
            //    Console.WriteLine("valid");
            //}
            //else
            //{
            //    Console.WriteLine("invalid");
            //}





            // question for maximum two number

            //string num1 = Console.ReadLine();
            //string num2 = Console.ReadLine();

            //int number1 = int.Parse(num1);
            //int number2 = int.Parse(num2);

            //if(number1 >  number2 )
            //{
            //    Console.WriteLine("number 1 is big ");
            //}
            //else
            //{
            //    Console.WriteLine("number 2 is big");
            //}




            //program for check image is landscape or portrait

            //Console.WriteLine("enter the image width ");
            //int width = int.Parse(Console.ReadLine());

            //Console.WriteLine("enter the height of image ");
            //int height = int.Parse(Console.ReadLine());

            //if(width > height)
            //{
            //    Console.WriteLine("this is landscape orientation");
            //}
            //else
            //{
            //    Console.WriteLine("this is portrait orientation");
            //}





            // program for demerit speed and all

            Console.WriteLine("enter the speed limit");
            int speedLimit = int.Parse(Console.ReadLine());


            Console.WriteLine("enter the car speed");
            int carspeed = int.Parse(Console.ReadLine());

            if (carspeed < speedLimit)
            {
                Console.WriteLine("OK");
            }

            else
            {
                int demerit = (carspeed - speedLimit) / 5;
                Console.WriteLine($"demeritpoint : {demerit}");

                if(demerit > 12)
                {
                    Console.WriteLine("license get suspended");
                }
            }
        }
    }
}
