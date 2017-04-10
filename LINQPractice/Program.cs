using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new StudentRepository().GetStudents();

            ////LINQ
            //var student = from s in students
            //              where s.ID > 115
            //              select s;

            ////LINQ Lambda
            //var student = students.Where(s => s.ID > 115);

            //Lambda
            var student = students.FindAll(s => s.First[0].ToString() == "S");

            foreach (var item in student)
            {
                Console.WriteLine("ID=" + item.ID);
                Console.WriteLine("First name=" + item.First);
            }

            Console.ReadKey();
        }
    }
}
