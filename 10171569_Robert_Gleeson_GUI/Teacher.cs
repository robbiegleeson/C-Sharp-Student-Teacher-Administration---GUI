using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10171569_Robert_Gleeson_GUI
{
    class Teacher : Employee
    {
        //Teacher property
        public string Subject { get; set; }


        //Override to string method
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5:0.00},{6}", Title, FirstName, LastName, Salary, Phone, Email, Subject);
        }
        //Retun search string format
        public string Search()
        {
            return string.Format("{0} {1} {2}\nPhone: {3}\nE-Mail: {4}", Title, FirstName, LastName, Phone, Email);
        }
        //Write to CSV string format
        public string WriteToCsv()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}", Title, FirstName, LastName, Salary, Phone, Email, Subject);
        }

        //Add teacher string format
        public Teacher(string title, string fName, string lName, double salary, string eMail, string phone, string subject)
            : base()
        {            
            Title = title;
            FirstName = fName;
            LastName = lName;
            Salary = salary;
            Phone = phone;
            Email = eMail;
            Subject = subject;
        }

        public string GetAllTeachers()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Salary);
            sb.Append(",");
            sb.Append(base.GetAll());
            return sb.ToString();
        }
        //Return search results string format
        public string ReturnSearch()
        {
            return string.Format(FirstName + " " + LastName + "\nPhone Number: " + Phone);
        }
    }
}
