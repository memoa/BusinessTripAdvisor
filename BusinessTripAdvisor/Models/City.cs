using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BusinessTripAdvisor.Models
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(5000)]
        public string Description { get; set; }

        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}