using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize students
            var students = new StudentRepository().GetStudents();

            //Display student with highest total score//Q
            GetStudentHighestTotalScore(students);

            //Display students with first name length greater than 10
            //GetStudentFirstNameThan10(students);

            //Display student with total score greater than 270
            //GetStudentTotalScoreThan270(students);

            //Print students with reversed name//Q
            //GetStudentWithReversedName(students);

            //Generate student to a new List object and the object 
            //have FirstName and LastName property
            //GenerateStudentFirstAndLastNameList(students);

            //Print students with First name Descending order
            //GetStudentsWithFirstNameDes(students);

            //Print students with Last name Ascending order
            //GetStudentsLastNameAsc(students);

            Console.ReadKey();
        }

        /// <summary>
        /// Print students with Last name Ascending order
        /// </summary>
        /// <param name="students">Student List</param>
        private static void GetStudentsLastNameAsc(List<Student> students)
        {
            //Lambda
            var student = students.OrderBy(s => s.Last);
            //LINQ
            //var student = from i in students
            //              orderby i.Last ascending
            //              select i;
            foreach (var s in student)
            {
                Console.WriteLine("Student ID: " + s.ID);
                Console.WriteLine("Student last name: " + s.Last);
                Console.WriteLine("Student first name: " + s.First);
            }
        }

        /// <summary>
        /// Print students with First name Descending order
        /// </summary>
        /// <param name="students">Student List</param>
        private static void GetStudentsWithFirstNameDes(List<Student> students)
        {
            //Lambda
            var student = students.OrderByDescending(s => s.First);
            //LINQ
            //var student = from s in students
            //              orderby s.First descending
            //              select s;
            foreach (var s in student)
            {
                Console.WriteLine("Student ID: " + s.ID);
                Console.WriteLine("Student first name: " + s.First);
                Console.WriteLine("Student last name: " + s.Last);
            }
        }

        /// <summary>
        /// Generate student to a new List object and the object have FirstName and LastName property
        /// </summary>
        /// <param name="students">Student List</param>
        private static void GenerateStudentFirstAndLastNameList(List<Student> students)
        {
            //Lambda
            var student = students.Select(t => new { ID = t.ID, First = t.First, Last = t.Last });
            //LINQ
            //var student = from s in students
            //              select new { s.ID, s.First,s.Last };
            foreach (var s in student)
            {
                Console.WriteLine("Student ID: " + s.ID);
                Console.WriteLine("Student first name: " + s.First);
                Console.WriteLine("Student last name: " + s.Last);
            }
        }

        /// <summary>
        /// Print students with reversed name
        /// </summary>
        /// <param name="students">Student List</param>
        private static void GetStudentWithReversedName(List<Student> students)
        {
            foreach (var s in students)
            {
                char[] first = s.First.ToCharArray();
                char[] last = s.Last.ToCharArray();
                Console.WriteLine("Student ID: " + s.ID);
                Console.WriteLine("Student first name: " + new string(first.Reverse().ToArray()));
                Console.WriteLine("Student last name: " + new string(last.Reverse().ToArray()));
            }
        }

        /// <summary>
        /// Display student with total score greater than 270
        /// </summary>
        /// <param name="students">Student List</param>
        private static void GetStudentTotalScoreThan270(List<Student> students)
        {
            //Lambda
            //var student = students.FindAll(s => s.Scores.Sum() > 270);
            //LINQ
            var student = from s in students
                          where s.Scores.Sum() > 270
                          select s;
            foreach (var s in student)
            {
                Console.WriteLine("Student ID: " + s.ID);
                Console.WriteLine("Student first name: " + s.First);
                Console.WriteLine("Student total score: " + s.Scores.Sum());
            }
        }

        /// <summary>
        /// Display students with first name length greater than 10
        /// </summary>
        /// <param name="students">Student List</param>
        private static void GetStudentFirstNameThan10(List<Student> students)
        {
            //Lambda
            //var student = students.FindAll(s => s.First.Length > 10);
            //LINQ
            var student = from s in students
                          where s.First.Length > 10
                          select s;
            foreach (var s in student)
            {
                Console.WriteLine("Student ID: " + s.ID);
                Console.WriteLine("Student first name: " + s.First);
                Console.WriteLine("Student first name length: " + s.First.Length);
            }
        }

        /// <summary>
        /// Display student with highest total score
        /// </summary>
        /// <param name="students"></param>
        private static void GetStudentHighestTotalScore(List<Student> students)
        {
            //var student = students.Select(s => s.Scores.Sum()).Max();
            var student = from s in students
                          where s.Scores.Sum() == students.Max(p => p.Scores.Sum())
                          select s;
            //Console.WriteLine(student);
            foreach (var s in student)
            {
                Console.WriteLine("Student ID: " + s.ID);
                Console.WriteLine("Student first name: " + s.First);
                Console.WriteLine("Total score: " + s.Scores.Sum());
            }
        }
    }
}
