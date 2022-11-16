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
        /// Http clients for computing servers.
        /// </summary>
        private readonly List<IComputingHttpClient> _httpClients;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistributionController"/> class.
        /// </summary>
        /// <param name="factory">Factory to build list of http clients for computing servers.</param>
        public DistributionController(IFactory<IComputingHttpClient> factory)
        {
            _httpClients = factory.CreateList();
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
                for (int i = 0; i < _httpClients.Count; i++)
                {
                    try
                    {
                        if (!await _httpClients[i].CheckForWork())
                        {
                            Console.WriteLine($"____________________________________________________________\n{i + 1}th server started work.\n____________________________________________________________");
                            var result = await _httpClients[i].GetResult(data);
                            Console.WriteLine($"____________________________________________________________\n{i + 1}th server done.\n____________________________________________________________");
                            return result;
                        }
                    }
                    catch
                    {
                        serversNotWorking++;
                    }
                }
            }
        }
    }
}
