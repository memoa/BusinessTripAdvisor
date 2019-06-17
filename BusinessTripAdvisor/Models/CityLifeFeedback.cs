using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BusinessTripAdvisor.Models
{
    public class CityLIfeFeedback
    {
        public int Id { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(5000)]
        public string Comment { get; set; }
        
        [Required]
        [StringLength(128)]
        public string AspNetUserId { get; set; }
        public ApplicationUser AspNetUser { get; set; }
        public Tag Tag { get; set; }
        public int TagId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}