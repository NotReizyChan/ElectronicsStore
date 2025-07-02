using ElectronicsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Management;




namespace ElectronicsStore.Views
{
    /// <summary>
    /// Логика взаимодействия для ProductsView.xaml
    /// </summary>
    public partial class ProductsView : Page
    {
        private List<Product> _products;
        private string _username;

        public ProductsView(string username)
        {
            InitializeComponent();
            _username = username;
            LoadProducts();
            ProductsItemsControl.ItemsSource = _products;
        }

        //public static int GenerateRandomIntegerPrice()
        //{
        //    return _random.Next(1, 1001);
        //}

        private void LoadProducts()
        {

            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Ноутбук ASUS ROG", Price = 55696.96, ImagePath = "pack://application:,,,/images/laptop.jpg" },
                new Product { Id = 2, Name = "Смартфон iPhone 13", Price = 79900.99, ImagePath = "pack://application:,,,/images/phone.jpg" },
                new Product { Id = 3, Name = "Наушники Sony WH-1000XM4", Price = 349244.98, ImagePath = "pack://application:,,,/images/headphones.jpg" },
                new Product { Id = 4, Name = "Монитор Dell 27", Price = 25500.19, ImagePath = "pack://application:,,,/images/monitor.jpg" },
                new Product { Id = 5, Name = "Клавиатура Logitech MX Keys", Price = 99.99, ImagePath = "pack://application:,,,/images/keyboard.jpg" },
                new Product { Id = 6, Name = "Мышь Razer DeathAdder", Price = 1690.25, ImagePath = "pack://application:,,,/images/mouse.jpg" },
                new Product { Id = 7, Name = "Планшет Samsung Galaxy Tab S7", Price = 64900.11, ImagePath = "pack://application:,,,/images/tablet.jpg" },
                new Product { Id = 8, Name = "Фитнес-браслет Xiaomi Mi Band 6", Price = 1490.10, ImagePath = "pack://application:,,,/images/band.jpg" },
                new Product { Id = 9, Name = "SSD Samsung 980 Pro 1TB", Price = 5490.34, ImagePath = "pack://application:,,,/Images/ssd.jpg" },
                new Product { Id = 10, Name = "Жесткий диск Seagate BarraCuda 2TB", Price = 1690.99, ImagePath = "pack://application:,,,/Images/hdd.jpg", },
                new Product { Id = 11, Name = "Материнская плата ASUS ROG Strix B550-F", Price = 1829.99, ImagePath = "pack://application:,,,/Images/motherboard.jpg", },
                new Product { Id = 12, Name = "Блок питания Corsair RM750x 750W", Price = 12912.49, ImagePath = "pack://application:,,,/Images/psu.jpg",  },
                new Product { Id = 13, Name = "Корпус NZXT H510 Black", Price = 8944.99, ImagePath = "pack://application:,,,/Images/case.jpg", },
                new Product { Id = 14, Name = "Охлаждение CPU Noctua NH-D15", Price = 9125.19, ImagePath = "pack://application:,,,/Images/cooler.jpg",  },
                new Product { Id = 15, Name = "Оперативная память Corsair Vengeance 32GB", Price = 1269.1, ImagePath = "pack://application:,,,/Images/ram.jpg",  },
                new Product { Id = 16, Name = "Веб-камера Logitech C920 HD Pro", Price = 7900.46, ImagePath = "pack://application:,,,/Images/webcam.jpg", },
                new Product { Id = 17, Name = "Микрофон Blue Yeti Blackout", Price = 12976.23, ImagePath = "pack://application:,,,/Images/mic.jpg",  },
                new Product { Id = 18, Name = "Игровой коврик Razer Goliathus Extended", Price = 151.69, ImagePath = "pack://application:,,,/Images/mat.jpg", },
                new Product { Id = 19, Name = "МФУ HP LaserJet Pro MFP", Price = 28802.69, ImagePath = "pack://application:,,,/Images/printer.jpg", },
                new Product { Id = 20, Name = "Роутер ASUS RT-AX86U", Price = 2495.99, ImagePath = "pack://application:,,,/Images/router.jpg", },
                new Product { Id = 21, Name = "Оперативная память Fujitsu RAM DDR4", Price = 5202.94, ImagePath = "pack://application:,,,/Images/ram1.jpg",  },
                new Product { Id = 22, Name = "Ноутбук honor magixbook", Price = 88400.919, ImagePath = "pack://application:,,,/images/laptop1.jpg" },
                new Product { Id = 23, Name = "Смартфон xiaomi redmi note 14", Price = 13590.39, ImagePath = "pack://application:,,,/images/phone1.jpg" },
                new Product { Id = 24, Name = "Клавиатура redsquare rgb", Price = 544322125123559.59, ImagePath = "pack://application:,,,/images/keyboard1.jpg" },
            };
        }




        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            int productId = (int)button.Tag;

            string cartFilePath = $"{_username}_cart.txt";

            if (!File.Exists(cartFilePath))
            {
                File.WriteAllText(cartFilePath, productId.ToString());
            }
            else
            {
                File.AppendAllText(cartFilePath, $",{productId}");
            }

            MessageBox.Show("Товар добавлен в корзину!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsItemsControl == null || _products == null) return;

            var selectedItem = (ComboBoxItem)SortComboBox.SelectedItem;
            string sortOption = selectedItem.Content.ToString();

            switch (sortOption)
            {
                case "По имени (А-Я)":
                    ProductsItemsControl.ItemsSource = _products.OrderBy(p => p.Name).ToList();
                    break;
                case "По имени (Я-А)":
                    ProductsItemsControl.ItemsSource = _products.OrderByDescending(p => p.Name).ToList();
                    break;
                case "По цене (↑)":
                    ProductsItemsControl.ItemsSource = _products.OrderBy(p => p.Price).ToList();
                    break;
                case "По цене (↓)":
                    ProductsItemsControl.ItemsSource = _products.OrderByDescending(p => p.Price).ToList();
                    break;
                default:
                    ProductsItemsControl.ItemsSource = _products;
                    break;
            }
        }
    }
}
