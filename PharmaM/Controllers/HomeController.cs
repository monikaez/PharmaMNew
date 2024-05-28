﻿using Microsoft.AspNetCore.Mvc;
using PharmaM.Core.Contracts;
using PharmaM.Core.Services;
using PharmaM.Models;
using System.Diagnostics;

namespace PharmaM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
       

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        
        }

        public async Task<IActionResult> Index()
        {
            var data = await _productService.GetAllAsync();
            return View(data);
        }

        
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Shop()
        {
            var data = await _productService.GetAllAsync();
            return View(data);
        }


        public IActionResult Privacy()
        {
            return View();
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}