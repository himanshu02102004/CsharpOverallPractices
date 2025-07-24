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





?/////////////without inbuild function
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class HelloWorld
{

    public static bool ana(string s1, string s2)
    {
        if (s1 == null || s2 == null) return false;

        s1 = s1.ToLower();
        s2 = s2.ToLower();

        if (s1.Length != s2.Length) return false;
        int[] f1 = new int[26];
        int[] f2 = new int[26];
        for (int i = 0; i < s1.Length; i++)
        {
            f1[s1[i] - 'a']++;
            f2[s2[i] - 'a']++;

        }

        for (int i = 0; i < 26; i++)
        {
            if (f1.Length != f2.Length) return false;
        }
        return true;


    }
    public static void Main(string[] args)
    {
        string s1 = "len";
        string s2 = "snel";
        Console.WriteLine(ana(s1, s2));
    }
}
