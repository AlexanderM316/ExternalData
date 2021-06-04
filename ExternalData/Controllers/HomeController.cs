using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExternalData.Models;
using Microsoft.Extensions.Logging;
using ExternalData.Repository.IRepository;


namespace ExternalData.Controllers
{
    public class HomeController : Controller
    {
        public static string ApiControllerUrl = "https://localhost:44337/api/hangfire";
        private readonly ILogger<HomeController> _logger;
        //private readonly IOrganizationRepository _orgaizationRepo;
        private readonly IOrgRatingRepository _orgRatingRepo;

        public HomeController(ILogger<HomeController> logger, IOrgRatingRepository orgRatingRepo)
        {
            _logger = logger;
            //_orgaizationRepo = orgaizationRepo;
            _orgRatingRepo = orgRatingRepo;
            
        }
       
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
     

    }
}
