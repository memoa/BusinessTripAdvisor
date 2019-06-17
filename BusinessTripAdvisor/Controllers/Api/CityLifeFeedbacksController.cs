using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BusinessTripAdvisor.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using BusinessTripAdvisor.ViewModels;


namespace BusinessTripAdvisor.Controllers.Api
{
    public class CityLifeFeedbacksController : ApiController
    {
        private ApplicationDbContext _context;

        public CityLifeFeedbacksController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/cityLifeFeedbacks
        public IHttpActionResult GetCityLifeFeedbacks()
        {
            var citiesInDb = _context.Cities.ToList();
            var tagsInDb = _context.Tags.ToList();

            var usersInDb = _context.Users.ToList();
            var userVMs = new List<UserViewModel>();
            foreach(var user in usersInDb)
            {
                var userVM = new UserViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
                userVMs.Add(userVM);
            }

            var cityLifeFeedbacks = _context.CityLIfeFeedbacks.ToList();

            var cityLifeFeedbackVMs = new List<CityLifeFeedbackViewModel>();

            foreach(var cityLifeFeedback in cityLifeFeedbacks)
            {
                var cityLifeFeedbackVM = new CityLifeFeedbackViewModel
                {
                    Id = cityLifeFeedback.Id,
                    City = citiesInDb.SingleOrDefault(c => c.Id == cityLifeFeedback.CityId),
                    Time = cityLifeFeedback.Time,
                    Rating = cityLifeFeedback.Rating,
                    Title = cityLifeFeedback.Title,
                    Comment = cityLifeFeedback.Comment,
                    User = userVMs.SingleOrDefault(u => u.Id == cityLifeFeedback.AspNetUserId),
                    Tag = tagsInDb.SingleOrDefault(t => t.Id == cityLifeFeedback.TagId),
                    Latitude = cityLifeFeedback.Latitude,
                    Longitude = cityLifeFeedback.Longitude
                };
                cityLifeFeedbackVMs.Add(cityLifeFeedbackVM);
            }

            return Ok(cityLifeFeedbackVMs);
        }

        // GET api/cityLifeFeedbacks/1
        public IHttpActionResult GetCityLifeFeedback(int id)
        {
            var cityLifeFeedback = _context.CityLIfeFeedbacks.SingleOrDefault(c => c.Id == id);

            if (cityLifeFeedback == null)
                return NotFound();

            return Ok(cityLifeFeedback);
        }

        // POST api/cityLifeFeedbacks
        [HttpPost]
        public IHttpActionResult CreateCityLifeFeedback(CityLIfeFeedback cityLifeFeedback)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.CityLIfeFeedbacks.Add(cityLifeFeedback);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + cityLifeFeedback.Id), cityLifeFeedback);
        }

        // PUT api/cityLifeFeedbacks/1
        [HttpPut]
        public IHttpActionResult UpdateCityLifeFeedback(int id, CityLIfeFeedback cityLifeFeedback)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cityLifeFeedbackInDb = _context.CityLIfeFeedbacks.SingleOrDefault(c => c.Id == id);

            if (cityLifeFeedbackInDb == null)
                return NotFound();

            cityLifeFeedbackInDb.CityId = cityLifeFeedback.CityId;
            cityLifeFeedbackInDb.Time = cityLifeFeedback.Time;
            cityLifeFeedbackInDb.Rating = cityLifeFeedback.Rating;
            cityLifeFeedbackInDb.Title = cityLifeFeedback.Title;
            cityLifeFeedbackInDb.Comment = cityLifeFeedback.Comment;
            cityLifeFeedbackInDb.AspNetUserId = cityLifeFeedback.AspNetUserId;
            cityLifeFeedbackInDb.TagId = cityLifeFeedback.TagId;
            cityLifeFeedbackInDb.Latitude = cityLifeFeedback.Latitude;
            cityLifeFeedbackInDb.Longitude = cityLifeFeedback.Longitude;

            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/cityLifeFeedbacks/1
        [HttpDelete]
        public IHttpActionResult DeleteCityLifeFeedback(int id)
        {
            var cityLifeFeedback = _context.CityLIfeFeedbacks.SingleOrDefault(c => c.Id == id);

            if (cityLifeFeedback == null)
                return NotFound();

            _context.CityLIfeFeedbacks.Remove(cityLifeFeedback);
            _context.SaveChanges();

            return Ok();
        }
    }
}
