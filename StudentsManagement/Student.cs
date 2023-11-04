using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace StudentsManagement
{
    class Student
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string FullName {
            protected get {
                return $"{FirstName} {LastName}";
            }
            set { }
        }
        public List<int> Grades { get; set; } = new List<int>();
        public string GradesList { get { return string.Join(", ", Grades); } }
        public string Class { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DateOfBirthString { protected get { return DateOfBirth.ToShortDateString(); } set { } }
        public string Pesel { get; set; }
        public int Semester { get; set; }
        public double Average { get; set; }
        public string Image { get; set; }
        public BitmapImage Avatar { protected get; set; }

        public Student(string firstName, string lastName, string studentsClass, string pesel, List<int> grades, int semester, string image)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Semester = semester;
            this.Class = studentsClass;
            this.Pesel = pesel;
            this.DateOfBirth = GetDateOfBirth();
            this.Average = ShowGradesAverage();
            this.Grades = grades;
            this.Image = image;
            this.Avatar = new BitmapImage(new Uri($"{image}", UriKind.RelativeOrAbsolute));
        }



        private DateTime GetDateOfBirth()
        {
            string rr = this.Pesel.Substring(0, 2);
            string mm = this.Pesel.Substring(2, 2);
            string dd = this.Pesel.Substring(4, 2);

            int monthInt = 0;
            int rrInt = 0;
            int year = 0;
            int day = 0;

            Int32.TryParse(mm, out monthInt);
            Int32.TryParse(rr, out rrInt);
            Int32.TryParse(dd, out day);

            if (monthInt >= 81 && monthInt <= 92)
            {
                year = 1800 + rrInt;
                monthInt -= 80;
            }
            else if (monthInt >= 21 && monthInt <= 32)
            {
                year = 2000 + rrInt;
                monthInt -= 20;
            }
            else if (monthInt >= 41 && monthInt <= 52)
            {
                year = 2100 + rrInt;
                monthInt -= 40;
            }
            else if (monthInt >= 60 && monthInt <= 72)
            {
                year = 2200 + rrInt;
                monthInt -= 60;
            }
            else
            {
                year = 1900 + rrInt;
            }

            return new DateTime(year, monthInt, day);
        }

        /* 
            **********************************************
            nazwa funkcji: ShowGrades
            opis funkcji: Wyświetla na ekranie listę ocen ucznia.
            parametry: brak
            zwracany typ i opis: void
            autor: Patryk Skolimowski
            ***********************************************
         */
        public void ShowGrades()
        {
            if (Grades.Count == 0)
            {
                Console.WriteLine("Ten uczeń nie ma żadnych ocen!");
            }
            else
            {
                Console.Write("Lista ocen: ");
                string gradesString = String.Join(",", Grades);

                Console.WriteLine($"{gradesString}");
            }
        }

        /*
            **********************************************
            nazwa funkcji: ShowGradesAverage
            opis funkcji: Wyświetla średnią ocen ucznia.
            parametry: brak
            zwracany typ i opis: void
            autor: Patryk Skolimowski
            ***********************************************
         */
        public double ShowGradesAverage()
        {
            double sum = 0;

            foreach (var grade in Grades)
            {
                sum += grade;
            }

            double average = Math.Round(sum / Grades.Count, 2);
            Console.WriteLine($"Średnia ocen: {average}");

            return average;
        }

        /*
            **********************************************
            nazwa funkcji: AddGrade
            opis funkcji: Dodaje ocenę do listy ocen ucznia.
            parametry: grade - ocena, która ma zostać dodana
            zwracany typ i opis: void
            autor: Patryk Skolimowski
            ***********************************************
         */
        public void AddGrade(int grade)
        {
            Grades.Add(grade);
        }

        /*
            **********************************************
            nazwa funkcji: DisplayStudentInfo
            opis funkcji: Wypisuje na ekran wszystkie dane ucznia.
            parametry: grade - ocena, która ma zostać dodana
            zwracany typ i opis: void
            autor: Patryk Skolimowski
            ***********************************************
         */
        public void DisplayStudentInfo()
        {
            Console.WriteLine($"\nImie i nazwisko: {this.FirstName} {this.LastName}");
            Console.WriteLine($"Klasa: {this.Class}");
            Console.WriteLine($"Data urodzenia: {this.DateOfBirth.ToShortDateString()}");

            this.ShowGrades();
            this.ShowGradesAverage();

            Console.WriteLine();
        }
    }
}
