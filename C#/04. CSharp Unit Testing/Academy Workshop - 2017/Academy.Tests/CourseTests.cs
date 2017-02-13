using System;
using Academy.Models;
using NUnit.Framework;
using Moq;
using Academy.Models.Contracts;
using System.Collections.Generic;

namespace Academy.Tests
{
    [TestFixture]
    [Category("Course")]
    public class CourseTests
    {
        [Test]
        public void CreateCourse_ShouldCreateValidCourse_WhenValidParametersArePassedToTheConstructor()
        {
            // Arrange
            var courseName = "Course";
            var courseLecturesPerWeek = 5;
            var courseStartingDate = new DateTime(2017, 01, 01).Date;
            var courseEndingDate = new DateTime(2017, 02, 02).Date;

            // Act
            var course = new Course(courseName, courseLecturesPerWeek, courseStartingDate, courseEndingDate);

            // Assert
            Assert.AreEqual(courseName, course.Name);
            Assert.AreEqual(courseLecturesPerWeek, course.LecturesPerWeek);
            Assert.AreEqual(courseStartingDate, course.StartingDate);
            Assert.AreEqual(courseEndingDate, course.EndingDate);
        }

        [Test]
        public void CreateCourse_ShouldCorrectlyInitializeCollections_WhenProvidedCorrectParameters()
        {
            // Arrange
            var courseName = "Course";
            var courseLecturesPerWeek = 5;
            var courseStartingDate = new DateTime(2017, 01, 01).Date;
            var courseEndingDate = new DateTime(2017, 02, 02).Date;

            // Act
            var course = new Course(courseName, courseLecturesPerWeek, courseStartingDate, courseEndingDate);

            // Assert
            Assert.IsNotNull(course.OnlineStudents);
            Assert.IsNotNull(course.OnsiteStudents);
            Assert.IsNotNull(course.Lectures);
        }

        [TestCase("Valid Name")]
        [TestCase("Abc")]
        [TestCase("aNameThatIsExactlyFourtyFourCharachtersLong44")]
        public void CreateCourse_ProvideValidCourseName_ShouldPassCorrectly(string name)
        {
            // Arrange
            var courseName = name;
            var courseLecturesPerWeek = 5;
            var courseStartingDate = new DateTime(2017, 01, 01).Date;
            var courseEndingDate = new DateTime(2017, 02, 02).Date;

            // Act & Assert
            Assert.DoesNotThrow(() => new Course(courseName, courseLecturesPerWeek, courseStartingDate, courseEndingDate));
        }

        [TestCase("   ")]
        [TestCase(null)]
        [TestCase("a")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void CreateCourse_ProvideInvalidCourseName_ShouldThrowArgumentException(string name)
        {
            // Arrange
            var courseName = name;
            var courseLecturesPerWeek = 5;
            var courseStartingDate = new DateTime(2017, 01, 01).Date;
            var courseEndingDate = new DateTime(2017, 02, 02).Date;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Course(courseName, courseLecturesPerWeek, courseStartingDate, courseEndingDate));
        }

        [TestCase("Valid Name")]
        [TestCase("Abc")]
        [TestCase("aNameThatIsExactlyFourtyFourCharachtersLong44")]
        public void CreateCourse_AssignValidName_CheckIfNameIsIndeedValid_ShouldBeCorrect(string name)
        {
            // Arrange
            var courseName = name;
            var courseLecturesPerWeek = 5;
            var courseStartingDate = new DateTime(2017, 01, 01).Date;
            var courseEndingDate = new DateTime(2017, 02, 02).Date;
            var course = new Course("Some name", courseLecturesPerWeek, courseStartingDate, courseEndingDate);

            // Act
            course.Name = name;

            // Assert
            Assert.AreEqual(courseName, course.Name);
        }

        [TestCase(1)]
        [TestCase(4)]
        [TestCase(7)]
        public void CreateCourse_AssignValidLecturesPerWeek_ShouldPass(int lecturesPerWeek)
        {
            // Arrange
            var courseName = "ValidName";
            var courseLecturesPerWeek = lecturesPerWeek;
            var courseStartingDate = new DateTime(2017, 01, 01).Date;
            var courseEndingDate = new DateTime(2017, 02, 02).Date;

            // Act & Assert
            Assert.DoesNotThrow(() => new Course(courseName, courseLecturesPerWeek, courseStartingDate, courseEndingDate));
        }

        [TestCase(-5)]
        [TestCase(0)]
        [TestCase(8)]
        public void CreateCourse_AssignInvalidLecturesPerWeek_ShouldThrowArgumentException(int lecturesPerWeek)
        {
            // Arrange
            var courseName = "ValidName";
            var courseLecturesPerWeek = lecturesPerWeek;
            var courseStartingDate = new DateTime(2017, 01, 01).Date;
            var courseEndingDate = new DateTime(2017, 02, 02).Date;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Course(courseName, courseLecturesPerWeek, courseStartingDate, courseEndingDate));
        }

        [TestCase(1)]
        [TestCase(4)]
        [TestCase(7)]
        public void CreateCourse_AssignValidLecturesPerWeek_CheckIfLectures_ShouldBeCorrect(int newLecturesPerWeek)
        {
            // Arrange
            var courseName = "ValidName";
            var courseLecturesPerWeek = 5;
            var courseStartingDate = new DateTime(2017, 01, 01).Date;
            var courseEndingDate = new DateTime(2017, 02, 02).Date;
            var course = new Course(courseName, courseLecturesPerWeek, courseStartingDate, courseEndingDate);

            // Act
            course.LecturesPerWeek = newLecturesPerWeek;

            // Assert
            Assert.AreEqual(newLecturesPerWeek, course.LecturesPerWeek);
        }

        [Test]
        public void CreateCourse_AssignValidStartingDate_ShouldPassCorrectly()
        {
            // Arrange
            var courseName = "ValidName";
            var courseLecturesPerWeek = 5;
            var courseStartingDate = new DateTime(2017, 01, 01).Date;
            var courseEndingDate = new DateTime(2017, 02, 02).Date;
            var course = new Course(courseName, courseLecturesPerWeek, courseStartingDate, courseEndingDate);

            // Act & Assert
            Assert.DoesNotThrow(() => course.StartingDate = new DateTime(2017, 03, 03).Date);
        }

        [Test]
        public void CreateCourse_AssignInvalidStartingDate_ShouldThrowArgumentNullException()
        {
            // Arrange
            var courseName = "ValidName";
            var courseLecturesPerWeek = 5;
            var courseStartingDate = new DateTime(2017, 01, 01).Date;
            var courseEndingDate = new DateTime(2017, 02, 02).Date;
            var course = new Course(courseName, courseLecturesPerWeek, courseStartingDate, courseEndingDate);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => course.StartingDate = null);
        }

        [Test]
        public void CreateCourse_AssignValidStartingDate_CheckIfCourseStartingDateIsEqualToIt_ShouldBeCorrect()
        {
            // Arrange
            var courseName = "ValidName";
            var courseLecturesPerWeek = 5;
            var courseStartingDate = new DateTime(2017, 01, 01).Date;
            var courseEndingDate = new DateTime(2017, 02, 02).Date;
            var course = new Course(courseName, courseLecturesPerWeek, courseStartingDate, courseEndingDate);

            var newCourseStartingDate = new DateTime(2017, 03, 03).Date;

            // Act
            course.StartingDate = newCourseStartingDate;

            // Assert
            Assert.AreEqual(newCourseStartingDate, course.StartingDate);
        }

        [Test]
        public void CreateCourse_AssignValidEndingDate_ShouldPassCorrectly()
        {
            // Arrange
            var courseName = "ValidName";
            var courseLecturesPerWeek = 5;
            var courseStartingDate = new DateTime(2017, 01, 01).Date;
            var courseEndingDate = new DateTime(2017, 02, 02).Date;
            var course = new Course(courseName, courseLecturesPerWeek, courseStartingDate, courseEndingDate);

            // Act & Assert
            Assert.DoesNotThrow(() => course.EndingDate = new DateTime(2017, 03, 03).Date);
        }

        [Test]
        public void CreateCourse_AssignInvalidEndingDate_ShouldThrowArgumentNullException()
        {
            // Arrange
            var courseName = "ValidName";
            var courseLecturesPerWeek = 5;
            var courseStartingDate = new DateTime(2017, 01, 01).Date;
            var courseEndingDate = new DateTime(2017, 02, 02).Date;
            var course = new Course(courseName, courseLecturesPerWeek, courseStartingDate, courseEndingDate);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => course.EndingDate = null);
        }

        [Test]
        public void CreateCourse_AssignValidEndingDate_CheckIfCourseStartingDateIsEqualToIt_ShouldBeCorrect()
        {
            // Arrange
            var courseName = "ValidName";
            var courseLecturesPerWeek = 5;
            var courseStartingDate = new DateTime(2017, 01, 01).Date;
            var courseEndingDate = new DateTime(2017, 02, 02).Date;
            var course = new Course(courseName, courseLecturesPerWeek, courseStartingDate, courseEndingDate);

            var newCourseEndingDate = new DateTime(2017, 03, 03).Date;

            // Act
            course.EndingDate = newCourseEndingDate;

            // Assert
            Assert.AreEqual(newCourseEndingDate, course.EndingDate);
        }

        [Test]
        public void CourseToString_ShouldNotReturnAnyLectures_ShouldBeCorrect()
        {

            // Arrange
            var courseName = "ValidName";
            var courseLecturesPerWeek = 5;
            var courseStartingDate = new DateTime(2017, 01, 01).Date;
            var courseEndingDate = new DateTime(2017, 02, 02).Date;

            // Act
            var course = new Course(courseName, courseLecturesPerWeek, courseStartingDate, courseEndingDate);

            // Assert
            StringAssert.Contains("There are no lectures in this course!", course.ToString());
            
        }

        [Test]
        public void CourseToString_ShouldReturnSomeLectures_ShouldBeCorrect()
        {

            // Arrange
            var courseName = "ValidName";
            var courseLecturesPerWeek = 5;
            var courseStartingDate = new DateTime(2017, 01, 01).Date;
            var courseEndingDate = new DateTime(2017, 02, 02).Date;
            var course = new Course(courseName, courseLecturesPerWeek, courseStartingDate, courseEndingDate);
            var mockedLecture = new Mock<ILecture>();

            // Act
            //course.Lectures.Add(new Lecture("Lecture", new DateTime(2017, 06, 02).Date, new Trainer("Trainer", new List<string>() { "tech", "tech2" })));
            course.Lectures.Add(mockedLecture.Object);

            // Assert
            StringAssert.DoesNotContain("There are no lectures in this course!", course.ToString());
        }

        [Test]
        public void CourseToString_ShouldCheckIfIteratesOverCollections_ShouldBeCorrect()
        {
            // Arrange
            var courseMock = new Mock<ICourse>();
            courseMock.Setup(c => c.ToString()).Verifiable();
            var obj = courseMock.Object;

            // Act
            obj.ToString();

            // Assert
            //StringAssert.Contains("There are no lectures in this course!", obj.ToString());
            courseMock.Verify(c => c.ToString());
        }
    }
}
