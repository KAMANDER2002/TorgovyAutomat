﻿using System;
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

namespace TorgovyAutomat
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Product> products;
            products = new List<Product> 
            {
                new Product{Name = "adasd", Images = ""},
                new Product{Name = "adasd", Images = ""},
                new Product{Name = "adasd", Images = ""},
                new Product{Name = "adasd", Images = ""},
                new Product{Name = "adasd", Images = ""},
                new Product{Name = "adasd", Images = ""},
                new Product{Name = "adasd", Images = ""},
                new Product{Name = "adasd", Images = ""},
                new Product{Name = "adasd", Images = ""},
                new Product{Name = "adasd", Images = ""},
                new Product{Name = "adasd", Images = ""},
                new Product{Name = "adasd", Images = ""}     
            };
            ProductsLv.ItemsSource = products.ToList();
        }
    }
}
