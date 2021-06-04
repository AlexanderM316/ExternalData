using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExternalData.Models.Dtos
{
    public class OrganizationDto
    {
        
        public int OID { get; set; }
        [Required]
        public double INN { get; set; }
    }
}
