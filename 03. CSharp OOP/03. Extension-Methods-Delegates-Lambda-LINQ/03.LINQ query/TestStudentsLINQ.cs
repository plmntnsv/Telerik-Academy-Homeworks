namespace _03.Extension_Methods_Delegates_Lambda_LINQ._03.LINQ_query
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _01.Extensions;
    using _16.Groups;

    public class TestStudentsLINQ
    {
        public static void Test()
        {
            List<Student> students = new List<Student>
            {
                new Student("Albert", "Einstein", 61, "123406", "+99/223344","albert.einsten@abv.bg", new List<int> {6, 6, 5, 6, 6, 6, 6 }, 2),
                new Student("Rollo", "Lothbrok", 39, "185486", "+88/964235","rolloyolo@gmail.com", new List<int> {3, 2, 4, 5, 4, 3, 6 }, 5),
                new Student("Ragnar", "Lothbrok", 37, "124863", "+46/589255","ragnar@abv.bg", new List<int> {5, 4, 5, 3, 6, 6, 5 }, 5),
                new Student("Walter", "White", 55, "234859", "+02/256488","ww@mail.bg", new List<int> {6, 6, 6, 5, 6, 5, 5 }, 2),
                new Student("Rick", "Grimes", 40, "785612", "+47/259864","rickgr33@yahoo.com", new List<int> {4, 5, 5, 4, 4, 4, 5 }, 3),
                new Student("Jon", "Snow", 23, "859666", "+02/914325","snauh@abv.bg", new List<int> {4, 5, 4, 5, 5, 6, 6 }, 1),
                new Student("Hulk", "Smash", 45, "124356", "+77/856823","qadafsgwrwqqeasd@gmail.com", new List<int> {2, 2, 4, 3, 5, 5, 6 }, 1),
                new Student("Dean", "Winchester", 34, "123789", "+78/523344","d.win@abv.bg", new List<int> {3, 4, 2, 4, 4, 3, 2 }, 3),
                new Student("Finn", "Mertens", 13, "123506", "+02/223344","finnthehuman@yahoo.com", new List<int> {5, 4, 4, 5, 3, 5, 4 }, 4),
                new Student("Eric", "Cartman", 9, "123895", "+78/561245","eric.cart@gmail.com", new List<int> {2, 2, 4, 5, 4, 3, 3 }, 4),
                new Student("Adolf", "Pitler", 44, "159706", "+02/657899","apttlr@gmail.com", new List<int> {4, 5, 6, 5, 6, 5, 6 }, 2)
            };

            //Console.WriteLine("Students in group 2 sorted by first name:");
            //var studentsFromGroupTwo = from student in students
            //                           where student.GroupNumber == 2
            //                           orderby student.FirstName
            //                           select student.FirstName + " "+student.LastName + " is in group " + student.GroupNumber;
            //foreach (var student in studentsFromGroupTwo)
            //{
            //    Console.WriteLine(student);
            //}
            //Console.WriteLine("\nSame using extension methods:");
            //foreach (var student in students.ExtractStudentsFromGroupTwo())
            //{
            //    Console.WriteLine(student);
            //}
            //Console.WriteLine("\nExtract students with mail abv.bg:");
            //var studentsWithAbv = from student in students
            //                      where student.Email.Contains("abv.bg")
            //                      select student.FirstName + " " + student.LastName + " is using " + student.Email;
            //foreach (var student in studentsWithAbv)
            //{
            //    Console.WriteLine(student);
            //}
            //Console.WriteLine("\nStudents with phones in sofia");
            //var studentsWithSofiaPhone = from student in students
            //                             where student.Phone.StartsWith("+02/")
            //                             select student.FirstName + " " + student.LastName + " phone is " + student.Phone;
            //foreach (var student in studentsWithSofiaPhone)
            //{
            //    Console.WriteLine(student);
            //}
            //Console.WriteLine("\nSelect all students that have at least one mark Excellent (6) into a new anonymous class");
            //var studentsWithAtLeastOneSix = from student in students
            //                                where student.Marks.Contains(6)
            //                                select new { fullname = student.FirstName + " " + student.LastName, marks = string.Join(", ", student.Marks) };
            //foreach (var student in studentsWithAtLeastOneSix)
            //{
            //    Console.WriteLine(student);
            //}
            //Console.WriteLine("\nExtract student with two twos using extension method");
            //students.ExtractStudentsWithTwoTwos();
            //Console.WriteLine("\nExtract students that enrolled in 2006:");
            //var studentsEnrolledIn2006 = students
            //                            .Where(student => student.FN.EndsWith("06"))
            //                            .Select(x => x.FirstName + " " + x.LastName + " FN: " + x.FN +" Marks: "+ x.GetMarks())
            //                            .ToList();
            //foreach (var student in studentsEnrolledIn2006)
            //{
            //    Console.WriteLine(student);
            //}

            //Console.WriteLine("\nExtract all students from Mathematics department:");
            Group[] groups = new Group[]
            {
                new Group(1, "Programming"),
                new Group(2, "Sport"),
                new Group(3, "Mathematics"),
                new Group(4, "Philosophy"),
                new Group(5, "Physics")
            };

            //var studentsFromMathDpt = students
            //                       .Join(groups,
            //                            stdnt => stdnt.GroupNumber,
            //                            group => group.GroupNumber,
            //                            (stdnt, group) =>
            //                            new { FullName = stdnt.FirstName + " " + stdnt.LastName, Department = group.DepartmentName })
            //                        .Where(x => x.Department == "Mathematics");

            //foreach (var student in studentsFromMathDpt)
            //{
            //    Console.WriteLine(student);
            //}
            //Console.WriteLine("\nGrouped students by GroupNumber");
            //var groupedByGroupNumber = students
            //                          .OrderBy(s => s.GroupNumber)
            //                          .GroupBy(s => s.GroupNumber)
            //                          .ToList();

            //foreach (var item in groupedByGroupNumber)
            //{
            //    foreach (var item2 in item)
            //    {
            //        Console.WriteLine(item2.FirstName + " is in group " + item2.GroupNumber);
            //    }

            //}
            Console.WriteLine("\nGroup students by group name using extensions:");
            students.ExtractStudentsByGroupName(groups);
        }

    }
}

