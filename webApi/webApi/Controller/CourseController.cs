using StudentData;
using StudentRepositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controller
{
    public class CourseController : ApiController
    {
        CourseRepositry service = new CourseRepositry(new SchoolContext());

        [HttpGet]
        public IHttpActionResult GetCourses()
        {
            var courses = service.GetAll();
            if (courses == null) return NotFound();
            return Ok(courses);
        }
    }
}
