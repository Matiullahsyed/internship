using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModels
{
   public class StudentCourse
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course_object { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student_Object { get; set; }
    }
}
