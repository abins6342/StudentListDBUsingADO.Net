using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentListDBUsingADO.Net
{
    public class MainOption
    {
       public void GetAllStudentDetailsOption()
        {
            var studentRepository = new StudentRepository();

            var students = studentRepository.GetAllStudents();
            foreach (var student in students)
            {
                Console.WriteLine($"\nName: {student.Name}");
                Console.WriteLine($"Age: {student.Age}");
                Console.WriteLine($"Mark: {student.Mark}");
            }
        }

        public void GetStudentByIdOption()
        {
            var studentRepository = new StudentRepository();
            Console.WriteLine("Enter the Id to get the details : ");
            int idOfStudent = int.Parse(Console.ReadLine());

            var students = studentRepository.GetStudentById(idOfStudent);

            Console.WriteLine($"\nName: {students.Name}");
            Console.WriteLine($"Age: {students.Age}");
            Console.WriteLine($"Mark: {students.Mark}");
        }

        public void InsertStudentOption()
        {
            var studentRepository = new StudentRepository();

            Console.WriteLine("\nEnter the Name of the Student you want to Insert: ");
            string studentName = Console.ReadLine();

            Console.WriteLine("Enter the Age: ");
            int studentAge = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Mark  : ");
            int studentMark = int.Parse(Console.ReadLine());

            var student = new Student()
            {
                Name = studentName,
                Age = studentAge,
                Mark = studentMark
            };
            studentRepository.InsertStudent(student);
            Console.WriteLine("Successfully Inserted ");
        }

        public void UpdateStudentOption()
        {
            var studentRepository = new StudentRepository();
            Console.WriteLine("\nEnter the Id of Student you want to Update: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Name : ");
            string studentName = Console.ReadLine();

            Console.WriteLine("Enter the Age : ");
            int studentAge = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Mark : ");
            int studentMark = int.Parse(Console.ReadLine());

            var student = new Student()
            {
                Id = studentId,
                Name = studentName,
                Age = studentAge,
                Mark = studentMark
            };
            studentRepository.UpdateStudent(student);
            Console.WriteLine("Updated Successfully");
        }
        public void DeleteStudentOption()
        {
            var studentRepository = new StudentRepository();

            Console.WriteLine("\nEnter the Id of Student you want to Delete");
            int idOfStudent = int.Parse(Console.ReadLine());

            studentRepository.DeleteStudent(idOfStudent);
            Console.WriteLine("Deleted Successfully ");
        }
    }
}
