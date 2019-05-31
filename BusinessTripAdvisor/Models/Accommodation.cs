using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BusinessTripAdvisor.Models
{
    public class Accommodation
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public AccommodationType AccommodationType { get; set; }
        public int AccommodationTypeId { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        public int? StarRating { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(5000)]
        public string Description { get; set; }
        [StringLength(255)]
        public string WebAddress { get; set; }
    }
}