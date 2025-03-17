using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace projects44
{

    class control
    {

        //static void Main (String[] args)
        //{


            /// if else loop
            /// 

            //int hrs = 17;
            //if(hrs>=0 && hrs < 12)
            //{
            //    Console.WriteLine("morning");
            //}

            //else if(hrs >=12 && hrs < 17)
            //{
            //    Console.WriteLine("evening");
            //}

            //else
            //{
            //    Console.WriteLine("night");
            //}








            /// conditonal operastor


            //bool isGoldprice = true;

            //float price = (isGoldprice) ? 19.56f : 20.34f;
            //Console.WriteLine(price);




            // enum loop

           
        
            static void Main (string[] args)
            {

            var season = Season.Autumn;
             
            switch (season)
            {

                // good for if both the case run

                case Season.Autumn:
                case Season.Summer:
                    Console.WriteLine(" we got promotion");
                    break;





                //case Season.Autumn:
                //    Console.WriteLine("THIS IS AUTUM AND BEAUTIFUL SEASON");
                //    break;


                //case Season.Summer:
                //    Console.WriteLine("THIS IS SUMMER SEASON");
                //    break;


                case Season.Winter:
                    Console.WriteLine("this is winter season");
                    break;


                default:
                    Console.WriteLine("i do n't understand");
                    break;

            }


            }
        

        


    }
}
