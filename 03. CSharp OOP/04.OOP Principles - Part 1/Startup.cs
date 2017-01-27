namespace _04.OOP_Principles___Part_1
{
    using System;
    using AnimalHierarchy;
    using School;
    using StudentsAndWorkers;

    public class Startup
    {
        public static void Main()
        {
            School.Student student = new School.Student("Milko", "Milchev", 2);
            School.Student studentTwo = new School.Student("Ivancho", "Ivanov", 1);
            SchoolClass seventhGradeA = new SchoolClass('a', new Teacher("Ms", "Ivanova"));
            seventhGradeA.AddStudent(student);
            seventhGradeA.AddStudent(studentTwo);
            seventhGradeA.RemoveStudent(studentTwo);
            School.Student studentThr = new School.Student("Grigor", "Grigorov", 1);
            student.AddComment("something");
            Console.WriteLine(student.Comments);
            TestStudentsAndWorkers.Test();
            AnimalHierarchyTest.Test();
        }
    }
}