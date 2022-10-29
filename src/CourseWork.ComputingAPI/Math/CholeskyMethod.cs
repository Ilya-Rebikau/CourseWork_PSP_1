// <copyright file="CholeskyMethod.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.ComputingAPI.Math
{
    using Accord.Math;
    using Matrix = CourseWork.Models.Matrix;
    using Vector = CourseWork.Models.Vector;

    /// <summary>
    /// SLAE solver using the Cholesky method.
    /// </summary>
    public class CholeskyMethod
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CholeskyMethod"/> class.
        /// </summary>
        /// <param name="matrix">Base matrix A.</param>
        /// <param name="vector">Base vector B.</param>
        public CholeskyMethod(Matrix matrix, Vector vector)
        {
            Matrix = matrix;
            Vector = vector;
        }

        /// <summary>
        /// Gets or sets base matrix A.
        /// </summary>
        public Matrix Matrix { get; set; }

        /// <summary>
        /// Gets or sets base vector B.
        /// </summary>
        public Vector Vector { get; set; }

        /// <summary>
        /// Solve SLAE using the Cholesky method.
        /// </summary>
        /// <returns>Vector result.</returns>
        public Vector Solve()
        {
            var l = new float[Matrix.Size][];
            var y = new float[Matrix.Size];
            var x = new float[Matrix.Size];
            for (int i = 0; i < l.GetUpperBound(0) + 1; i++)
            {
                l[i] = new float[Matrix.Size];
                float temp;
                for (int j = 0; j < i; j++)
                {
                    temp = 0;
                    for (int k = 0; k < j; k++)
                    {
                        temp += l[i][k] * l[j][k];
                    }
                    l[i][j] = (Matrix.Numbers[i][j] - temp) / l[j][j];
                }

                temp = Matrix.Numbers[i][i];
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

                y[i] = (Vector.Numbers[i] - summa) / l[i][i];
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
