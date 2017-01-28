namespace School.Tests
{
    using System;
    using Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTests
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
        public void School_GenerateInitialId_CheckIfItIsInRange_ShouldPass()
        {
            int id = School.GenerateId();
            Assert.IsTrue(id <= Constants.MaxIdNumber && id >= Constants.MinIdNumber);
        }
        
        [TestMethod]
        public void School_GenerateIdThenAddSomeNumberToIt_CheckIfItIsInRange_ShouldBeFalse()
        {
            int id = School.GenerateId() + 90000;
            Assert.IsFalse(id <= Constants.MaxIdNumber && id >= Constants.MinIdNumber);
        }

        [TestMethod]
        public void School_GenerateIdThenAddSomeNumberToIt_CheckIfItIsCorrect_ShouldPass()
        {
            int id = School.GenerateId() + 40001;
            Assert.AreEqual(50001, id);
        }

        [TestMethod]
        public void School_GenerateIdThenAddSomeNumberToIt_CheckIfItIsCorrect_ShouldBeFalse()
        {
            int id = School.GenerateId() + 40001;
            Assert.AreNotEqual(50002, id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void School_CreateAStudentWithIdThenGenerateTheSameId_ShouldThrowArgumentException()
        {
            Student student = new Student("Student", 10000);
            School.GenerateId();
        }
    }
}
