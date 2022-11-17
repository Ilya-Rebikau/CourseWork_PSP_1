// <copyright file="ISolver.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.ComputingAPI.Interfaces
{
    using CourseWork.Models;

    /// <summary>
    /// Solver for SLAE.
    /// </summary>
    public interface ISolver
    {
        /// <summary>
        /// Solve SLAE.
        /// </summary>
        /// <param name="matrix">Matrix.</param>
        /// <param name="vector">Vector.</param>
        /// <returns>Vector with result.</returns>
        public Vector Solve(Matrix matrix, Vector vector);
    }
}
