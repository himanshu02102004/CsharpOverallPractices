using System;
using System.Text;
namespace Stringbuilder
{
    class Program
    {
        public static void Main(String[] args)
        {
            //StringBuilder str = new StringBuilder(" ");
            //  str.Append("mishra");
            //str.AppendLine("  himanshu ");


            // str.AppendFormat("{0:C}", 25);

            StringBuilder str = new StringBuilder("HELLO World");
            //    str.Insert(5, " C# ");
            //  str.Remove(5, 6);    // 5 se chalu kro 6 character remove karna hai
            str.Replace("World", "C#");

            Console.WriteLine(str);

        }
    }
}
