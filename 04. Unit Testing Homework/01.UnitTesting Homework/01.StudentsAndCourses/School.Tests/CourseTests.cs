namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void Course_CreateCourseThenAddStudentAndCheckCapacity_ShouldBeCorrect()
        {
            Course course = new Course();
            course.JoinCourse(new Student("Student"));
            Assert.AreEqual(course.CourseStudents.Count, 1);
        }

        [TestMethod]
        public void Course_CreateCourseAddStudentThenRemoveAndCheckCapacity_ShouldBeCorrect()
        {
            Course course = new Course();
            Student student = new Student("Student");
            course.JoinCourse(student);
            course.LeaveCourse(student);
            Assert.AreEqual(course.CourseStudents.Count, 0);
        }

        [TestMethod]
        public void Course_CreateCourseAddSomeStudentsThenRemoveSomeAndCheckCapacity_ShouldBeCorrect()
        {
            Course course = new Course();
            Student student = new Student("Student");
            Student secondStudent = new Student("Second Student");
            Student thirdStudent = new Student("Third Student");
            course.JoinCourse(student);
            course.JoinCourse(secondStudent);
            course.JoinCourse(thirdStudent);
            course.LeaveCourse(student);
            course.LeaveCourse(secondStudent);
            Assert.AreEqual(course.CourseStudents.Count, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Course_CreateCourseAddStudentTwice_ShouldThrowArgumentException()
        {
            Course course = new Course();
            Student student = new Student("Student");
            course.JoinCourse(student);
            course.JoinCourse(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Course_CreateCourseAddStudentAndTryToLeaveTwice_ShouldThrowArgumentException()
        {
            Course course = new Course();
            Student student = new Student("Student");
            course.JoinCourse(student);
            course.LeaveCourse(student);
            course.LeaveCourse(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Course_CreateCourseThenRemoveAStudentThatIsNotInIt_ShouldThrowArgumentException()
        {
            Course course = new Course();
            Student student = new Student("Student");
            course.LeaveCourse(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Course_CreateCourseThenAddAStudentCreateAnotherStudentAndTryToRemoveHimHer_ShouldThrowArgumentException()
        {
            Course course = new Course();
            Student student = new Student("Student");
            Student secondStudent = new Student("Second student");
            course.JoinCourse(student);
            course.LeaveCourse(secondStudent);
        }

        [TestMethod]
        public void Course_CreateCourseFillTheCourse_ShouldBeCorrect()
        {
            Course course = new Course();
            for (int i = 0; i < 29; i++)
            {
                Student student = new Student("Student" + i);
                course.JoinCourse(student);
            }
            Assert.AreEqual(29, course.CourseStudents.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Course_CreateCourseFillTheCourseAndAddOneMore_ShouldThrowArgumentException()
        {
            Course course = new Course();
            for (int i = 0; i < 29; i++)
            {
                Student student = new Student("Student"+i);
                course.JoinCourse(student);
            }
            Student anotherStudent = new Student("Another Student");
            course.JoinCourse(anotherStudent);
        }
    }
}
