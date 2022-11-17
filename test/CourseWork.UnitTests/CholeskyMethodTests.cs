using CourseWork.ComputingAPI.Math;
using CourseWork.Models;
using CourseWork.Web.Interfaces;
using CourseWork.Web.Services;

namespace CourseWork.UnitTests
{
    /// <summary>
    /// Tests for the Cholesky method.
    /// </summary>
    public class CholeskyMethodTests
    {
        /// <summary>
        /// Path to files.
        /// </summary>
        private static readonly string _pathToFiles = @"../../../../../src/CourseWork.Web/wwwroot/files";

        /// <summary>
        /// Gets test matrix.
        /// </summary>
        /// <param name="matrixName">Name of file with matrix.</param>
        /// <returns>Matrix.</returns>
        private static Matrix GetTestMatrix(string matrixName)
        {
            ISerializer<Matrix> serializer = new MyXmlSerializer<Matrix>();
            return serializer.ReadObject(Path.Combine(_pathToFiles, matrixName));
        }

        /// <summary>
        /// Gets test vector.
        /// </summary>
        /// <param name="vectorName">Name of file with vector</param>
        /// <returns>Vector.</returns>
        private static Vector GetTestVector(string vectorName)
        {
            ISerializer<Vector> serializer = new MyXmlSerializer<Vector>();
            return serializer.ReadObject(Path.Combine(_pathToFiles, vectorName));
        }

        /// <summary>
        /// Compare results from the Cholesky method and file with vector X for the first matrix A and vector B.
        /// </summary>
        [Test]
        public void CompareResults_First()
        {
            // Arrange
            var matrix = GetTestMatrix("A1.xml");
            var vector = GetTestVector("B1.xml");
            var expectedVectorX = GetTestVector("X1.xml");
            var choleskyMethod = new CholeskyMethodSolver();

            // Act
            var actualVectorX = choleskyMethod.Solve(matrix, vector);

            // Assert
            Assert.That(actualVectorX, Is.EqualTo(expectedVectorX));
        }

        /// <summary>
        /// Compare results from the Cholesky method and file with vector X for the second matrix A and vector B.
        /// </summary>
        [Test]
        public void CompareResults_Second()
        {
            // Arrange
            var matrix = GetTestMatrix("A2.xml");
            var vector = GetTestVector("B2.xml");
            var expectedVectorX = GetTestVector("X2.xml");
            var choleskyMethod = new CholeskyMethodSolver();

            // Act
            var actualVectorX = choleskyMethod.Solve(matrix, vector);

            // Assert
            Assert.That(actualVectorX, Is.EqualTo(expectedVectorX));
        }

        /// <summary>
        /// Compare results from the Cholesky method and file with vector X for the third matrix A and vector B.
        /// </summary>
        [Test]
        public void CompareResults_Third()
        {
            // Arrange
            var matrix = GetTestMatrix("A3.xml");
            var vector = GetTestVector("B3.xml");
            var expectedVectorX = GetTestVector("X3.xml");
            var choleskyMethod = new CholeskyMethodSolver();

            // Act
            var actualVectorX = choleskyMethod.Solve(matrix, vector);

            // Assert
            Assert.That(actualVectorX, Is.EqualTo(expectedVectorX));
        }

        /// <summary>
        /// Compare results from the Cholesky method and the Seidel method for the first matrix A and vector B.
        /// </summary>
        [Test]
        public void CompareResult_WithSeidelMethod_First()
        {
            // Arrange
            var matrix = GetTestMatrix("A1.xml");
            var vector = GetTestVector("B1.xml");
            var seidelMethod = new SeidelMethod();
            var choleskyMethod = new CholeskyMethodSolver();

            // Act
            var seidelVector = seidelMethod.Solve(matrix, vector);
            var choleskyVector = choleskyMethod.Solve(matrix, vector);

            // Assert
            Assert.That(seidelVector, Is.EqualTo(choleskyVector));
        }

        /// <summary>
        /// Compare results from the Cholesky method and the Seidel method for the second matrix A and vector B.
        /// </summary>
        [Test]
        public void CompareResult_WithSeidelMethod_Second()
        {
            // Arrange
            var matrix = GetTestMatrix("A2.xml");
            var vector = GetTestVector("B2.xml");
            var seidelMethod = new SeidelMethod();
            var choleskyMethod = new CholeskyMethodSolver();

            // Act
            var seidelVector = seidelMethod.Solve(matrix, vector);
            var choleskyVector = choleskyMethod.Solve(matrix, vector);

            // Assert
            Assert.That(seidelVector, Is.EqualTo(choleskyVector));
        }

        /// <summary>
        /// Load test for big matrix.
        /// </summary>
        [Test]
        public void LoadTest()
        {
            // Arrange and Act
            static void testAction()
            {
                var matrix = new Matrix(new float[int.MaxValue][]);
                for (int i = 0; i < int.MaxValue; i++)
                {
                    matrix.Numbers[i] = new float[int.MaxValue];
                }
            }

            // Assert
            Assert.Throws<OutOfMemoryException>(testAction);
        }
    }
}