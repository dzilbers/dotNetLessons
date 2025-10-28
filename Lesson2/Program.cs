// See https://aka.ms/new-console-template for more information

//Lesson2.Class1 obj1 = new() { Field = 8 };

//Console.WriteLine(obj1);

//Console.WriteLine(obj1.Field);
////obj1.Field = 10;

//Console.WriteLine(obj1.Sum("nothing"));

//Console.WriteLine(obj1.Sum("Sum of numbers", 2, 6, 8));

//obj1.Optional(n3:10,n1:8);

//Record1 r1 = new Record1(1, 2);
//Record1 r2 = r1 with { N2 = 3 };
//Record1 r3 = r1 with { };

using Lesson2;

//Class1 obj = new();
//Console.WriteLine(obj);

//Struct1 s1;
//s1.field = 10;
//Console.WriteLine(s1.field);

internal class Program
{
    private static void Main(string[] args)
    {
        object o1 = 3;
        object o2 = "Hello";

        int i1 = (int)o1;

        Console.WriteLine(o1 is int);

        Class1 c1;
        f1(out c1, 20);
        Console.WriteLine(c1);

        Class1 c2 = new();;
        f2(ref c2, 30);
        Console.WriteLine(c2);

        Class1 c3 = new() { Field = 40 };
        f3(in c3, 50);
        Console.WriteLine(c3);

        fp(1, "asdasddsa", 3.14, c1);

        c1.Optional(n3: 8, n2: 2, n1: 0);

        Record1 r1 = new(1, 2);
        //r1.N1 = 10;
        Console.WriteLine(r1);
        Record1 r2 = r1 with { };
    }

    /// <summary>
    /// best for output parameters
    /// </summary>
    /// <param name="c">good parameter</param>
    /// <param name="n">bad parameter</param>
    public static void f1(out Class1 c, int n)
    {
        //Console.WriteLine(c);
        c = new() { Field = n };
    }

    public static void f2(ref Class1 c, int n)
    {
        Console.WriteLine(c);
        c = new() { Field = n };
    }

    public static void f3(in Class1 c, int n)
    {
        Console.WriteLine(c);
        //c = new() { Field = n };
    }

    public static void fp(params object[] args)
    {
        foreach (var arg in args)
            Console.WriteLine(arg);
    }

}