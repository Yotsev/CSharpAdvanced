using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>(Capacity);
        }

        public int Capacity { get; set; }
        public int Count { get { return students.Count; } }
        public string RegisterStudent(Student student)
        {
            if (students.Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            if (student != null)
            {
                students.Remove(student);
                return $"Dismissed student {student.FirstName} {student.LastName}";
            }

            return "Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();
            List<Student> studentsInSubjec = students.Where(s => s.Subject == subject).ToList();

            if (studentsInSubjec.Count > 0)
            {
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");

                foreach (Student student in studentsInSubjec)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
            }
            else
            {
                sb.AppendLine("No students enrolled for the subject");
            }

            return sb.ToString().Trim();
        }
        public int GetStudentsCount()
        {
            return Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
            return student;
        }
    }
}
