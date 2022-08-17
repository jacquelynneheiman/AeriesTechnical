using System;
using System.ComponentModel;

namespace JacquelynneHeiman_Aeries.Models
{
    public class ContactModel
    {
        [DisplayName("Student Id")]
        public int StudentId { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        public string Relationship { get; set; }

        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        public string Mobile { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [DisplayName("Zip Code")]
        public int ZipCode { get; set; }

        public ContactModel()
        {
            StudentId = 0;
            LastName = "Last Name";
            FirstName = "First Name";
            Relationship = "Relationship";
            EmailAddress = "Email";
            Mobile = "Mobile";
            Address = "Address";
            City = "City";
            State = "State";
            ZipCode = 0;
        }
    }
}

