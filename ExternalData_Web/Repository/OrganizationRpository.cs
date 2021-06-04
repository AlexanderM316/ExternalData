using ExternalData_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExternalData_Web.Repository.IRepository
{
    public class OrganizationRepository : Repository<Organization>, IOrganizationRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public OrganizationRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}
