namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystemDbContext context)
        {

            for (int i = 0; i < 1; i++)
            {
                var student = new Student()
                {
                    FirstName = "Pesho" + i,
                    LastName = "Ivanov"
                };

                var course = new Course()
                {
                    Name = "Physics",
                };

                var homework = new Homework()
                {
                    DeadLine = DateTime.Now,
                    StudentId = student.Id,
                    CourseId = course.Id
                };


                context.Students.Add(student);
                context.Courses.Add(course);
                context.Homeworks.Add(homework);
                context.SaveChanges();
                
            }





            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
