
using StudentData;
using StudentModels;
using StudentRepositry.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepositry
{
  public class StudentRepository : BaseRepositry<Student>
    {
        public StudentRepository(SchoolContext context) : base(context)
        {
          
        }
        public bool AddStudent(StudentPostDto student)
        {
            Student std = new Student();
            std.Name = student.Name;
            std.Email = student.Email;
            std.Contact = student.Contact;
            std.Password = student.Password;
            std.ConfirmPassword = student.ConfirmPassword;
           
            using (var context=new SchoolContext())
            {
                context.Students.Add(std);
                List<StudentCourse> courselist = new List<StudentCourse>();
                foreach (var courseid in student.CoursesList)
                {
                    StudentCourse scourse = new StudentCourse();
                    scourse.StudentId = std.Id;
                    scourse.CourseId = courseid;
                    courselist.Add(scourse);
                }
                context.StudentCourses.AddRange(courselist);
                context.SaveChanges();
                return true;
            }
            
        }

        public StudentPostDto GetStudentById(int id)
        {
            using (SchoolContext db = new SchoolContext())
            {
                var student = (from s in db.Students.Where(x => x.Id == id)
                               select new StudentPostDto()
                               {
                                   student = s,
                                   Courses = (from c in db.Courses
                                             join sc in db.StudentCourses on c.CourseId equals sc.CourseId  where sc.StudentId == id

                                             select new CourseDto()
                                             {
                                                CourseId=sc.CourseId,
                                                Name=c.Name
                                                 
                                             }).ToList()

                               }).FirstOrDefault();
                return student;

            }
        }

        public List<StudentPostDto>  GetStudent()
        {
            using (SchoolContext db = new SchoolContext())
            {
                var students = (from s in db.Students
                                select new StudentPostDto()
                                {
                                    student = s,
                                    CoursesCount = db.StudentCourses.Where(x => x.StudentId == s.Id).Count()

                                }).ToList();
                return students;
              
            }


        }
    }
}
