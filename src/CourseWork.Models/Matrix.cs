// <copyright file="Matrix.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// Represents matrix model.
    /// </summary>
    [Serializable]
    public class Matrix
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="numbers">Numbers in matrix.</param>
        public Matrix(double[,] numbers)
        {
            Numbers = numbers;
            Size = numbers.GetLength(0);
            ConvertDoubleDimensionsArrayToSingleDimensionArray(numbers);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// Needs for serialization and deserialization.
        /// </summary>
        private Matrix()
        {
        }

        /// <summary>
        /// Gets or sets size of matrix.
        /// </summary>
        [XmlElement]
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets numbers in matrix.
        /// </summary>
        [XmlIgnore]
        public double[,] Numbers { get; set; }

        /// <summary>
        /// Gets or sets numbers in matrix in single dimension array.
        /// </summary>
        [XmlArray]
        public double[] SingleDimensionNumbers { get; set; }

        /// <summary>
        /// Converting double dimensions array to single dimension array.
        /// </summary>
        /// <param name="numbers">Double dimensions array.</param>
        private void ConvertDoubleDimensionsArrayToSingleDimensionArray(double[,] numbers)
        {
            SingleDimensionNumbers = new double[numbers.Length];
            int k = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    SingleDimensionNumbers[k++] = numbers[i, j];
                }
            }
        }
    }
}