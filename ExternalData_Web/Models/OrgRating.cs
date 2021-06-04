using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExternalData_Web.Models
{
    public class OrgRating
    {
        public int ID { get; set; }
        [Required]
        public int Org_ID { get; set; }
        public decimal Rating { get; set; }

        public Organization Organization { get; set; }
    }
}
