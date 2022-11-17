// <copyright file="MathsController.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.ComputingAPI.Controllers
{
    using CourseWork.ComputingAPI.Attributes;
    using CourseWork.ComputingAPI.Interfaces;
    using CourseWork.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Doing math computing.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [ExceptionFilter]
    public class MathsController : ControllerBase
    {
        /// <summary>
        /// Is server working now or not.
        /// </summary>
        private static bool _isWorking = false;

        /// <summary>
        /// Solver for SLAE.
        /// </summary>
        private readonly ISolver _solver;

        /// <summary>
        /// Initializes a new instance of the <see cref="MathsController"/> class.
        /// </summary>
        /// <param name="solver">Solver for SLAE.</param>
        public MathsController(ISolver solver)
        {
            _solver = solver;
        }

        /// <summary>
        /// Gets result of slae solving it via the Cholesky method.
        /// </summary>
        /// <param name="data">Data model with matrix and vector data.</param>
        /// <returns>DataModel with result-vector.</returns>
        [HttpPost("GetResult")]
        [DisableRequestSizeLimit]
        public DataModel GetSlaeResult([FromBody] DataModel data)
        {
            _isWorking = true;
            var vectorX = _solver.Solve(data.Matrix, data.Vector);
            var result = new DataModel
            {
                Vector = vectorX,
            };

            _isWorking = false;
            return result;
        }

        /// <summary>
        /// Check computing method for working.
        /// </summary>
        /// <returns>True if working right now and false if not.</returns>
        [HttpGet("CheckForWork")]
        public bool CheckForWork()
        {
            return _isWorking;
        }
    }
}
