namespace School
{
    using System.Collections.Generic;
    using Common;
    using Contracts;

    public class Course : ICourse
    {
        private IList<Student> courseStudents;

        public Course()
        {
            this.courseStudents = new List<Student>();
        }

        public IList<Student> CourseStudents
        {
            get
            {
                return this.courseStudents;
            }
        }

        public void JoinCourse(Student student)
        {
            Validator.ValidateCourseCapacity(this);
            Validator.ValidateStudentEnteringCourse(this, student);
            this.CourseStudents.Add(student);
        }

        public void LeaveCourse(Student student)
        {
            Validator.ValidateStudentLeavingCourse(this, student);
            this.CourseStudents.Remove(student);
        }
    }
}
