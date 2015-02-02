using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10171569_Robert_Gleeson_GUI
{
    class Student : Person
    {
        //Student Properties
        public int StudentID { get; set; }
        public string Status { get; set; }

        //Override to String method
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}", StudentID, Title, FirstName, LastName, Phone, Email, Status);
        }
        //Search format
        public string Search()
        {
            return string.Format("{0} {1} {2}\nPhone: {3}\nE-Mail: {4}", Title, FirstName, LastName, Phone, Email);
        }

        //Write to CSV format
        public string WriteToCsv()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}", StudentID, Title, FirstName, LastName, Phone, Email, Status);
        }

        //Student information format
        public Student(int id, string title, string fName, string lName, string phone, string eMail, string status)
            : base()
        {
            StudentID = id;
            Title = title;
            FirstName = fName;
            LastName = lName;
            Phone = phone;
            Email = eMail;
            Status = status;
        }

        public string GetAllStudents()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(StudentID);
            sb.Append(",");
            sb.Append(base.GetAll());
            return sb.ToString();
        }

        public string ReturnSearch()
        {
            return string.Format(FirstName + " " + LastName + "\nPhone Number: " + Phone);
        }
    }
}
