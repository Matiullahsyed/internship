using StudentData;
using StudentModels;
using StudentRepositry.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            using (var context = new SchoolContext())
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
                                AllCourses= (from c in db.Courses
                                select new CourseDto()
                             {
                                CourseId = c.CourseId,
                                Name = c.Name
                                }).ToList(),
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
        public bool UpdateStudent(StudentPostDto studentPost)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Student std = new Student();
                std.Id = studentPost.Id;
                std.Name = studentPost.Name;
                std.Email = studentPost.Email;
                std.Contact = studentPost.Contact;
                std.Password = studentPost.Password;
                std.ConfirmPassword = studentPost.ConfirmPassword;
                db.Entry(std).State = EntityState.Modified;
                var stdPreCourses = db.StudentCourses.Where(x => x.StudentId == studentPost.Id).ToList();
                if (stdPreCourses != null)
                {
                    db.StudentCourses.RemoveRange(stdPreCourses);
                    db.SaveChanges();
                    List<StudentCourse> courseList = new List<StudentCourse>();
                    if (studentPost.CoursesList != null)
                    {
                        foreach (var Course in studentPost.CoursesList)
                        {
                            StudentCourse course_Obj = new StudentCourse();
                            course_Obj.StudentId = studentPost.Id;
                            course_Obj.CourseId = Convert.ToInt32(Course);
                            courseList.Add(course_Obj);
                            course_Obj.CourseId = Convert.ToInt32(Course);
                            courseList.Add(course_Obj);
                        }
                        db.StudentCourses.AddRange(courseList);
                        db.SaveChanges(); 
                    }
                }
            }
            return true;
        }
        public bool DeleteStudent(int id)
        {
             Delete(id);
            return false;
        }
        public List<StudentPostDto> GetAllStudents(Pager pager)
        {
            List<Pager> StudentList = new List<Pager>();
            try
            {
                using (SchoolContext db = new SchoolContext())
                {
                    var students = (from s in db.Students
                                     select new StudentPostDto()
                                     {
                                         Id = s.Id,
                                         Name = s.Name,
                                         Email = s.Email,
                                         Contact = s.Contact,
                                         Password = s.Password,
                                         ConfirmPassword = s.ConfirmPassword,
                                         CoursesCount = db.StudentCourses.Where(sc => sc.Id == s.Id).Count(),
                                     }).OrderBy(x => x.Id).Skip(pager.start).Take(pager.length).ToList();
                    students[0].TotalRecord = db.Students.Count();
                    return students;
                }
            }

            catch (Exception)
            {
                return null;
            }

        }
    }
        }
    

