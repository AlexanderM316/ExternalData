using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExternalData_Web.Models
{
    public class Organization
    {
        public int OID { get; set; }
        [Required]
        public double INN { get; set; }
    }
}
