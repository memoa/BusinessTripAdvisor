using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessTripAdvisor.Models
{
    public class BTAUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Pass { get; set; }
        public string Tel { get; set; }
        public bool Authentificated { get; set; }
        public string KeyStone { get; set; }

        public UserType UserType { get; set; }
        public int UserTypeId { get; set; }

        public City City { get; set; }
        public int CityId { get; set; }
    }
}