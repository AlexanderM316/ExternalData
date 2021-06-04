using ExternalData_Web.Models;
using ExternalData_Web.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExternalData_Web.Controllers
{
    public class OrgRatingController : Controller
    {
        private readonly IOrgRatingRepository _orgRating;
        public OrgRatingController(IOrgRatingRepository orgRating)
        {
            _orgRating = orgRating;
        }
        public IActionResult Index()
        {
            return View(new OrgRating() { });
        }
        public async Task<IActionResult> GetAllOrgRating()
        {
            return Json(new { data = await _orgRating.GetAllAsync(APIpath.api) });
        }
    }
}
