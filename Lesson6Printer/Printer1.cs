namespace Lesson6Printer;

internal delegate void PrintEventHandler1();

internal class Printer1
{
    public PrintEventHandler1? PageOver;
    private int _pageCount = 20;
    private void handlePageOver() => PageOver?.DynamicInvoke();
    //                   { if (PageOver != null) PageOver(); }     
    public void Print(int pages)
    {
        if (pages <= _pageCount)
            _pageCount -= pages;
        else
        {
            _pageCount = 0;
            handlePageOver();
        }
    }

}
