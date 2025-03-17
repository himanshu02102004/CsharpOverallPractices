using System;
using System.Collections.Generic;

namespace Exercises
{
    class Arrayproblem1
    {
        public static void Start()
        {
            List<string> names = new List<string>();
            string input;
            Console.WriteLine("Enter names (press Enter to stop):");

            while (!string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                names.Add(input);
            }

            Console.WriteLine(GenerateLikeMessage(names));
        }

        static string GenerateLikeMessage(List<string> names)
        {
            switch (names.Count)
            {
                case 0:
                    return "";
                case 1:
                    return $"{names[0]} likes the post.";
                case 2:
                    return $"{names[0]} and {names[1]} like the post.";
                default:
                    return $"{names[0]}, {names[1]} and {names.Count - 2} others like the post.";
            }
        }
    }

}   
