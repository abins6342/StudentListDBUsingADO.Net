using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentListDBUsingADO.Net
{
    public class StudentRepository
    {
        private SqlConnection _sqlConnection;
        public StudentRepository()
        {
            _sqlConnection = new SqlConnection("data source=(localdb)\\mssqllocaldb;database=training");
        }

        public List<Student> GetAllStudents()
        {
            try
            {
                _sqlConnection.Open();
                var sqlCommand = new SqlCommand(cmdText: "Select * from Student ", _sqlConnection);
                var sqlReader = sqlCommand.ExecuteReader();
                var studentList = new List<Student>();
                while (sqlReader.Read())
                {
                    studentList.Add(new Student
                    {
                        Id = (int)sqlReader["StudentId"],
                        Name = (string)sqlReader["StudentName"],
                        Age = (int)sqlReader["StudentAge"],
                        Mark = (int)sqlReader["StudentMark"]
                    });
                }
                return studentList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public Student GetStudentById(int studentId)
        {
            try
            {
                _sqlConnection.Open();
                var sqlCommand = new SqlCommand(cmdText: "Select * from Student where StudentId=@id ", _sqlConnection);
                sqlCommand.Parameters.AddWithValue("id",studentId);

                var sqlDataReader = sqlCommand.ExecuteReader();
                var student = new Student();
                while (sqlDataReader.Read())
                {
                    student.Id = (int)sqlDataReader["StudentId"];
                    student.Name = (string)sqlDataReader["StudentName"];
                    student.Age = (int)sqlDataReader["StudentAge"];
                    student.Mark = (int)sqlDataReader["StudentMark"];
                }
                return student;

            }
            catch (Exception e)
            {

                throw;
            }

            finally
            {
                _sqlConnection.Close();
            }
        }

        public bool InsertStudent(Student student)
        {
            try
            {
                _sqlConnection.Open();
                var sqlCommand = new SqlCommand(cmdText: "Insert into Student (StudentName,StudentAge,StudentMark) Values(@Name,@Age,@Mark)",_sqlConnection);
                sqlCommand.Parameters.AddWithValue("Name",student.Name);
                sqlCommand.Parameters.AddWithValue("Age", student.Age);
                sqlCommand.Parameters.AddWithValue("Mark", student.Mark);
                sqlCommand.ExecuteNonQuery();

                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public bool DeleteStudent(int StudentId)
        {
            try
            {
                _sqlConnection.Open();
                var sqlCommand = new SqlCommand(cmdText: "Delete from Student Where StudentId=@Id", _sqlConnection);
                sqlCommand.Parameters.AddWithValue("Id", StudentId);
               
                sqlCommand.ExecuteNonQuery();

                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public bool UpdateStudent(Student student)
        {
            try
            {
                _sqlConnection.Open();
                var sqlCommand = new SqlCommand(cmdText: "Update Student Set StudentName=@Name, StudentMark=@Mark, ModificationDate=@Modification where StudentId=@Id", _sqlConnection);

                sqlCommand.Parameters.AddWithValue("Id", student.Id);
                sqlCommand.Parameters.AddWithValue("Name", student.Name);
                sqlCommand.Parameters.AddWithValue("Mark", student.Mark);
                sqlCommand.Parameters.AddWithValue("Modification", DateTime.Now);

                sqlCommand.ExecuteNonQuery();

                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
    }
}
