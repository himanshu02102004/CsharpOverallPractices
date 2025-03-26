
/// problem solved through explicit conversion
using System;

interface IA
{
    void show();
}

interface IB : IA
{
    void show();
}

interface IC : IA
{
    void show();
}

class D : IB, IC
{
    void IB.show() => Console.WriteLine(" IB   ___Implementation");
    void IC.show() => Console.WriteLine(" IC implementation");
    public void show() => Console.WriteLine("D  iss  implementation");


}




class Diamond_Problem
{
    public static void Main(String[] args)
    {


        D d = new D();
        d.show();

        ((IB)d).show();
        ((IC)d).show();


    }
}



//// THROUGH VIRTUAL METHOD


//using System;
//class A
//{
//    public virtual void show() => Console.WriteLine(" A Implementation");
//}

//class B:A
//{
//    public override void show() => Console.WriteLine(" B Implementation");
//}

//class C: A
//{
//    public override void show() => Console.WriteLine(" C Implemntation");
   
//}


//class D: A
//{
//     private B b= new B();
//    private C c = new C();

//    public override void show()
//    {
//        Console.WriteLine(" D implementation");
//        b.show();
//        c.show();
//    }

//}
//class Program
//{
//    public static void Main(String[] args)
//    {
//        D d = new D();
//        d.show();
//    }
//}   