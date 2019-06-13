using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessTripAdvisor.Models;

namespace BusinessTripAdvisor.Controllers.Api
{
    public class CitiesController : ApiController
    {
        private ApplicationDbContext _context;

        public CitiesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/cities
        public IHttpActionResult GetCities()
        {
            var cities = _context.Cities.ToList();

            return Ok(cities);
        }

        // GET api/cities/1
        public IHttpActionResult GetCity(int id)
        {
            var city = _context.Cities.SingleOrDefault(c => c.Id == id);

            if (city == null)
                return NotFound();

            return Ok(city);
        }

        // POST api/cities
        [HttpPost]
        public IHttpActionResult CreateCity(City city)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Cities.Add(city);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + city.Id), city);
        }

        // PUT api/cities/1
        [HttpPut]
        public IHttpActionResult UpdateCity(int id, City city)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cityInDb = _context.Cities.SingleOrDefault(c => c.Id == id);

            if (cityInDb == null)
                return NotFound();

            cityInDb.Name = city.Name;
            cityInDb.Description = city.Description;
            cityInDb.Latitude = city.Latitude;
            cityInDb.Longitude = city.Longitude;

            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/cities/1
        [HttpDelete]
        public IHttpActionResult DeleteCity(int id)
        {
            var city = _context.Cities.SingleOrDefault(c => c.Id == id);

            if (city == null)
                return NotFound();

            _context.Cities.Remove(city);
            _context.SaveChanges();

            return Ok();
        }
    }
}
