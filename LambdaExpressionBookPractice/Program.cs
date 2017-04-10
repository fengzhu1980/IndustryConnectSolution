using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressionBookPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            BookRepository br = new BookRepository();
            var books = br.GetBooks();

            ////Linq
            //var book = from b in books
            //           where b.Price > 10
            //           select b;
            //Lambda
            var book = books.Where(b => b.Price > 5);

            foreach (var item in book)
            {
                Console.WriteLine("Isbn={0}",item.Isbn);
                Console.WriteLine("Price={0}", item.Price);
                Console.WriteLine("Title={0}", item.Title);
            }

            Console.ReadKey();
        }
    }
}
