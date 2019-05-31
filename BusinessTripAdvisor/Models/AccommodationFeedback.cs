using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BusinessTripAdvisor.Models
{
    public class AccommodationFeedback
    {
        public int Id { get; set; }
        public Accommodation Accommodation { get; set; }
        public int AccommodationId { get; set; }
        public DateTime Time { get; set; }
        public int Rating { get; set; }
        [Required]
        [StringLength(5000)]
        public string Comment { get; set; }
        public ApplicationUser User { get; set; }
    }
}