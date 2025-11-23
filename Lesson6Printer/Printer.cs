namespace Lesson6Printer;

internal class Printer
{
    //public event EventHandler? PageOver;
    public event EventHandler<PrinterEventArgs>? PageOver;
    private int _pageCount = 20;
    private void handlePageOver(EventArgs args) => PageOver?.DynamicInvoke(this, args);
    //                   { if (PageOver != null) PageOver(); }     
    public void Print(int pages)
    {
        if (pages <= _pageCount)
            _pageCount -= pages;
        else
        {
            handlePageOver(new PrinterEventArgs(pages, _pageCount));
            _pageCount = 0;
        }
    }

    internal void AddPaper(int pagesToAdd)
    {
        _pageCount += pagesToAdd;
    }
}
