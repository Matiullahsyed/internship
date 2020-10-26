using StudentData;
using StudentModels;
using StudentRepositry;
using StudentRepositry.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
namespace MVC.Controllers
{
    public class StudentController : Controller
    {
        StudentRepository studentrepo = new StudentRepository(new SchoolContext());
        CourseRepositry courserepo = new CourseRepositry(new SchoolContext());
        public ActionResult Index()
        {
            var sudents = studentrepo.GetStudent();
            return Json(sudents, JsonRequestBehavior.AllowGet);
        }
        public ActionResult StudentList()
        {
            return View("ListOfStudent");
        }
        public ActionResult StudentForm()
        {
            return RedirectToAction("AddCourse");
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
            return RedirectToAction("StudentList");
        }
        [HttpGet]
        public ActionResult EditStudentRecord(int id)
        {
            var student = studentrepo.GetStudentById(id);

            return View("EditStudentRecord", student);
        }
        [HttpPost]
        public ActionResult UpdateStudentRecord(StudentPostDto studentPost)
        {
            studentrepo.UpdateStudent(studentPost);
            return RedirectToAction("StudentList");
        }
        public ActionResult DeletStudentRecord(int id)
        {
            studentrepo.DeleteStudent(id);
            return RedirectToAction("StudentList");
        }
        [HttpPost]
        public ActionResult LoadData(Pager pager)
        {
            List<StudentPostDto> StudentModel = studentrepo.GetAllStudents(pager);

            return Json(new { draw = pager.draw, recordsFiltered = StudentModel[0].TotalRecord, recordsTotal = StudentModel[0].TotalRecord, data = StudentModel }, JsonRequestBehavior.AllowGet);
        }
    }
}