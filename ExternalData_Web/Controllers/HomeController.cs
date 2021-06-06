using ExternalData_Web.Models;
using ExternalData_Web.Models.ViewModel;
using ExternalData_Web.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ExternalData_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IOrganizationRepository _orgaizationRepo;
        private readonly IOrgRatingRepository _orgRatingRepo;

        public HomeController(ILogger<HomeController> logger, IOrgRatingRepository orgRatingRepo, IOrganizationRepository orgaizationRepo)
        {
            _logger = logger;
            _orgaizationRepo = orgaizationRepo;
            _orgRatingRepo = orgRatingRepo;

        }
    

        public async Task<IActionResult> Index()
        {
            Organization_OrgRatingVM organization_OrgRatings = new Organization_OrgRatingVM()
            {
                OrgRatings = await _orgRatingRepo.GetAllAsync(APIpath.api + "GetOrgRatings"),
                Organizations = await _orgaizationRepo.GetAllAsync(APIpath.api+ "GetOrganizations"),

            };
            return View(organization_OrgRatings);
        }
        //public IActionResult Upsert(int ? id)
        //{

        //}

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
