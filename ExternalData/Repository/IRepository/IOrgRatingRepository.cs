using ExternalData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExternalData.Repository.IRepository
{
    public interface IOrgRatingRepository
    {
        ICollection<OrgRating> GetOrgRatings();

        OrgRating GetOrgRating(int Org_ID);
        //OrgRating GetOrganizationOrgRating(int OID);
        bool OrgRatingExists(int ID);
        bool CreateOrgRating(OrgRating orgRating);
        bool UpdateOrgRating(OrgRating orgRating);
        bool DeleteOrgRating(OrgRating orgRating);

        bool Save();
    }
}
