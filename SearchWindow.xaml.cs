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

namespace desktop1
{
    /// <summary>
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        private desktopEntities1 desktopEntities1 = new desktopEntities1();
        public SearchWindow()
        {
            InitializeComponent();
            DGridPoisk.ItemsSource = desktopEntities1.GetContext().desktop.ToList();
        }
        private void filterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string filterText = SearchTextBox.Text.Trim();

                if (string.IsNullOrEmpty(filterText))
                {
                    DGridPoisk.ItemsSource = desktopEntities1.GetContext().desktop.ToList();
                }
                else
                {
                    var filteredCategories = desktopEntities1.GetContext().desktop.Where(c =>
                    c.mobile_number.Contains(filterText) ||
                    c.work_number.Contains(filterText) ||
                    c.home_number.Contains(filterText)
                ).ToList();

                    if (filteredCategories.Any())
                    {
                        DGridPoisk.ItemsSource = filteredCategories;
                    }
                    else
                    {
                        DGridPoisk.ItemsSource = null; 
                        MessageBox.Show("Нет абонентов, удовлетворяющих критерию поиска.");
                    }
                }
            }
        }
    }
}
    

