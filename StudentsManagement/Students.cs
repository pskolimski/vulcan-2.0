﻿using Newtonsoft.Json;
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

        /*
            **********************************************
            nazwa funkcji: GetStudentsFromFile
            opis funkcji: Wczytuje uczniów z pliku JSON.
            parametry: filePath - ścieżka do pliku JSON
            zwracany typ i opis: void
            autor: Patryk Skolimowski
            ***********************************************
         */
        public static void GetStudentsFromFile(string filePath)
        {
            var json = File.ReadAllText(filePath);
            students = JsonConvert.DeserializeObject<List<Student>>(json);
        }


        /*
            **********************************************
            nazwa funkcji: SaveStudentsToFile
            opis funkcji: Zapisuje uczniów do pliku JSON.
            parametry: filePath - ścieżka do pliku JSON
            zwracany typ i opis: void
            autor: Patryk Skolimowski
            ***********************************************
         */
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
            opis funkcji: Zwraca ucznia z najwyższą średnią.
            parametry: brak
            zwracany typ i opis: Student - obiekt ucznia z najwyższą średnią
            autor: Patryk Skolimowski
            ***********************************************
         */
        static public Student GetTheBestStudent()
        {
            var sortedStudents = students.OrderByDescending(s => s.GetStudentAverage()).ToList();

            return sortedStudents[0];
        }

        /*
            **********************************************
            nazwa funkcji: GetTheWorstStudent
            opis funkcji: Zwraca ucznia z najniższą średnią.
            parametry: brak
            zwracany typ i opis: Student - obiekt ucznia z najniższą średnią
            autor: Patryk Skolimowski
            ***********************************************
         */
        static public Student GetTheWorstStudent()
        {
            var sortedStudents = students.OrderBy(s => s.GetStudentAverage()).ToList();

            return sortedStudents[0];
        }
    }

}
