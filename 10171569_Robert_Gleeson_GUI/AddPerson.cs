using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _10171569_Robert_Gleeson_GUI
{   

    public partial class AddPerson : Form    
    {               
        College c = new College();

        public AddPerson()
        {           
            InitializeComponent();
            //Use of Enums foe combo box
            cmbSStatus.DataSource = Enum.GetValues(typeof(Status));
            cmdStudentTitle.DataSource = Enum.GetValues(typeof(StudentTitle));
            cmbTeacherTitle.DataSource = Enum.GetValues(typeof(TeacherTitle));
        }

        //Load students to List
        private void btnLoadStudents_Click(object sender, EventArgs e)
        {
            foreach (Student s in c.GetStudentList())
            {
                lstDisplay.Items.Add(s.ToString());
                
            }                            
        }

        private void btnSaveStudent_Click(object sender, EventArgs e)
        {
            
        }

        //Add students to List
        private void btnAddStudent_Click(object sender, EventArgs e)
        {                      
                //Try catch used to catch errors    
                try
                {
                    string title = cmdStudentTitle.SelectedItem.ToString();
                    string fName = txtStudentFirstName.Text;
                    string lName = txtStudentLastName.Text;
                    int id = int.Parse(txtStudentID.Text);
                    string eMail = txtStudentEmail.Text;
                    string phone = txtStudentPhone.Text;
                    string status = cmbSStatus.SelectedItem.ToString();

                    lblNote.Text = c.AddStudent(title, fName, lName, id, eMail, phone, status);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please ensure all fields are entered");
                }

                cmdStudentTitle.Text = "";
                txtStudentFirstName.Text = "";
                txtStudentLastName.Text = "";
                txtStudentID.Text = "";
                txtStudentEmail.Text = "";
                txtStudentPhone.Text = "";
                cmbSStatus.Text = "";                
            
        }

        //Show List objects
        private void btnShowStudentInfo_Click(object sender, EventArgs e)
        {
            lstDisplay.Items.Clear();
            foreach (Student s in c.Students)
            {
                lstDisplay.Items.Add(s.GetAllStudents());
            }
        }

        //Remove selected item from list
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult YesNo = MessageBox.Show("Do you really want to delete this entry?", "CONFIRM", MessageBoxButtons.YesNo);

            if (YesNo == DialogResult.Yes)
            {
                lstDisplay.Items.Remove(lstDisplay.SelectedItem);
                c.DeleteStudent();
            }           
        }
        
        //Search for student in list
        private void btnSearch_Click(object sender, EventArgs e)
        {                   
            foreach (Student s in c.Students)
            {
                if (txtSearchFirstName.Text == s.FirstName && txtSearchLastName.Text == s.LastName)
                {
                    lblDisplaySearchS.Text = s.ReturnSearch();
                    txtSearchFirstName.Text = "";
                    txtSearchLastName.Text = "";
                }
            }
        }
        
        //Add teacher to list
        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            //Use try catch for errors
            try
            {
                string title = cmbTeacherTitle.SelectedItem.ToString();
                string fName = txtTeacherFirstName.Text;
                string lName = txtTeacherLastName.Text;                
                string eMail = txtTeacherEmail.Text;
                string phone = txtTeacherPhone.Text;
                double salary = double.Parse(txtTeacherSalary.Text);
                string subject = txtTeacherSubject.Text;

                lblNote2.Text = c.AddTeacher(title, fName, lName, salary, eMail, phone, subject);
            }
            catch (Exception)
            {
                MessageBox.Show("Please ensure all fields are entered");
            }

            cmbTeacherTitle.Text = "";
            txtTeacherFirstName.Text = "";
            txtTeacherLastName.Text = "";
            txtTeacherSalary.Text = "";
            txtTeacherEmail.Text = "";
            txtTeacherPhone.Text = "";
            txtTeacherSubject.Text = "";            
            
        }
        
        //Show Teacher Info
        private void btnShowTeacherInfo_Click(object sender, EventArgs e)
        {
            lstDisplay.Items.Clear();
            foreach (Teacher t in c.Teachers)
            {
                lstDisplay.Items.Add(t.GetAllTeachers());
            }
        }

        //Load teachers to list
        private void btnLoadTeachers_Click(object sender, EventArgs e)
        {
            foreach (Teacher t in c.GetTeacherList())
            {
                lstDisplay2.Items.Add(t.ToString());
            }
        }
       
        //Search teachers in list
        private void btnSearchT_Click(object sender, EventArgs e)
        {
            foreach (Teacher t in c.Teachers)
            {
                if (txtSearchFirstNameT.Text == t.FirstName && txtSearchLastNameT.Text == t.LastName)
                {
                    lblDisplaySearchT.Text = t.ReturnSearch();
                    txtSearchFirstNameT.Text = "";
                    txtSearchLastNameT.Text = "";
                }
            }
        }

        private void btnLoadT_Click(object sender, EventArgs e)
        {
            
        }
        //Delete selected list object
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult YesNo = MessageBox.Show("Do you really want to delete this entry?", "CONFIRM", MessageBoxButtons.YesNo);

            if (YesNo == DialogResult.Yes)
            {
                lstDisplay2.Items.Remove(lstDisplay2.SelectedItem);
                c.DeleteTeacher();
            }
        }     
              
        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult YesNo = MessageBox.Show("Do you want to save now?", "CONFIRM", MessageBoxButtons.YesNo);
            if (YesNo == DialogResult.Yes)
            {
                c.SaveTeacher();
            }

            this.Close();
            Login f = new Login();
            f.Show();
        }       

        //Exit the program
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        //Read in studnet csv file and add to list
        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c.ReadInS();
            MessageBox.Show("Files Loaded", "SUCCESS");
        }

        
        //Save all information to csv
        private void saveAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            c.SaveStudent();
            c.SaveTeacher();
        }

        //Save changes on exit
        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult YesNo = MessageBox.Show("Do you want to save now?", "CONFIRM", MessageBoxButtons.YesNo);
            if (YesNo == DialogResult.Yes)
            {
                c.SaveStudent();
                c.SaveTeacher();
            }

            this.Hide();

            Login f = new Login();
            f.Show();
        }

        private void grpAddTeacher_Enter(object sender, EventArgs e)
        {

        }
        //Add csv to Teachers List
        private void teachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c.ReadInListTeachers();
            MessageBox.Show("Files Loaded", "SUCCESS");
        }
        //Clear Display
        private void btnClearSList_Click(object sender, EventArgs e)
        {
            lstDisplay.Text = "";
        }

        private void btnClearTList_Click(object sender, EventArgs e)
        {
            lstDisplay2.Text = "";
        }

        private void btnClearSS_Click(object sender, EventArgs e)
        {
            lblDisplaySearchS.Text = "";
        }

        private void btnClearTS_Click(object sender, EventArgs e)
        {
            lblDisplaySearchT.Text = "";
        }
        //About function
        private void btnINFO_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To load files, choose file from 'Import File' tab and click\nTo save changes click 'Save All' - Entires saved to .csv file\nTo delete entry, load file, select person to be removed and click 'delete'\n\n\nVersion 1.5", "INFO");
        }

        private void AddPerson_Load(object sender, EventArgs e)
        {

        }
        //Operator equality overload example
        private void btnEqualityEx_Click(object sender, EventArgs e)
        {
            lblEquality.Text = c.OperatorOverload();
                
        }

       


    }
}
