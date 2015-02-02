using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _10171569_Robert_Gleeson_GUI
{
    class College
    {
        //Seperate file paths for Student and Teacher CSV files
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Students.csv";
        string filePathT = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Teachers.csv";
       
        //Both Teacher and Student Lists created
        public List<Student> Students;
        public List<Teacher> Teachers;


        public College()
        {
            //New instance of Student and Teacher Class
            Students = new List<Student>();
            Teachers = new List<Teacher>();
        }

        //Start Student Block

        //Student List method to return values in Student List
        public List<Student> GetStudentList()
        {
            return Students;
        }

        //Method to Add Students to Student List
        public string AddStudent(string title, string fName, string lName, int id, string eMail, string phone, string status)
        {
            Student s = new Student(id, title, fName, lName, phone, eMail, status);
            
            bool flag = true;

            id = s.StudentID;
            //Check for studnt ID
            foreach (Student st in Students)
            {
                if (id == st.StudentID)
                {
                    Console.WriteLine("That ID already exists");
                    flag = false;
                }
            }
            if (flag)
            {
                s.Title = title;
                s.FirstName = fName;
                s.LastName = lName;
                s.StudentID = id;
                s.Email = eMail;
                s.Phone = phone;
                s.Status = status;
                //Student added to list
                Students.Add(s);                
            }

            return "Student Added to list";
        }

        //Save Student Method - to write to CSV file
        public void SaveStudent()
        {
            StreamWriter sw = new StreamWriter(filePath);
            foreach (Student s in Students)
            {
                //Each entry is saved to CSV in write to CSV format in Student Class
                sw.WriteLine(s.WriteToCsv());
            }
            sw.Close();            
        }

        //Delete Student Method
        public void DeleteStudent()
        {
            for (int i = 0; i < Students.Count; i++)
            {
                Student s = Students[i];
                Students.Remove(s);
            }
        }       
            

        //End Student Block

        //Eacher List method to return values in Teacher List
        public List<Teacher> GetTeacherList()
        {
            return Teachers;
        }

        //Method to add Teacher information to Teacher List
        public string AddTeacher(string title, string fName, string lName, double salary, string eMail, string phone, string subject)
        {
            Teacher t = new Teacher(title, fName, lName, salary, eMail, phone, subject);            
            
                t.Title = title;
                t.FirstName = fName;
                t.LastName = lName;
                t.Salary = salary;
                t.Email = eMail;
                t.Phone = phone;
                t.Subject = subject;

                Teachers.Add(t);
            

            return "Teacher Added to list";
        }

        //Method to save teacher information to Teacher List
        public void SaveTeacher()
        {
            StreamWriter st = new StreamWriter(filePathT);
            foreach (Teacher t in Teachers)
            {
                //Each techer added wrote to CSV file in Write to CSV format in Teacher class
                st.WriteLine(t.WriteToCsv());
            }
            st.Close();
        }

        //Method to delete teacher
        public void DeleteTeacher()
        {
            for (int i = 0; i < Teachers.Count; i++)
            {
                Teacher t = Teachers[i];
                Teachers.Remove(t);
            }
        }


        //Method to read in Student information from CSV and add to Student List
        public void ReadInS()
        {
            //Try catch used to find errors
            try
            {
                StreamReader sr = new StreamReader(File.OpenRead(filePath));
                while (!sr.EndOfStream)
                {
                    string[] student = sr.ReadLine().Split(',');

                    int id = int.Parse(student[0]);
                    string title = student[1];
                    string fName = student[2];
                    string lName = student[3];
                    
                    string phone = student[4];
                    string email = student[5];
                    string status = student[6];
                    //Student added in this format
                    Student std = new Student(id, title, fName, lName, phone, email, status);
                    Students.Add(std);                    
                }
                sr.Close();
            }
            catch (Exception e)
            {

               Console.WriteLine("ERROR :" + e.ToString());
            }
        }
       
        //Method to read in Teacher infdormation from CSV and add to Teacher List
        public void ReadInListTeachers()
        {
            //Try Catch used to find errors
            try
            {
                StreamReader sr = new StreamReader(File.OpenRead(filePathT));
                while (!sr.EndOfStream)
                {
                    string[] teacher = sr.ReadLine().Split(',');
                    string title = teacher[0];
                    string fName = teacher[1];
                    string lName = teacher[2];
                    double salary = double.Parse(teacher[3]);
                    string phone = teacher[4];
                    string email = teacher[5];
                    string subject = teacher[6];
                    //Teacher assed in this format
                    Teacher tea = new Teacher(title, fName, lName, salary, phone, email, subject);
                    Teachers.Add(tea);
                }
                sr.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine("ERROR :" + ex.ToString());
            } 
        }

        //End Teacher Block

        //Test Instance Student Teacher information
        public string OperatorOverload()
        {
            Student a = new Student(10171569, "Mr", "Rob", "Gleeson", "0862108998", "rob.gleeson@icloud.com", "Postgrad");
            Teacher b = new Teacher("Mr", "Rob", "Gleeson", 45000, "rob.gleeson@icloud.com", "0862108998", "Web");

            Students.Add(a);
            Teachers.Add(b);

            if (a == b)
            {
                return "True";
            }
            else
                return "False";
        }
        
    }
}
