using system;

namespace Exercises { 
    class Stringbuilderques5
    {


        public static void ques()
        {
            Console.WriteLine("enter the word  in this")
             String input = Console.ReadLine().Tolower();
            int count = 0

            char[ ] vowels = { 'a', 'e'.'i', 'o', 'u' };


            foreach( char c in input)
            {
                if(Array.Exists(vowels,v=>v == c))
                {
                    count++;
                }
            }

            Console.WriteLine($"number vowers {count}");
           

        }
    }
}}