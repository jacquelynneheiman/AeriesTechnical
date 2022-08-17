using System;
using System.ComponentModel;
using JacquelynneHeiman_Aeries.Services;

namespace JacquelynneHeiman_Aeries.Models
{
    public class StudentModel
    {
        [DisplayName("School Code")]
        public int SchoolCode { get; set; }

        [DisplayName("Student Id")]
        public int StudentId { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [DisplayName("Zip Code")]
        public int ZipCode { get; set; }

        public List<ContactModel> contacts = new List<ContactModel>();

        public StudentModel()
        {
            SchoolCode = 0;
            StudentId = 0;
            LastName = "Last Name";
            FirstName = "First Name";
            Address = "Address";
            City = "City";
            State = "State";
            ZipCode = 0;
        }

        public void GetContacts()
        {
            StudentsDAO studentsDAO = new StudentsDAO();
            contacts = studentsDAO.GetContactsById(StudentId);
        }
    }
}

