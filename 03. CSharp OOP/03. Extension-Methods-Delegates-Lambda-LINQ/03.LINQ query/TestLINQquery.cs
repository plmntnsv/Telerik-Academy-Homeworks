namespace _03.Extension_Methods_Delegates_Lambda_LINQ._03.LINQ_query
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class TestLINQquery
    {
        public static void Test()
        {
            Student[] students = new Student[]
            {
            new Student("Arnold", "Abrnold", 23),
            new Student("Elvis", "Presley", 30),
            new Student("Arnold", "Aarnold", 26),
            new Student("Aaz", "Zaaz", 24),
            new Student("Zizi", "Bizi", 42),
            new Student("Some", "Name", 19),
            new Student("Ragnar", "Zlothbrok", 35),
            new Student("Bumbo", "Dumbo", 26),
            new Student("Zaza", "Baza", 18)
            };

            Console.WriteLine("Compare first name and last name of students lexicographically:");
            List <Student> studentsNamesCompareList = students.NamesComparer();
            foreach (Student student in studentsNamesCompareList)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();
            Console.WriteLine("Get students in age range 18 - 24:");
            var studentsAgeRangeList =
                                    from student in students
                                    where student.Age >= 18 && student.Age <= 24
                                    select student;
            foreach (var student in studentsAgeRangeList)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
            Console.WriteLine("Order students with lambda expresions first by first name then by last name:");
            var studentsByNameWithExtensions = students
                                .OrderByDescending(student => student.FirstName)
                                .ThenByDescending(student => student.LastName);
            foreach (Student student in studentsByNameWithExtensions)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();
            Console.WriteLine("Rewrite the same with LINQ.");
            var studentsByNameWithLINQ = from student in students
                                         orderby student.FirstName descending, student.LastName descending
                                         select student;
            foreach (Student student in studentsByNameWithLINQ)
            {
                Console.WriteLine(student);
            }
        }

        public static List<Student> NamesComparer(this Student[] students)
        {
            List<Student> result =
                (from student in students
                 where (string.Compare(student.FirstName, student.LastName) < 0)
                 select student).ToList();
            return result;
        }
    }
}
