using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData
{
  public  class SchoolContext:DbContext
    {
        public SchoolContext() : base("name=student")
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
