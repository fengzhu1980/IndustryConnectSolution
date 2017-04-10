using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Exercise_updated
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize students
            List<Student> students = new StudentRepository().GetStudents();

            //4. Use FindAll and Lambda Expressions to display all students with 
            //their first name starting with the character "T"
            GetStudentsFirstNameT(students);

            //5. Use FindAll and Lambda Expressions to display students with 
            //the highest individual score.
            //GetStudentsHighestScore(students);

            //6. Use FindAll and Lambda Expressions to display students with 
            //the highest total score.
            //GetStudentHighestTotalScore(students);

            Console.ReadKey();
        }

        /// <summary>
        /// Display student with the highest total score
        /// </summary>
        /// <param name="students">Student List</param>
        private static void GetStudentHighestTotalScore(List<Student> students)
        {
            var highestSum = students[0].Scores.Sum();
            Student student = new Student();
            //var student = students.FindAll(s => (s.Scores.Sum() > highestSum));

            foreach (var s in students)
            {
                if (s.Scores.Sum() > highestSum)
                {
                    highestSum = s.Scores.Sum();
                    student = s;
                }
            }
            Console.WriteLine("Student ID: " + student.ID);
            Console.WriteLine("Student first name: " + student.First);
            Console.WriteLine("Total score: " + student.Scores.Sum());
        }

        /// <summary>
        /// Get each student's highest individual score
        /// </summary>
        /// <param name="students">Student List</param>
        private static void GetStudentsHighestScore(List<Student> students)
        {
            //var highestScore = students[0].Scores.Max();
            //Get each student's highest individual score
            //var student = students.FindAll(s => (s.Scores.Max());
            foreach (var s in students)
            {
                Console.WriteLine("Student ID: {0}", s.ID);
                Console.WriteLine("Student first name: {0}", s.First);
                Console.WriteLine("Highest score is: {0}", s.Scores.Max());
            }
        }

        /// <summary>
        /// Students first name starting with the character "T"
        /// </summary>
        /// <param name="students">Student List</param>
        private static void GetStudentsFirstNameT(List<Student> students)
        {
            //Students first name starting with the character "T"
            //Lambda expression
            //var student = students.FindAll(s => s.First[0].ToString() == "T");
            //LINQ to Object
            var st = from s in students
                          where s.First[0].ToString() == "T"
                          select s;
            List<Student> student = st.ToList();

            //Output
            foreach (var s in student)
            {
                Console.WriteLine("Student ID: " + s.ID);
                Console.WriteLine("Student first name: " + s.First);
            }
        }
    }
}
