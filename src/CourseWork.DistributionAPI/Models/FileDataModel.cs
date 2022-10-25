// <copyright file="FileDataModel.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.DistributionAPI.Models
{
    /// <summary>
    /// Represents data model for matrix and vector.
    /// </summary>
    public class FileDataModel
    {
        /// <summary>
        /// Gets or sets byte data of matrix.
        /// </summary>
        public byte[] MatrixData { get; set; }

        /// <summary>
        /// Gets or sets byte data of vector.
        /// </summary>
        public byte[] VectorData { get; set; }
    }
}
