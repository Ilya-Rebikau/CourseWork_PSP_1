// <copyright file="DistributionController.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.DistributionAPI.Controllers
{
    using CourseWork.DistributionAPI.Attributes;
    using CourseWork.DistributionAPI.Interfaces;
    using CourseWork.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Working with files uploading and downloading.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [ExceptionFilter]
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
                int serversNotWorking = 0;
                bool isFirstWorking = false, isSecondWorking = false, isThirdWorking = false;
                try
                {
                    isFirstWorking = await _firstHttpClient.CheckForWork();
                }
                catch
                {
                    serversNotWorking++;
                }

                try
                {
                    isSecondWorking = await _secondHttpClient.CheckForWork();
                }
                catch
                {
                    serversNotWorking++;
                }

                try
                {
                    isThirdWorking = await _thirdHttpClient.CheckForWork();
                }
                catch
                {
                    serversNotWorking++;
                }

                if (serversNotWorking == 3)
                {
                    throw new HttpRequestException("Все вычислительные серверы отключены!");
                }

                if (!isFirstWorking)
                {
                    Console.WriteLine("____________________________________________________________\nFirst server started work.");
                    var result = await _firstHttpClient.GetResult(data);
                    Console.WriteLine("First server done.\n____________________________________________________________");
                    return result;
                }

                if (!isSecondWorking)
                {
                    Console.WriteLine("____________________________________________________________\nSecond server started work.");
                    var result = await _secondHttpClient.GetResult(data);
                    Console.WriteLine("Second server done.\n____________________________________________________________");
                    return result;
                }

                if (!isThirdWorking)
                {
                    Console.WriteLine("____________________________________________________________\nThird server started work.");
                    var result = await _thirdHttpClient.GetResult(data);
                    Console.WriteLine("Third server done.\n____________________________________________________________");
                    return result;
                }
            }
        }
    }
}
