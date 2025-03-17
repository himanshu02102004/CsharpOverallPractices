using System;

namespace projects44
{


    public enum ShippingMethod
    {
        RegularAirmall =1,
        RegisteredAirmall =2,
        Express =3
    }
    class Enum
    {

        static void Main(string[] args)
        {
            var method = ShippingMethod.Express;
            Console.WriteLine((int)method);


            var methodid = 3;
            Console.WriteLine( (ShippingMethod) methodid);


            Console.WriteLine(method.ToString());

            var methodName = "express";

            
            var shippingMethod=(ShippingMethod)System.Enum.Parse(typeof(ShippingMethod), methodName);

            Console.WriteLine(shippingMethod);
        
        }

    }
    }

