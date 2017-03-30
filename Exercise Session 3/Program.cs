using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_Session_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintNamesByDifferentLoops();


            List<int> names = new List<int> { 1, 3, 4, 5, 6, 7, 8, 13, 15 };
            //PrintNumbersByDifferentLoops(names);
            //Console.WriteLine(PrintSumFromList(names));
            //PrintOddNumbers(names);
            //Console.WriteLine(PrintLargestNumber(names));
            //Console.WriteLine(PrintSmallestNumber(names));
            //Console.WriteLine(PrintAverageNumber(names));
            PrintByDescending(names);

            Console.ReadKey();
        }
        /// <summary>
        /// Print names by different loops
        /// </summary>
        private static void PrintNamesByDifferentLoops()
        {
            string[] names = { "Bob", "Mary", "Joe", "Sue", "John", "Nancy" };
            //Print names by using for loops
            Console.WriteLine("Print names by using for loops");
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }

            //Print names by using while loops
            Console.WriteLine("Print names by using while loops");
            int j = 0;
            while (j < names.Length)
            {
                Console.WriteLine(names[j]);
                j++;
            }

            //Print names by using foreach loops
            Console.WriteLine("Print names by using foreach loops");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        /// <summary>
        /// Print each number by different loops
        /// </summary>
        private static void PrintNumbersByDifferentLoops(List<int> names)
        {
            //List<int> names = new List<int> { 1, 3, 4, 5, 6, 7, 8, 13, 15 };
            //For loops
            Console.WriteLine("Use for loops");
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }

            //while loops
            Console.WriteLine("Use while loops");
            int j = 0;
            while (j < names.Count)
            {
                Console.WriteLine(names[j]);
                j++;
            }

            //foreach loops
            Console.WriteLine("use foreach loops");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        /// <summary>
        /// Print the total of the list of numbers
        /// </summary>
        /// <param name="lists">List<int></int></param>
        /// <returns>int</returns>
        private static int PrintSumFromList(List<int> lists)
        {
            int sum = 0;
            foreach (var item in lists)
            {
                sum += item;
            }
            return sum;
        }

        /// <summary>
        /// Print the numbers from the list where the number's can't be divided by 2
        /// </summary>
        /// <param name="lists"></param>
        private static void PrintOddNumbers(List<int> lists)
        {
            foreach (var item in lists)
            {
                if (item % 2 != 0)
                {
                    Console.WriteLine(item);
                }
            }
        }

        /// <summary>
        /// Print the largest number from the list
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        private static int PrintLargestNumber(List<int> lists)
        {
            int n = lists[0];
            foreach (var item in lists)
            {
                if (item > n)
                {
                    n = item;
                }
            }
            return n;
        }

        /// <summary>
        /// Print the smallest number from the list
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        private static int PrintSmallestNumber(List<int> lists)
        {
            int a = lists[0];
            foreach (var item in lists)
            {
                if (item < a)
                {
                    a = item;
                }
            }
            return a;
        }

        /// <summary>
        /// Print the average value from the list of numbers
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        private static double PrintAverageNumber(List<int> lists)
        {
            return lists.Average();
        }

        /// <summary>
        /// Print the numbers from the list using order by descending
        /// </summary>
        /// <param name="lists"></param>
        private static void PrintByDescending(List<int> lists)
        {
            lists.OrderByDescending(x => x);
            //lists.Reverse();
            foreach (var item in lists)
            {
                Console.WriteLine(item);
            }
        }
    }
}
