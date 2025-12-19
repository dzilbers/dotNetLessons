namespace Lesson2;
internal class Class1
{
    //public Class1(int x) => Field = x;

    private int field = 1;
    public int Field
    {
        get => field;
        set => field = value;
    }
    // public int Field => field;

    //public void func(int x) => Field = x;

    public DateTime Today => DateTime.Now;

    public int Prop { get; set; }

    public override string ToString()
        => $"Hello Moshe, you are number {field}";

    public string Sum(string text, params int[] args)
    {
        int sum = 0;
        foreach (var arg in args)
            sum += arg;
        return text + ": " + sum;
    }

    public void Optional(int n1, int n2 = 2, int n3 = 8)
    {
        Console.WriteLine(Sum("Optional", n1, n2, n3));
    }

}



