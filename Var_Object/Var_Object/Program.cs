using System;

class Program
{
    static void Main()
    {
        // Using var
        var num = 10;  // The compiler infers that num is of type int
        Console.WriteLine("var example: " + num.GetType());  // Output: System.Int32

        // Using dynamic
        dynamic dyn = 10;  // Initially an int
        Console.WriteLine("dynamic example (int): " + dyn.GetType());  // Output: System.Int32
        dyn = "Hello";  // Now dyn is a string (dynamic typing at runtime)
        Console.WriteLine("dynamic example (string): " + dyn.GetType());  // Output: System.String

        // Using object
        object obj = 10;  // Initially an int
        Console.WriteLine("object example (int): " + obj.GetType());  // Output: System.Int32
        obj = "Hello";  // Now obj is a string (requires casting to access members)
        Console.WriteLine("object example (string): " + obj.GetType());  // Output: System.String

        // Note: Accessing members directly from object will result in a compilation error
        // obj.Length; // This would give an error, because obj is an object and needs to be cast.
    }
}
