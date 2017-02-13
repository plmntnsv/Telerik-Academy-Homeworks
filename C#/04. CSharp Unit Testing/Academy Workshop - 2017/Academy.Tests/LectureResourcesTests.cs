using Academy.Core.Factories;
using Academy.Core.Providers;
using Academy.Models.Utils.LectureResources;
using NUnit.Framework;
using System;

namespace Academy.Tests
{
    [TestFixture]
    [Category("LectureResource")]
    public class LectureResourcesTests
    {
        [Test]
        public void CreateLectureResource_ShouldThrowArgumentException_WhenPassedResourceTypeIsInvalid()
        {
            // Arrange
            var factory = AcademyFactory.Instance;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateLectureResource("invalid", "name", "some url"));            
        }

        [Test]
        public void CreateLectureResource_ShouldThrowArgumentException_WhenPassedNameIsWhiteSpace()
        {
            // Arrange
            var factory = AcademyFactory.Instance;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateLectureResource("video", " ", "some url"));
        }

        [Test]
        public void CreateLectureResource_ShouldThrowArgumentException_WhenPassedNameIsNullSpace()
        {
            // Arrange
            var factory = AcademyFactory.Instance;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateLectureResource("video", null, "some url"));
        }

        [Test]
        public void CreateLectureResource_ShouldThrowArgumentException_WhenPassedNameIsTooShortSpace()
        {
            // Arrange
            var factory = AcademyFactory.Instance;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateLectureResource("video", "a", "some url"));
        }

        [Test]
        public void CreateLectureResource_ShouldThrowArgumentException_WhenPassedNameIsTooLongSpace()
        {
            // Arrange
            var factory = AcademyFactory.Instance;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateLectureResource("video", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "some url"));
        }

        [Test]
        public void CreateLectureResource_ShouldThrowArgumentException_WhenPassedUrlIsWhiteSpace()
        {
            // Arrange
            var factory = AcademyFactory.Instance;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateLectureResource("video", "name", " "));
        }

        [Test]
        public void CreateLectureResource_ShouldThrowArgumentException_WhenPassedUrlIsNull()
        {
            // Arrange
            var factory = AcademyFactory.Instance;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateLectureResource("video", "name", null));
        }

        [Test]
        public void CreateLectureResource_ShouldThrowArgumentException_WhenPassedUrlIsTooShortSpace()
        {
            // Arrange
            var factory = AcademyFactory.Instance;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateLectureResource("video", "name", "a"));
        }

        [Test]
        public void CreateLectureResource_ShouldThrowArgumentException_WhenPassedUrlIsTooLong()
        {
            // Arrange
            var factory = AcademyFactory.Instance;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateLectureResource("video", "name", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
        }

        [Test]
        public void CreateLectureResource_ProvideValidVideoResource_ShouldCreateAValidInstanceOfAResource()
        {
            // Arrange
            var factory = AcademyFactory.Instance;

            // Act
            var resource = factory.CreateLectureResource("video", "name", "some url");

            // Assert
            Assert.IsInstanceOf<VideoResource>(resource);
        }

        [Test]
        public void CreateLectureResource_ProvideValidDemoResource_ShouldCreateAValidInstanceOfAResource()
        {
            // Arrange
            var factory = AcademyFactory.Instance;

            // Act
            var resource = factory.CreateLectureResource("demo", "name", "some url");

            // Assert
            Assert.IsInstanceOf<DemoResource>(resource);
        }

        [Test]
        public void CreateLectureResource_ProvideValidHomeworkResource_ShouldCreateAValidInstanceOfAResource()
        {
            // Arrange
            var factory = AcademyFactory.Instance;

            // Act
            var resource = factory.CreateLectureResource("homework", "name", "some url");

            //Assert
            Assert.IsInstanceOf<HomeworkResource>(resource);
        }

        [Test]
        public void CreateLectureResource_ProvideValidPresentationResource_ShouldCreateAValidInstanceOfAResource()
        {
            // Arrange
            var factory = AcademyFactory.Instance;

            // Act
            var resource = factory.CreateLectureResource("presentation", "name", "some url");

            // Assert
            Assert.IsInstanceOf<PresentationResource>(resource);
        }

        [Test]
        public void CreateLectureResource_ProvideValidNameForVideoResource_ShouldCreateAValidVideoResourceName()
        {
            // Arrange
            var factory = AcademyFactory.Instance;
            string expectedType = "video",
                   expectedName = "name",
                   expectedUrl = "some url";

            // Act
            var resource = factory.CreateLectureResource(expectedType, expectedName, expectedUrl);

            // Assert
            Assert.AreEqual(expectedName, resource.Name);
        }

        [Test]
        public void CreateLectureResource_ProvideValidUrlForVideoResource_ShouldCreateAValidVideoResourceUrl()
        {
            // Arrange
            var factory = AcademyFactory.Instance;
            string expectedType = "video",
                   expectedName = "name",
                   expectedUrl = "some url";

            // Act
            var resource = factory.CreateLectureResource(expectedType, expectedName, expectedUrl);

            // Assert
            Assert.AreEqual(expectedUrl, resource.Url);
        }

        [Test]
        public void CreateLectureResource_ProvideValidDueDateForHomeworkResource_ShouldCreateAValidHomeworkResourceDueDate()
        {
            // Arrange
            var factory = AcademyFactory.Instance;
            string expectedType = "homework",
                   expectedName = "name",
                   expectedUrl = "some url";
            var expectedDueDate = DateTimeProvider.Now.AddDays(7);

            // Act
            var resource = factory.CreateLectureResource(expectedType, expectedName, expectedUrl);
            var homeworkResource = resource as HomeworkResource;

            // Assert
            Assert.AreEqual(expectedDueDate, homeworkResource.DueDate);
        }
    }
}
