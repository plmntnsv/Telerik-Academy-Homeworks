using NUnit.Framework;
using Moq;
using Academy.Core.Contracts;
using Academy.Commands.Adding;
using System;
using Academy.Tests.Fakes;
using System.Collections.Generic;
using Academy.Models;
using Academy.Models.Enums;
using Academy.Models.Contracts;

namespace Academy.Tests
{
    [TestFixture]
    [Category("AddStudentToSeasonCommand")]
    public class AddStudentToSeasonCommandTests
    {
        [Test]
        public void CreateCommand_ShouldThrowArgumentNullException_WhenProvdedNullFactoryToTheConstructor()
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();
            
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(null, engineStub.Object));
        }

        [Test]
        public void CreateCommand_ShouldThrowArgumentNullException_WhenProvdedNullEngineToTheConstructor()
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(factoryStub.Object, null));
        }

        [Test]
        public void CreateCommand_ShouldCorrectlyAssignPassedAcademyFactory_WhenProvdedValidParamsToTheConstructor()
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            // Act
            var addStudent = new AddStudentToSeasonCommandFake(factoryStub.Object, engineStub.Object);

            // Assert
            Assert.AreSame(factoryStub.Object, addStudent.ExposeFactoty);
        }

        [Test]
        public void CreateCommand_ShouldCorrectlyAssignPassedEngine_WhenProvdedValidParamsToTheConstructor()
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            // Act
            var addStudent = new AddStudentToSeasonCommandFake(factoryStub.Object, engineStub.Object);

            // Assert
            Assert.AreSame(engineStub.Object, addStudent.ExposeEngine);
        }

        [Test]
        public void Execute_ShouldThrowArgumentException_WhenStudentIsAlreadyAPartOfThatSeason()
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var seasonMock = new Mock<ISeason>();
            var studentMock = new Mock<IStudent>();

            var addStudentCommand = new AddStudentToSeasonCommandFake(factoryStub.Object, engineMock.Object);

            seasonMock.SetupGet(s => s.Students).Returns(new List<IStudent>() { new Student("Student", Track.Dev) });
            studentMock.SetupGet(st => st.Username).Returns("Student");

            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent>() { studentMock.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            // Act & Assert
            Assert.Throws<ArgumentException>(() => addStudentCommand.Execute(new List<string>() { "Student", "0" }));
        }

        [Test]
        public void Execute_ShouldAddTheStudentToTheSeason_WhenProvidedValidStudent()
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var seasonMock = new Mock<ISeason>();
            var studentMock = new Mock<IStudent>();

            var addStudentCommand = new AddStudentToSeasonCommandFake(factoryStub.Object, engineMock.Object);

            seasonMock.SetupGet(s => s.Students).Returns(new List<IStudent>() { new Student("AnotherStudent", Track.Dev) });
            studentMock.SetupGet(st => st.Username).Returns("Student");

            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent>() { studentMock.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            // Act
            var command = addStudentCommand.Execute(new List<string>() { "Student", "0" });

            // Assert
            Assert.AreEqual(2, seasonMock.Object.Students.Count);
        }

        [Test]
        public void Execute_ShouldAddTheStudentToTheSeasonAndLogSuccessMessage_WhenProvidedValidStudent()
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var seasonMock = new Mock<ISeason>();
            var studentMock = new Mock<IStudent>();

            var addStudentCommand = new AddStudentToSeasonCommandFake(factoryStub.Object, engineMock.Object);

            seasonMock.SetupGet(s => s.Students).Returns(new List<IStudent>() { new Student("AnotherStudent", Track.Dev) });
            studentMock.SetupGet(st => st.Username).Returns("Student");

            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent>() { studentMock.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            // Act
            var command = addStudentCommand.Execute(new List<string>() { "Student", "0" });

            // Assert
            StringAssert.Contains("Student", command);
            StringAssert.Contains("0", command);
        }
    }
}
    