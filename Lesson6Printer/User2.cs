namespace Lesson6Printer;

internal class User2
{
    private readonly int id;
    private readonly Printer1? _printer;
    public User2(int id, Printer1 printer)
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
