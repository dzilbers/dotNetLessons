using System.Reflection;
using System.Xml.Serialization;

namespace xml
{
    //public record Student(int Id, string LastName, string? FirstName = null)
    //{
    //    public Student() : this(0, "", "") { }
    //}

    class Program
    {
        //public static List<Student> list = new()
        //{
        //    new(Id:1, FirstName:"Avrumi", LastName:"Rosenberg"),
        //    new(Id:2, FirstName:"Israel", LastName:"Hartuv"),
        //    new(Id:3, LastName:"Eliahu"),
        //};

        //static void Main(string[] args)
        //{
            //string path = Assembly.GetExecutingAssembly().Location;
            //path = Path.GetDirectoryName(path)!;
            //path = Path.GetDirectoryName(path)!;
            //path = Path.GetDirectoryName(path)!;
            //path = Path.GetDirectoryName(path)!;
            //path += @"\students.xml";
            //FileStream fsout = new FileStream(path, FileMode.Create);
            //XmlSerializer xs = new XmlSerializer(typeof(List<Student>));
            //xs.Serialize(fsout, list);
            //fsout.Close();
            //FileStream fsin = new FileStream(path, FileMode.Open);
            //var result = (IEnumerable<Student>?)xs.Deserialize(fsin);
            //fsin.Close();
            //if (result is null)
            //{
            //    Console.WriteLine("Can't deserialize");
            //    return;
            //}
            //foreach (var stud in result)
            //    Console.WriteLine(stud);
        //}

        //static int count = 0;
        //private static int digitCount(int num)
        //{
        //    if (num < 10)
        //    {
        //        ++count;
        //        return 1;
        //    }
        //    return digitCount(num / 10) + 1;
        //}

        static void Main(string[] args)
        {
            #region linq to anonymous object
            //List<string> strings = new List<string>() { "Wolpert", "Fay", "Basali", "Adini", "Fichman", "Minerbi", "Mamistvalov" };
            //foreach (var item in from s in strings
            //                     select new { Lower = s.ToLower(), Upper = s.ToUpper() })
            //    Console.WriteLine(item);
            #endregion
            #region linq let
            //int[] numbersA = { 1, 22, 333, 4444, 55555, 666666, 7777777 }; // len = 7
            //int[] numbersB = { 1, 3, 5 }; // len = 3
            //var result = from num1 in numbersA
            //             let digits = digitCount(num1)
            //             from num2 in numbersB
            //             where digits == num2
            //             select new { Number = num1, Digits = digits }; // num1;
            //var result2 = new List<int>();
            //foreach (var num1 in numbersA)
            //{
            //    int digits = digitCount(num1);
            //    foreach (var num2 in numbersB)
            //        if (digits == num2)
            //            result2.Add(num1);
            //}

            //foreach (var num in result)
            //    Console.Write(" " + num);
            //Console.WriteLine();
            //Console.WriteLine("While count = " + count);
            #endregion
            //var v = from stud in initList()
            //        let av = stud.Grades.Average()
            //        let test = test()
            //        where av > 80
            //        //orderby stud.Age descending, stud.Name
            //        select new { /*Id = stud.Id,*/ Name = stud.Name, /*Age = stud.Age,*/ Aver = av };

            //Console.WriteLine("After LINQ query");

            //foreach (var item in v)
            //    Console.WriteLine(item);
            //        //"age: {3, 2} name: {0,-10} id: {1,-5} average: {2}",
            //        //item.Name, item.Id, item.Aver, item.Age);

            List<string> words = new List<string>
            {
                "do", "apple", "coin", "orange", "red", "blue", "divide", "add", "subtract", "mutiply",
                "israel", "dubai", "word", "list", "observer", "observable", "average", "student", "await",
                "async", "bonus", "bus"
            };

            //var dictionary = 
            //    from word in words
            //    let first = word[0].ToString().ToUpper()
            //    //orderby word
            //    group first + word.Substring(1) by first;

            //var fixedDictionary = 
            //    from g in dictionary
            //    orderby g.Key
            //    select g;

            var dictionary = 
                from word in words
                let first = word[0].ToString().ToUpper()
                group first + word.Substring(1) by first
                into g // from g in result of the above
                orderby g.Key
                select g;

            foreach (var g in dictionary /* fixedDictionary */)
            {
                Console.WriteLine(g.Key);
                foreach (var word in g)
                    Console.WriteLine("   " + word);
            }

            //foreach (var item in initList().GroupBy(s => s.Name[0], (first, studs) => new { FirstChar = first, Count = studs.Count() }))
            //    Console.WriteLine("{0, 1}: count = {1, -2}", item.FirstChar, item.Count);

            //#region Parallel LinQ
            //IEnumerable<string> names = (from st in initList().AsParallel().AsOrdered()
            //                             orderby st.Grades[0]
            //                             select st.Name).AsSequential();
            //foreach (var name in names)
            //    Console.WriteLine(name);
            //#endregion
        }

        static List<Student> initList()
        {
            return new List<Student>
            {
                new() { Id = 1, Name = "Reuven", Age = 24, Grades = new List<int>() { 98, 96, 88 } },
                new Student() { Id = 2, Name = "Shimon", Age = 24, Grades = new List<int>() { 78, 80, 58 } },
                new Student() { Id = 3, Name = "Levy", Age = 24, Grades = new List<int>() { 83, 87, 70 } },
                new Student() { Id = 4, Name = "Yehuda", Age = 24, Grades = new List<int>() { 100, 72, 32 } },
                new Student() { Id = 5, Name = "Issachar", Age = 24, Grades = new List<int>() { 64, 71, 83 } },
                new Student() { Id = 6, Name = "Zvulun", Age = 24, Grades = new List<int>() { 90, 95, 60 } },
                new Student() { Id = 7, Name = "Gad", Age = 24, Grades = new List<int>() { 43, 25, 75 } },
                new Student() { Id = 8, Name = "Dan", Age = 24, Grades = new List<int>() { 99, 92, 90 } },
                new Student() { Id = 9, Name = "Asher", Age = 24, Grades = new List<int>() { 100, 100, 0 } },
                new Student() { Id = 10, Name = "Naftali", Age = 24, Grades = new List<int>() { 100, 100, 0 } },
                new Student() { Id = 11, Name = "Yossef", Age = 24, Grades = new List<int>() { 100, 100, 0 } },
                new Student() { Id = 12, Name = "Binyamin", Age = 24, Grades = new List<int>() { 100, 100, 0 } },
                new Student() { Id = 13, Name = "Dina", Age = 24, Grades = new List<int>() { 100, 100, 0 } },
                new Student() { Id = 14, Name = "Menashe", Age = 24, Grades = new List<int>() { 100, 100, 0 } },
                new Student() { Id = 15, Name = "Efraim", Age = 24, Grades = new List<int>() { 100, 100, 0 } },
                new Student() { Id = 16, Name = "Onan", Age = 24, Grades = new List<int>() { 100, 100, 0 } },
                new Student() { Id = 17, Name = "Shela", Age = 24, Grades = new List<int>() { 100, 100, 0 } },
                new Student() { Id = 18, Name = "Kehat", Age = 24, Grades = new List<int>() { 100, 100, 0 } },
                new Student() { Id = 19, Name = "Gershon", Age = 24, Grades = new List<int>() { 100, 100, 0 } },
                new Student() { Id = 20, Name = "Merari", Age = 24, Grades = new List<int>() { 100, 100, 0 } },
            };
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public List<int>? Grades { get; set; }
    }

}

