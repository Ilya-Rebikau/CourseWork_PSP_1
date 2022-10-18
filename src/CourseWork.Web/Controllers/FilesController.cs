// <copyright file="FilesController.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.Web.Controllers
{
    using CourseWork.Web.Extensions;
    using CourseWork.Web.Interfaces;
    using CourseWork.Web.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Working with files uploading and downloading.
    /// </summary>
    public class FilesController : Controller
    {
        /// <summary>
        /// HttpClient.
        /// </summary>
        private readonly IDistributionHttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilesController"/> class.
        /// </summary>
        /// <param name="httpClient">HttpClient.</param>
        public FilesController(IDistributionHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Send file to server.
        /// </summary>
        /// <param name="file">File.</param>
        /// <returns>Redirection to main page.</returns>
        [HttpPost("send")]
        public async Task<IActionResult> SendFile(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            byte[] fileData = new byte[stream.Length];
            await stream.ReadAsync(fileData);
            var data = new FileDataModel
            {
                Data = fileData,
            };

            await _httpClient.SendFileToServer(data);
            return RedirectToAction(nameof(Index), typeof(HomeController).GetControllerName());
        }
    }
}
