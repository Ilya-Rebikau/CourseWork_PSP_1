// <copyright file="DistributionController.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.DistributionAPI.Controllers
{
    using CourseWork.DistributionAPI.Interfaces;
    using CourseWork.DistributionAPI.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Working with files uploading and downloading.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class DistributionController : ControllerBase
    {
        IComputingHttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistributionController"/> class.
        /// </summary>
        public DistributionController(IComputingHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Distribute data between different servers.
        /// </summary>
        /// <param name="data">Data with matrix and vector.</param>
        /// <returns>Task with result.</returns>
        [HttpPost("DistributeFiles")]
        public async Task<FileDataModel> DistributeFiles([FromBody] FileDataModel data)
        {
            var result = await _httpClient.GetResult(data);
            return result;
        }
    }
}
