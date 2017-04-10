using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePhotoPractice
{
    public class PhotoProcessor
    {
        public delegate void PhotoFilterHandler(Photo photo);

        public void Process(string path, PhotoFilterHandler photoFilterHandler)
        {
            var photo = Photo.Load(path);
            Console.WriteLine("Processing photo {0}......",path);
            photoFilterHandler(photo);
            photo.Save();
        }
    }
}
