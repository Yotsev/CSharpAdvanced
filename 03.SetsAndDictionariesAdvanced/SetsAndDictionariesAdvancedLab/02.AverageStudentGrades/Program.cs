using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] studentInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string studentName = studentInfo[0];
                decimal studentGrade = decimal.Parse(studentInfo[1]);

                if (!studentGrades.ContainsKey(studentName))
                {
                    studentGrades.Add(studentName, new List<decimal>());
                }

                studentGrades[studentName].Add(studentGrade);
            }

            foreach (var student in studentGrades)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ",student.Value.Select(x => x.ToString())):F2} (avg: {student.Value.Average():F2})");
            }
        }
    }
}
