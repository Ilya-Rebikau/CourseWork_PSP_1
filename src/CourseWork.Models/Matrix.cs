// <copyright file="Matrix.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.Models
{
    /// <summary>
    /// Represents matrix model.
    /// </summary>
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
            SingleDimensionNumbers = new double[numbers.Length];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    SingleDimensionNumbers.Append(numbers[i, j]);
                }
            }
        }

        /// <summary>
        /// Gets size of matrix.
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Gets or sets numbers in matrix.
        /// </summary>
        public double[,] Numbers { get; set; }

        /// <summary>
        /// Gets numbers in matrix in single dimension array.
        /// </summary>
        public double[] SingleDimensionNumbers { get; }
    }
}