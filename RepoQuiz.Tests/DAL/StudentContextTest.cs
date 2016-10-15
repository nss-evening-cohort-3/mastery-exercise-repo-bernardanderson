using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RepoQuiz.DAL;
using RepoQuiz.Models;

namespace RepoQuiz.Tests.DAL
{
    [TestClass]
    public class StudentContextTest
    {
        // Start of setup of mock
        Mock<StudentContext> mock_context { get; set; }
        Mock<DbSet<Student>> mock_student_table { get; set; }
        List<Student> student_list { get; set; } // May not need this
        StudentRepository repo { get; set; }

        List<Student> populatedStudentList = new List<Student>()
            {
                new Student
                {
                    StudentID = 1,
                    FirstName = "Billy",
                    LastName = "Joel",
                    Major = "Music"
                },
                new Student
                {
                    StudentID = 2,
                    FirstName = "David",
                    LastName = "Gahan",
                    Major = "Music"
                }
            };

        public void ConnectMocksToDatastore()
        {
            var queryable_list = student_list.AsQueryable();

            mock_student_table.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(queryable_list.Provider);
            mock_student_table.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(queryable_list.Expression);
            mock_student_table.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(queryable_list.ElementType);
            mock_student_table.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(() => queryable_list.GetEnumerator());

            mock_context.Setup(c => c.Students).Returns(mock_student_table.Object);

            mock_student_table.Setup(t => t.Add(It.IsAny<Student>())).Callback((Student a) => student_list.Add(a));
            //mock_student_table.Setup(t => t.Remove(It.IsAny<Student>())).Callback((Student a) => student_list.Remove(a));
        }

        [TestInitialize]
        public void Initialize()
        {
            // Create Mock BlogContext
            mock_context = new Mock<StudentContext>();
            mock_student_table = new Mock<DbSet<Student>>();
            student_list = new List<Student>(); 
            repo = new StudentRepository(mock_context.Object);

            ConnectMocksToDatastore();
        }

        [TestCleanup]
        public void TearDown()
        {
            repo = null; // Clears the repo 
        }
        // End of Setup of Mock

        [TestMethod]
        public void Repo_CanICreateAnInstanceOfTheRepo()
        {
            StudentRepository repo = new StudentRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void Repo_DoesTheRepoHaveContext()
        {
            StudentRepository repo = new StudentRepository();
            StudentContext actual_context = repo.Context;
            Assert.IsInstanceOfType(actual_context, typeof(StudentContext));
        }

        [TestMethod]
        public void Repo_IsTheRepoEmptyOfStudents()
        {
            // Act
            List<Student> actual_students = repo.GetAllStudents();
            int expected_student_count = 0;
            int actual_student_count = actual_students.Count;

            // Assert
            Assert.AreEqual(expected_student_count, actual_student_count);
        }

        [TestMethod]
        public void Repo_CanStudentsBeAdded_CheckedViaCount()
        {
            // Act
            int expected_student_count = populatedStudentList.Count;
            int actual_student_count = repo.AddStudents(populatedStudentList).Count;

            // Assert
            Assert.AreEqual(expected_student_count, actual_student_count);
        }

        [TestMethod]
        public void Repo_CanStudentsBeAdded_CheckedViaFirstName()
        {
            // Act
            List<Student> studentListReturned = repo.AddStudents(populatedStudentList);

            // Assert
            Assert.IsTrue(studentListReturned[0].FirstName == "Billy");
            Assert.IsTrue(studentListReturned[1].FirstName == "David");
        }

        [TestMethod]
        public void Repo_CanStudentsBeGotten_CheckedViaCount()
        {
            // Act
            repo.AddStudents(populatedStudentList);
            int expected_student_count = populatedStudentList.Count;
            int actual_student_count = repo.GetAllStudents().Count;

            // Assert
            Assert.AreEqual(expected_student_count, actual_student_count);
        }

        [TestMethod]
        public void Repo_CanStudentsGotten_CheckedViaFirstName()
        {
            // Act
            repo.AddStudents(populatedStudentList);
            List<Student> studentListReturned = repo.GetAllStudents();

            // Assert
            Assert.IsTrue(studentListReturned[0].FirstName == "Billy");
            Assert.IsTrue(studentListReturned[1].FirstName == "David");
        }
    }
}
