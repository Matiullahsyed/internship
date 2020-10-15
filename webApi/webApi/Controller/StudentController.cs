using Newtonsoft.Json;
using StudentData;
using StudentModels;
using StudentRepositry;
using StudentRepositry.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controller
{
    public class StudentController : ApiController
    {

        StudentRepository service = new StudentRepository(new SchoolContext());
        CourseRepositry servicecourse = new CourseRepositry(new SchoolContext());

        // GET/webApi/Students
        [HttpGet]
        public IHttpActionResult GetStudents()
        {
            var students = service.GetStudent();
           
            if (students == null) return NotFound();
            return Ok(students);
        }
        // GET/webApi/Students/id
        [HttpGet]
        public IHttpActionResult GetStudent(int id)
        {
            var student = service.GetStudentById(id);

            if (student == null) return NotFound();
            return Ok(student);

        }


        // POST/webApi/Students/StudentObjet
        [HttpPost]
        public IHttpActionResult PostStudent(StudentPostDto student)
        {
           
            if (student == null) return BadRequest();
            service.AddStudent(student);
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
