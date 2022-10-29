// <copyright file="MathsController.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.ComputingAPI.Controllers
{
    using CourseWork.ComputingAPI.Math;
    using CourseWork.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Doing math computing.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class MathsController : ControllerBase
    {
        /// <summary>
        /// Gets result of slae solving it via the Cholesky method.
        /// </summary>
        /// <param name="data">Data model with matrix and vector data.</param>
        /// <returns>DataModel with result-vector.</returns>
        [HttpPost("GetResult")]
        [DisableRequestSizeLimit]
        public DataModel GetSlaeResult([FromBody] DataModel data)
        {
            var solver = new CholeskyMethod(data.Matrix, data.Vector);
            var vectorX = solver.Solve();
            var result = new DataModel
            {
                Vector = vectorX,
            };

            return result;
        }
    }
}
