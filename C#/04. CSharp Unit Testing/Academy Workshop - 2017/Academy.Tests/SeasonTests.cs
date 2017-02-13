using System;
using Academy.Models;
using NUnit.Framework;
using Moq;
using Academy.Models.Contracts;
using System.Collections.Generic;
using Academy.Models.Enums;

namespace Academy.Tests
{
    [TestFixture]
    [Category("Season")]
    public class SeasonTests
    {
        [Test]
        public void ListUsers_ShouldIterateOverStudentCollection_WhenMethodCalled_ShouldBeCorrect()
        {
            // Assert
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);
            var studentMock = new Mock<IStudent>();

            // Act
            season.Students.Add(studentMock.Object);
            studentMock.Setup(s => s.ToString());

            var temp = season.ListUsers();

            // Assert
            studentMock.Verify(s => s.ToString());
        }

        [Test]
        public void ListUsers_ShouldIterateOverTrainerCollection_WhenMethodCalled_ShouldBeCorrect()
        {
            // Assert
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);
            var trainerMock = new Mock<ITrainer>();

            // Act
            season.Trainers.Add(trainerMock.Object);
            trainerMock.Setup(s => s.ToString());

            var temp = season.ListUsers();

            // Assert
            trainerMock.Verify(s => s.ToString());
        }

        [Test]
        public void ListUsers_ShouldReturnMessageThereAreNoUsers_WhenThereAreNoUsersProvided_ShouldBeCorrect()
        {
            // Assert & Act?
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);

            // Assert
            StringAssert.Contains("no users", season.ListUsers());
        }

        [Test]
        public void ListCourses_ShouldIterateOverCourseCollection_WhenMethodCalled_ShouldBeCorrect()
        {
            // Assert
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);
            var courseMock = new Mock<ICourse>();

            // Act
            season.Courses.Add(courseMock.Object);
            courseMock.Setup(s => s.ToString());

            season.ListCourses();

            // Assert
            courseMock.Verify(s => s.ToString());
        }

        [Test]
        public void ListCourses_ShouldReturnMessageThereAreNoCourses_WhenThereAreNoCoursesProvided_ShouldBeCorrect()
        {
            // Assert & Act?
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);

            // Assert
            StringAssert.Contains("no courses", season.ListCourses());
        }
    }
}
