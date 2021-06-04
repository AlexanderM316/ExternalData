using ExternalData.Data;
using ExternalData.Models;
using ExternalData.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExternalData.Repository
{
    public class OrgRatingRepository : IOrgRatingRepository
    {
        private readonly ApplicationDbContext _db;

        public OrgRatingRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateOrgRating(OrgRating orgRating)
        {
            _db.OrgRating.Add(orgRating);
            return Save();
        }

        public bool DeleteOrgRating(OrgRating orgRating)
        {
            _db.OrgRating.Remove(orgRating);
            return Save();
        }

        public OrgRating GetOrgRating(int Org_ID)
        {
            return _db.OrgRating.FirstOrDefault(a => a.Org_ID == Org_ID);
        }

        //public OrgRating GetOrganizationOrgRating(int OID)
        //{
        //    return _db.OrgRating.Include(c => c.organization).Where(c => c.Org_ID == OID).FirstOrDefault();
        //}

        public ICollection<OrgRating> GetOrgRatings()
        {
            return  _db.OrgRating.OrderBy(a => a.ID).ToList();
           
        }

        public bool OrgRatingExists(int ID)
        {
            return _db.OrgRating.Any(a => a.ID == ID);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateOrgRating(OrgRating orgRating)
        {
            _db.OrgRating.Update(orgRating);
            return Save();
        }
    }
}
