using System;
using System.Data;
using MySql.Data.MySqlClient;
using JacquelynneHeiman_Aeries.Models;

namespace JacquelynneHeiman_Aeries.Services
{
    public class StudentsDAO
    {
        public List<StudentModel> GetStudentData()
        {
            List<StudentModel> students = new List<StudentModel>();

            string mySqlCommand = "SELECT * FROM StudentData";

            using (MySqlConnection connection = ConnectMySQL.GetConnection())
            {
                MySqlCommand command = new MySqlCommand(mySqlCommand, connection);

                try
                {
                    MySqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        StudentModel newStudent = new StudentModel();

                        newStudent.SchoolCode = dataReader.GetInt32("SchoolCode");
                        newStudent.StudentId = dataReader.GetInt32("StudentId");
                        newStudent.LastName = dataReader.GetString("LastName");
                        newStudent.FirstName = dataReader.GetString("FirstName");
                        newStudent.Address = dataReader.GetString("Address");
                        newStudent.City = dataReader.GetString("City");
                        newStudent.State = dataReader.GetString("State");
                        newStudent.ZipCode = dataReader.GetInt32("ZipCode");

                        students.Add(newStudent);
                    }

                    dataReader.Close();

                    Console.WriteLine("Successfully obtained student records.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to get student records: " + e.Message);
                }

                connection.Close();
            }

            return students;
        }

        public List<ContactModel> GetContactsById(int studentId)
        {
            List<ContactModel> contacts = new List<ContactModel>();

            string mySqlCommand = "SELECT * FROM ContactData WHERE StudentId = @studentId";

            using(MySqlConnection connection = ConnectMySQL.GetConnection())
            {
                MySqlCommand command = new MySqlCommand(mySqlCommand, connection);
                command.Parameters.Add("@studentId", MySqlDbType.Int32).Value = studentId;

                try
                {
                    MySqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            ContactModel newContact = new ContactModel();

                            newContact.StudentId = dataReader.GetInt32("StudentId");
                            newContact.LastName = dataReader.GetString("LastName");
                            newContact.FirstName = dataReader.GetString("FirstName");
                            newContact.Relationship = dataReader.GetString("Relationship");
                            newContact.EmailAddress = dataReader.GetString("EmailAddress");
                            newContact.Mobile = dataReader.GetString("Mobile");
                            newContact.Address = dataReader.GetString("Address");
                            newContact.City = dataReader.GetString("City");
                            newContact.State = dataReader.GetString("State");
                            newContact.ZipCode = dataReader.GetInt32("ZipCode");

                            contacts.Add(newContact);

                        }
                    }

                    dataReader.Close();

                    Console.WriteLine("Successfully obtained contact for student: " + studentId);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Could not get contacts: " + e.Message);
                }
            }

            return contacts;
        }
    }
}

