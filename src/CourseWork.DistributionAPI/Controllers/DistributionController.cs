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
    [Route("distributionapi/[controller]")]
    [ApiController]
    public class DistributionController : ControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DistributionController"/> class.
        /// </summary>
        public DistributionController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> DistributeFiles([FromBody] FileDataModel matrixFileData, [FromBody] FileDataModel vectorFileData)
        {
            //TODO распределение файлов по серверам.
            return Ok();
        }
    }
}
