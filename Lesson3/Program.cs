using System.Reflection;

namespace Lesson3;

class Program
{
    static bool odd(int number) => number % 2 == 1;

    public static void Main()
    {
        int[] numbers = [3, 7, 3, 8, 0, 3, 87, 34, 78];
        foreach(var num in numbers.ToList().FindAll(odd))
            Console.WriteLine(num);

        //printInfo(typeof(MyClass));
        //Console.WriteLine("-----------------------------------");
        //var anonymousObject = new { Id = 2222, Name = "Yossi" };
        var anonym1 = new { Id = 2222, Name = "Yossi" };
        //printInfo(anonymousObject.GetType());
        //Console.WriteLine(anonymousObject == anonym1);
        //Console.WriteLine(anonymousObject.Equals(anonym1));
        //Console.WriteLine(anonymousObject);
        //var anonym2 = anonymousObject with { Name = "Dani" };
        //PrintInfo("", anonymousObject.GetType());
        //Console.WriteLine(anonymousObject.GetType().Name);
        //Console.WriteLine("-----------------------------------");
        //var anonymousOther = new { Id = "123", Name = 3.5 };
        //printInfo(anonymousOther.GetType());
        //var anonymousOther1 = new { Name = 3.5, Id = "123" };
        //printInfo(anonymousOther1.GetType());
        //Console.WriteLine(anonymousOther.Equals(anonymousOther1));
        //object[] array = new object[5];
        //array[1] = anonym2;
        //var anonymousObject2 = new { Id = 2222, Name = "Yossi" };
        //var anonymousObject2 = new { Name = "Yossi", Id = 2222 };
        //var anonymousObject2 = new { Id = 2222, Name = 4 };
        //Console.WriteLine(anonymousObject2.GetType().Name);

        //Console.WriteLine("" + anonymousObject.GetHashCode()
        //    + " : " + anonymousObject2.GetHashCode());
        //Console.WriteLine("Equals = " + anonymousObject.Equals(anonymousObject2));
        //Console.WriteLine("== : " + (anonymousObject == anonymousObject2));
        //string str = "123";
        //int i = str.ToInt();
        //int j = "234".ToInt();

        //Console.WriteLine("123"[1]);

        //anonymousObject.ToStringProperty();
        //Console.WriteLine("-----------------------------------");
        //DateTime.Now.ToStringProperty();
        Console.WriteLine("DateTime.Now:");
        DateTime.Now.ToStringProperty();
        Console.WriteLine("Anonymous object:");
        anonym1.ToStringProperty();
        Console.WriteLine("MyClass object:");
        new MyClass().ToStringProperty();

        //DateTime? date = null;
        ////if (date == null) ;
        //DateTime date3 = (DateTime)(date ?? DateTime.Now);
        //var myObject = new MyGenericClass<int, string>();
        //myObject!.MyFunction(3, "I am here");

        //MyDelegate myDel = null;
        ////Console.WriteLine(myDel(3, "abc"));
        //Console.WriteLine(myDel?.Invoke(3, "abc"));

        //MyClass obj = null;
        //obj?.f1();
        //var v = obj?.f2();
        //foreach (var number in func())
        //    Console.WriteLine(number);

        //MD md = null;
        //md += MyF1;
        //md += MyF2;
        //md += MyF3;
        //md();

        SomeDelegate myDlgt = new SomeDelegate(sum);
        myDlgt += mult;
        myDlgt += sub;
        myDlgt -= sum;
        //Console.WriteLine(myDlgt!(3, 2));

        //foreach (var d in myDlgt!.GetInvocationList())
        //    Console.WriteLine(d.Method);
        //if (myDlgt is Delegate)
        //    Console.WriteLine("myDlgt is Delegate == true");
        //foreach (var item in myDlgt!.GetInvocationList())
        //    Console.WriteLine(item?.DynamicInvoke(3, 2));
        //Console.WriteLine(myDlgt(3, 2));
        var fList = myDlgt?.GetInvocationList();
        Console.WriteLine(fList?[0].DynamicInvoke(3, 2));

        //if (myDlgt is Delegate) Console.WriteLine("myDlgt is Delegate == true");
        //foreach (var item in myDlgt.GetInvocationList()) // (Delegate item …)
        //    Console.WriteLine(item.DynamicInvoke(3, 2));

        //printInfo(typeof(SomeDelegate));

        //static int sum(int num1, int num2) => num1 + num2;
        //static int mult(int num1, int num2) => num1 * num2;
        //static int sub(int num1, int num2) => num1 - num2;

        //List<int?> list = new();
        //var result = list.FirstOrDefault();

        //MyRecord record1 = new(2, "Dani");
        //MyRecord record2 = new(3, "Moti", Category.Admin);

    }

    //static IEnumerable<int> func()
    //{
    //    yield return 25;
    //    yield return 36;
    //}

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

    static void printInfo(Type type) => printInfo("", type);
    static public int sum(int num1, int num2) { return num1 + num2; }
    static public int mult(int num1, int num2) { return num1 * num2; }
    static public int sub(int num1, int num2) { return num1 - num2; }

    static void printInfo(string suffix, Type type)
    {
        string category = type.IsValueType ? "ValueType" : "ReferenceType";
        Console.WriteLine(suffix + $"""Type Name: {type.Name}: {category} {type switch { { IsInterface: true } => "interface", { IsEnum: true } => "enum", { IsClass: true } => "class", _ => "" }} {type switch { { IsAbstract: true } => "abstract", { IsSealed: true } => "sealed", _ => "" }} {type switch { { IsGenericType: true } => "generic", _ => "" }}""");

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
    public static void MyF1() => Console.WriteLine("F1");
    public static void MyF2() => Console.WriteLine("F2");
    public static void MyF3() => Console.WriteLine("F3");
}

public delegate int SomeDelegate(int x, int y);

class MyGenericClass<T, U> // where T : struct // where T : class
{
    T? _myField; // = null;
    internal void MyFunction(T parm1, U parm2)
    {
        _myField = parm1;
        Console.WriteLine("" + _myField + " and " + parm2);
    }
}

static class MyTools
{
    public static int ToInt(this string str) => int.Parse(str);
    
    public static void ToStringProperty<T>(this T t)
    {
        string str = "";
        foreach (PropertyInfo item in t!.GetType().GetProperties())
            str += "\n" + item.Name + ": " + item.GetValue(t, null);
        Console.WriteLine(str);
    }
}
enum Category { User, Admin }
record MyRecord (int ID, string Name, Category Category = Category.User);

class MyClass
{
    public int Id;
    public string? Name;

    //public void f1() { }
    //public int f2() => 0;
}
