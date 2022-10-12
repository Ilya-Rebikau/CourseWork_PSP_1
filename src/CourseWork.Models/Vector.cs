// <copyright file="Vector.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.Models
{
    /// <summary>
    /// Represents vector model.
    /// </summary>
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
        /// Gets or sets numbers in vector.
        /// </summary>
        public double[] Numbers { get; set; }
    }
}
