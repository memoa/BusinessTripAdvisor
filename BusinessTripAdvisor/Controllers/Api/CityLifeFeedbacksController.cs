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


namespace BusinessTripAdvisor.Controllers.Api
{
    public class CityLifeFeedbacksController : ApiController
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CityLifeFeedbacksController()
        {
            _context = new ApplicationDbContext();
            //_userManager = userManager;
            //_signInManager = new ApplicationSignInManager();
        }

        // GET api/cityLifeFeedbacks
        public IHttpActionResult GetCityLifeFeedbacks()
        {
            var cityLifeFeedbacks = _context.CityLIfeFeedbacks.ToList();

            return Ok(cityLifeFeedbacks);
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
            cityLifeFeedback.Time = DateTime.Now;

            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.ToList()[0].Errors[0].ErrorMessage);

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
