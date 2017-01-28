namespace School.Common
{
    using System;

    public static class Validator
    {
        public static void ValidateIdRange(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(string.Format(message, Constants.MinIdNumber, Constants.MaxIdNumber));
            }
        }

        public static void ValidateIdUniqueness(int value)
        {
            if (School.students.Exists(x => x.Id == value))
            {
                throw new ArgumentException(Constants.StudentWithSameIdFound);
            }
        }

        public static void ValidateNullOrEmptyName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(Constants.EmptyName);
            }
        }

        public static void ValidateCourseCapacity(Course course)
        {
            if (course.CourseStudents.Count == Constants.MaxStudentsPerCourse)
            {
                throw new ArgumentException(Constants.MaxStudentsPerCourseCapacityReached);
            }
        }

        public static void ValidateStudentEnteringCourse(Course course, Student student)
        {
            if (course.CourseStudents.Contains(student))
            {
                throw new ArgumentException(Constants.InvalidStudentEnteringCourse);
            }
        }

        public static void ValidateStudentLeavingCourse(Course course, Student student)
        {
            if (!course.CourseStudents.Contains(student))
            {
                throw new ArgumentException(Constants.InvalidStudentLeavingCourse);
            }
        }
    }
}
