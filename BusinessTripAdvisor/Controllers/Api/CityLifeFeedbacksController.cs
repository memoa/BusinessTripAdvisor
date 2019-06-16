using System;
using System.Collections.Generic;
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
            /*
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated == true)
            {
                var auth_users = System.Web.HttpContext.Current.User;
                if (auth_users != null)
                {
                    var userid = Convert.ToInt32(auth_users..UserId);
                }
            }
            */
            //string currentUserId = _userManager. .GetUserId();
            /*
            string currentUserId = SignInManager
                .AuthenticationManager
                .AuthenticationResponseGrant.Identity.GetUserId();
                */
            //ApplicationUser currentUser = _context.Users.FirstOrDefault(x => x.Id == currentUserId);

            //var sysUser = System.Web.HttpContext.Current.User;
            /*
            object httpContext;
            actionContext.Request.Properties.TryGetValue("MS_HttpContext", out httpContext);
            ((HttpContext)context).
            string currentUserId = RequestContext.Principal.Identity.GetUserId();
            */
            var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            cityLifeFeedback.User = _context.Users.FirstOrDefault(x => x.Id == currentUserId);

            if (!ModelState.IsValid)
                //return BadRequest(ModelState.Values.ToList()[0].Errors[0].ErrorMessage);
            return BadRequest(currentUserId.ToString());

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
            cityLifeFeedbackInDb.User = cityLifeFeedback.User;
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
