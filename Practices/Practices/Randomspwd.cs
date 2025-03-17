
//using System;
//namespace Practices
//{
//    class Randomspwd
//    {
//        public static void randomeclasses()


//        {  {

//                control flow exercises 1;

//                var rand = new Random();

//                const int pwdlength = 10;

//                var buffer = new char[pwdlength];

//                for (int i = 0; i < pwdlength; i++)

//                    buffer[i] = (char)('a' + rand.Next(0, 26));
//                var password = new string(buffer);

//                Console.WriteLine(password);












//                // Console.WriteLine((char) rand.Next(98,122));
//                //  Console.WriteLine();
//            }
//        }
//    }
//} 

using System;

namespace Exercises
{
    class Randomspwd
    {
        public static void randomeclasses()
        {
            var rand = new Random();
            const int pwdlength = 10;
            var buffer = new char[pwdlength];

            for (int i = 0; i < pwdlength; i++)
            {
                buffer[i] = (char)('a' + rand.Next(0, 26));
            }

            var password = new string(buffer);
            Console.WriteLine("Generated Password: " + password);
        }
    }
}
