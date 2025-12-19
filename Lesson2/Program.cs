using Lesson2;

using System.Reflection;

class Program
{
    public static void Main()
    {
        //Class1 obj1 = new() { Field = 8 };
        //Console.WriteLine(obj1);
        //Console.WriteLine(obj1.Field);
        ////obj1.Field = 10;
        //Console.WriteLine(obj1.Sum("nothing"));
        //Console.WriteLine(obj1.Sum("Sum of numbers", 2, 6, 8));

        //obj1.Optional(n3:10,n1:8);

        //Record1 r1 = new Record1(1, 2);
        //Record1 r2 = r1 with { N2 = 3 };
        //Record1 r3 = r1 with { };
        //Class1 obj = new();
        //Console.WriteLine(obj);

        //Struct1 s1;
        //s1.field = 10;
        //Console.WriteLine(s1.field);

        object o1 = 3;
        object o2 = "Hello";

        int i1 = (int)o1;

        Console.WriteLine(o1 is int);

        Class1 c1;
        f1(out c1, 20);
        Console.WriteLine(c1);

        Class1 c2 = new(); ;
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

        MyClass test1 = new();
        MyRecord test2 = new(7, "Dani");
        Console.WriteLine(test1);
        Console.WriteLine(test2);
        Console.ReadKey();
        printInfo("", typeof(MyRecord));
        Console.Write("Press any key...");
        Console.ReadKey();

        Console.WriteLine(" ID:{0} called {1}, gender={2}", 4, "Yossi", MyClass.Genders.Female);
        Console.Write("Press any key...");
        MyClass myObj = new();
        Console.WriteLine(myObj.Number);
        ValueType obj9 = MyClass.Genders.Male;
        Console.WriteLine(obj9);
        Console.ReadKey();



        object objA = obj9;

        Console.WriteLine("Hello, World!");
        int number = (8);
        var test = 2.5;
        uint positive = (uint)number;
        Console.WriteLine(number);

        positive = 38u;

        MyClass.Genders a = MyClass.Genders.Male;
        var obj = new MyClass() { Gender = MyClass.Genders.Male };
        obj.Gender = a;
        Console.WriteLine(obj.Gender);
        Console.WriteLine(obj.Func1("something", 4, 8, 11, 2));

        obj.Func2(par2: "Dani", par1: 5, par3: 2.5);

        MyRecord rec1 = new(123, "Yossi");
        MyRecord rec3 = rec1;
        MyRecord rec2 = rec1 with { Number = 877 };
        Console.WriteLine(rec1);
        Console.WriteLine(rec2);
        rec2.Family = 8;

        int? nullableNumber = null;

        int num = 1;
        nullableNumber = num;
        num = nullableNumber ?? 0;
        num = nullableNumber!.Value;
        var check = nullableNumber!.HasValue;

        func(ref num);
        Console.WriteLine(num);
    }
    static void func(ref int i)
    {
        Console.WriteLine(i);
        i = 8;
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

    public void Func2(int par1, string par2, double par3) { }


    static string accessLevel(FieldInfo item) => (item.IsInitOnly ? ", readonly" : "") + ", access: " +
        item switch
        {
            { IsPrivate: true } => "private",
            { IsPublic: true } => "public",
            { IsFamily: true } => "protected",
            { IsFamilyAndAssembly: true } => "internal private",
            { IsFamilyOrAssembly: true } => "private protected",
            { IsAssembly: true } => "internal",
            _ => ""
        };
    static string accessLevel(MethodInfo item) => ", access: " +
    item switch
    {
        { IsPrivate: true } => "private",
        { IsPublic: true } => "public",
        { IsFamily: true } => "protected",
        { IsFamilyAndAssembly: true } => "internal private",
        { IsFamilyOrAssembly: true } => "private protected",
        { IsAssembly: true } => "internal",
        _ => ""
    };
    static string accessLevel(ConstructorInfo item) => ", access: " +
    item switch
    {
        { IsPrivate: true } => "private",
        { IsPublic: true } => "public",
        { IsFamily: true } => "protected",
        { IsFamilyAndAssembly: true } => "internal private",
        { IsFamilyOrAssembly: true } => "internal protected",
        { IsAssembly: true } => "internal",
        _ => ""
    };

    static void printInfo(string suffix, Type type)
    {
        string category = type.IsValueType ? "ValueType" : "ReferenceType";
        Console.WriteLine(suffix + $"""Type Name: {type.Name}: {category} {type switch { { IsInterface: true } => "interface", { IsEnum: true } => "enum", { IsClass: true } => "class", _ => "" }} {type switch { { IsAbstract: true } => "absract", { IsSealed: true } => "sealed", _ => "" }} {type switch { { IsGenericType: true } => "generic", _ => "" }}""");

        Console.WriteLine(suffix + "Base Type: ");
        if (type.BaseType == null)
            Console.WriteLine(suffix + suffix + "None");
        else
            printInfo(suffix + "  ", type.BaseType);

        FieldInfo[] staticFields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
        FieldInfo[] instanceFields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        PropertyInfo[] staticProperties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
        PropertyInfo[] instanceProperties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        MethodInfo[] staticMethods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
        MethodInfo[] instanceMethods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        ConstructorInfo[] staticConstructors = type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
        ConstructorInfo[] instanceConstructors = type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        Console.WriteLine(suffix + "Member Info:");
        if (staticFields.Length > 0)
        {
            Console.WriteLine(suffix + " Static fields:");
            foreach (var item in staticFields)
                Console.WriteLine(suffix + "  name: {0,-32} type: {1,-11} in: {2}" +
                    accessLevel(item) + (item.IsLiteral ? " literal" : ""), item.Name, item.MemberType, item.DeclaringType?.Name);
        }
        if (instanceFields.Length > 0)
        {
            Console.WriteLine(suffix + " Instance fields:");
            foreach (var item in instanceFields)
                Console.WriteLine(suffix + "  name: {0,-32} type: {1,-11} in: {2}" +
                    accessLevel(item) + (item.IsLiteral ? " literal" : ""), item.Name, item.MemberType, item.DeclaringType?.Name);
        }

        if (staticProperties.Length > 0)
        {
            Console.WriteLine(suffix + " Static properties:");
            foreach (var item in staticProperties)
            {
                Console.Write(suffix + "    name: {0,-32} type: {1,-11} in: {2}",
                                  item.Name, item.MemberType, item.DeclaringType?.Name);
                Console.WriteLine((item.CanRead ? ", GET" + accessLevel(item.GetGetMethod()!) : "") +
                                  (item.CanWrite ? ", SET" + accessLevel(item.GetSetMethod()!) : ""));
            }
        }
        if (instanceFields.Length > 0)
        {
            Console.WriteLine(suffix + " Instance properties:");
            foreach (var item in instanceProperties)
            {
                Console.Write(suffix + "  name: {0,-32} type: {1,-11} in: {2}",
                                  item.Name, item.MemberType, item.DeclaringType?.Name);
                Console.WriteLine((item.CanRead ? ", GET" + accessLevel(item.GetGetMethod()!) : "") +
                                  (item.CanWrite ? ", SET" + accessLevel(item.GetSetMethod()!) : ""));
            }
        }

        if (staticMethods.Length > 0)
        {
            Console.WriteLine(suffix + " Static methods:");
            foreach (var item in staticMethods)
                Console.WriteLine(suffix + "  name: {0,-32} type: {1,-11} in: {2}" + accessLevel(item),
                                  item.Name, item.MemberType, item.DeclaringType?.Name);
        }
        if (instanceMethods.Length > 0)
        {
            Console.WriteLine(suffix + " Instance methods:");
            foreach (var item in instanceMethods)
                Console.WriteLine(suffix + "  name: {0,-32} type: {1,-11} in: {2}" + accessLevel(item),
                                  item.Name, item.MemberType, item.DeclaringType?.Name);
        }

        if (staticConstructors.Length > 0)
        {
            Console.WriteLine(suffix + " Static constructors:");
            foreach (var item in staticConstructors)
                Console.WriteLine(suffix + "  name: {0,-32} type: {1,-11} in: {2}" + accessLevel(item),
                                  item.Name, item.MemberType, item.DeclaringType?.Name);
        }
        if (instanceConstructors.Length > 0)
        {
            Console.WriteLine(suffix + " Instance constructors:");
            foreach (var item in instanceConstructors)
                Console.WriteLine(suffix + "  name: {0,-32} type: {1,-11} in: {2}" + accessLevel(item),
                                  item.Name, item.MemberType, item.DeclaringType?.Name);
        }

        //MemberInfo[] members = type.GetMembers((BindingFlags)0x7FFF);
        //foreach (var item in members)
        //    Console.WriteLine(suffix + "name: {0,-32} type: {1,-11} in: {2}",
        //                      item.Name, item.MemberType, item.DeclaringType?.Name);
    }
}

record MyRecord(int Number, string Name)
{
    public int Family = 1;
}

class Try(int number)
{
    public int Number = number;
}

/// <summary>
/// f ssf ds  d d d gadfg dfg
/// </summary>
public class MyClass
{
    public enum Genders { Male, Female }

    private Genders _gender = Genders.Female;
    public Genders Gender { get => _gender; set => _gender = value; }

    public DateTime Today { get => DateTime.Now; }

    public int Number { get; set; } = 8;

    /// <summary>
    /// This functions creates a string with
    /// all the number with + beteen them
    /// </summary>
    /// <param name="begin">starting string for the result</param>
    /// <param name="numbers">all the numbers to be represented</param>
    /// <returns>the resulting string</returns>
    public string Func1(string begin, params int[] numbers)
    {
        string result = begin + ": ";
        foreach (var number in numbers)
            result += number + " + ";
        return result + "0";
    }

    public void Func2(int par1, string par2, double par3) { }
}
