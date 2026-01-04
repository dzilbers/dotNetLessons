#pragma warning disable IDE0079 // Remove unnecessay suppression
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable IDE0060 // Remove unused parameter

using System.Diagnostics;
using System.Reflection;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
namespace Attributes;

/// <summary>
/// Person class for demonstration of attributes:
/// <list type="bullet">
/// <item>DebuggerDisplay</item>
/// <item>Obsolete</item>
/// </list>
/// </summary>
[DebuggerDisplay("{Name,nq}({Id,h})", Type = "Person")]
//[DebuggerDisplay("{Name,nq}({Id})")]
//[DebuggerDisplay("{Name}({Id})")]
class Person
{
    //[DebuggerDisplay("{Id,d}", Name = "Identification Number")]
    internal int Id;
    //[Developer("Moti", 18)]
    internal string? Name;

    //[Obsolete("Please stop using this function, use F2(int) instead", true)]
    [Obsolete("Please stop using this function, use F2(int) instead")]
    //[Obsolete]
    internal void F1() { }
    internal void F2(int num) { }

    public override string ToString() => $"Person: #{Id}, name: {Name}";
}

[Developer("Dani", 59, Reviewed = true)]
internal class Program
{
    //[DebuggerDisplay("This is the Main method")] // invalid
    private static void Main(string[] args)
    {
        // Main:
        //Person p = new() { Id = 123, Name = "Donald" };
        //p.F1();
        //Console.WriteLine(p);

        GetAttribute(typeof(Program));
    }

    [Developer("Dani", 59, Reviewed = true)]
    [Developer("Yossi", 52)]
    public static void GetAttribute(Type t)
    {
        // Get instance of the attribute.
        if (Attribute.GetCustomAttribute(t, typeof(DeveloperAttribute)) is DeveloperAttribute att1)
        {
            // Get the Name value.
            Console.WriteLine($"The Name is: {att1.Name}.");
            // Get the Level value.
            Console.WriteLine($"The Level is: {att1.Level}.");
            // Get the Reviewed value.
            Console.WriteLine($"The Reviewed is: {att1.Reviewed}.");
        }
        else
            Console.WriteLine("The attribute was not found.");

        Console.WriteLine("================================");
        if (t.GetCustomAttribute(typeof(DeveloperAttribute)) is DeveloperAttribute att2)
        {
            // Get the Name value.
            Console.WriteLine($"The Name is: {att2.Name}.");
            // Get the Level value.
            Console.WriteLine($"The Level is: {att2.Level}.");
            // Get the Reviewed value.
            Console.WriteLine($"The Reviewed is: {att2.Reviewed}.");
        }
        else
            Console.WriteLine("The attribute was not found.");

        Console.WriteLine("================================");
        var att3 = t.GetCustomAttribute<DeveloperAttribute>();
        if (att3 is not null)
        {
            // Get the Name value.
            Console.WriteLine($"The Name is: {att3.Name}.");
            // Get the Level value.
            Console.WriteLine($"The Level is: {att3.Level}.");
            // Get the Reviewed value.
            Console.WriteLine($"The Reviewed is: {att3.Reviewed}.");
        }
        else
            Console.WriteLine("The attribute was not found.");

        Console.WriteLine("======== Attribute data:");
        foreach (var data in t.GetCustomAttributesData())
        {
            Console.WriteLine($"  Attribute type is {data.AttributeType}");
            Console.WriteLine("    ========= Arguments:");
            foreach (var arg in data.ConstructorArguments)
                Console.WriteLine($"    ({arg.ArgumentType}){arg.Value}");
            Console.WriteLine("    ========= Named Arguments:");
            foreach (var arg in data.NamedArguments)
                Console.WriteLine($"    {arg.MemberName} = {arg.TypedValue}");
        }


        Console.WriteLine("======== Method attributes:");
        // Get the method-level attributes.

        // Get all methods in this class, and put them
        // in an array of System.Reflection.MemberInfo objects.
        MemberInfo[] myMemberInfo = t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

        // Loop through all methods in this class that are in the
        // MyMemberInfo array.
        foreach (var member in myMemberInfo)
        {
            Console.WriteLine($"Interrogating member {member.Name} ({member}):");
            // Get instance of the attribute.
            foreach(DeveloperAttribute att in member.GetCustomAttributes<DeveloperAttribute>())
            {
                Console.WriteLine("  ===========================");
                // Get the Name value.
                Console.WriteLine($"  The Name is: {att.Name}.");
                // Get the Level value.
                Console.WriteLine($"  The Level is: {att.Level}.");
                // Get the Reviewed value.
                Console.WriteLine($"  The Reviewed is: {att.Reviewed}.");
            }
            Console.WriteLine("  ===========================");
        }

    }
}

#pragma warning restore IDE0060 // Remove unused parameter
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore IDE0079 // Remove unnecessay suppression