using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentsManagement
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Student activeStudent
        {
            get; set;
        }

        public MainWindow()
        {
            InitializeComponent();
            Students.GetStudentsFromFile(@"Students.json");
            this.activeStudent = Students.students[0];
            this.DataContext = activeStudent;
            GradesList.ItemsSource = activeStudent.Grades;
            StudentsCount.Content = $"W systemie {Students.students.Count} uczniów";
            RenderStudentsList();
        }

        public void RenderStudentsList() {
            StudentsList.Items.Clear();
            foreach (var student in Students.students)
            {
                ListBoxItem item = new ListBoxItem
                {
                    Content = $"{student.FirstName} {student.LastName}",
                    Tag = student.Pesel
                };
                item.Style = (Style)FindResource("ListItem");
                item.Selected += Item_Selected;
                StudentsList.Items.Add(item);
            }
        }

        private void Item_Selected(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;

            foreach (var student in Students.students)
            {
                if (student.Pesel == item.Tag.ToString())
                {
                    activeStudent = student;
                    this.DataContext = activeStudent;
                    GradesList.ItemsSource = activeStudent.Grades;
                    break;
                }
            }
        }

        private void LoadFromFile_Clicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Wybierz plik z uczniami",
                Filter = "Pliki json (*.json)|*.json",
                Multiselect = false
            };

            bool result = (bool)openFileDialog.ShowDialog();

            if (result)
            {
                string fileName = openFileDialog.FileName;
                Students.GetStudentsFromFile(fileName);
                RenderStudentsList();
            }
        }

        private void ExportToFile_Clicked(object sender, RoutedEventArgs e)
        {
            // export to json

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Wybierz plik do zapisu",
                Filter = "Pliki json (*.json)|*.json",
                FileName = "Students.json"
            };

            bool result = (bool)saveFileDialog.ShowDialog();
            if (result)
            {
               string fileName = saveFileDialog.FileName;
               
                Students.SaveStudentsToFile(fileName);
              
            }
        }

        private void Next_Person_Button_Clicked(object sender, RoutedEventArgs e)
        {
            int index = Students.students.IndexOf(activeStudent);

            if (index < Students.students.Count - 1)
            {
                activeStudent = Students.students[index + 1];
            }
            else
            {
                activeStudent = Students.students[0];
            }
            this.DataContext = activeStudent;
            GradesList.ItemsSource = activeStudent.Grades;
        }

        private void Previous_Person_Button_Clicked(object sender, RoutedEventArgs e)
        {
            int index = Students.students.IndexOf(activeStudent);

            if (index > 0)
            {
                activeStudent = Students.students[index - 1];
            }
            else
            {
                activeStudent = Students.students[Students.students.Count - 1];
            }
            this.DataContext = activeStudent;
            GradesList.ItemsSource = activeStudent.Grades;
        }
    }
}
