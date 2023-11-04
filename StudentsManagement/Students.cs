using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagement
{
    internal static class Students
    {
        static public List<Student> students { get; set; } = new List<Student>();

        public static void GetStudentsFromFile(string filePath)
        {
            var json = File.ReadAllText(filePath);
            students = JsonConvert.DeserializeObject<List<Student>>(json);
        }

        public static void SaveStudentsToFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(students);
            File.WriteAllText(filePath, json);
        }

        /*
            **********************************************
            nazwa funkcji: AddStudent
            opis funkcji: Dodaje ucznia do statycznej listy uczniów.
            parametry: student - obiekt ucznia, który ma zostać dodany do listy
            zwracany typ i opis: void
            autor: Patryk Skolimowski
            ***********************************************
         */
        static public void AddStudent(Student student)
        {
            students.Add(student);
        }

        /*
            **********************************************
            nazwa funkcji: GetTheBestStudent
            opis funkcji: Wyświetla najlepszego ucznia.
            parametry: brak
            zwracany typ i opis: void
            autor: Patryk Skolimowski
            ***********************************************
         */
        static public void GetTheBestStudent()
        {
            var sortedStudents = students.OrderByDescending(s => s.ShowGradesAverage()).ToList();

            Console.WriteLine("\n\nNAJLEPSZY UCZEŃ");
            sortedStudents[0].DisplayStudentInfo();
        }

        /*
            **********************************************
            nazwa funkcji: GetTheWorstStudent
            opis funkcji: Wyświetl najsłabszego ucznia z listy.
            parametry: brak
            zwracany typ i opis: void
            autor: Patryk Skolimowski
            ***********************************************
         */
        static public void GetTheWorstStudent()
        {
            var sortedStudents = students.OrderBy(s => s.ShowGradesAverage()).ToList();

            Console.WriteLine("\n\nNAJSŁABSZY UCZEŃ");
            sortedStudents[0].DisplayStudentInfo();
        }

        static public void DisplayAllStudents()
        {
            foreach (var student in students)
            {
                student.DisplayStudentInfo();
            }
        }
    }

}
