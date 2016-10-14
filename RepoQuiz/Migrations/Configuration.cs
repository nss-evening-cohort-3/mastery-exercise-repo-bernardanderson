namespace RepoQuiz.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using DAL;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StudentContext context)
        {
            NameGenerator SeedNameGenerator = new NameGenerator();
            List<Student> StudentList = SeedNameGenerator.GenerateRandomStudentList();

            foreach (var student in StudentList)
            {
                context.Students.AddOrUpdate(
                    new Student { FirstName = student.FirstName, LastName = student.LastName, Major = student.Major}
                );
            }
        }
    }
}
