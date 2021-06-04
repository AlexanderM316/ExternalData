using ExternalData_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExternalData_Web.Repository.IRepository
{
    public class OrgRatingRepository : Repository<OrgRating>, IOrgRatingRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public OrgRatingRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
   
}
