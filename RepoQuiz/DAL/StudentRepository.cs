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

        virtual public List<Student> GetAllStudents()
        {
            return Context.Students.Select(a => a).ToList();
        }

        virtual public List<Student> AddStudents(List<Student> sentStudentList)
        {
            foreach (var student in sentStudentList)
            {
                Context.Students.Add(new Student
                {
                    StudentID = student.StudentID,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Major = student.Major
                });
            }
            Context.SaveChanges();

            return GetAllStudents();
        }



    }
}