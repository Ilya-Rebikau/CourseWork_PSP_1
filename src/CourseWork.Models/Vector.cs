// <copyright file="Vector.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// Represents vector model.
    /// </summary>
    [Serializable]
    public class Vector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector"/> class.
        /// </summary>
        /// <param name="numbers">Numbers in vector.</param>
        public Vector(double[] numbers)
        {
            Numbers = numbers;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector"/> class.
        /// Needs for serialization and deserialization.
        /// </summary>
        private Vector()
        {
        }

        /// <summary>
        /// Gets or sets numbers in vector.
        /// </summary>
        [XmlArray]
        public double[] Numbers { get; set; }
    }
}
