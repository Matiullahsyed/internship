namespace StudentData.Migrations
{
    using StudentModels;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentData.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StudentData.SchoolContext context)
        {
            if (!context.Courses.Any())
            {
                context.Courses.AddRange(new List<Course>{
                    new Course { Name="Ajax"},
                    new Course { Name = "jQuery" },
                    new Course { Name = "Java" },
                });
                context.SaveChanges();
            }
        }
    }
}
