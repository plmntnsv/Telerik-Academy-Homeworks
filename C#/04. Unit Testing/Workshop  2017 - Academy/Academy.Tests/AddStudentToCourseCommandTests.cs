using System;
using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Moq;
using NUnit.Framework;
using Academy.Tests.Fakes;
using Academy.Models.Contracts;
using System.Collections.Generic;

namespace Academy.Tests
{
    [TestFixture]
    [Category("AddStudentToCourseCommand")]
    public class AddStudentToCourseCommandTests
    {
        [Test]
        public void Initialize_ShouldThrowArgumentNullException_WhenPassedFactoryToTheConstructorIsNull()
        {
            // Arrange
            var engineMock = new Mock<IEngine>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(null, engineMock.Object));
        }

        [Test]
        public void Initialize_ShouldThrowArgumentNullException_WhenPassedEngineToTheConstructorIsNull()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(factoryMock.Object, null));
        }

        [Test]
        public void Initialize_ShouldCorrectlyAssignPassedFactoryParameter_WhenPassedFactoryToTheConstructorIsValid()
        {
            // Arrange
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();

            // Act
            var courseCommand = new AddStudentToCourseCommandFake(factoryMock.Object, engineMock.Object);

            // Assert
            Assert.AreSame(factoryMock.Object, courseCommand.ExposeFactoty);
        }

        [Test]
        public void Initialize_ShouldCorrectlyAssignPassedEngineParameter_WhenPassedEngineToTheConstructorIsValid()
        {
            // Arrange
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();

            // Act
            var courseCommand = new AddStudentToCourseCommandFake(factoryMock.Object, engineMock.Object);

            // Assert
            Assert.AreSame(engineMock.Object, courseCommand.ExposeEngine);
        }

        [Test]
        public void Execute_ShouldThrowArgumentException_WhenPassedCourseFormIsInvalid()
        {
            // Arrange
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();
            var courseCommand = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(st => st.Username).Returns("Name");

            var courseMock = new Mock<ICourse>();

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(s => s.Courses).Returns(new List<ICourse>() { courseMock.Object });

            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent>() { studentMock.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            // Act & Assert
            Assert.Throws<ArgumentException>(() => courseCommand.Execute(new List<string>() { "Name", "0", "0", "onspace" }));
        }

        [Test]
        public void Execute_AddTheStudentInTheOnsitedAttendanceForm_ShouldBeCorrect()
        {
            // Arrange
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();
            var courseCommand = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(st => st.Username).Returns("Name");

            var courseMock = new Mock<ICourse>();
            courseMock.SetupGet(c => c.OnlineStudents).Returns(new List<IStudent>() { });
            courseMock.SetupGet(c => c.OnsiteStudents).Returns(new List<IStudent>() { });

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(s => s.Courses).Returns(new List<ICourse>() { courseMock.Object });

            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent>() { studentMock.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            // Act
            courseCommand.Execute(new List<string>() { "Name", "0", "0", "onsite" });

            // Assert
            Assert.AreEqual(1, courseMock.Object.OnsiteStudents.Count);
        }

        [Test]
        public void Execute_AddTheStudentInTheOnlinedAttendanceForm_ShouldBeCorrect()
        {
            // Arrange
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();
            var courseCommand = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(st => st.Username).Returns("Name");

            var courseMock = new Mock<ICourse>();
            courseMock.SetupGet(c => c.OnlineStudents).Returns(new List<IStudent>() { });
            courseMock.SetupGet(c => c.OnsiteStudents).Returns(new List<IStudent>() { });

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(s => s.Courses).Returns(new List<ICourse>() { courseMock.Object });

            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent>() { studentMock.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            // Act
            courseCommand.Execute(new List<string>() { "Name", "0", "0", "online" });

            // Assert
            Assert.AreEqual(1, courseMock.Object.OnlineStudents.Count);
        }

        [Test]
        public void Execute_AddTheStudentInTheOnlinedAttendanceForm_ShouldRetrunCorrectMessage()
        {
            // Arrange
            var engineMock = new Mock<IEngine>();
            var factoryMock = new Mock<IAcademyFactory>();
            var courseCommand = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(st => st.Username).Returns("Name");

            var courseMock = new Mock<ICourse>();
            courseMock.SetupGet(c => c.Name).Returns("Course");
            courseMock.SetupGet(c => c.OnlineStudents).Returns(new List<IStudent>() { });
            courseMock.SetupGet(c => c.OnsiteStudents).Returns(new List<IStudent>() { });

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(s => s.Courses).Returns(new List<ICourse>() { courseMock.Object });

            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent>() { studentMock.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            // Act
            var command = courseCommand.Execute(new List<string>() { "Name", "0", "0", "online" });

            // Assert
            StringAssert.Contains("Name", command);
            StringAssert.Contains("0", command);
            StringAssert.Contains("Course", command);
        }
    }
}
