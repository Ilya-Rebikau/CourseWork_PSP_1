// <copyright file="FilesController.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.Web.Controllers
{
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
        /// Send files with matrix and vector to server and get result file.
        /// </summary>
        /// <param name="matrixFile">File with matrix.</param>
        /// <param name="vectorFile">File with vector.</param>
        /// <returns>File with result vector.</returns>
        [HttpPost]
        public async Task<IActionResult> SendMatrixAndVectorToServer(IFormFile matrixFile, IFormFile vectorFile)
        {
            CheckFilesForNull(matrixFile, vectorFile);
            using var matrixStream = matrixFile.OpenReadStream();
            byte[] matrixData = new byte[matrixStream.Length];
            await matrixStream.ReadAsync(matrixData);
            if (matrixData.Length == 0)
            {
                throw new ArgumentException("Файл с матрицей пустой!");
            }

            using var vectorStream = vectorFile.OpenReadStream();
            byte[] vectorData = new byte[vectorStream.Length];
            await vectorStream.ReadAsync(vectorData);
            if (vectorData.Length == 0)
            {
                throw new ArgumentException("Файл с вектором пустой!");
            }

            var data = new FileDataModel
            {
                MatrixData = matrixData,
                VectorData = vectorData,
            };

            var result = await _httpClient.SendFileToServer(data);
            return File(result.VectorData, "application/xml", "VectorX.xml");
        }

        private static void CheckFilesForNull(IFormFile matrixFile, IFormFile vectorFile)
        {
            if (matrixFile == null)
            {
                throw new ArgumentException("Файл с матрицей не загружен!");
            }

            if (vectorFile == null)
            {
                throw new ArgumentException("Файл с вектором не загружен!");
            }
        }
    }
}
