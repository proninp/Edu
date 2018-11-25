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
            btnEmplBlock.Click += (sender, args) =>
            {
                if (EmplSP.DataContext != null)
                {
                    ((Employee)EmplSP.DataContext).Blocked = true;
                    cbDep.DataContext = cbDep.SelectedItem;
                }
            };
            btnEmplAdd.Click += (sender, args) =>
            {
                if (cbDep.SelectedItem != null)
                {
                    int lastId = Data.Dep.Select(d => d.Employees.Select(e => e.Id).Max()).Max() + 1;
                    ((Department)cbDep.SelectedItem).Employees.Add(new Employee(lastId, "Имя", "Фамилия", 18, "", "0"));
                    lvEmpl.ItemsSource = ((Department)cbDep.SelectedItem).Employees;
                    lvEmpl.SelectedItem = ((Department)cbDep.SelectedItem).Employees.OrderByDescending(e => e.Id).Take(1);
                }
            };
        }
    }
}
