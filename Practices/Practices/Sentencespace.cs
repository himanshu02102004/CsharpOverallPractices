    using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Xml.Schema;

namespace Practices
{
    class Sentencespace
    {
        public static void space()
        {


            var sentence = " this is realyy so good in programming concept and crack many examination related to codingsadfgdsasfgsadfgdsaDfgdsatryrseasrdtseaty";
            const int maxLength = 10;

            var store = new List<string>();
            var words = sentence.Split(' ');
            int index = 0;
             int totalcharacter = 0;

            while(index <= words.Length)
            {
                var word = words[index];

                if ( word.Length + 1 > maxLength)
                 break;

                store.Add(word);
                totalcharacter += word.Length + 1;
                

                index++;

            }

            var final = string.Join(" ", store) + "...";
            Console.WriteLine(final);




          
            
            
           
            //else
            //{
            //    var words = sentence.Split(' ');
            //    var totalcharacter = 0;
            //    var sumaryword = new List<string>();

            //    foreach (var word in words)
            //    {
            //        sumaryword.Add(word);
            //        totalcharacter += word.Length + 1;
            //        if (totalcharacter > maxLength)
            //            break;
            //    }

            //    var summary = string.Join(" ", sumaryword) + "....";
            //    Console.WriteLine(summary);
            //}
            }
    }
}
