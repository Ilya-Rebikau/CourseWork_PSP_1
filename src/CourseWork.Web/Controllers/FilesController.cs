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
        /// Send files with matrix and vector to server.
        /// </summary>
        /// <param name="matrixFile">File with matrix.</param>
        /// <param name="vectorFile">File with vector.</param>
        /// <returns>Redirection to main page.</returns>
        [HttpPost]
        public async Task<IActionResult> SendMatrixAndVectorToServer(IFormFile matrixFile, IFormFile vectorFile)
        {
            using var matrixStream = matrixFile.OpenReadStream();
            byte[] matrixData = new byte[matrixStream.Length];
            await matrixStream.ReadAsync(matrixData);
            using var vectorStream = vectorFile.OpenReadStream();
            byte[] vectorData = new byte[vectorStream.Length];
            await vectorStream.ReadAsync(vectorData);
            var data = new FileDataModel
            {
                MatrixData = matrixData,
                VectorData = vectorData,
            };

            await _httpClient.SendFileToServer(data);
            return RedirectToAction(nameof(Index), typeof(HomeController).GetControllerName());
        }

        ///// <summary>
        ///// Recieve vector X from server.
        ///// </summary>
        ///// <returns>File with vector X.</returns>
        //[HttpGet]
        //public FileResult RecieveVectorX()
        //{
        //    return File();
        //}
    }
}
