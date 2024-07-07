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
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace desktop1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private desktopEntities1 desktopEntities1 = new desktopEntities1();
        public MainWindow()
        {
            InitializeComponent();
            DGridNomer.ItemsSource = desktopEntities1.GetContext().desktop.ToList();
        }

        private void OpenSearchWindow(object sender, RoutedEventArgs e)
        {
            SearchWindow objstets = new SearchWindow();
            objstets.ShowDialog();
        }

        private void OpenStreetshWindow(object sender, RoutedEventArgs e)
        {
            StreetsWindow objstets = new StreetsWindow();
            objstets.ShowDialog();
        }

        private void ExportToCSV(object sender, RoutedEventArgs e)
        {
            
            List<desktop> data = DGridNomer.ItemsSource.Cast<desktop>().ToList();

            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName, false, Encoding.GetEncoding("windows-1251")))
                {
                   
                    writer.WriteLine("Id;Имя;Фамилия;Отчество;Улица;Номер дома;Номер телефона мобильный;Номер телефона рабочий;Номер телефона домашний");

                   
                    foreach (desktop item in data)
                    {
                        writer.WriteLine($"{item.Id};{item.Name};{item.Surname};{item.Patronymic};{item.Streets};{item.house_number};{item.mobile_number};{item.work_number};{item.home_number}");
                    }
                }

                MessageBox.Show("Данные успешно сохранены в CSV файл.", "Информация");
            }
        }
    }
}