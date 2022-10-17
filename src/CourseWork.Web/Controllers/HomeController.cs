// <copyright file="HomeController.cs" company="IlyaRebikau">
// Copyright (c) IlyaRebikau. All rights reserved.
// </copyright>

namespace CourseWork.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Main controller for home page.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Start page.
        /// </summary>
        /// <returns>View with main page.</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}