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
        /// <exception cref="ArgumentException">Throws ArgumentException in case matrix is not square.</exception>
        public Matrix(float[][] numbers)
        {
            if (numbers.Length != numbers[0].Length)
            {
                throw new ArgumentException("Matrix is not square");
            }

            Numbers = numbers;
            Size = numbers.Length;
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
        [XmlArray]
        [XmlArrayItem("Row")]
        public float[][] Numbers { get; set; }
    }
}