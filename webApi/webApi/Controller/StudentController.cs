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

        StudentServices service = new StudentServices(new SchoolContext());

        // POST/webApi/Students
        [HttpGet]
        public IHttpActionResult GetStudents()
        {
            var students = service.GetAll();
            if (students == null) return NotFound();
            return Ok(students);
        }

        

        // POST/webApi/Students/StudentObjet
        [HttpPost]
        public IHttpActionResult PostStudent(Student student)
        {

            if (student == null) return BadRequest();
            service.Post(student);
            return Ok("Student has been Added");
            
        }

        // DELET/webApi/Students/1
        [HttpDelete]
        public IHttpActionResult DeleteStudent(int id)
        {
            service.Delete(id);
            return Ok(" Student has been Deleted");
        }

        // PUT/webApi/Students
        [HttpPut]
        public IHttpActionResult UpdateStudent(Student student)
        {
            if (student == null) return BadRequest();
            service.Update(student);
            return Ok("Student has been updateds");
        }


    }
}
