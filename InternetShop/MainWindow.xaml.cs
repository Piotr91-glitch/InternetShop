using System.Linq;
using System.Windows;
using System.Windows.Controls;
using InternetShop.Data;
using InternetShop.Models;
using InternetShop.Repositories;

namespace InternetShop
{
    public partial class MainWindow : Window
    {
        private readonly Repository<Product> _productRepository;

        public MainWindow()
        {
            InitializeComponent();
            var context = new AppDbContext();
            _productRepository = new Repository<Product>(context);
            LoadProducts();
        }

        private void LoadProducts()
        {
            var products = _productRepository.GetAll().ToList();
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

            _productRepository.Insert(product);
            LoadProducts();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (textBox.Text == "Name" || textBox.Text == "Description" || textBox.Text == "Price" || textBox.Text == "Stock")
                {
                    textBox.Text = string.Empty;
                }
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    switch (textBox.Name)
                    {
                        case "NameTextBox":
                            textBox.Text = "Name";
                            break;
                        case "DescriptionTextBox":
                            textBox.Text = "Description";
                            break;
                        case "PriceTextBox":
                            textBox.Text = "Price";
                            break;
                        case "StockTextBox":
                            textBox.Text = "Stock";
                            break;
                    }
                }
            }
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
