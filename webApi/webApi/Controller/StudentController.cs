using Newtonsoft.Json;
using StudentData;
using StudentRepositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace webApi.Controller
{
    public class StudentController : ApiController
    {

        StudentServices service = new StudentServices();

        // POST/webApi/Students
        [HttpGet]
        public IHttpActionResult GetStudents()
        {
            return Ok(service.GetStudents());
        }

        // GET/webApi/Students/1
        [HttpGet]
        public IHttpActionResult GetStudent(int id)
        {
            return Ok(JsonConvert.SerializeObject(service.GetStudent(id)));
        }

        // POST/webApi/Students/StudentObjet
        [HttpPost]
        public IHttpActionResult PostStudent(Student student)
        {
            service.AddStudent(student);
            return Ok("Student has been Added");
        }

        // DELET/webApi/Students/1
        [HttpDelete]
        public IHttpActionResult DeleteStudent(int id)
        {
            service.DeleteStudent(id);
            return Ok(" Student has been Deleted");
        }

        // PUT/webApi/Students
        [HttpPut]
        public IHttpActionResult UpdateStudent(Student student)
        {
            service.UpdateStudent(student);
            return Ok("Student has been updateds");
        }


    }
}
