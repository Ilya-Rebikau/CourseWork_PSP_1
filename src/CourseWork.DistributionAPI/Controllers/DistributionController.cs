// <copyright file="DistributionController.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.DistributionAPI.Controllers
{
    using CourseWork.DistributionAPI.Interfaces;
    using CourseWork.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Working with files uploading and downloading.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class DistributionController : ControllerBase
    {
        /// <summary>
        /// HttpClient for first server.
        /// </summary>
        private readonly IFirstComputingHttpClient _firstHttpClient;

        /// <summary>
        /// HttpClient for second server.
        /// </summary>
        private readonly ISecondComputingHttpClient _secondHttpClient;

        /// <summary>
        /// HttpClient for third server.
        /// </summary>
        private readonly IThirdComputingHttpClient _thirdHttpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistributionController"/> class.
        /// </summary>
        /// <param name="firstHttpClient">HttpClient for first server.</param>
        /// <param name="secondHttpClient">HttpClient for second server.</param>
        /// <param name="thirdHttpClient">HttpClient for third server.</param>
        public DistributionController(
            IFirstComputingHttpClient firstHttpClient,
            ISecondComputingHttpClient secondHttpClient,
            IThirdComputingHttpClient thirdHttpClient)
        {
            _firstHttpClient = firstHttpClient;
            _secondHttpClient = secondHttpClient;
            _thirdHttpClient = thirdHttpClient;
        }

        /// <summary>
        /// Distribute data between different servers.
        /// </summary>
        /// <param name="data">Data with matrix and vector.</param>
        /// <returns>Task with result.</returns>
        [HttpPost("DistributeFiles")]
        public async Task<DataModel> DistributeFiles([FromBody] DataModel data)
        {
            while (true)
            {
                var isFirstWorking = await _firstHttpClient.CheckForWork();
                var isSecondWorking = await _secondHttpClient.CheckForWork();
                var isThirdWorking = await _thirdHttpClient.CheckForWork();
                if (!isFirstWorking)
                {
                    Console.WriteLine("First-------------------------------------------------------------------------");
                    var result = await _firstHttpClient.GetResult(data);
                    return result;
                }

                if (!isSecondWorking)
                {
                    Console.WriteLine("Second-------------------------------------------------------------------------");
                    var result = await _secondHttpClient.GetResult(data);
                    return result;
                }

                if (!isThirdWorking)
                {
                    Console.WriteLine("Third-------------------------------------------------------------------------");
                    var result = await _thirdHttpClient.GetResult(data);
                    return result;
                }
            }
        }
    }
}
