

namespace _4._Students
{
    using System;
    using System.Numerics;
    using System.Collections.Generic;
    using System.Linq;
    class Students
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                List<string> studentArray = Console.ReadLine()
                    .Split()
                    .ToList();

                string firstName = studentArray[0];
                string lastName = studentArray[1];
                decimal grade = decimal.Parse(studentArray[2]);

                Student student = new Student(firstName, lastName, grade);

                students.Add(student);
            }

            Console.WriteLine(string.Join(Environment.NewLine, students.OrderByDescending(student => student.Grade)));
        }
    }

    public class Student
    {
        public Student(string firstName, string lastName, decimal grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade}";
        }
    }
}
