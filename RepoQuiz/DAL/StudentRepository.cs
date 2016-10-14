using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepoQuiz.Models;

namespace RepoQuiz.DAL
{
    public class StudentRepository
    {
        public StudentContext Context { get; set; }

        public StudentRepository()
        {
            Context = new StudentContext();
        }

        public StudentRepository(StudentContext _context)
        {
            Context = _context;
        }

        // Gets the Student table, adds them to the Student "object" and adds each "object" to a List<>
        virtual public List<Student> GetAllStudents()
        {
            var StudentTable = Context.Students;

            List<Student> ListOfStudents = new List<Student>();

            foreach (var student in StudentTable)
            {
                ListOfStudents.Add( new Student()
                {
                    StudentID = student.StudentID,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Major = student.Major
                });
            }
            return ListOfStudents;
        }



    }
}