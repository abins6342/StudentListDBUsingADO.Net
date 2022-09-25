using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;

namespace StudentListDBUsingADO.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainOpion=new MainOption();
            Console.WriteLine("Student Management System");
            Console.WriteLine("--------------------------");

            Console.WriteLine("\n1. Show All the Student Details \n2.Show a Partitcular Student \n3. Insert a Student\n4.Update the Student Details\n5. Delete the Student ");
            Console.WriteLine("Choose the Option");
            int chooseOption=int.Parse(Console.ReadLine());
           
            switch (chooseOption)
            {

                case 1:
                    mainOpion.GetAllStudentDetailsOption();
                    break;
                case 2:
                    mainOpion.GetStudentByIdOption();
                    break;
                case 3:
                    mainOpion.InsertStudentOption();
                    break;
                case 4:
                    mainOpion.UpdateStudentOption();
                    break;
                case 5:
                    mainOpion.DeleteStudentOption();
                    break;
                default: Console.WriteLine("Invalid Option !!!! Please choose a correct option");
                    break;
            }
           
        }
    }
}
