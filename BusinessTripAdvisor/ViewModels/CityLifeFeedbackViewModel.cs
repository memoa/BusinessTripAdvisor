using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessTripAdvisor.Models;
using System.ComponentModel.DataAnnotations;

namespace BusinessTripAdvisor.ViewModels
{
    public class CityLifeFeedbackViewModel
    {
        public int Id { get; set; }
        public City City { get; set; }
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

        public UserViewModel User { get; set; }
        public Tag Tag { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

    }
}