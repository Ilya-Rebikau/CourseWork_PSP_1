// <copyright file="MathsController.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.ComputingAPI.Controllers
{
    using CourseWork.ComputingAPI.Math;
    using CourseWork.ComputingAPI.Models;
    using CourseWork.DAL.Interfaces;
    using CourseWork.DAL.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Doing math computing.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class MathsController : ControllerBase
    {
        /// <summary>
        /// Serializer for matrix.
        /// </summary>
        private readonly ISerializer<Matrix> _matrixSerializer;

        /// <summary>
        /// Serializer for vector.
        /// </summary>
        private readonly ISerializer<Vector> _vectorSerializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="MathsController"/> class.
        /// </summary>
        /// <param name="matrixSerializer">Serializer for matrix.</param>
        /// <param name="vectorSerializer">Serializer for vector.</param>
        public MathsController(ISerializer<Matrix> matrixSerializer, ISerializer<Vector> vectorSerializer)
        {
            _matrixSerializer = matrixSerializer;
            _vectorSerializer = vectorSerializer;
        }

        /// <summary>
        /// Gets result of slae solving it via the Cholesky method.
        /// </summary>
        /// <param name="data">Data model with matrix and vector data.</param>
        /// <returns>FileDataModel with result-vector.</returns>
        [HttpPost("GetResult")]
        [DisableRequestSizeLimit]
        public FileDataModel GetSlaeResult([FromBody] FileDataModel data)
        {
            var matrix = _matrixSerializer.ReadObject(data.MatrixData);
            var vector = _vectorSerializer.ReadObject(data.VectorData);
            var solver = new CholeskyMethod(matrix, vector);
            var vectorX = solver.Solve();
            var result = new FileDataModel
            {
                VectorData = _vectorSerializer.WriteObject(vectorX),
            };

            return result;
        }
    }
}
