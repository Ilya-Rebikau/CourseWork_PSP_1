// <copyright file="FilesController.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.DistributionAPI.Controllers
{
    using CourseWork.DistributionAPI.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Working with files uploading and downloading.
    /// </summary>
    [Route("api/[controller]")]
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
        public async Task<IActionResult> RecieveFiles([FromBody] FileDataModel matrixFileData, [FromBody] FileDataModel vectorFileData)
        {
            return Ok();
        }
    }
}
