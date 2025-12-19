namespace Lesson6Printer;

internal class PrinterEventArgs : EventArgs
{
    public int PagesRequested { get; }
    public int PagesAvailable { get; }
    public bool Handled { get; set; } = false;

    public PrinterEventArgs(int pagesRequested, int pagesAvailable)
    {
        PagesRequested = pagesRequested;
        PagesAvailable = pagesAvailable;
    }
}
