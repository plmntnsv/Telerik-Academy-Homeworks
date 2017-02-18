namespace _04.OOP_Principles___Part_1.StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class TestStudentsAndWorkers
    {
        public static void Test()
        {
            List<Student> studentsList = new List<Student>
            {
                new Student("Bruce", "Banner", 6),
                new Student("Peter", "Parker", 5),
                new Student("Hello", "There", 3),
                new Student("Ran", "Dom", 2),
                new Student("Smart", "Guy", 6),
                new Student("Ronald", "Mcdonald", 2),
                new Student("Peshko", "Peshkev", 4),
                new Student("Walter", "White", 6),
                new Student("Typical", "Student", 4),
                new Student("Goshko", "Goshkev", 3)
            };

            Console.WriteLine("Sort students by grades using extension method:");
            studentsList.SortByGrade();

            List<Worker> workersList = new List<Worker>
            {
                new Worker("Gosho", "Goshev", 200, 8),
                new Worker("Tosho", "Toshev", 250, 8),
                new Worker("Pesho", "Peshev", 320, 6),
                new Worker("Ivan", "Ivanov", 150, 4),
                new Worker("Cvetka", "Cvetkova", 235, 5),
                new Worker("Atanas", "Atanasov", 115, 8),
                new Worker("Bobi", "Bobev", 260, 8),
                new Worker("Stoyanka", "Stoyankova", 180, 7),
                new Worker("Emil", "Emilov", 195, 8),
                new Worker("Bai", "Ivan", 500, 12),
            };

            Console.WriteLine("\nSort in descending order workers by money per hour:");
            var sortedWorkers = from worker in workersList
                                orderby worker.MoneyPerHour() descending
                                select string.Format("{0,-8} {1,-10} - {2,6:F2}lv. per hour", worker.FirstName, worker.LastName, worker.MoneyPerHour());
            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine(worker);
            }

            Console.WriteLine("\nMerge students and workers and order them by name:");
            ////var merged = studentsList
            ////            .Concat<Human>(workersList)
            ////            .OrderBy(x => x.FirstName)
            ////            .ThenBy(x => x.LastName);
            List<Human> merged = new List<Human>();
            merged.AddRange(studentsList);
            merged.AddRange(workersList);
            merged = merged
                    .OrderBy(x => x.FirstName)
                    .ThenBy(y => y.LastName)
                    .ToList();
            foreach (var human in merged)
            {
                Console.WriteLine(human.FirstName + " " + human.LastName);
            }
        }

        public static void SortByGrade(this List<Student> students)
        {
            var sorted = students
                        .OrderBy(x => x.Grade)
                        .Select(y => y.FirstName + " " + y.LastName + " " + y.Grade)
                        .ToList();
            foreach (var student in sorted)
            {
                Console.WriteLine(student);
            }
        }
    }
}
