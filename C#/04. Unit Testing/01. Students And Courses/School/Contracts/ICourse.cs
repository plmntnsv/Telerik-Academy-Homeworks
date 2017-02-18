namespace School.Contracts
{
    using System.Collections.Generic;

    public interface ICourse
    {
        IList<Student> CourseStudents { get; }

        void JoinCourse(Student student);

        void LeaveCourse(Student student);
    }
}
