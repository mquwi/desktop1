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
    /// Логика взаимодействия для StreetsWindow.xaml
    /// </summary>
    public partial class StreetsWindow : Window
    {
        private desktopEntities1 desktopEntities1 = new desktopEntities1();
        public StreetsWindow()
        {
            InitializeComponent();

           
            DGridStreets.ItemsSource = desktopEntities1.GetContext().desktop.ToList();

           
            StreetsComboBox.SelectionChanged += ComboBox_SelectionChanged;
            NameComboBox.SelectionChanged += ComboBox_SelectionChanged;
            SurnameComboBox.SelectionChanged += ComboBox_SelectionChanged;
            PatronymicComboBox.SelectionChanged += ComboBox_SelectionChanged;
            HousenumberComboBox.SelectionChanged += ComboBox_SelectionChanged;
        }

        private void LoadComboBoxData()
        {
         
            var streets = desktopEntities1.GetContext().desktop.Select(d => d.Streets).Distinct().ToList();
            StreetsComboBox.ItemsSource = streets;

            
            var names = desktopEntities1.GetContext().desktop.Select(d => d.Name).Distinct().ToList();
            NameComboBox.ItemsSource = names;

            
            var surnames = desktopEntities1.GetContext().desktop.Select(d => d.Surname).Distinct().ToList();
            SurnameComboBox.ItemsSource = surnames;

            
            var patronymics = desktopEntities1.GetContext().desktop.Select(d => d.Patronymic).Distinct().ToList();
            PatronymicComboBox.ItemsSource = patronymics;

            var houseNumbers = desktopEntities1.GetContext().desktop.Select(d => d.house_number).Distinct().ToList();
            HousenumberComboBox.ItemsSource = houseNumbers;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            string selectedStreet = (string)StreetsComboBox.SelectedItem;
            string selectedName = (string)NameComboBox.SelectedItem;
            string selectedSurname = (string)SurnameComboBox.SelectedItem;
            string selectedPatronymic = (string)PatronymicComboBox.SelectedItem;
            string selectedHouseNumber = (string)HousenumberComboBox.SelectedItem;

           
            DGridStreets.ItemsSource = desktopEntities1.GetContext().desktop.Where(d =>
                (string.IsNullOrEmpty(selectedStreet) || d.Streets == selectedStreet) &&
        (string.IsNullOrEmpty(selectedName) || d.Name == selectedName) &&
        (string.IsNullOrEmpty(selectedSurname) || d.Surname == selectedSurname) &&
        (string.IsNullOrEmpty(selectedPatronymic) || d.Patronymic == selectedPatronymic) &&
        (string.IsNullOrEmpty(selectedHouseNumber) || d.house_number == selectedHouseNumber)
    ).ToList();
        }

        
    }
}