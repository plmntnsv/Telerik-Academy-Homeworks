namespace _03.Extension_Methods_Delegates_Lambda_LINQ._01.Extensions
{
    using _03.LINQ_query;
    using _16.Groups;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ExtractStudentsExtension
    {
        public static List<string> ExtractStudentsFromGroupTwo(this List<Student> students)
        {
            var studentsFromGroupTwo = (from student in students
                                       where student.GroupNumber == 2
                                       orderby student.FirstName
                                       select student.FirstName + " " + student.LastName + " is in group " + student.GroupNumber).ToList();
            return studentsFromGroupTwo;
        }

        public static void ExtractStudentsWithTwoTwos(this List<Student> students)
        {
            var studentsWithTwoTwos = students
                                    .Where(student => student.Marks.FindAll(x => x == 2).Count == 2)
                                    .ToList();
            foreach (var stud in studentsWithTwoTwos)
            {
                Console.WriteLine(stud.FirstName+" "+stud.LastName+" "+string.Join(", ",stud.Marks));
            }
        }

        public static void ExtractStudentsByGroupName (this List<Student> students, Group[] groupArr )
        {
            var studentsFromGroupedByDpt = students
                                   .Join(groupArr,
                                        stdnt => stdnt.GroupNumber,
                                        group => group.GroupNumber,
                                        (stdnt, group) => 
                                        new { FullName = stdnt.FirstName + " " + stdnt.LastName, Department = group.DepartmentName })
                                        .GroupBy(st => st.Department);
            foreach (var student in studentsFromGroupedByDpt)
            {
                foreach (var student2 in student)
                {
                    Console.WriteLine(student2);
                }
            }
        }
    }
}
