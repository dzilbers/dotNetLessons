var oldArray = new[] { 2, 4, 5, 8, 10 };
var newArray =
    from number in oldArray
    where number % 2 == 0
    select number * 2;

foreach (var number in newArray)
    Console.Write(number + ",");
Console.WriteLine();

oldArray[3] = 20;
foreach (var number in newArray)
    Console.Write(number + ",");
Console.WriteLine();

var realArray =
    (from number in oldArray
     where number % 2 == 0
     select number * 2).ToList();

//Console.WriteLine(newArray.Average());

//List<Student> studentList =
//[
//    new Student {Id =  1, Name = "Yossi", Grades = [67, 90, 81]},
//    new Student {Id =  2, Name = "Dani", Grades = [100, 100, 100, 100]},
//    new Student {Id =  3, Name = "Eli", Grades = [61, 62, 63]},
//    new Student {Id =  4, Name = "Srulik", Grades = [73, 62, 81]}
//];

//Console.WriteLine($"{studentList.Average(student => student!.Grades!.Average())}");