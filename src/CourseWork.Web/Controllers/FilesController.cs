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
        /// Path to files directory.
        /// </summary>
        private readonly string _pathToFiles;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilesController"/> class.
        /// </summary>
        /// <param name="httpClient">HttpClient.</param>
        /// <param name="environment">IWebHostEnvironment object.</param>
        public FilesController(IDistributionHttpClient httpClient, IWebHostEnvironment environment)
        {
            _httpClient = httpClient;
            _pathToFiles = Path.Combine(environment.WebRootPath, "files");
        }

        /// <summary>
        /// Send files with matrix and vector to server and get result file.
        /// </summary>
        /// <param name="matrixFileName">File name with matrix.</param>
        /// <param name="vectorFileName">File name with vector.</param>
        /// <returns>File with result vector.</returns>
        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> SendMatrixAndVectorToServer(string matrixFileName, string vectorFileName)
        {
            ReadData(matrixFileName, vectorFileName, out byte[] matrixData, out byte[] vectorData);
            var data = new FileDataModel
            {
                MatrixData = matrixData,
                VectorData = vectorData,
            };

            var result = await _httpClient.SendFileToServer(data);
            return File(result.VectorData, "application/xml", "VectorX.xml");
        }

        private void ReadData(string matrixFileName, string vectorFileName, out byte[] matrixData, out byte[] vectorData)
        {
            using var matrixStream = new FileStream(Path.Combine(_pathToFiles, matrixFileName + ".xml"), FileMode.Open, FileAccess.Read);
            int blockSize = 1;
            byte[] block = new byte[blockSize];
            var allBytes = new List<byte>();
            while (matrixStream.Read(block, 0, blockSize) > 0)
            {
                allBytes.AddRange(block);
            }

            matrixData = allBytes.ToArray();
            if (matrixData.Length == 0)
            {
                throw new ArgumentException("Файл с матрицей пустой!");
            }

            using var vectorStream = new FileStream(Path.Combine(_pathToFiles, vectorFileName + ".xml"), FileMode.Open, FileAccess.Read);
            allBytes = new List<byte>();
            while (vectorStream.Read(block, 0, blockSize) > 0)
            {
                allBytes.AddRange(block);
            }

            vectorData = allBytes.ToArray();
            if (vectorData.Length == 0)
            {
                throw new ArgumentException("Файл с вектором пустой!");
            }
        }
    }
}
