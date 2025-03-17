using System;


namespace Exercises
{
    class guess
    {


        public static void guest()

        {

            Random randoms = new Random();
            int number = randoms.Next(1, 10);
            //Console.WriteLine(number);

            int attempt = 4;
            Console.WriteLine("Currently you have a four chance and guess the numebr between 1 to 10");
            
            while(attempt > 0)
            {
                Console.WriteLine("guess the number");

                var input = Console.ReadLine();
                if(! int.TryParse(input,out int numbers))
                {
                    Console.WriteLine("invalid no");
                    continue;
                }
                if (number == numbers)
                {
                    Console.WriteLine("no. get matched");
                }
                else
                {
                    attempt--;
                    if (attempt > 0)
                    {
                        Console.WriteLine($"attempt left {attempt}");


                    }
                    else
                    {

                        if (attempt == 0)
                        {
                            Console.WriteLine($"the random  number are {number}");
                        }
                        Console.WriteLine("game over ");
                    }
                }

            }



        }
    }
}
