using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO;


namespace ElectronicsStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        //public ImageSource ProductImage => new BitmapImage(new Uri(ImagePath));
        public string ImagePath { get; set; }
    }
}
