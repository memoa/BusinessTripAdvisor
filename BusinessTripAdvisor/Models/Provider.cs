using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BusinessTripAdvisor.Models
{
    public class Provider
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public TransportationType TransportationType { get; set; }
        public int TransportationTypeId { get; set; }
    }
}