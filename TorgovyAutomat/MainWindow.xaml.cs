using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using TorgovyAutomat.Controler;
using TorgovyAutomat.Model;

namespace TorgovyAutomat
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        float summ = 0;
        WebClient client = new WebClient() {Encoding = Encoding.UTF8 };
        
        public MainWindow()
        {
            InitializeComponent();
            GetBalance();

            ProductsLv.ItemsSource = JsonConvert.DeserializeObject<List<DrinksRepositoryJson>>(client.DownloadString(HostConnection.HostName + "Drinks"));
            
        }
        private void GetBalance()
        {
            BalanceText.Text = $"Баланс: {summ} руб.";
        }

        private void OneRubleButton_Click(object sender, RoutedEventArgs e)
        {
            summ += 1;
            GetBalance();
        }

        private void TwoRublesButton_Click(object sender, RoutedEventArgs e)
        {
            summ += 2;
            GetBalance();
        }

        private void FiveRublesButton_Click(object sender, RoutedEventArgs e)
        {
            summ += 5;
            GetBalance();
        }

        private void TenRublesButton_Click(object sender, RoutedEventArgs e)
        {
            summ += 10;
            GetBalance();
        }

        private void ProductsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsLv.SelectedItem != null)
            {
                DrinksRepositoryJson drink = (DrinksRepositoryJson)ProductsLv.SelectedItem;
                MessageBox.Show(drink.Cost.ToString() + "f" + summ.ToString());
                if (drink.Cost < summ)
                {
                    MessageBox.Show(drink.name);
                    summ -= drink.Cost;
                    MessageBox.Show(summ.ToString());
                }
                else MessageBox.Show("Денег мало" + summ.ToString());
            }
            ProductsLv.UnselectAll();

            //    MessageBox.Show("Вам не хватает денег");
        }
    }
}
