using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoQuiz.DAL;
using RepoQuiz.Models;

namespace RepoQuiz.Tests.DAL
{
    [TestClass]
    public class NameGeneratorTests
    {
        [TestMethod]
        public void NameGen_CanICreateAnInstanceOfTheClass()
        {
            NameGenerator nameGen = new NameGenerator();
            Assert.IsNotNull(nameGen);
        }

        [TestMethod]
        public void NameGen_CanIGetFiftyRandomStudents()
        {
            // Act
            NameGenerator nameGen = new NameGenerator();
            List<Student> actual_students = nameGen.GenerateRandomStudentList(50);
            int expected_student_count = 50;
            int actual_student_count = actual_students.Count;

            // Assert
            Assert.AreEqual(expected_student_count, actual_student_count);
        }

        [TestMethod]
        public void NameGen_AreAllRandomNamesUnique()
        {
            // Act
            NameGenerator nameGen = new NameGenerator();
            List<Student> actual_students = nameGen.GenerateRandomStudentList(50);

            // Assert
            CollectionAssert.AllItemsAreUnique(actual_students);
        }
    }
}
