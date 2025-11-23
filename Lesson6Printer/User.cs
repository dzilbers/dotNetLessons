namespace Lesson6Printer;

internal class User
{
    private readonly int id;
    private readonly Printer? _printer;
    public User(int id, Printer printer)
    {
        this.id = id;
        _printer = printer;
        printer.PageOver += myPageOver;
    }

    static Random rnd = new Random();

    //private void myPageOver(object? printer, EventArgs args)
    private void myPageOver(object? printer, PrinterEventArgs args)
    {
        if (args.Handled)
            return;

        Console.WriteLine($"User#{id}: There is no paper - bring it!");
        //var pArgs = args as PrinterEventArgs;
        //Console.WriteLine($"The printer has {pArgs?.PagesAvailable} while it was requested to print {pArgs?.PagesRequested}");
        Console.WriteLine($"The printer has {args?.PagesAvailable} while it was requested to print {args?.PagesRequested}");
        if (rnd.NextDouble() < 0.5)
        {
            int pagesToAdd = rnd.Next(10, 51);
            Console.WriteLine($"User#{id}: I am bringing {pagesToAdd} pages.");
            _printer?.AddPaper(pagesToAdd);
            args!.Handled = true;
        }
        else
        {
            Console.WriteLine($"User#{id}: Sorry, I can't bring paper now.");
        }
    }

}
