namespace Lesson6Printer;

internal class User3
{
    private readonly int id;
    private readonly Printer3? _printer;
    public User3(int id, Printer3 printer)
    {
        this.id = id;
        _printer = printer;
        printer.PageOver += myPageOver;
    }

    private void myPageOver()
    {
        Console.WriteLine($"User#{id}: There is no paper - bring it!");
    }

}
