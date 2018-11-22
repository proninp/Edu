using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Personal
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cbDep.ItemsSource = Data.Dep;
        }

        private void CbDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvEmpl.ItemsSource = Data.Dep.Where(x => x.Id == ((Department)((ComboBox)sender).SelectedItem).Id).First().Employees;
        }
    }
}
