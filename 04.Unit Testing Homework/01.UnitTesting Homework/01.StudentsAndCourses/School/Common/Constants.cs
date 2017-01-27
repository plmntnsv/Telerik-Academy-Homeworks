namespace School.Common
{
    public class Constants
    {
        public const int MaxStudentsPerCourse = 29;
        public const int MinIdNumber = 10000;
        public const int MaxIdNumber = 99999;

        public const string MaxStudentsPerCourseCapacityReached = "This course is already full. A course can have up to 29 students.";
        public const string InvalidStudentLeavingCourse = "The student cannot leave, because he/she is not in this course!";
        public const string InvalidStudentEnteringCourse = "The student cannot enter, because he/she is already in this course!";
        public const string EmptyName = "The name cannot be empty or null!";
        public const string MinOrMaxIdNumberReached = "Student's number cannot be lower than {0} or greater than {1}.";
        public const string StudentWithSameIdFound = "There is already a student with the same ID.";
    }
}
