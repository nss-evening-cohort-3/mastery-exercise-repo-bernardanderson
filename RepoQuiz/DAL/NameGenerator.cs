using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepoQuiz.Models;

namespace RepoQuiz.DAL
{
    public class NameGenerator
    {
        private List<string> PossibleFirstNames = new List<string>
        {
            "Jim", "Bob", "Fred", "Bill", "Joe", "Curly", "Susan", "Heather", "Jackie", "Chase", "Gerdie", "Nancy"
        };

        private List<string> PossibleLastNames = new List<string>
        {
            "Andrews", "Bracken", "Ford", "Jackson", "Harley", "Martinson", "Worthington", "Johnson", "Rothchild", "Vanderbilt", "Evans", "Potter"
        };

        private List<string> PossibleMajors = new List<string>
        {
            "English", "Chemistry", "Biology", "Physics", "Math", "Philosophy", "Psychology", "Music", "Art", "Law", "Political Science", "Pre-Med"
        };

        public List<Student> GenerateRandomStudentList()
        {
            List<Student> StudentList = new List<Student>();
            Random RandomNumber = new Random();

            while (StudentList.Count < 10 )
            {
                Student RandomStudent = new Student()
                {
                    FirstName = PossibleFirstNames[RandomNumber.Next(0, PossibleFirstNames.Count)],  
                    LastName = PossibleLastNames[RandomNumber.Next(0, PossibleLastNames.Count)],
                    Major = PossibleMajors[RandomNumber.Next(0, PossibleMajors.Count)]
                };

                if (!StudentList.Contains(RandomStudent))
                {
                    StudentList.Add(RandomStudent);
                }
            }
            return StudentList;
        }
    }
}