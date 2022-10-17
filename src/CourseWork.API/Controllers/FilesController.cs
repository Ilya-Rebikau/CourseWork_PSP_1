// <copyright file="FilesController.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.API.Controllers
{
    using CourseWork.API.Models;
    using CourseWork.DAL.Interfaces;
    using CourseWork.DAL.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Working with files uploading and downloading.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
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
        /// Initializes a new instance of the <see cref="FilesController"/> class.
        /// </summary>
        /// <param name="matrixSerializer">Serializer for matrix.</param>
        /// <param name="vectorSerializer">Serializer for vector.</param>
        public FilesController(ISerializer<Matrix> matrixSerializer, ISerializer<Vector> vectorSerializer)
        {
            _matrixSerializer = matrixSerializer;
            _vectorSerializer = vectorSerializer;
        }

        [HttpPost]
        public async Task<IActionResult> RecieveMatrix([FromBody] FileDataModel fileData)
        {

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RecieveVector([FromBody] FileDataModel fileData)
        {

            return Ok();
        }
    }
}
