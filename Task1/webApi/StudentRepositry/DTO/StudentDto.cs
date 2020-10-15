using StudentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepositry.DTO
{
   public class StudentDto
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Contact { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
      
    }
    public class StudentPostDto:StudentDto
    {
        public Student student { get; set; }
        public List<int> CoursesList { get; set; }
        public int CoursesCount { get; internal set; }
        public List<CourseDto> Courses { get; set; }
    }
    public class CourseDto 
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
    }

}
