using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10171569_Robert_Gleeson_GUI
{
    class Person
    {
        //Person Properties
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }        

        //Operator overload methods
        public static bool operator ==(Person student, Person teacher)
        {
            if (student.LastName == teacher.LastName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Person student, Person teacher)
        {
            if (student.LastName != teacher.LastName)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override bool Equals(object p)
        {
            Person student;
            if (p == null)
            {
                return false;
            }
            else
            {
                student = (Student)p;
            }
            return this.LastName == student.FirstName;
        }

        public override int GetHashCode()
        {
            return LastName.GetHashCode() ^ FirstName.GetHashCode();
        }

        //Return all information
        public string GetAll()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Title);
            sb.Append(" ");
            sb.Append(FirstName);
            sb.Append(" ");
            sb.Append(LastName);
            sb.Append(" ");
            sb.Append(Email);
            sb.Append(" ");
            sb.Append(Phone);
            return sb.ToString();
        }

        //Return search result properties
        public string SearchResult()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Title);
            sb.Append(" ");
            sb.Append(FirstName);
            sb.Append(" ");
            sb.Append(LastName);
            sb.Append(" ");

            return sb.ToString();
        }

        public string ReturnSearch()
        {
            return string.Format(FirstName + " " + LastName);
        }
    }
}
