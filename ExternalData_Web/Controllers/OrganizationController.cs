using ExternalData_Web.Models;
using ExternalData_Web.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExternalData_Web.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IOrganizationRepository _organization;
        public OrganizationController(IOrganizationRepository organization)
        {
            _organization = organization;
        }
        public IActionResult Index()
        {
            return View(new Organization() { });
        }
        public async Task<IActionResult> GetAllOrganizations()
        {
            return Json(new { data = await _organization.GetAllAsync(APIpath.api) });
        }
    }
}
