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
using System.IO;
namespace TorgovyAutomat
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        float summ = 0;
        string crashString;
        WebClient client = new WebClient() {Encoding = Encoding.UTF8 };
        string path = Environment.CurrentDirectory + "crashlog.txt";
        public MainWindow()
        {
            InitializeComponent();
            GetBalance();
            try{
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
                ProductsLv.ItemsSource = JsonConvert.DeserializeObject<List<DrinksRepositoryJson>>(client.DownloadString(HostConnection.HostName + "Drinks"));
            }
            
            catch(Exception ex)
            {
                MessageBox.Show("Произошла ошибка связанная с сервером,"+Environment.NewLine+" подробности в фале CrashLogs","Внимание",MessageBoxButton.OKCancel, MessageBoxImage.Error);
                crashString = File.ReadAllText(path) + "[" + DateTime.Now.ToString("g")+"]" + " " + ex + Environment.NewLine + Environment.NewLine; 
                File.WriteAllText(path, crashString);
                this.Close();
            }
            
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
              
                if (drink.Cost <= summ)
                {
                    MessageBox.Show("Спасибо за покупку");
                    summ -= drink.Cost;
                    GetBalance();
                }
                else MessageBox.Show("Денег недостаточно, внесите нужную сумму");
            }
            ProductsLv.UnselectAll();

            
        }

        private void Sdacha_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ваша сдача " + summ.ToString() + " руб.");
            summ = 0;
            GetBalance();
        }
    }
}
