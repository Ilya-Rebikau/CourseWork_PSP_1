// <copyright file="MathsController.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.ComputingAPI.Controllers
{
    using System.IO;
    using CourseWork.ComputingAPI.Math;
    using CourseWork.ComputingAPI.Models;
    using CourseWork.DAL.Interfaces;
    using CourseWork.DAL.Models;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Doing math computing.
    /// </summary>
    [Route("computingapi/[controller]")]
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
        /// Path to file with result of slae.
        /// </summary>
        private readonly string _pathToResult;

        /// <summary>
        /// Path to file with result of slae with its name.
        /// </summary>
        private readonly string _pathToResultWithFileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="MathsController"/> class.
        /// </summary>
        /// <param name="matrixSerializer">Serializer for matrix.</param>
        /// <param name="vectorSerializer">Serializer for vector.</param>
        /// <param name="environment">Web environment.</param>
        public MathsController(ISerializer<Matrix> matrixSerializer, ISerializer<Vector> vectorSerializer, IWebHostEnvironment environment)
        {
            _matrixSerializer = matrixSerializer;
            _vectorSerializer = vectorSerializer;
            _pathToResult = Path.Combine(environment.WebRootPath, "Files");
            _pathToResultWithFileName = Path.Combine(_pathToResult, "VectorX.xml");
        }

        /// <summary>
        /// Gets result of slae solving it via the Cholesky method.
        /// </summary>
        /// <param name="matrixData">Matrix data.</param>
        /// <param name="vectorData">Vector data.</param>
        /// <returns>Vector-result X.</returns>
        [HttpPost("GetResult")]
        public FileResult GetSlaeResult([FromBody] FileDataModel matrixData, [FromBody] FileDataModel vectorData)
        {
            var matrix = _matrixSerializer.ReadObject(matrixData.Data);
            var vector = _vectorSerializer.ReadObject(vectorData.Data);
            var solver = new CholeskyMethod(matrix, vector);
            var vectorX = solver.Solve();
            _vectorSerializer.WriteObject(vectorX, _pathToResultWithFileName);
            return File(_pathToResult, "application/xml", "VectorX.xml");
        }
    }
}
