using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExternalData.Services;
using ExternalData.Repository.IRepository;
using AutoMapper;
using ExternalData.Models.Dtos;
using ExternalData.Models;

namespace ExternalData.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class HangfireController : ControllerBase
    {
        
        private IOrgRatingRepository _orgRatingRepo;
        private IOrganizationRepository _organization;
        private readonly IMapper _mapper;

        public HangfireController(IOrgRatingRepository orgRatingRepository, IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _orgRatingRepo = orgRatingRepository;
            _organization = organizationRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetOrgRatings()
        {
            var objList = _orgRatingRepo.GetOrgRatings();
            var objDto = new List<OrgRatingDto>();
            foreach(var obj in objList)
            {
                objDto.Add(_mapper.Map<OrgRatingDto>(obj));
            }
            return Ok(objDto);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetOrganizations()
        {
            var objList = _organization.GetOrganizations();
            var objDto = new List<OrganizationDto>();
            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<OrganizationDto>(obj));
            }
            return Ok(objDto);
        }

        [HttpGet("ByOrg_ID")]
        [Route("[action]")]
        public IActionResult GetOrgRating(int Org_ID)
        {
            var obj = _orgRatingRepo.GetOrgRating(Org_ID);
            if(obj == null)
            {
                return NotFound();
            }
     
            var objDto = _mapper.Map<OrgRatingDto>(obj);
            
            return Ok(objDto);
        }
        [HttpPost]
        public IActionResult CreateOrgRating([FromBody] OrgRatingDto orgRatingDto)
        {
            if(orgRatingDto == null)
            {
                return BadRequest(ModelState);
            }
            if (_orgRatingRepo.OrgRatingExists(orgRatingDto.ID))
            {
                ModelState.AddModelError("", "Org_ID already exists");
                return StatusCode(404, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var orgRatingObj = _mapper.Map<OrgRating>(orgRatingDto);
            if (!_orgRatingRepo.CreateOrgRating(orgRatingObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving OrgRating with ID ={orgRatingObj.ID}");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }
        [HttpPatch("ByOrg_ID")]
        public IActionResult UpdateOrgRating(int Org_ID, [FromBody] OrgRatingDto orgRatingDto)
        {
            if (orgRatingDto == null || !(Org_ID==orgRatingDto.Org_ID))
            {
                return BadRequest(ModelState);
            }
            var orgRatingObj = _mapper.Map<OrgRating>(orgRatingDto);
            if (!_orgRatingRepo.UpdateOrgRating(orgRatingObj))
            {
                ModelState.AddModelError("", $"Something went wrong when Updating OrgRating with ID ={orgRatingObj.ID}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult ImportData()
        {
            try
            {
                UpdateService.UpdateDB();
                return Ok("DB updated");
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }
    }
}
