using StudentData;
using StudentModels;
using StudentRepositry;
using StudentRepositry.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class StudentController : Controller
    { 
        StudentRepository studentrepo = new StudentRepository(new SchoolContext());
        CourseRepositry courserepo = new CourseRepositry(new SchoolContext());
        public ActionResult Index()
        {
            var sudents = studentrepo.GetStudent();
            return View("ListOfStudent",sudents);
        }

        public ActionResult StudentForm()
        {
            return View("StudentForm");
        }
        [HttpGet]
        public ActionResult AddCourse()
        {
            var courses = courserepo.GetAll();
            return View("StudentForm", courses);
        }
        [HttpPost]
        public ActionResult AddStudent(StudentPostDto student)
        {
            studentrepo.AddStudent(student);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditStudentRecord(int id)
        {
           var student= studentrepo.GetStudentById(id);

            return View("EditStudentRecord",student);
        }
        [HttpPost]
        public ActionResult UpdateStudentRecord(StudentPostDto studentPost)
        {
            studentrepo.UpdateStudent(studentPost);
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public ActionResult DeletStudentRecord(int id)
        {
            studentrepo.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}