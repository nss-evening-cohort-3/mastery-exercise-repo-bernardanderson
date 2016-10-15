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
        [TestMethod]
        public void Context_CanICreateAnInstanceOfTheClass()
        {
            StudentContext testContext = new StudentContext();
            Assert.IsNotNull(testContext);
        }

        [TestMethod]
        public void Context_ContextIsCorrectType()
        {
            StudentContext testContext = new StudentContext();
            Assert.IsInstanceOfType(testContext.Students, typeof(DbSet<Student>));
        }
    }
}
