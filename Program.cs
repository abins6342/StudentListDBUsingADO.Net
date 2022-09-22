using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace StudentListDBUsingADO.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentRepository = new StudentRepository();

            var student = new Student()
            {
                Id=5,
                Name= "Abin",
                Mark=90
            };
            Console.WriteLine(studentRepository.UpdateStudent(student));
        }
    }
}
