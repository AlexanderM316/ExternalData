using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExternalData.Models;
using ExternalData.Models.Dtos;

namespace ExternalData.Mapper
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<OrgRating, OrgRatingDto>().ReverseMap();
        }
    }
}
