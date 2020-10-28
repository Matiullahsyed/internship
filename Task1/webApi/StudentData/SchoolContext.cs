using StudentModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StudentData
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("name=student")
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public virtual decimal AddStudentUsingSp(Student student)
        {
            var new_Name = new SqlParameter("@Name", student.Name);
            var new_Email = new SqlParameter("@Email", student.Email);
            var new_Conatct = new SqlParameter("@Contact", student.Contact);
            var new_Password = new SqlParameter("@Password", student.Password);
            var new_ConfirmPassword = new SqlParameter("@ConfirmPassword", student.ConfirmPassword);
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<decimal>("spAddStudent @Name, @Email, @Contact, @Password, @ConfirmPassword", new_Name, new_Email, new_Conatct, new_Password, new_ConfirmPassword).First();
        }
        public virtual decimal AddStudentCourseUsingSp(StudentCourse studentCourse)
        {
            var new_StudentId = new SqlParameter("@StudentId", studentCourse.StudentId);
            var new_CourseId = new SqlParameter("@CourseId", Convert.ToInt32(studentCourse.CourseId));
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<decimal>("spAddStudentCourse @StudentId,@CourseId", new_StudentId, new_CourseId).First();
        }
    }
}

