using System;
using System.Linq;
using System.Windows;
using InternetShop.Data;
using InternetShop.Models;

namespace InternetShop
{
    public partial class MainWindow : Window
    {
        private AppDbContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadProducts();
        }

        private void LoadProducts()
        {
            var products = _context.Products.ToList();
            ProductsListBox.ItemsSource = products;
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            var product = new Product
            {
                Name = NameTextBox.Text,
                Description = DescriptionTextBox.Text,
                Price = decimal.Parse(PriceTextBox.Text),
                Stock = int.Parse(StockTextBox.Text)
            };

            _context.Products.Add(product);
            _context.SaveChanges();
            LoadProducts();
        }
    }
}
