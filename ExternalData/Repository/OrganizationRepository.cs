using ExternalData.Data;
using ExternalData.Models;
using ExternalData.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExternalData.Repository
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly ApplicationDbContext _db;

        public OrganizationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateOrganization(Organization organization)
        {
            _db.Organization.Add(organization);
            return Save();
        }

        public bool DeleteOrganization(Organization organization)
        {
            _db.Organization.Remove(organization);
            return Save();
        }

        public Organization GetOrganization(int OID)
        {
            return _db.Organization.FirstOrDefault(a => a.OID == OID);
        }

        public ICollection<Organization> GetOrganizations()
        {
            return _db.Organization.OrderBy(a => a.OID).ToList();
        }

        public bool OrganizationExists(int ID)
        {
            return _db.Organization.Any(a => a.OID == ID);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateOrganization(Organization organization)
        {
            _db.Organization.Update(organization);
            return Save();
        }
    }
}
