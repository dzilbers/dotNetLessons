static class CoffeeAsyncExample
{
    static async void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // This is the entry point for the program (the Main Thread)
        // Starting from C# 7.1, Main can also be async
        Console.WriteLine($"[Main Thread: {Environment.CurrentManagedThreadId}]" + $" הלקוח ניגש לקופה ומזמין קפה.".reverse());

        // 1. הזמנה: קריאה למתודה האסינכרונית
        Console.WriteLine($"[Main Thread: {Environment.CurrentManagedThreadId}]" + $" הזמנת הקפה נשלחה למוזגת...".reverse());
        var coffeeTask = orderCoffeeAsync();

        // 2. (הזמזם) Task-קבלת ה
        Console.WriteLine($"[Main Thread: {Environment.CurrentManagedThreadId}]" + $" .(Task-" + $" קיבלתי את הזמזם )ה".reverse());

        // 3. (ההמתנה הלא חוסמת) await-ה:
        // !משתחרר כאן. הוא לא מחכה Main Thread-ה
        Console.WriteLine($"[Main Thread: {Environment.CurrentManagedThreadId}]" + $" אני הולך לשבת, לקרוא עיתון ולחכות לצפצוף...".reverse());

        // הנוכחי משוחרר Thread-כאן הקסם קורה. ה .await-נקודת ה
        string myCoffee = await coffeeTask;

        // 4. סיום המשימה והמשך ביצוע (Continuation):
        // !Thread-כשהגענו לכאן, הפעולה הסתיימה. שימו לב למזהה ה
        // .המקורי Main Thread-שונה מה Thread סביר להניח שזה יהיה ,Console באפליקציית
        Console.WriteLine($"--- הזמזם צפצף! ---".reverse());
        Console.WriteLine($"[Continuation Thread: {Environment.CurrentManagedThreadId}]" + $" לקחתי את הקפה: ".reverse() + $"{myCoffee}");
        Console.WriteLine($"[Continuation Thread: {Environment.CurrentManagedThreadId}]" + $" ממשיך בסדר היום שלי.".reverse());

        Console.Read(); // כדי שהחלון לא ייסגר מיד
    }

    // מתודה שמדמה את עבודת המוזגת (פעולה אסינכרונית ש"לוקחת זמן")
    static async Task<string> orderCoffeeAsync()
    {
        Console.WriteLine($"   --> [Worker Thread: {Environment.CurrentManagedThreadId}]" + $" המוזגת מתחילה להכין את הקפה...".reverse());

        // 
        // .(כמו קריאה לרשת או לדיסק שלוקחת 3 שניות) I/O הדמיה של פעולת
        // .שצוין בשורה הקודמת משתחרר בזמן ההמתנה הזו Thread-גם כאן, ה
        await Task.Delay(3000);

        Console.WriteLine($"   --> [Worker Thread: {Environment.CurrentManagedThreadId}]" + $" המוזגת סיימה! הקפה מוכן.".reverse());
        return "אספרסו כפול חם".reverse();
    }

    static string reverse(this String str) => new(str.Reverse().ToArray());
}