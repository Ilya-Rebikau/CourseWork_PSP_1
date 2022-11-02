using CourseWork.Models;

namespace CourseWork.UnitTests
{
    internal class SeidelMethod
    {
        public SeidelMethod(Matrix matrix, Vector vector)
        {
            Matrix = matrix;
            Vector = vector;
        }

        public Matrix Matrix { get; set; }

        public Vector Vector { get; set; }

        public float Precision { get; set; } = 0.00001F;

        public Vector Solve()
        {
            var x = new float[Matrix.Size];
            var xNew = new float[Matrix.Size];
            bool converge = false;
            while (!converge)
            {
                var loss = 0.0F;
                Array.Copy(x, xNew, x.Length);
                for (var i = 0; i < Matrix.Size; i++)
                {
                    var sum1 = 0.0F;
                    var sum2 = 0.0F;
                    for (var j = 0; j < i; j++)
                    {
                        sum1 += Matrix.Numbers[i][j] * xNew[j];
                    }

                    for (var j = i + 1; j < Matrix.Size; j++)
                    {
                        sum2 += Matrix.Numbers[i][j] * x[j];
                    }
                        
                    xNew[i] = (Vector.Numbers[i] - sum1 - sum2) / Matrix.Numbers[i][i];
                    loss += (float)Math.Pow(xNew[i] - x[i], 2);
                }

                converge = Math.Sqrt(loss) <= Precision;
                Array.Copy(xNew, x, xNew.Length);
            }

            return new Vector(x);
        }
    }
}
