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

namespace StudentsManagement
{
    /// <summary>
    /// Logika interakcji dla klasy StudentsList.xaml
    /// </summary>
    public partial class StudentsList : Window
    {
        public StudentsList()
        {
            InitializeComponent();
        }

        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = Students.students;
        }
    }
}
