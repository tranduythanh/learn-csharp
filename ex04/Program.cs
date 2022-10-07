namespace ex04
{
    class Program
    {
        static void Main()
        {
            MyDate d1 = new MyDate(28, 2, 2022);
            Console.WriteLine(d1.DaysOfMonth());
            Console.WriteLine(d1);
            Console.WriteLine(d1.Next());
            Console.WriteLine(d1.Next().Next());

            MyDate d2 = new MyDate(28, 2, 2024);
            Console.WriteLine(d2.DaysOfMonth());
            Console.WriteLine(d2);
            Console.WriteLine(d2.Next());
            Console.WriteLine(d2.Next().Next());

            Classroom c = new Classroom(5);
            c.AddStudent("Trần", "Duy Thanh", 9, 7);
            c.AddStudent("Nguyễn", "Hiền Minh Châu", 9, 9);
            c.AddStudent("Võ", "Quang Nguyên", 7, 8);
            c.AddStudent("Nguyễn", "Quỳnh Như", 7, 5);
            c.AddStudent("Phan", "Nguyễn Quốc Quyên", 9, 5);
            c.Print();
            Console.WriteLine("Avg Literature: {0}", c.ClassAvgLiterature());
            Console.WriteLine("Avg Math:       {0}", c.ClassAvgMath());
            Console.WriteLine("-------- Sort by name -------");
            c.SortByName();
            c.Print();
            Console.WriteLine("-------- Sort by avg and name -------");
            c.SortByAvgAndName();
            c.Print();
        }
    }
}