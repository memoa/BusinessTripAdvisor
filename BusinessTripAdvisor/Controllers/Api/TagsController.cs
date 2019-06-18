using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessTripAdvisor.Models;

namespace BusinessTripAdvisor.Controllers.Api
{
    public class TagsController : ApiController
    {
        private ApplicationDbContext _context;

        public TagsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/tags
        public IHttpActionResult GetTags()
        {
            var tags = _context.Tags.ToList();

            return Ok(tags);
        } 
    }
}
