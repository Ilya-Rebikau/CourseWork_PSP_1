// <copyright file="DistributionController.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.DistributionAPI.Controllers
{
    using CourseWork.DistributionAPI.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Working with files uploading and downloading.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class DistributionController : ControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DistributionController"/> class.
        /// </summary>
        public DistributionController()
        {
        }

        /// <summary>
        /// Distribute data between different servers.
        /// </summary>
        /// <param name="data">Data with matrix and vector.</param>
        /// <returns></returns>
        [HttpPost("DistributeFiles")]
        public async Task<IActionResult> DistributeFiles([FromBody] FileDataModel data)
        {
            await Task.Delay(1);

            // TODO распределение файлов по серверам.
            return Ok();
        }
    }
}
