using Microsoft.VisualStudio.TestTools.UnitTesting;
using School.Common;
using System;

namespace School.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestInitialize()]
        public void MyTestInitialize()
        {
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            School.Reset();
        }

        [TestMethod]
        public void Student_CheckIfNameExists_ShouldPass()
        {
            Student student = new Student("Student");
            Assert.AreEqual("Student", student.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Student_CheckIfNameIsEmpty_ShouldThrowArgumentException()
        {
            Student student = new Student(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Student_CheckIfNameIsNull_ShouldThrowArgumentException()
        {
            Student student = new Student(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTwoStudents_GiveFirstAutomaticIdGiveSecondTheTheSameIdManually_ShouldThrowArgumentException()
        {
            Student student = new Student("Student");
            Student secondStudent = new Student("Second student", 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTwoStudents_GiveThemSameId_ShouldThrowArgumentException()
        {
            Student student = new Student("Student", 12345);
            Student secondStudent = new Student("Second student", 12345);
        }

        [TestMethod]
        public void Student_CheckIfIdIsCorrect_ShouldPass()
        {
            Student student = new Student("Student", 56789);
            Assert.AreEqual(56789, student.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateStudent_WithOutOfRangeId_ShouldThrowArgumentException()
        {
            Student student = new Student("Student", 5678910);
        }
    }
}
