namespace RepoQuiz.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StudentContext context)
        {
            NameGenerator SeedNameGenerator = new NameGenerator();

            while (context.Students.Count() < 11)
            {
                Student RandomStudent = new Student();

                RandomStudent = SeedNameGenerator.GenerateRandomStudent();

                context.Students.AddOrUpdate(
                    stu => stu.FirstName,
                    RandomStudent
                    );
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
