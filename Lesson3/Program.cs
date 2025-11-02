using System.Reflection;

namespace Lesson3;

class Program
{
    static void Main(string[] args)
    {
        //PrintInfo("", typeof(MyClass));
        //Console.WriteLine("-----------------------------------");
        //var anonymousObject = new { Id = 2222, Name = "Yossi" };
        //PrintInfo("", anonymousObject.GetType());
        //Console.WriteLine(anonymousObject.GetType().Name);
        //Console.WriteLine("-----------------------------------");
        //var anonymousObject2 = new { Id = 2222, Name = "Yossi" };
        //var anonymousObject2 = new { Name = "Yossi", Id = 2222 };
        //var anonymousObject2 = new { Id = 2222, Name = 4 };
        //Console.WriteLine(anonymousObject2.GetType().Name);

        //Console.WriteLine("" + anonymousObject.GetHashCode()
        //    + " : " + anonymousObject2.GetHashCode());
        //Console.WriteLine("Equals = " + anonymousObject.Equals(anonymousObject2));
        //Console.WriteLine("== : " + (anonymousObject == anonymousObject2));

        //int i = "123".ToInt();
        //Console.WriteLine("123"[1]);

        //anonymousObject.ToStringProperty();
        //Console.WriteLine("-----------------------------------");
        //DateTime.Now.ToStringProperty();

        //DateTime? date = null;
        ////if (date == null) ;
        //DateTime date3 = (DateTime)(date ?? DateTime.Now);

        //MyDelegate myDel = null;
        ////Console.WriteLine(myDel(3, "abc"));
        //Console.WriteLine(myDel?.Invoke(3, "abc"));

        //MyClass obj = null;
        //obj?.f1();
        //var v = obj?.f2();

        //MD md = null;
        //md += MyF1;
        //md += MyF2;
        //md += MyF3;
        //md();

        SomeDelegate myDlgt = new SomeDelegate(sum);
        myDlgt += mult;
        myDlgt += sub;
        myDlgt -= sum;

        //foreach (var d in myDlgt!.GetInvocationList())
        //    Console.WriteLine(d.Method);
        //if (myDlgt is Delegate)
        //    Console.WriteLine("myDlgt is Delegate == true");
        //foreach (var item in myDlgt!.GetInvocationList())
        //    Console.WriteLine(item?.DynamicInvoke(3, 2));
        //Console.WriteLine(myDlgt(3, 2));
        var fList = myDlgt?.GetInvocationList();
        Console.WriteLine(fList?[0].DynamicInvoke(3, 2));
    }

    static public int sum(int num1, int num2) { return num1 + num2; }
    static public int mult(int num1, int num2) { return num1 * num2; }
    static public int sub(int num1, int num2) { return num1 - num2; }

    /// <summary>
    /// Prints internal info for the type using reflection
    /// </summary>
    /// <param name="suffix">indentation spaces</param>
    /// <param name="type">type object</param>
    static void PrintInfo(string suffix, Type type)
    {
        Console.WriteLine(suffix + "Type Name: " + type.Name);
        Console.WriteLine(suffix + "Base Type: ");
        if (type.BaseType == null)
            Console.WriteLine(suffix + suffix + "None");
        else
            PrintInfo(suffix + "  ", type.BaseType);
        Console.WriteLine(suffix + "Member Info:");
        MemberInfo[] members = type.GetMembers(BindingFlags.Public
            | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var item in members)
            Console.WriteLine(suffix + "name: {0,-15} type: {2,-11} in: {1}",
                              item.Name, item.DeclaringType?.Name, item.MemberType);
    }
    public static void MyF1() => Console.WriteLine("F1");
    public static void MyF2() => Console.WriteLine("F2");
    public static void MyF3() => Console.WriteLine("F3");
}
public delegate int SomeDelegate(int x, int y);
public delegate void MD();
public delegate int MyDelegate(int p1, string p2);

static class MyTools
{
    public static int ToInt(this string str) => int.Parse(str);
    
    public static void ToStringProperty<T>(this T t)
    {
        string str = "";
        foreach (var item in t!.GetType().GetProperties())
            str += "\n" + item.Name + ": " + item.GetValue(t, null);
        Console.WriteLine(str);
    }
}

class MyClass
{
    public int Id;
    public string? Name;

    //public void f1() { }
    //public int f2() => 0;
}
