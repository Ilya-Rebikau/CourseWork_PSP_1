// <copyright file="CholeskyMethodSolver.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CourseWork.UnitTests")]

namespace CourseWork.ComputingAPI.Math
{
    using Accord.Math;
    using CourseWork.ComputingAPI.Interfaces;
    using Matrix = CourseWork.Models.Matrix;
    using Vector = CourseWork.Models.Vector;

    /// <summary>
    /// SLAE solver using the Cholesky method.
    /// </summary>
    internal class CholeskyMethodSolver : ISolver
    {
        /// <inheritdoc/>
        public Vector Solve(Matrix matrix, Vector vector)
        {
            var l = new float[matrix.Size][];
            var y = new float[matrix.Size];
            var x = new float[matrix.Size];
            for (int i = 0; i < l.GetUpperBound(0) + 1; i++)
            {
                l[i] = new float[matrix.Size];
                float temp;
                for (int j = 0; j < i; j++)
                {
                    temp = 0;
                    for (int k = 0; k < j; k++)
                    {
                        temp += l[i][k] * l[j][k];
                    }

                    l[i][j] = (matrix.Numbers[i][j] - temp) / l[j][j];
                }

                temp = matrix.Numbers[i][i];
                for (int k = 0; k < i; k++)
                {
                    temp -= l[i][k] * l[i][k];
                }

                l[i][i] = (float)System.Math.Sqrt(temp);
            }

            var lt = l.Transpose();
            for (int i = 0; i < l.GetUpperBound(0) + 1; i++)
            {
                float summa = 0;
                for (int j = 0; j < i; j++)
                {
                    summa += l[i][j] * y[j];
                }

                y[i] = (vector.Numbers[i] - summa) / l[i][i];
            }

            for (int i = lt.GetUpperBound(0); i >= 0; i--)
            {
                float summa = 0;
                for (int j = lt.GetUpperBound(0); j > i; j--)
                {
                    summa += lt[i][j] * x[j];
                }

                x[i] = (y[i] - summa) / lt[i][i];
            }

            return new Vector(x);
        }
    }
}
