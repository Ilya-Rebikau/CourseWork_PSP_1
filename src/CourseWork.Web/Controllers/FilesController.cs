// <copyright file="FilesController.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.Web.Controllers
{
    using CourseWork.Models;
    using CourseWork.Web.Attributes;
    using CourseWork.Web.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Working with files uploading and downloading.
    /// </summary>
    [ExceptionFilter]
    public class FilesController : Controller
    {
        /// <summary>
        /// Serializer for matrix.
        /// </summary>
        private readonly ISerializer<Matrix> _matrixSerializer;

        /// <summary>
        /// Serializer for vector.
        /// </summary>
        private readonly ISerializer<Vector> _vectorSerializer;

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
        /// <param name="matrixSerializer">Serializer for matrix.</param>
        /// <param name="vectorSerializer">Serializer for vector.</param>
        public FilesController(IDistributionHttpClient httpClient, IWebHostEnvironment environment, ISerializer<Matrix> matrixSerializer, ISerializer<Vector> vectorSerializer)
        {
            _httpClient = httpClient;
            _pathToFiles = Path.Combine(environment.WebRootPath, "files");
            _matrixSerializer = matrixSerializer;
            _vectorSerializer = vectorSerializer;
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
            var matrix = _matrixSerializer.ReadObject(Path.Combine(_pathToFiles, matrixFileName + ".xml"));
            var vector = _vectorSerializer.ReadObject(Path.Combine(_pathToFiles, vectorFileName + ".xml"));
            var data = new DataModel
            {
                Matrix = matrix,
                Vector = vector,
            };

            var result = await _httpClient.SendFileToServer(data);
            return File(_vectorSerializer.WriteObjectToByteArray(result.Vector), "application/xml", "VectorX.xml");
        }
    }
}
