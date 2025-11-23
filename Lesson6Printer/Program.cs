using Lesson6Printer;

// Try 1 & 2 - Simple Printer
//Printer1 printer1 = new();
//_ = new User2(1, printer1);
//_ = new User2(2, printer1);
//printer1?.PageOver?.Invoke();
//Console.WriteLine("Please enter pages to print:");
//printer1?.Print(int.Parse(Console.ReadLine()!));

// Try 3 - Simple Printer
//Printer3 printer3 = new();
//_ = new User3(1, printer3);
//_ = new User3(2, printer3);
////printer3?.PageOver?.Invoke();
//Console.WriteLine("Please enter pages to print:");
//printer3?.Print(int.Parse(Console.ReadLine()!));

// Try with EventArgs - Simple Printer
Printer printer = new();
_ = new User(1, printer);
_ = new User(2, printer);
Console.WriteLine("Please enter pages to print:");
printer?.Print(int.Parse(Console.ReadLine()!));

