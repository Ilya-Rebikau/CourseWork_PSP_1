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
        public Vector(float[] numbers)
        {
            Numbers = numbers;
            Size = numbers.Length;
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
        public float[] Numbers { get; set; }

        /// <summary>
        /// Gets or sets size of vector.
        /// </summary>
        [XmlElement]
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets presicion for comparing vectors.
        /// </summary>
        [XmlIgnore]
        public float Precision { get; set; } = 0.005F;

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            var vector = (Vector)obj;
            if (vector.Size != Size)
            {
                return false;
            }

            for (int i = 0; i < Size; i++)
            {
                var firstValue = vector.Numbers[i];
                var secondValue = Numbers[i];
                if (Math.Abs(firstValue - secondValue) > Precision)
                {
                    return false;
                }
            }

            return true;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Size.GetHashCode();
        }
    }
}
