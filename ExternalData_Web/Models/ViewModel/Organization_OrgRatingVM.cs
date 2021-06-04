using ExternalData_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExternalData_Web.Models.ViewModel
{
    public class Organization_OrgRatingVM
    {
        public IEnumerable<OrgRating> OrgRatings {get;set; }
        public IEnumerable<Organization> Organizations { get; set; }
    }
}
