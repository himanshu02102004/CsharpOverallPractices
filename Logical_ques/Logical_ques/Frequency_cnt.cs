using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical_ques
{
    class Frequency_cnt
    {

        // Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Collections.Generic;

public class HelloWorld
    {
        public static void Main(string[] args)
        {
            string str = "enginner";
            Dictionary<char, int> cnt = new Dictionary<char, int>();
            foreach (char i in str)
            {
                if (cnt.ContainsKey(i))
                {
                    cnt[i]++;
                }
                else
                {
                    cnt[i] = 1;
                }
            }
            foreach (var pair in cnt)
            {
                Console.WriteLine($"{pair.Key}:{pair.Value}");
            }


        }



        /// for integer
        ///   public static void Main(string[] args)
        {
            int s= 2345;
        char str= s.ToString(); /"23432"
       
        Dictionary<char, int> cnt = new Dictionary<char, int>();
            foreach (char i in str)
            {
                if (cnt.ContainsKey(i))
                {
                    cnt[i]++;
                }
                else
                {
                    cnt[i] = 1;
                }
            }
            foreach (var pair in cnt)
{
    Console.WriteLine($"{pair.Key}:{pair.Value}");
}


        }
    }
}
}
