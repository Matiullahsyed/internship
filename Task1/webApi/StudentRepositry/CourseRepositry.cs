using StudentData;
using StudentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepositry
{
   public class CourseRepositry : BaseRepositry<Course>
    {
        public CourseRepositry(SchoolContext context) : base(context)
        {

        }

    }
}
