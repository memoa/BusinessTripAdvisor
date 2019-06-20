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
using System.Data.Entity;


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
            /*
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
            */
            var cityLifeFeedbacks = _context.CityLIfeFeedbacks
                .Include(f => f.City)
                .Include(f => f.AspNetUser)
                .Include(f => f.Tag)
                .ToList();

            var cityLifeFeedbackVMs = new List<CityLifeFeedbackViewModel>();

            foreach(var cityLifeFeedback in cityLifeFeedbacks)
            {
                var cityLifeFeedbackVM = new CityLifeFeedbackViewModel
                {
                    Id = cityLifeFeedback.Id,
                    City = cityLifeFeedback.City,
                    Time = cityLifeFeedback.Time,
                    Rating = cityLifeFeedback.Rating,
                    Title = cityLifeFeedback.Title,
                    Comment = cityLifeFeedback.Comment,
                    User = new UserViewModel {
                        Id = cityLifeFeedback.AspNetUser.Id,
                        FirstName = cityLifeFeedback.AspNetUser.FirstName,
                        LastName = cityLifeFeedback.AspNetUser.LastName
                    },
                    Tag = cityLifeFeedback.Tag,
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
            var cityLifeFeedback = _context.CityLIfeFeedbacks
                .Include(f => f.City)
                .Include(f => f.AspNetUser)
                .Include(f => f.Tag)
                .SingleOrDefault(c => c.Id == id);

            if (cityLifeFeedback == null)
                return NotFound();

            var cityLifeFeedbackVM = new CityLifeFeedbackViewModel
            {
                Id = cityLifeFeedback.Id,
                City = cityLifeFeedback.City,
                Time = cityLifeFeedback.Time,
                Rating = cityLifeFeedback.Rating,
                Title = cityLifeFeedback.Title,
                Comment = cityLifeFeedback.Comment,
                User = new UserViewModel
                {
                    Id = cityLifeFeedback.AspNetUser.Id,
                    FirstName = cityLifeFeedback.AspNetUser.FirstName,
                    LastName = cityLifeFeedback.AspNetUser.LastName
                },
                Tag = cityLifeFeedback.Tag,
                Latitude = cityLifeFeedback.Latitude,
                Longitude = cityLifeFeedback.Longitude
            };

            return Ok(cityLifeFeedbackVM);
        }

        // POST api/cityLifeFeedbacks
        [HttpPost]
        public IHttpActionResult CreateCityLifeFeedback(CityLIfeFeedback cityLifeFeedback)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (_context.Cities.SingleOrDefault(c => c.Id == cityLifeFeedback.CityId) == null)
                return BadRequest();
            if (_context.Users.SingleOrDefault(u => u.Id == cityLifeFeedback.AspNetUserId) == null)
                return BadRequest();
            if (_context.Tags.SingleOrDefault(t => t.Id == cityLifeFeedback.TagId) == null)
                return BadRequest();

            _context.CityLIfeFeedbacks.Add(cityLifeFeedback);
            _context.SaveChanges();

            var cityLifeFeedbackVM = new CityLifeFeedbackViewModel
            {
                Id = cityLifeFeedback.Id,
                City = cityLifeFeedback.City,
                Time = cityLifeFeedback.Time,
                Rating = cityLifeFeedback.Rating,
                Title = cityLifeFeedback.Title,
                Comment = cityLifeFeedback.Comment,
                User = new UserViewModel
                {
                    Id = cityLifeFeedback.AspNetUser.Id,
                    FirstName = cityLifeFeedback.AspNetUser.FirstName,
                    LastName = cityLifeFeedback.AspNetUser.LastName
                },
                Tag = cityLifeFeedback.Tag,
                Latitude = cityLifeFeedback.Latitude,
                Longitude = cityLifeFeedback.Longitude
            };

            return Created(new Uri(Request.RequestUri + "/" + cityLifeFeedbackVM.Id), cityLifeFeedbackVM);
        }

        // PUT api/cityLifeFeedbacks/1
        [HttpPut]
        public IHttpActionResult UpdateCityLifeFeedback(int id, CityLIfeFeedback cityLifeFeedback)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (_context.Cities.SingleOrDefault(c => c.Id == cityLifeFeedback.CityId) == null)
                return BadRequest();
            if (_context.Users.SingleOrDefault(u => u.Id == cityLifeFeedback.AspNetUserId) == null)
                return BadRequest();
            if (_context.Tags.SingleOrDefault(t => t.Id == cityLifeFeedback.TagId) == null)
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

            var cityLifeFeedbackVM = new CityLifeFeedbackViewModel
            {
                Id = cityLifeFeedbackInDb.Id,
                City = cityLifeFeedbackInDb.City,
                Time = cityLifeFeedbackInDb.Time,
                Rating = cityLifeFeedbackInDb.Rating,
                Title = cityLifeFeedbackInDb.Title,
                Comment = cityLifeFeedbackInDb.Comment,
                User = new UserViewModel
                {
                    Id = cityLifeFeedbackInDb.AspNetUser.Id,
                    FirstName = cityLifeFeedbackInDb.AspNetUser.FirstName,
                    LastName = cityLifeFeedbackInDb.AspNetUser.LastName
                },
                Tag = cityLifeFeedbackInDb.Tag,
                Latitude = cityLifeFeedbackInDb.Latitude,
                Longitude = cityLifeFeedbackInDb.Longitude
            };

            return Ok(cityLifeFeedbackInDb);
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
