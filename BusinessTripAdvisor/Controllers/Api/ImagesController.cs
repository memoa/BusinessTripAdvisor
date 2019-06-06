using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Web;

namespace BusinessTripAdvisor.Controllers.Api
{
    public class ImagesController : ApiController
    {
        // POST api/images
        public IHttpActionResult UploadImage(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine("~/Images", _FileName);
                    file.SaveAs(_path);
                }
                // ViewBag.Message = "File Uploaded Successfully!!";
                return Ok();
            }
            catch
            {
                //ViewBag.Message = "File upload failed!!";
                return BadRequest();
            }
        }
    }
}
