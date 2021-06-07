using ExternalData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExternalData.Repository.IRepository
{
    public interface IOrganizationRepository
    {
        ICollection<Organization> GetOrganizations();

        Organization GetOrganization(int OID);
        Organization GetOrganizationByINN(double INN);
        bool OrganizationExists(double inn);
        bool CreateOrganization(Organization organization);
        bool UpdateOrganization(Organization organization);
        bool DeleteOrganization(Organization organization);

        bool Save();
    }
}
