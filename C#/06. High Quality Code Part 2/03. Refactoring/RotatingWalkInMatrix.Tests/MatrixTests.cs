using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RotatingWalkInMatrix;

namespace RotatingWalkInMatrix.Tests
{
    [TestFixture]
    public class MatrixTests
    {
        [Test]
        public void Constructor_CreateMatrix_ShouldNotThrow()
        {
            Assert.DoesNotThrow(() => new Matrix());
        }

        [Test]
        public void Constructor_CreateMatrixWithInvalidSize_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<ArgumentException>(() => new Matrix(0));
        }

        [Test]
        public void Constructor_ShouldReturnValidInstanceOfMatrix()
        {
            Matrix matrix = new Matrix();
            Assert.IsInstanceOf<Matrix>(matrix);
        }

        [Test]
        public void SizeProperty_CreateMatrixWithNoSizeProvided_ShouldCreateMatrixWithCorrectDefaultSizeDimensions()
        {
            Matrix matrix = new Matrix();

            Assert.AreEqual(3, matrix.Size);
        }

        [Test]
        public void SizeProperty_CreateMatrixWithSizeProvided_ShouldCreateMatrixWithProvidedSizeDimensions()
        {
            Matrix matrix = new Matrix(6);

            Assert.AreEqual(6, matrix.Size);
        }

        [Test]
        public void Fill_ShouldNotThrow()
        {
            Matrix matrix = new Matrix();

            Assert.DoesNotThrow(() => matrix.Fill());
        }

        [Test]
        public void ToString_ShouldDisplayTheDefaultSizeMatrixInTheRequiredFormat_ShouldBeCorrect()
        {
            Matrix matrix = new Matrix();
            matrix.Fill();

            string matrixToStr = matrix.ToString();
            string expectedMatrixToStr = "  1  7  8\r\n  6  2  9\r\n  5  4  3";

            Assert.AreEqual(expectedMatrixToStr, matrixToStr);
        }

        [Test]
        public void ToString_ShouldDisplayTheMatrixWithProvidedSizeInTheRequiredFormat_ShouldBeCorrect()
        {
            Matrix matrix = new Matrix(5);
            matrix.Fill();

            string matrixToStr = matrix.ToString();
            string expectedMatrixToStr = "  1 13 14 15 16\r\n 12  2 17 19 23\r\n 11 18  3 20 24\r\n 10 22 21  4 25\r\n  9  8  7  6  5";

            Assert.AreEqual(expectedMatrixToStr, matrixToStr);
        }
    }
}
