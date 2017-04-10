using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePhotoPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();
            PhotoProcessor.PhotoFilterHandler photoFilter = filters.ApplyBrightness;
            photoFilter += filters.ApplyContrast;
            photoFilter += filters.RemoveRedEye;
            photoFilter += filters.Resize;
            photoFilter += CustomerFilter;  

            processor.Process("photo.jpg", photoFilter);
            Console.ReadKey();
        }

        static void CustomerFilter(Photo photo)
        {
            Console.WriteLine("Customer filter");
        }
    }
}
