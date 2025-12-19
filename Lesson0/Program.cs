namespace Lesson0;

internal class Program
{
    private static int _number = 0;

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.ReadKey();

        Console.WriteLine(_number);
        string text = "Test";
        Console.WriteLine(text);

        //DateTime dt1 = DateTime.TryParse("04.05.2024"); // need one more parameter, returns bool
        DateTime dt2 = DateTime.Parse("04.05.2024");
        //DateTime dt3 = new DateTime("04.05.2024"); // there is no constructor with string parameter
        //DateTime dt4 = (DateTime)"04.05.2024"; // there is no explicit conversion from string
    }
}
