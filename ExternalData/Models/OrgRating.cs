using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExternalData.Models
{
    public class OrgRating
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Org_ID { get; set; }
        public decimal Rating { get; set; }
        [ForeignKey("Org_ID")]
        public Organization organization { get; set; }

    }
}
